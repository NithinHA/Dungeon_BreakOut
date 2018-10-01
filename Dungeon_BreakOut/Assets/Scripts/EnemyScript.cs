using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public GameObject player_death_effect;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void Player_Collision(GameObject player)
	{
		Instantiate(player_death_effect, transform.position, Quaternion.identity);
		Destroy(player.transform.GetChild(0).gameObject);			//destroys the player_model object which is the first child of player.
		PlayerMovement.move_velocity = Vector2.zero;				//stops the player by setting its static field move_velocity value to 0.
		GameManager.is_game_over = true;		//for some reason, this script dies immidiately and we can not wait for some time and reload the scene.
												//So, use GameManager script to do so. 
	}
	
}
