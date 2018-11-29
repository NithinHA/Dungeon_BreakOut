using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerMovement : MonoBehaviour {

	[Header("Movement")]
	public float speed;
	public bool is_moving = false;
	float x_dir, y_dir;

	public GameObject movement_effect;
	bool display_effect = true;

	public static Vector2 move_velocity;		//this is accessed by EnemyScript to set player's move_velocity to 0 when player dies

	Rigidbody2D rb;
	Transform player_model;			//player model is child of this empty GameObject

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		player_model = transform.GetChild(0);
	}
	
	void Update () {
		if (player_model != null)			//this helps to avoid null reference exception when player_model is destroyed in EnemyScript.
		{
			if (Mathf.Abs(rb.velocity.x) < 1 && Mathf.Abs(rb.velocity.y) < 1)
			{
				player_model.localScale = Vector2.one;      //when player comes to rest, reset player's localscale

				if (!display_effect) {
					AudioSource audio = GetComponent<AudioSource>();
					audio.pitch = Random.Range(1f, 2f);
					audio.Play();

					Transform feet = player_model.GetChild(0);
					GameObject effect = Instantiate(movement_effect, player_model);		//this used to be most confusing part. But glad it worked somehow :P
					effect.transform.position = feet.position;
					display_effect = true;
				}

				x_dir = 0;
				y_dir = 0;
				is_moving = false;
			}
			else
			{
				//Player movement animation
				player_model.localScale = new Vector2(Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f));      //simple animation by changing the scale of player randomly, to make it look like player is moving.
				display_effect = false;
			}

			if (!is_moving)
			{
				//StreamReader reader = new StreamReader("C:/Users/Public/Documents/Unity Projects/Dungeon_BreakOut/input.txt");
				//string s = reader.ReadLine();
				//if (s == "left")
				//{
				//	x_dir = -1;
				//	player_model.rotation = Quaternion.Euler(0, 0, -90);
				//}
				//else if (s == "right")
				//{
				//	x_dir = 1;
				//	player_model.rotation = Quaternion.Euler(0, 0, 90);
				//}
				//else if (s == "up")
				//{
				//	y_dir = 1;
				//	player_model.rotation = Quaternion.Euler(0, 0, 180);
				//}
				//else if (s == "down")
				//{
				//	y_dir = -1;
				//	player_model.rotation = Quaternion.Euler(0, 0, 0);
				//}



				if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
				{
					y_dir = 1;
					player_model.rotation = Quaternion.Euler(0, 0, 180);
				}
				else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
				{
					y_dir = -1;
					player_model.rotation = Quaternion.Euler(0, 0, 0);
				}
				else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
				{
					x_dir = -1;
					player_model.rotation = Quaternion.Euler(0, 0, -90);
				}
				else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
				{
					x_dir = 1;
					player_model.rotation = Quaternion.Euler(0, 0, 90);
				}

				Vector2 movement_input = new Vector2(x_dir, y_dir);
				move_velocity = movement_input.normalized * speed;

				is_moving = true;
				//reader.Close();
			}
		}
	}

	private void FixedUpdate() {
		if(!FinishScript.is_level_complete)
			rb.velocity = move_velocity * Time.deltaTime;
	}
}
