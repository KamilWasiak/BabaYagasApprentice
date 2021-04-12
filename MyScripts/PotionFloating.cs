using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionFloating : MonoBehaviour
{
    public float degreesPerSecond = 25f;
    public float speed;
    public float amplitude;
    float tempPosition;
    // Start is called before the first frame update
    void Start()
    {
        tempPosition = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {

        tempPosition = Mathf.Sin(Time.realtimeSinceStartup * speed) * amplitude;
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
        transform.position = new Vector3(transform.position.x, tempPosition + 720f, transform.position.z);
    }
}
