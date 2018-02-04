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

    public AudioSource audioSource;
    public AudioSource audioSourceOneShot;
    public AudioClip ac_MainSong, ac_LevelSong;
    public Texture2D cursorTexture;
    public Vector2 centroCursor = Vector2.zero;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Cursor.SetCursor(cursorTexture, centroCursor, CursorMode.Auto);
    }
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

    public void PlaySong(AudioClip ac)
    {
        audioSource.clip = ac;
        audioSource.Play();
    }
    public void PlayUISong(AudioClip ac)
    {
        audioSourceOneShot.PlayOneShot(ac);
    }
    public void SceneChange(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ControlAudio()
    {
        AudioListener.volume = 1 - AudioListener.volume;
    }
}
