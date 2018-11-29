using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public GameObject player_death_effect;
	public GameManager gm;

	void Awake () {
		gm = FindObjectOfType<GameManager>();
	}
	
	void Update () {
		
	}

	public void Player_Collision(GameObject player)
	{
		Instantiate(player_death_effect, transform.position, Quaternion.identity);

		FindObjectOfType<AudioManager>().Play("PlayerDeath");
		
		Destroy(player.transform.GetChild(0).gameObject);			//destroys the player_model object which is the first child of player.
		PlayerMovement.move_velocity = Vector2.zero;                //stops the player by setting its static field move_velocity value to 0.
		gm.PlayerDeath();		//for some reason, this script dies immidiately and we can not wait for some time and reload the scene.
												//So, use GameManager script to do so. 
	}
	
}
