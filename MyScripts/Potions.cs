using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{

    //array of arrays containing potions

    string[] stainPotion;
    string[] lovePotion;
    string[] invisPotion;
    string[] deathPotion;
    string[] lightPotion;
    //string[] truthPotion;


    public List<string[]> potions = new List<string[]>();
    public List<string[]> finishedPotions = new List<string[]>();
    public string[] requiredPotion;
    public Transform potionSpawn;
    public GameObject potdeath;
    public GameObject potstain;
    public GameObject potlight;
    public GameObject potinvis;
    public GameObject potlove;
    GameObject clone;
    MeshRenderer rend;
    public Material[] mat;
    GameObject emptyBottle;
    public CameraController cameraController;
    public AudioSource HagAudio;
    public AudioClip death;
    public AudioClip invisible;
    public AudioClip light;
    public AudioClip love;



    void Start()
    {

        stainPotion = new string[3] { "Alcohol", "BoneDust", "ChildTears" };
        lovePotion = new string[3] { "LockHair", "VoodooDoll", "HeartTrinket" };
        invisPotion = new string[6] { "BatBlood", "ChildTears", "DogTeeth", "Flies", "Slugs", "Peppermint" };
        deathPotion = new string[4] { "RosePetals", "BoneDust", "Flies", "ChildTears" };
        lightPotion = new string[5] { "Toenail", "VoodooDoll", "BatBlood", "Sapphire", "DogTeeth" };
        //truthPotion = new string[4] { "Sapphire", "CatEye", "SnakeVenom", "Nettles" };


        requiredPotion = stainPotion;
        clone= Instantiate(potstain, potionSpawn.position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        potions.Add(lovePotion);
        potions.Add(invisPotion);
        potions.Add(deathPotion);
        potions.Add(lightPotion);
        //potions.Add(truthPotion);


        foreach (var ingriedient in requiredPotion)   //iterates through each ingriedient in list
        {
            Debug.Log(ingriedient);                 //prints out the list of ingriedients
        }
    }

    void Update()
    {
        //if (Input.GetKeyDown("r"))
        //{
        //    getPotion();
        //}
    }

    public void getPotion()    //this method is used to determine which potion the witch wants the player to craft
    {
        Destroy(clone);

        try
        {
            requiredPotion = potions[UnityEngine.Random.Range(0, potions.Count)];

            if (requiredPotion == stainPotion)
            {
                clone = Instantiate(potstain, potionSpawn.position, Quaternion.identity);
            }
            else if (requiredPotion == lovePotion)
            {
                clone = Instantiate(potlove, potionSpawn.position, Quaternion.identity);
                HagAudio.clip = love;
                HagAudio.volume = 0.8f * StaticPlayer.volume;
                HagAudio.Play();
            }
            else if (requiredPotion == invisPotion)
            {
                clone = Instantiate(potinvis, potionSpawn.position, Quaternion.identity);
                clone.transform.position = new Vector3(-490, 718.5f, -880);
                HagAudio.clip = invisible;
                HagAudio.volume = 0.8f * StaticPlayer.volume;
                HagAudio.Play();
            }
            else if (requiredPotion == deathPotion)
            {
                clone = Instantiate(potdeath, potionSpawn.position, Quaternion.identity);
                clone.transform.position = new Vector3(-490, 718.5f, -880);
                HagAudio.clip = death;
                HagAudio.volume = 0.8f * StaticPlayer.volume;
                HagAudio.Play();
            }
            else if (requiredPotion == lightPotion)
            {
                clone = Instantiate(potlight, potionSpawn.position, Quaternion.identity);
                HagAudio.clip = light;
                HagAudio.volume = 0.8f * StaticPlayer.volume;
                HagAudio.Play();
            }
            clone.transform.Rotate(-90, 0, 0);


            potions.Remove(requiredPotion);               //removes potion from list of potions so that it isnt used twice
            foreach (var ingriedient in requiredPotion)   //iterates through each ingriedient in list
            {
                Debug.Log(ingriedient);                 //prints out the list of ingriedients
            }

            foreach (var potionsRemaining in potions)   //iterates through each ingriedient in list
            {
                Debug.Log(potionsRemaining);                 //prints out the list of ingriedients
            }
        }
        catch(Exception e)
        {
            cameraController.GameEnd();
        }
        
        
    }

    public void bottleColour()
    {
        emptyBottle = GameObject.FindGameObjectWithTag("flask");
        rend = emptyBottle.GetComponent<MeshRenderer>();
        if (requiredPotion == stainPotion)
        {
            Material[] bottleMaterials = rend.materials;
            bottleMaterials[2] = mat[0];
            rend.materials = bottleMaterials;
        }
        else if (requiredPotion == lovePotion)
        {
            Material[] bottleMaterials = rend.materials;
            bottleMaterials[2] = mat[1];
            rend.materials = bottleMaterials;
        }
        else if (requiredPotion == invisPotion)
        {
            Material[] bottleMaterials = rend.materials;
            bottleMaterials[2] = mat[2];
            rend.materials = bottleMaterials;
        }
        else if (requiredPotion == deathPotion)
        {
            Material[] bottleMaterials = rend.materials;
            bottleMaterials[2] = mat[3];
            rend.materials = bottleMaterials;
        }
        else if (requiredPotion == lightPotion)
        {
            Material[] bottleMaterials = rend.materials;
            bottleMaterials[2] = mat[4];
            rend.materials = bottleMaterials;
        }

    }

}


