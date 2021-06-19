using UnityEngine;

public class Part_Detection : Part_Controller
{

    Part_Controller controller;

    Transform basePart;

    Color highlightColor;

    bool onPart;

    void Start()
    {

        controller = transform.parent.GetComponent<Part_Controller>(); // Reference the parent Part_Controller script

        // Set the original position of the base part transform and the highlight color
        basePart = transform.parent;
        highlightColor = Color.red;
    }

    // This function is called when this gameobject's collider detects the user's cursor is within its boundaries
    private void OnMouseEnter()
    {
        // If the user isn't moving the part around, set the 
        // onPart boolean to true, the Part_Controller hoveredOver 
        // boolean to true, and change the part's color to the highlighted color
        if (!controller.movingPart)
        {
            onPart = true;
            controller.hoveredOver = true;

            controller.ChangePartColor(highlightColor);
        }        
    }

    // This function is called when this gameobject's collider detects the user's cursor leaves its boundaries
    private void OnMouseExit()
    {
        // If the user isn't moving the part around, set the 
        // onPart boolean to false, the Part_Controller hoveredOver 
        // boolean to false, and reset the part's colors
        if (!controller.movingPart)
        {
            onPart = false;
            controller.hoveredOver = false;

            controller.ResetPartColors();
        }       
        
    }

    // This function is called when this gameobject's collider detects the user's mouse1 button is pressed down within its boundaries
    private void OnMouseDown()
    {
        // If the user is hovering over the current part,
        // disable the user's cursor, set the Part_Controller
        // connected and movingPart booleans to false and true
        // respectfully, and reset the part's colors
        if (onPart)
        {
            Cursor.visible = false;

            controller.connected = false;
            controller.movingPart = true;

            controller.ResetPartColors();
        }        
    }

    // This function is called when this gameobject's collider detects the user's mouse1 button is released within its boundaries
    private void OnMouseUp()
    {
        // Enable the user's cursor
        Cursor.visible = true;

        // If the current part is close enough to its origin to 
        // be replaced, set its position to its original position, 
        // set the Part_Controller connected and movingPart variables 
        // to true and false respectfully, and reset the part's colors
        if (controller.canReplacePart)
        {
            basePart.position = controller.origPos;

            controller.connected = true;

            controller.movingPart = false;
            controller.ResetPartColors();
        }
        // Otherwise, set the Part_Controller connected and movingPart variables to false
        else
        {
            controller.movingPart = false;
            controller.connected = false;
        }
    }
}
