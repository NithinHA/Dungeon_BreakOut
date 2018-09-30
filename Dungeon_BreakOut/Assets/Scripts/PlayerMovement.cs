using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public bool is_moving = false;

	float x_dir, y_dir;

	Rigidbody2D rb;
	Vector2 move_velocity;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if(Mathf.Abs(rb.velocity.x) < 1 && Mathf.Abs(rb.velocity.y) < 1) {
			transform.GetChild(0).localScale = Vector2.one;
			x_dir = 0;
			y_dir = 0;
			is_moving = false;
		}
		else
		{
			//Player movement animation
			transform.GetChild(0).localScale = new Vector2(Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f));
		}
		
		if (!is_moving) {
			if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
				y_dir = 1;
				transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 180);
			}
			else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
				y_dir = -1;
				transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
			}
			else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
				x_dir = -1;
				transform.GetChild(0).rotation = Quaternion.Euler(0, 0, -90);
			}
			else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
				x_dir = 1;
				transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 90);
			}

			Vector2 movement_input = new Vector2(x_dir, y_dir);
			move_velocity = movement_input.normalized * speed;
			
			is_moving = true;
		}

	}
	private void FixedUpdate() {
		rb.velocity = move_velocity * Time.deltaTime;
	}
}
