using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.random;

public class PickUp : MonoBehaviour
{

    public PauseMenu inputEnabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Animator babaAnim;
    public Shelf shelf;
    GameObject pickedUpObject = null;
    Rigidbody rb;
    public Cauldron cauldron;
    public Potions potions;
    int correct=0;
    bool correctPot;
    int lives = 3;
    public CanvasGroup myCG;
    public RecipeBook book;
    public AudioSource audioSource;
    public AudioClip getPotion;
    public AudioClip penalty1;
    public AudioClip penalty2;
    public AudioClip penalty3;
    public AudioSource HagAudio;
    public AudioClip success1;
    public AudioClip success2;
    public AudioClip fail1;
    public AudioClip fail2;
    public GameObject GameOverScreen;
    public string[] toArray;

    public GameObject emptyBottle;
    public Transform emptyBottleSpawn;
    //public MeshRenderer rend;
    //public Material[] mat;
    //bool flash = false;
    // Update is called once per frame
    void Update()
    {
     
        StaticPlayer.lives = lives;

        RaycastHit hit;
        PauseMenu pauseMenu = inputEnabled.GetComponent<PauseMenu>();
         toArray = cauldron.cauldron.ToArray();
        if (Input.GetKeyDown("e") && pauseMenu.InputEnabled)
        {
            if (pickedUpObject == null)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 150))
                {
                    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    if (hit.collider.gameObject.layer == 10)
                    {

                        pickedUpObject = hit.collider.gameObject; //we use this to determine whether an object is picked up by the player. If it's not null, then the player is doing so.
                        rb = hit.rigidbody;
                        rb.useGravity=false;
                        rb.freezeRotation=true;
                        
                        pickedUpObject.transform.parent = transform; //attach the object to the camera so it moves along with it.
                        pickedUpObject.transform.position = transform.position + (transform.forward * 100); //might need changing as it's untested.
                        //Debug.Log(pickedUpObject);
                    }
                    else if (hit.collider.gameObject.tag == "DogSkull")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnDogTeeth();
                    }
                    else if (hit.collider.gameObject.tag == "NettlePlant")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnNettles();
                    }
                    else if (hit.collider.gameObject.tag == "Snail")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnSlugs();
                    }
                    else if (hit.collider.gameObject.tag == "Rose")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnRosePetals();
                    }
                    else if (hit.collider.gameObject.tag == "Snake")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnSnakeVenom();
                    }
                    else if (hit.collider.gameObject.tag == "Bat")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnBatBlood();
                    }
                    else if (hit.collider.gameObject.tag == "BoneDustBag")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnBoneDust();
                    }
                    else if (hit.collider.gameObject.tag == "SapphireBag")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnSapphire();
                    }
                    else if (hit.collider.gameObject.tag == "VoodooDollGround")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnVoodooDoll();
                    }
                    else if (hit.collider.gameObject.tag == "ToenailJar")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnToenail();
                    }
                    else if (hit.collider.gameObject.tag == "LockHairJar")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnLockHair();
                    }
                    else if (hit.collider.gameObject.tag == "PeppermintPlant")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnPeppermint();
                    }
                    else if (hit.collider.gameObject.tag == "HeartTrinketGround")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnHeartTrinket();
                    }
                    else if (hit.collider.gameObject.tag == "FliesGround")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnFlies();
                    }
                    else if (hit.collider.gameObject.tag == "CatEyeGround")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        Destroy(pickedUpObject);
                        shelf.spawnCatEye();
                    }

                    else if (hit.collider.gameObject.tag == "RecipeBook")
                    {
                        book.BookOpening();
                        
                        //play book opening animation
                        //execute book menu method
                    }
                }
            }
            else if (pickedUpObject != null)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 150))
                {
                    if (pickedUpObject.tag == "flask" && hit.collider.gameObject.tag == "Cauldron")
                    {
                        toArray = cauldron.cauldron.ToArray();
                        if (potions.requiredPotion.Length == toArray.Length)
                        {
                            for (int i = 0; i < toArray.Length; i++)
                            {
                                if (potions.requiredPotion[i] == toArray[i])
                                {
                                    correct++;
                                }
                            }

                            if (correct == potions.requiredPotion.Length)
                            {
                            
                                correctPot = true;
                                Debug.Log(correctPot);
                                audioSource.clip = getPotion;
                                audioSource.volume = 0.4f * StaticPlayer.volume;
                                audioSource.Play();
                                potions.bottleColour();

                                

                                if (UnityEngine.Random.Range(0,1) < 0.5f)
                                {
                                    HagAudio.clip = success1;
                                    HagAudio.volume = 0.8f * StaticPlayer.volume;
                                    HagAudio.Play();
                                }
                                else
                                {
                                    HagAudio.clip = success2;
                                    HagAudio.volume = 0.8f * StaticPlayer.volume;
                                    HagAudio.Play();
                                }

                                //[] bottleMaterials = rend.materials;
                                //bottleMaterials[2] = mat[1];
                                //rend.materials = bottleMaterials;


                            }
                            
                        }
                        else
                        {
                            correctPot = false;
                            Debug.Log(correctPot);
                            lives--;
                            myCG.alpha = 1;
                            babaAnim.SetTrigger("isSad");
                            Destroy(pickedUpObject);
                            GameObject clone = Instantiate(emptyBottle, emptyBottleSpawn.position, Quaternion.identity);
                            clone.transform.Rotate(-90, 0, 0);
                            clone.transform.localScale = new Vector3(transform.localScale.x * 60, transform.localScale.y * 60, transform.localScale.z * 70);
                            clone.name = emptyBottle.name;

                            switch (lives)
                            {
                                case 2:
                                    audioSource.clip = penalty1;
                                    audioSource.volume = 0.2f * StaticPlayer.volume;
                                    audioSource.Play();

                                    HagAudio.clip = fail1;
                                    HagAudio.volume = 0.8f * StaticPlayer.volume;
                                    HagAudio.Play();

                                    break;

                                case 1:
                                    audioSource.clip = penalty2;
                                    audioSource.volume = 0.6f * StaticPlayer.volume;
                                    audioSource.Play();

                                    HagAudio.clip = fail2;
                                    HagAudio.volume = 0.8f * StaticPlayer.volume;
                                    HagAudio.Play();

                                    break;

                                case 0:
                                    audioSource.clip = penalty3;
                                    audioSource.volume = 0.4f * StaticPlayer.volume;
                                    audioSource.Play();

                                    GameOverScreen.SetActive(true);

                                    break;
                            }

                            //lose
                        }
                        correct = 0;
                        shelf.respawnIngriedients();
                        cauldron.cauldron.Clear();
                    }
                    else if(pickedUpObject.tag=="flask"&&hit.collider.gameObject.tag=="Witch")
                    {
                        if(correctPot==true)
                        {
                          
                            babaAnim.SetTrigger("isClap");
                            potions.getPotion();
                            correctPot = false;
                            Destroy(pickedUpObject);
                            GameObject clone = Instantiate(emptyBottle, emptyBottleSpawn.position, Quaternion.identity);
                            clone.transform.Rotate(-90, 0, 0);
                            clone.transform.localScale = new Vector3(transform.localScale.x * 60, transform.localScale.y * 60, transform.localScale.z * 70);
                            clone.name = emptyBottle.name;
                        }
                        
                    }
                    else
                    {
                        rb.freezeRotation = false;
                        rb.useGravity = true;
                        pickedUpObject.transform.parent = null; //drop the object
                        pickedUpObject = null;  //and nullify the object pointer

                    }
                }
            }
        }
        if (pickedUpObject!=null)
        {
            pickedUpObject.transform.position = transform.position + (transform.forward * 100f);
        }
    }
    
   
    


}


