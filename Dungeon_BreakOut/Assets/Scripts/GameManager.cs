using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public int stars_count = 0;

	void Start () {

	}
	
	void Update () {
		
	}

	public void StarCollected()
	{
		stars_count++;
		Debug.Log(stars_count + " stars!");
	}


	public void PlayerDeath() {						//this function will be called by the EnemyScript.
		StartCoroutine(wait_before_restart());		//wait for 1 second before restart
	}
	IEnumerator wait_before_restart() {             //the reason why this coroutine is not directly called is because, EnemyMovement script dies right 
		yield return new WaitForSeconds(1);			//after it calls for restart. And if calling object dies, coroutine also dies.. I HAD NO IDEA!!
		Restart();
	}
	public void Restart()           //this is the common restart function used for restarting after player dies or player wins.
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
