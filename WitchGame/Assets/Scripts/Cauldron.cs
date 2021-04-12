using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class Cauldron : MonoBehaviour
{
    public Shelf shelf;
    public GameObject prop;
    public List<string> cauldron = new List<string>();
    public Potions potions;
    public AudioSource audioSource;
    public AudioClip addIngrediant;

    void Start()
    {

     
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 10)              //checks if the layer of the colliding object is 10 ("Pickups")
        {
            if (col.gameObject.tag == "HolyWater")
            {
                shelf.respawnIngriedients();
                cauldron.Clear();                       //removes all ingriedients from cauldron
                Destroy(col.gameObject);                //deactivates object once its been added to the cauldron
 
                Debug.Log("Cauldron has been emptied");
                                     
                 
            }
            else if (col.gameObject.tag=="flask")
            {

            }
            else
            {
                cauldron.Add(col.gameObject.tag);       //adds object to cauldron
                Destroy(col.gameObject);        //deactivates object once its been added to the cauldron
            }

                audioSource.clip = addIngrediant;
                audioSource.volume = 0.4f * StaticPlayer.volume;
                audioSource.Play();
            }

        }
    }