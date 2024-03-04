using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene1 : MonoBehaviour
{
    public int sceneNumber;


    public void OnTriggerEnter(Collider other)
    {
        ChangeTheScene(sceneNumber);
    }

    public void ChangeTheScene(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Ik ga dood");
    }
}