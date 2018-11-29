using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

	Color col1, col2;
	bool cur_color;
	SpriteRenderer sp;
	public GameObject star_particles;

	GameManager gm;

	void Start () {
		gm = FindObjectOfType<GameManager>();

		sp = GetComponent<SpriteRenderer>();
		col1 = new Color(1, 1, 1);
		col2 = new Color(1f, 0.8f, 0.5f);

		InvokeRepeating("ChangeColor", 0.3f, 0.3f);
	}
	
	void Update () {

	}

	void ChangeColor() {
		if (cur_color) {
			sp.color = col1;
			cur_color = !cur_color;
		}
		else {
			sp.color = col2;
			cur_color = !cur_color;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			FindObjectOfType<AudioManager>().Play("CoinCollect");

			Instantiate(star_particles, transform.position, Quaternion.identity);
			Destroy(gameObject);
			gm.StarCollected();
		}
	}
	
}
