﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public LevelManager instance;
	//public GameObject MenuScreen;

	/// <summary>
	/// This is the main method that instantiates the Level Manager class
	/// Only a single instance can exist. This will ensure that there are no duplicates
	/// when reloading a scene.
	/// </summary>
	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject); 
		}
	}

	/// <summary>
	/// Load the level with the given name
	/// </summary>
	/// <param name="name">Name.</param>
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
        SceneManager.LoadSceneAsync(name);
	}

    IEnumerator LoadAsyncLevel(string name) {
        Debug.Log("New Level load: " + name);
        AsyncOperation async = SceneManager.LoadSceneAsync(name);
        yield return async;
    }

	/// <summary>
	/// Loads the main game.
	/// </summary>
	public void LoadMainGame()
	{
		SceneManager.LoadSceneAsync("01Level");
		//MenuScreen.active = false;
	}

	/// <summary>
	/// Quits the request.
	/// </summary>
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
