using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject CutsceneCamera1;
    public GameObject CutsceneCamera2;
    public GameObject CutsceneCamera3;
    public GameObject GameEndScreen;
    //public GameObject GameEndText;
    public GameObject GameEndIcon;
    public AudioSource HagAudio;
    public AudioSource GameMusic;
    public AudioClip EndDayAudio;
    public AudioClip stain;
    public GameObject HagChat;
    //public Animator anim;
    public string scene;

    private float timer;
    private float stopTimer;
    private bool gameEnd;
    //private Image alphaChannel;
    private float fadeAmount;
    private Color objectColor;
    private float musicFade;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        stopTimer = 0f;
        gameEnd = false;
    //anim.SetTrigger("isTalk");
}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Debug.Log("Pass1");
        if (!gameEnd)
        {

            if (timer < 15)
            {
                if (timer > 6 && CutsceneCamera1.active)
                {
                    //Debug.Log("Pass2");
                    CutsceneCamera1.SetActive(false);
                    CutsceneCamera2.SetActive(true);
                }
                if (timer > 10 && CutsceneCamera2.active)
                {
                    //Debug.Log("Pass2");
                    CutsceneCamera2.SetActive(false);
                    CutsceneCamera3.SetActive(true);
                }
                if (timer > 13 && CutsceneCamera3.active)
                {
                    //Debug.Log("Pass2");
                    CutsceneCamera3.SetActive(false);
                    playerCamera.SetActive(true);

                    HagAudio.clip = stain;
                    HagAudio.volume = 0.8f * StaticPlayer.volume;
                    HagAudio.Play();
                    HagChat.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    timer = 14.5f;
                    CutsceneCamera1.SetActive(false);
                    CutsceneCamera2.SetActive(false);
                    CutsceneCamera3.SetActive(false);
                    playerCamera.SetActive(true);
                    HagAudio.Stop();
                    HagAudio.clip = stain;
                    HagAudio.volume = 0.8f * StaticPlayer.volume;
                    HagAudio.Play();
                    HagChat.SetActive(true);
                }
            }
            else
            {
                //GameEnd();
            }
        }
        else
        {
            


            if (timer - stopTimer > 7 && GameEndIcon.active)
            {
                //Debug.Log("Pass3?");
                GameEndIcon.SetActive(true);
                //alphaChannel = GameEndIcon.GetComponent<RawImage>();
                //alphaChannel.CrossFadeAlpha(0, 5, true);
                objectColor = GameEndIcon.GetComponent<RawImage>().color;
                fadeAmount = objectColor.a + (Time.deltaTime / 5);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                GameEndIcon.GetComponent<RawImage>().color = objectColor;
            }
            else
            {
                musicFade = GameMusic.volume - (Time.deltaTime / 15);
                GameMusic.volume = musicFade;

                objectColor = GameEndScreen.GetComponent<Image>().color;
                fadeAmount = objectColor.a + (Time.deltaTime / 5);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                GameEndScreen.GetComponent<Image>().color = objectColor;
            }
            if (timer - stopTimer > 20)
            {
                Application.Quit();
            }
        }
    }

    public void GameEnd()
    {
        CutsceneCamera1.SetActive(true);
        playerCamera.SetActive(false);

        StaticPlayer.lives = 4;

        HagAudio.clip = EndDayAudio;
        HagAudio.volume = 0.8f * StaticPlayer.volume;
        HagAudio.Play();

        GameEndScreen.SetActive(true);

        stopTimer = timer;
        gameEnd = true;

        HagChat.SetActive(false);
    }
}
