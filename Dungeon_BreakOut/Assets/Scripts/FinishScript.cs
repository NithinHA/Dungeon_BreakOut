using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishScript : MonoBehaviour {

	public static bool is_level_complete = false;

	public GameManager gm;
	public GameObject complete_level_UI;
	public TextMeshProUGUI win_text;

	void Start () {
		
	}
	
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Player")) {

			FindObjectOfType<AudioManager>().Play("WinAudio");

			is_level_complete = true;
			win_text.text = "<b>LEVEL\nCOMPLETE</b>\n\nScore: " + gm.stars_count + "/5";
			complete_level_UI.SetActive(true);
		}
	}
	
}
