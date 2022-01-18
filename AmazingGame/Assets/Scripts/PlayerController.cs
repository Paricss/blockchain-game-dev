using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    public float jumpsAllowed;
    private float timesJumped;
    
    private Rigidbody2D rb;
    private float moveInput;
    private float jumpInput;
    private float previousJumpInput;

    
    // Start is called before the first frame update
    void Start()
    {
        //connect rigibody2d in unity
        rb = GetComponent<Rigidbody2D>();
        timesJumped = 0;
        previousJumpInput = 0;
        
    }

    // Update runs once per frame.
    void FixedUpdate()
    {
        // it really works in multiple platform like PC/PS4
        //-1 is left. 0 is still. 1 is right
        moveInput = Input.GetAxis("Horizontal");
        //2 means 2d 
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);

        //jump
        // -1 going down, 0 is nothing pressed, 1 is going up
        jumpInput = Input.GetAxis("Vertical");
        if(jumpInput > 0 && timesJumped < jumpsAllowed && previousJumpInput == 0){
            //jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            timesJumped++;
        }

        previousJumpInput = jumpInput;
    }
    //Unity calls it when the object (which must have a Rigidbody) collides with any collider. 
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground"))
        {
          timesJumped = 0;
        }
	else if(other.gameObject.CompareTag("Coin"))
	{
	  Destroy(other.gameObject);
	//textManager changing text
	  TextManager.instance.IncreaseScore();
	
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
