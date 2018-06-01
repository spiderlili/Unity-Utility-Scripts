using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health=2;	
	public int value=1;		//points after the player has killed the enemy 
	public AudioClip enemyHurtAudio;	

	private Animator animator;			
	private Collider collider;			
	private Rigidbody rigidbody;		

	void Start(){
		animator = GetComponent<Animator> ();	
		collider = GetComponent<Collider> ();	
		rigidbody = GetComponent<Rigidbody> ();	
	}

	//enemy's damage handling function for the PlayerAttack script
	public void TakeDamage(int damage){	
		health -= damage;			//enemy damage points
		if (enemyHurtAudio != null) //play the enemyHurtAudio at the player's position
            AudioSource.PlayClipAtPoint (enemyHurtAudio, transform.position);
		if (health <= 0) {			//if the player is dead
			if (GameManager.gm != null) {	
				GameManager.gm.AddScore (value); //reward points for killing the enemy
			}
			animator.applyRootMotion = true;	//the animation influences the enemy's movement and position
			animator.SetTrigger ("isDead");		//play the enemy dead animation
			collider.enabled = false;			//prevent collision with other game objects 
			rigidbody.useGravity = false;		//prevent the enemy from falling through the terrain after the collider has been disabled
			Destroy (gameObject, 3.0f);			//delete the enemy 
		}
	}
}
