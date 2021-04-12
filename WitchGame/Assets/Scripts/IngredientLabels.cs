using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientLabels : MonoBehaviour
{
    private bool ShowRollover;
    private Rect objRect;
    private Vector2 MousePos;
    public Font font;
    public PauseMenu inputEnabled;
    private Color startcolor;

    void Start()
    {
        ShowRollover = false;
        objRect = new Rect(0, 200, 200, 35);
        MousePos = new Vector2(0, 0);
        
    }

    void OnMouseEnter() 
    {
        PauseMenu pauseMenu = inputEnabled.GetComponent<PauseMenu>();
        if (pauseMenu.InputEnabled)
        {
            ShowRollover = true;

            startcolor = this.GetComponent<Renderer>().material.color;
            //startcolor = renderer.material.color;
            this.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
    void OnMouseExit()
    {
        PauseMenu pauseMenu = inputEnabled.GetComponent<PauseMenu>();
        if (pauseMenu.InputEnabled)
        {
            ShowRollover = false;

            //renderer = GetComponent<Renderer>();
            this.GetComponent<Renderer>().material.color = startcolor;
        }
    }
    void OnGUI()
    {
        if (ShowRollover)
        {
            //this will place the label on the objects local 0,0
            //objPos = Camera.main.WorldToScreenPoint(transform.position);
            //this will place the label on the mouse cursor
            MousePos = Input.mousePosition;
            objRect.x = MousePos.x;
            objRect.y = Mathf.Abs(MousePos.y - Camera.main.pixelHeight);
            GUI.skin.font = font;
            GUI.contentColor = Color.white;
            GUI.skin.label.fontSize = 24;
            GUI.Label(objRect, gameObject.name + " (e)");

        }
    }
}
