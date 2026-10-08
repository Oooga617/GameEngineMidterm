using UnityEngine;

public class Fruit : PickUp
{
    public float scoreGive = 10f;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
