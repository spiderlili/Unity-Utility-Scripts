using UnityEngine;
using System.Collections;

//use WASD and arrow keys to move the player back and forth / rotate the player left and right
public class PlayerMove : MonoBehaviour {

    public float moveSpeed = 10.0f;		
    public float rotateSpeed = 40.0f;	
    public float jumpVelocity = 2.0f;	

	private Animator animator;		
    private Rigidbody rigidbody;	

    private float h;				//get player's horizontal input
    private float v;				//get player's vertical input
    private bool isGrounded;		//check if the player is on the ground
    private float groundedRaycastDistance = 0.1f;	//raycast distance to the ground

    void Start () {
		animator= GetComponent<Animator> ();	
        rigidbody = GetComponent<Rigidbody>();	
    }

	//physics update 
    void FixedUpdate()
    {
        //cast a ray with the length of groundedRaycastDistance downwards from the player transform position，check if the ray has been hit and the player is grounded 
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, groundedRaycastDistance);
        Jump(isGrounded);	
    }

	void Jump(bool isGround)
	{
		//if the player is grounded and the space key is pressed: set the isJump animator param to true 
		if (Input.GetKey(KeyCode.Space) && isGround)
		{
            //change the player's movement speed by adding an upward jumpVelocity force to the player's rigidbody
            rigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);	
			animator.SetBool("isJump", true);   //set the animator param isJump to true，play the player's jump animation
        }
		else if(isGround) animator.SetBool("isJump", false);	//set the animator param isJump to false，stop the player's jump animation
	}

    //player movement
    void Update () {
        float h = Input.GetAxisRaw("Horizontal");	
        float v = Input.GetAxisRaw("Vertical");		
        MoveAndRotate(h, v);		//move and rotate the player according to the horizontal and vertical input
    }

    void MoveAndRotate(float h, float v)
    {
		// v>0 => get the player's forward input，move the player forward in moveSpeed and calculate the amount to translate
        if (v > 0) transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // v<0 => player's backward input，move the player backward in moveSpeed
        else if (v < 0) transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);	

		//if there is vertical player input, set the isMove animation param to true and play the player's running animation
        if (v != 0.0f) animator.SetBool("isMove", true);

        //if there is no vertical player input，set the isMove animation param to false and stop the player's runnning animation
        else animator.SetBool("isMove", false);

        //rotate clockwise according to the horizontal player input around the upward-directed vector(0, 1, 0) 
        transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);
    }

}
