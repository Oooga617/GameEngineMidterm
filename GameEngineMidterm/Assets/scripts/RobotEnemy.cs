using UnityEngine;

public class RobotEnemy : Enemy
{
    Vector2 moveDir;
    public float bubbleYDisplace = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bubble"))
        {
            BubbleManager.Instance.summonBubble(this.transform.position, bubbleYDisplace);
            GameObject spawner = Instantiate(itemSpawner, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
