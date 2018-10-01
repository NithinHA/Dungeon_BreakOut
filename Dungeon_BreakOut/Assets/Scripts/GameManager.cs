using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static bool is_game_over = false;
	int stars_count = 0;

	void Start () {
		
	}
	
	void Update () {
		if (is_game_over)
		{
			is_game_over = false;           //since is_game_over is static field, if we dont write this statement, is_game_over is set to true even after scene is reloaded. 
			StartCoroutine(Restart());
		}
	}

	public void StarCollected()
	{
		stars_count++;
		Debug.Log(stars_count + " stars!");
	}

	IEnumerator Restart()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
