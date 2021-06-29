using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_Manager : MonoBehaviour
{

    public Part_Controller[] controllers;

    public UI_Manager uiManager;

    public Transform hoveredPart;

    // Start is called before the first frame update
    void Start()
    {
        // Reference the UI_Manager script by finding the UI gameobject within the hierarchy
        uiManager = GameObject.Find("UI").GetComponent<UI_Manager>();
        controllers = new Part_Controller[transform.childCount - 1];

        for(int i = 0; i < transform.childCount - 1; i++)
        {
            controllers[i] = transform.GetChild(i).GetComponent<Part_Controller>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hoveredPart)
        {            
            uiManager.connectedStatus = SetUI(); // Update the UI only if a part is hovered over
        }        
    }

    // This function updates the UI's text, setting the current part 
    // and its connection status by returning a string
    public string SetUI()
    {
        uiManager.partHoveredOver = hoveredPart;

        if (hoveredPart.GetComponent<Part_Controller>().connected == true)
        {
            return "Connected";
        }
        else
        {
            return "Disconnected";
        }
    }

    public void ResetParts()
    {
        for(int i = 0; i < controllers.Length; i++)
        {
            if (controllers[i])
            {
                controllers[i].ResetPartPosition();
            }            
        }
    }
}
