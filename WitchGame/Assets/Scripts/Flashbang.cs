using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashbang : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public CanvasGroup myCG;
    // Update is called once per frame
    void Update()
    {
        
        if (myCG.alpha > 0)
        {
            myCG.alpha = myCG.alpha - (Time.deltaTime/4);
            
            
        }
    }
}
