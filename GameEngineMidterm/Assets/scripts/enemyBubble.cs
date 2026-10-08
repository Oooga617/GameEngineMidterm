
using UnityEngine;

public class enemyBubble : PickUp
{
    public float moveTime = 2f;
    public float xDisplace = 0.5f;
    Vector3 leftPos, middlePos;
    float moveProgress, moveRatio;
    bool goesLeft = true;
    public GameObject spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        middlePos = this.transform.position;
        leftPos = new Vector3(middlePos.x - xDisplace, middlePos.y, middlePos.z);
    }

    // Update is called once per frame
    void Update()
    {
        moveProgress += Time.deltaTime;
        if (goesLeft)
        {
            if (moveProgress < moveTime)
            {
                moveRatio = moveProgress / moveTime;
                this.transform.position = Vector3.Lerp(middlePos, leftPos, moveRatio);
            }
            else
            {
                moveProgress = 0;
                goesLeft = !goesLeft;
            }
            
        }
        else
        {
            if (moveProgress < moveTime)
            {
                moveRatio = moveProgress / moveTime;
                this.transform.position = Vector3.Lerp(leftPos, middlePos, moveRatio);
            }
            else
            {
                moveProgress = 0;
                goesLeft = !goesLeft;
            }
        }
       
    }
    
     protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject fSpawner = Instantiate(spawner, this.transform.position, Quaternion.identity);
            SpawnerManager.Instance.getSpawners();
            Destroy(this.gameObject);
        }
    }
}
