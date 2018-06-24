using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroupLogic : MonoBehaviour
{

	public string EnemyName;
	public AudioClip SceneEnter;
	private AudioSource _audioSource;
	private bool _moveToNextScene;

	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_moveToNextScene = false;
	}

	void Update()
	{
		if (!_audioSource.isPlaying && _moveToNextScene)
		{
			_moveToNextScene = false;
			
			Global.CurrentEnemy = EnemyName;
			SceneManager.LoadScene("scenes/Question", LoadSceneMode.Additive);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			_audioSource.clip = SceneEnter;
			_audioSource.Play();
			_moveToNextScene = true;
		}
	}
}
