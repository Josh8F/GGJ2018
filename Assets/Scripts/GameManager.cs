using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController _PlayerController;

    public GameObject btnSpace;
    public bool canInteract = false;


    public void ControlPanel(GameObject obj)
    {
        obj.SetActive(!obj.activeInHierarchy);
    }

    public void ChangeInteraction()
    {
        canInteract = !canInteract;
        btnSpace.SetActive(!btnSpace.activeInHierarchy);
    }
    public bool getInteraction()
    {
        return canInteract;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void StartGame()
    {
        _PlayerController.canMove = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
