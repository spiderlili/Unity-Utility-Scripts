using UnityEngine;
using System.Collections;

public class EnemyTrace : MonoBehaviour {

	public GameObject target;		//target the player
	public float moveSpeed=8.0f;	
	public float minDist=2.2f;		//stop chasing when the distance between the enemy and the target is smaller than minDist

	private float dist;				
	private Animator animator;				//enemy animations
	private EnemyHealth enemyHealth;		

	void Start () {
		animator = GetComponent<Animator> ();		
		enemyHealth = GetComponent<EnemyHealth> (); 
	}

	//chase after target
	void Update () {
		if (enemyHealth!=null && enemyHealth.health <= 0) return;	//stop if the enemy is dead
		if (target == null) {					//stop if the target hasn't been set
			animator.SetBool ("isStop", true);  //play the stop animation when the enemey is not chasing after the target
            return;
		}
		dist = Vector3.Distance (transform.position, target.transform.position);	//calculate the distance between the enemy's position and the target's position
		//when the game is playing
		if (GameManager.gm==null || GameManager.gm.gameState == GameManager.GameState.Playing) {			
			if (dist > minDist) {	//when the enemy's distance to the target is bigger than minDist 
				transform.LookAt (target.transform);				//the enemy faces the target
				transform.eulerAngles=new Vector3(0.0f,transform.eulerAngles.y,0.0f);	//the player only rotates around the y axis 
				transform.position += transform.forward * moveSpeed * Time.deltaTime;	//the enemy moves towards the target in moveSpeed
			}
			animator.SetBool ("isStop", false);	//play the running animation when the enemey is chasing after the target
		}
	}
}
