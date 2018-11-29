using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	void Awake () {
		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.playOnAwake = false;
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}
	}
	
	public void Play(string name)
	{
		Sound sound = Array.Find(sounds, s => s.name == name);
		sound.source.Play();
		Debug.Log(sound.name);
	}
}
