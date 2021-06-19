using UnityEngine;
using UnityEngine.UI;

public class Part_Controller : Part_Manager
{

    Part_Manager mainController;

    public Transform[] parts;

    public Color[] partColors;

    public Vector3 origPos;

    float mouseY;
    float mouseX;
    float mouseSensitivity = 0.02f;
    float attachRadius = 0.001f;

    public bool canReplacePart;
    public bool movingPart;

    public bool hoveredOver;
    public bool connected;

    void Start()
    {
        mainController = transform.parent.GetComponent<Part_Manager>(); // Reference the mainController script on the base robot gameobject

        // Initialize the parts and partColors array sizes
        parts = new Transform[transform.childCount];
        partColors = new Color[transform.childCount];

        
        for(int i = 0; i <= transform.childCount - 1; i++) // Fill in the parts and partColors arrays
        {
            parts[i] = transform.GetChild(i);
            partColors[i] = parts[i].GetComponent<Renderer>().material.color;
        }

        // Set the original position of this part
        origPos = transform.position;

        movingPart = false;
        canReplacePart = false;
        hoveredOver = false;
        connected = true;
    }

    void Update()
    {
        // If the current part is being clicked on
        if (movingPart)
        {
            DragPart(); // Allow the user to drag the part around

            // If the part is less than 0.001 units away from its original 
            // position, change the part color to indicate it can be replaced, 
            // otherwise set the part's colors to their original colors
            if (ResetRangeDetect(transform.position.magnitude - origPos.magnitude)) 
            {
                ChangePartColor(Color.green);
                canReplacePart = true;
            }
            else
            {
                ResetPartColors();
                canReplacePart = false;                
            }
        }

        // If the current part is being hovered over with the mouse 
        // or is being clicked on, set the referenced Main_Controller 
        // hoveredPart variable to the current part
        if (hoveredOver || movingPart)
        {
            mainController.hoveredPart = transform;
        }
    }

    //  This function changes the color of a part by going through 
    //  and changing the color of each child gameobject's material
    public void ChangePartColor(Color partColor)
    {
        for(int i = 0; i < parts.Length; i++)
        {
            parts[i].GetComponent<Renderer>().material.color = partColor;
        }
    }

    // This function resets the colors of the part by returning 
    // each child gameobject's material color back to its original color
    public void ResetPartColors()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].GetComponent<Renderer>().material.color = partColors[i];
        }
    }

    // This function takes in a float, and determines whether it's close 
    // enough to the part's original position to be snapped into place 
    // using a float as a radius
    public bool ResetRangeDetect(float range)
    {
        if(range <= attachRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // This function moves the current part when it's being held 
    // using the mouse's axis' 
    void DragPart()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");

        if (Input.GetAxis("Mouse X") != 0)
            transform.Translate(Vector3.right * -mouseX * mouseSensitivity);

        if (Input.GetAxis("Mouse Y") != 0)
            transform.Translate(Vector3.up * mouseY * mouseSensitivity);

        mouseX = 0;
        mouseY = 0;
    }
}
