﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class myGameManager : MonoBehaviour {
    public bool recording=true;
    private float fixedDeltaTime;
    private bool isPaused = false;
	// Use this for initialization
	void Start () {

        PlayerPrefsManager.UnlockLevel(2);
        //print(PlayerPrefsManager.IsLevelUnlocked(1));
        //print(PlayerPrefsManager.IsLevelUnlocked(2));
        fixedDeltaTime = Time.fixedDeltaTime;
        print(fixedDeltaTime);
    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;

        }
        else {
            recording = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && isPaused)
        {
            isPaused = false;
            ResumeGame();
        }else if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            isPaused = true;
            PauseGame();
        }
        //print("update");
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
    }
    private void OnApplicationPause(bool pause)
    {
        //print("OnApplicationPause was called");
        //isPaused = pause;
        
    }
}
