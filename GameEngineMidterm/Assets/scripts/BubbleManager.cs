using UnityEngine;

public class BubbleManager : Singleton<BubbleManager>
{
    public GameObject enemyBubble;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void summonBubble(Vector3 coordinates, float yDis)
    {
        Vector3 newPos = new Vector3(coordinates.x, coordinates.y + yDis, coordinates.z);
        GameObject enemyB = Instantiate(enemyBubble, newPos, Quaternion.identity);
    }
}
