using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            anim.SetTrigger("Open");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("Close");
    }
}
