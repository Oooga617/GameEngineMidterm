using UnityEngine;

public class FruitSpawner : Spawner
{
    public GameObject peach, Cactus;
    float choose;
    public override Fruit spawnPickUp()
    {
        GameObject spawnedItem;
        choose = Random.Range(0.0f, 1.0f);
        if (choose <= 0.5f)
        {
             spawnedItem = peach;
        }
        else
        {
             spawnedItem = Cactus;
        }
        Instantiate(spawnedItem, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        return spawnedItem.GetComponent<Fruit>();
    }
}
