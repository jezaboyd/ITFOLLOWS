﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Neighbourhood_1");
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }



}
