using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PS_RestartLvl : MonoBehaviour
{
    //if something enters the trigger, the active scene gets reloaded

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reloads active scene
    }
}