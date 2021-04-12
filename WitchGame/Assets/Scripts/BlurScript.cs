using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlurScript : MonoBehaviour
{
    int storedLives;
    public Image imageComponent;

    // Start is called before the first frame update
    void Start()
    {
        storedLives = StaticPlayer.lives;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeInHierarchy && storedLives != StaticPlayer.lives)
        {
            storedLives = StaticPlayer.lives;

            //Image img = this.gameObject.GetComponent<Image>();
            //img.color.a -= 1f * Time.deltaTime;
            //this.gameObject.color = color;
            Debug.Log("Pass");

            //Image image = GetComponent<Image>();

            Color c = imageComponent.color;
            Debug.Log(imageComponent.color);
            c.a = 1f;
            imageComponent.color = c;

            Debug.Log(imageComponent.color);

            Debug.Log(StaticPlayer.lives);

            this.gameObject.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, true);
        }

        if (StaticPlayer.lives == 2)
        {
            this.gameObject.SetActive(true);
        }

        if (StaticPlayer.lives == 0)
        {
            this.gameObject.SetActive(true);
        }



    }
}
