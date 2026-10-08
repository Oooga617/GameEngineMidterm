using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    bool isLeft = false;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bubble"))
        {
            
            Destroy(this.gameObject);
        }
    }
}
