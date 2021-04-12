using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public GameObject[] ingriedients;
   

    public Transform[] ingriedientSpawns;


    public PickUp respawnables;
    void Start()
    {

    }


    void Update()
    {
        
    }


    public void respawnIngriedients()
    {
        PickUp pickUp = respawnables.GetComponent<PickUp>();
        for (int i = 0; i < pickUp.toArray.Length; i++)
        {
            if (pickUp.toArray[i] == "Slugs")
            {
                spawnSlugs();
            }

            else if (pickUp.toArray[i] == "Flies")
            {
                spawnFlies();
            }

            else if (pickUp.toArray[i] == "DogTeeth")
            {
                spawnDogTeeth();
            }

            else if (pickUp.toArray[i] == "LockHair")
            {
                spawnLockHair();
            }

            else if (pickUp.toArray[i] == "Peppermint")
            {
                spawnPeppermint();
            }

            else if (pickUp.toArray[i] == "BatBlood")
            {
                spawnBatBlood();
            }

            else if (pickUp.toArray[i] == "CatEye")
            {
                spawnCatEye();
            }

            else if (pickUp.toArray[i] == "SnakeVenom")
            {
                spawnSnakeVenom();
            }

            else if (pickUp.toArray[i] == "BoneDust")
            {
                spawnBoneDust();
            }

            else if (pickUp.toArray[i] == "Toenail")
            {
                spawnToenail();
            }

            else if (pickUp.toArray[i] == "Alcohol")
            {
                spawnAlcohol();
            }

            else if (pickUp.toArray[i] == "Sapphire")
            {
                spawnSapphire();
            }

            else if (pickUp.toArray[i] == "HolyWater")
            {
                spawnHolyWater();
            }

            else if (pickUp.toArray[i] == "RosePetals")
            {
                spawnRosePetals();
            }

            else if (pickUp.toArray[i] == "Nettles")
            {
                spawnNettles();
            }

            else if (pickUp.toArray[i] == "HeartTrinket")
            {
                spawnHeartTrinket();
            }

            else if (pickUp.toArray[i] == "ChildTears")
            {
                spawnChildTears();
            }

            else if (pickUp.toArray[i] == "VoodooDoll")
            {
                spawnVoodooDoll();
            }


        }
    }

    public void spawnSlugs()
    {
        GameObject clone = Instantiate(ingriedients[0], ingriedientSpawns[0].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[0].name;


    }
    public void spawnFlies()
    {
        GameObject clone = Instantiate(ingriedients[1], ingriedientSpawns[1].position, Quaternion.identity);
        clone.transform.Rotate(123, -127, 4);
        clone.name = ingriedients[1].name;

    }
    public void spawnDogTeeth()
    {
        GameObject clone = Instantiate(ingriedients[2], ingriedientSpawns[2].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[2].name;

    }
    public void spawnLockHair()
    {
        GameObject clone = Instantiate(ingriedients[3], ingriedientSpawns[3].position, Quaternion.identity);
        clone.transform.Rotate(7.5f, -164.5f, -21.5f);
        clone.name = ingriedients[3].name;

    }
    public void spawnPeppermint()
    {
        GameObject clone = Instantiate(ingriedients[4], ingriedientSpawns[4].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[4].name;
    }
    public void spawnBatBlood()
    {
        GameObject clone = Instantiate(ingriedients[5], ingriedientSpawns[5].position, Quaternion.identity);
        //clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[5].name;
    }
    public void spawnCatEye()
    {
        GameObject clone = Instantiate(ingriedients[6], ingriedientSpawns[6].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[6].name;
    }
    public void spawnSnakeVenom()
    {
        GameObject clone = Instantiate(ingriedients[7], ingriedientSpawns[7].position, Quaternion.identity);
       //clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[7].name;
    }
    public void spawnBoneDust()
    {
        GameObject clone = Instantiate(ingriedients[8], ingriedientSpawns[8].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[8].name;
    }
    public void spawnToenail()
    {
        GameObject clone = Instantiate(ingriedients[9], ingriedientSpawns[9].position, Quaternion.identity);
        //clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[9].name;
    }
    public void spawnAlcohol()
    {
        GameObject clone = Instantiate(ingriedients[10], ingriedientSpawns[10].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[10].name;
    }
    public void spawnSapphire()
    {
        GameObject clone = Instantiate(ingriedients[11], ingriedientSpawns[11].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[11].name;
    }
    public void spawnHolyWater()
    {
        GameObject clone = Instantiate(ingriedients[12], ingriedientSpawns[12].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[12].name;
    }
    public void spawnRosePetals()
    {
        GameObject clone = Instantiate(ingriedients[13], ingriedientSpawns[13].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[13].name;
    }
    public void spawnNettles()
    {
        GameObject clone = Instantiate(ingriedients[14], ingriedientSpawns[14].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[14].name;
    }
    public void spawnHeartTrinket()
    {
        GameObject clone = Instantiate(ingriedients[15], ingriedientSpawns[15].position, Quaternion.identity);
        clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[15].name;
    }
    public void spawnChildTears()
    {
        GameObject clone = Instantiate(ingriedients[16], ingriedientSpawns[16].position, Quaternion.identity);
        //clone.transform.Rotate(-90, 0, 0);
        clone.name = ingriedients[16].name;
    }
    public void spawnVoodooDoll()
    {
        GameObject clone = Instantiate(ingriedients[17], ingriedientSpawns[17].position, Quaternion.identity);
        clone.transform.Rotate(84, -65, 49);
        clone.name = ingriedients[17].name;
    }

}
