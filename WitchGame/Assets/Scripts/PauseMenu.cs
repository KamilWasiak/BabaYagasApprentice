using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = true;

    public GameObject PauseMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject Blur;
    public GameObject BackgroundImage;
    public AudioSource GameSong;
    public AudioSource CauldronAudio;
    public AudioSource HagAudio;
    public RecipeBook bookStatus;
    public GameObject cameraPlayer;
    public string scene;

    public bool InputEnabled;

    void Start()
    {
        InputEnabled = false;
        Time.timeScale = 0f;
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        RecipeBook recipeBook = bookStatus.GetComponent<RecipeBook>();


        if (Input.GetKeyDown(KeyCode.Escape) && !recipeBook.bookOpen && StaticPlayer.lives > 0 && StaticPlayer.lives != 4 && cameraPlayer.active)
        {
            if (!GamePaused)
            {
                Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && StaticPlayer.lives <= 0)
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void Resume()
    {
        if (BackgroundImage.activeSelf)
        {
            GameSong.Play();
            HagAudio.Play();
            HagAudio.volume = 0.8f + StaticPlayer.volume;
        }
        InputEnabled = true;
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
        BackgroundImage.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameSong.volume = 0.4f * StaticPlayer.volume;
        GameSong.pitch = 1f;

    }

    void Pause() 
    {
        InputEnabled = false;
        PauseMenuUI.SetActive(true);
        //BackgroundImage.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameSong.volume = 0.1f * StaticPlayer.volume;
        GameSong.pitch = 0.8f;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }

    public void OptionsBack()
    {
        PauseMenuUI.SetActive(true);
        OptionsMenuUI.SetActive(false);
    }

    public void SetVolume(float value)
    {
        StaticPlayer.volume = value;
        GameSong.volume = 0.1f * StaticPlayer.volume;
        CauldronAudio.volume = 0.2f * StaticPlayer.volume;
    }

    public void SetSensitivity(float value)
    {
        StaticPlayer.sensitivity = value;
    }

}
