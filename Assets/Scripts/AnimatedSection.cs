using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatedSection : MonoBehaviour
{

	public AudioClip IntroClip;
	private AudioSource _audioSource;
	void Start()
	{
		_audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_audioSource.isPlaying || Input.anyKeyDown)
		{
			SceneManager.LoadScene("scenes/Hallway", LoadSceneMode.Single);
		}
	}
}
