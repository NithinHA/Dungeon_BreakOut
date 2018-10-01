using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour {
	

	void Start () {
		
	}
	
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
			StartCoroutine(Win());
		}
	}

	IEnumerator Win()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
