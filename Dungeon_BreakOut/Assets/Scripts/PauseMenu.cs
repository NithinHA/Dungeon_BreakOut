using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject pause_UI;

	public static bool is_paused = false;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !FinishScript.is_level_complete) {
			if (is_paused) {
				Resume();
			}
			else {
				Pause();
			}
		}
	}

	void Pause()
	{
		pause_UI.SetActive(true);
		Time.timeScale = 0;
		is_paused = true;
	}

	public void Resume()
	{
		pause_UI.SetActive(false);
		Time.timeScale = 1;
		is_paused = false;
	}

	public void Retry()
	{
		Time.timeScale = 1;
		is_paused = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadMenu()
	{
		Time.timeScale = 1;
		is_paused = false;
		SceneManager.LoadScene(0);
	} 

	public void QuitGame()
	{
		Application.Quit();
	}
}
