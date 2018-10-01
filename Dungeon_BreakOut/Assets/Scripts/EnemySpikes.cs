using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpikes : EnemyScript {
	


	void Start () {
		
	}
	
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			base.Player_Collision(collision.gameObject);		//calls the parent class method
		}
	}
}
