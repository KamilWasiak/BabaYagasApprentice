using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HagChat : MonoBehaviour
{
    public AudioSource HagAudio;
    public AudioClip idle1;
    public AudioClip idle2;
    public AudioClip upIdle1;
    public AudioClip upIdle2;
    //public Collider boxCollider;

    //private AudioClip[] activeAudio;

    private float timer;
    private bool topFloor;

    // Start is called before the first frame update
    void Start()
    {
        timer = 15f;
        //activeAudio.Load(idle1);
        //activeAudio.Load(idle2);
        topFloor = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (HagAudio.isPlaying)
        {
            timer = 15f;
        }

        if (timer < 0)
        {
            if (topFloor)
            {
                if (UnityEngine.Random.Range(0, 1) < 0.5f)
                {
                    HagAudio.clip = upIdle1;
                    HagAudio.volume = 0.8f * StaticPlayer.volume;
                    HagAudio.Play();
                }
                else
                {
                    HagAudio.clip = upIdle2;
                    HagAudio.volume = 0.8f * StaticPlayer.volume;
                    HagAudio.Play();
                }
            }
            else
            {
                if (UnityEngine.Random.Range(0, 1) < 0.5f)
                {
                    HagAudio.clip = idle1;
                    HagAudio.volume = 0.8f * StaticPlayer.volume;
                    HagAudio.Play();
                }
                else
                {
                    HagAudio.clip = idle2;
                    HagAudio.volume = 0.8f * StaticPlayer.volume;
                    HagAudio.Play();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //activeAudio.Load(upIdle1);
        //activeAudio.Load(upIdle2);
        //activeAudio.UnloadAsset(idle1);
        //activeAudio.UnloadAsset(idle2);

        topFloor = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //activeAudio.UnloadAsset(upIdle1);
        //activeAudio.UnloadAsset(upIdle2);
        //activeAudio.Load(idle1);
        //activeAudio.Load(idle2);

        topFloor = false;
    }
}
