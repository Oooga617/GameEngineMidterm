using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //movement variables
    public float moveSpeed = 25.0f;
    public float jumpForce = 300.0f;
    bool hasJumped = false;
    float moveX;
    public GameObject bubble;
    bool isLeft = false;
    public float bubbleDisplaceX = 0.5f;


    //physics
    Rigidbody2D rb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gets access to rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets the 2D move direction
        moveX = Input.GetAxis("Horizontal");

        //gets direction to know where to fire bubble
        if (moveX < 0)
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }

       if (Input.GetKeyDown(KeyCode.Space) && hasJumped==false)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FireBubble();
        }
        
    }

    //using forces to push player
    private void FixedUpdate()
    {
        Vector2 dir = new Vector2 (moveX * moveSpeed, 0);
        rb.AddForce(dir);
    }

    void FireBubble()
    {
        StartCoroutine(shootProjectile());
    }
    IEnumerator shootProjectile()
    {
        Vector3 currentPos = this.transform.position;
        Vector3 newPos = new Vector3(currentPos.x + bubbleDisplaceX, currentPos.y, currentPos.z);
        GameObject bubbleObj = Instantiate(bubble, newPos, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(bubbleObj);
        yield return null;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when jumping and colliding with ground, be able to jump again
        if (collision.gameObject.CompareTag("ground") && hasJumped == true)
        {
            hasJumped = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
    public void killPlayer()
    {
        //GameManager.Instance.retryLevel();
        this.gameObject.SetActive(false);

    }
}
