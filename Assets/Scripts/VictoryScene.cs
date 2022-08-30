﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    public float waitForAnyKey = 2f;

    public GameObject anyKeyText;

    public string mainMenuScene;
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitForAnyKey > 0)
        {
            waitForAnyKey -= Time.deltaTime;
            if(waitForAnyKey <= 0)
            {
                anyKeyText.SetActive(true);
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(mainMenuScene);
            }
        }
    }
}
