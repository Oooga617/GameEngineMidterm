using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //movement variables
    public float moveSpeed;
    public float jumpForce;
    bool hasJumped = false;
    Vector2 moveDir;
    

    //input actions:
    PlayerCharacterActions action;

    //physics
    Rigidbody2D rb;

    private InputAction move, jump;

    void Awake()
    {
        action = new PlayerCharacterActions();
    }

    private void OnEnable()
    {
        //initializes the inputs from the input system
        move = action.Player.Move;
        move.Enable();
        jump = action.Player.Jump;
        jump.Enable();
    }

    void OnDisable()
    {
        //disables the inputs
        move.Disable();
        jump.Disable();
    }

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
        moveDir = move.ReadValue<Vector2>();

        //press q to quit
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.quitGame();
        }
        
    }

    //using forces to push player
    private void FixedUpdate()
    {
        //if its not moving, dont move, if moving then apply forces
        if (moveDir.x != 0.0)
        {
            movePlayer(moveDir);
        }
        //press a button to jump, I couldnt figure out how to get the new input system working for subscribing and doing the jump method so im using the old input system
        //to save time
        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            rb.AddForce(Vector2.up * jumpForce);
            hasJumped = true;
        }
    }

    //uses forces to push the player around, used in fixed update 
    void movePlayer (Vector2 dir)
    {
        rb.AddForce(dir * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when jumping and colliding with ground, be able to jump again
        if (collision.gameObject.CompareTag("Ground") && hasJumped == true)
        {
            hasJumped = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if reached house call on game manager to move onto next level
        if (collision.gameObject.CompareTag("House"))
        {
            GameManager.Instance.nextLevel();
        }
    }
    public void killPlayer()
    {
        GameManager.Instance.retryLevel();
        this.gameObject.SetActive(false);

    }
}
