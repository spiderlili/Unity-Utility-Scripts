using UnityEngine;
using System.Collections;

//attach to weapon object to manage player attack
public class PlayerAttack : MonoBehaviour {

    public int shootingDamage = 1;				
    public float shootingRange=50.0f;			
    public AudioClip shootingAudio;				
    public float timeBetweenShooting = 1.0f; //the min duration between shoots(shooting animation >= 1.0f)

	private Animator animator;			
    private LineRenderer gunLine;		//laser shooting line effect 

    private float timer;				//record the time passed after the player's last shot
    private Ray ray;
    private RaycastHit hitInfo;

    public KeyCode shootingKey = KeyCode.J;
    public KeyCode shootingKeyAlt = KeyCode.Mouse0;

    void Start () {
		animator = GetComponentInParent<Animator>();	
		gunLine = GetComponent<LineRenderer>();			
        timer = 0.0f;		//reset attack time duration
	}

	void Update () {
        //if J is pressed or PC mouse is pressed and time passed is longer than timeBetweenShooting, invoke shoot 
        if ((Input.GetKeyDown(shootingKey) || Input.GetKey(shootingKeyAlt)) && timer>timeBetweenShooting)
        {
            timer = 0.0f;							//reset time after shooting
			animator.SetBool("isShooting", true);	//play the player shooting animation
			Invoke("shoot", 0.5f);					
        }
		//not shooting
        else
        {
            timer += Time.deltaTime;	//update time
            gunLine.enabled = false;	//disable the gun laser shooting line effect
			animator.SetBool("isShooting", false);	//stop the player shooting animation
        }
	}

    void shoot()
	{
		AudioSource.PlayClipAtPoint(shootingAudio, transform.position); //play the sound effect at the gun's transform position 
		ray.origin = Camera.main.transform.position;	//set the ray origin to the camera position 
        ray.direction = Camera.main.transform.forward;	//set the ray direction to the camera's forward direction
        gunLine.SetPosition(0, transform.position);		//set the first point of the gunLine's position to the gun's transform position 
        //shoot a raycast with the length of shootingRange to check if the ray has hit any game object 
		if (Physics.Raycast(ray, out hitInfo, shootingRange))
        {
            if (hitInfo.collider.gameObject.tag == "Enemy")	//check if the game object hit is an enemy
            {
				//get enemy's health from the EnemyHealth script
                EnemyHealth enemyHealth = hitInfo.collider.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
					//cause shootingDamage to the enemy
					enemyHealth.TakeDamage(shootingDamage);	
                }
				if(enemyHealth.health>0)	//the enemy moves backwards if it's been damaged and not dead
					hitInfo.collider.gameObject.transform.position += transform.forward * 2;
            }
			gunLine.SetPosition(1, hitInfo.point);	//when a game object has been hit: set gunLine's 2nd point to the game object's hitInfo.point
        }
        //if the gunLine hasn't hit anything, set gunLine's second hit point to the furthermost position of the raycast 
        else gunLine.SetPosition(1, ray.origin + ray.direction * shootingRange);
		gunLine.enabled = true;	//enable the gunLine line renderer to show the effect of gun shot laser line 
    }
}
