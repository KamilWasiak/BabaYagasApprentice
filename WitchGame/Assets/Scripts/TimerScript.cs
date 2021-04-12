using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    float timer;
    public string scene;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(scene);
            LoopScript.loop++;
            Debug.Log(LoopScript.loop);
        }

    }

}
