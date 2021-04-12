using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    [SerializeField] private GameObject recipeBook;
    [SerializeField] private bool isPaused;
    public bool bookOpen;

    void Start()
    {
        
    }

    void Update()
    {

    }

    // Update is called once per frame
    public void BookOpening()
    {
       
        isPaused = !isPaused;
        

        if (isPaused)
        {
            OpenBook();
        }

        else
        {
            CloseBook();
        }

    }

    public void OpenBook()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        recipeBook.SetActive(true);
        bookOpen = true;
    }

    public void CloseBook()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        recipeBook.SetActive(false);
        bookOpen = false;
    }
}
