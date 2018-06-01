using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public int damage=1;					//cause damage to the player
	public float timeBetweenAttack=0.8f;	//the min time between enemy's attacks >= attack animation duration 
	public AudioClip enemyAttackAudio;		

	private float timer;				
	private Animator animator;			
	private EnemyHealth enemyHealth;	

	void Start(){
		timer = 0.0f;								//reset the time from the last attack
		animator = GetComponent<Animator> ();		
		enemyHealth = GetComponent<EnemyHealth> ();	
	}

    //check if any object with an isTrigger collider has entered the enemy's attack range 
    void OnTriggerStay(Collider collider){
		if (enemyHealth.health <= 0) 	//stop attacking if the enemy is dead
			return;
        //when the time passed is longer than timeBetweenAttack and the player has entered the enemy's attack range
        if (timer>=timeBetweenAttack && collider.gameObject.tag == "Player") {
			//when the game is playing
			if(GameManager.gm==null || GameManager.gm.gameState==GameManager.GameState.Playing){
				timer=0.0f;         //reset the time from the last attack
                animator.SetBool ("isAttack", true);	//play the player's attack animation
				if(enemyAttackAudio!=null)				//play the attack audio at the enemy's position
					AudioSource.PlayClipAtPoint(enemyAttackAudio,transform.position);
				if (GameManager.gm != null)
					GameManager.gm.PlayerTakeDamage (damage);//use the GameManager to take damage from the player 
			}
		}
	}

    //check if any object with an isTrigger collider has left the enemy's attack range
    void OnTriggerExit(Collider collider){
        //if the player has left the enemy's attack range
        if (collider.gameObject.tag == "Player")
			animator.SetBool ("isAttack", false);	//stop the enemy's attack animation
	}

    //update the attack time
	void Update(){
		timer += Time.deltaTime;	
	}
}
