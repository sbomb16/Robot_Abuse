using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    public Text statusText;

    public Transform partHoveredOver;

    public string connectedStatus;    

    // Start is called before the first frame update
    void Start()
    {
        // Reference the status text by getting the text UI element in the hierarchy
        statusText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // If a part is being hovered over, set the statusText text to 
        // whatever part is being hovered over, along with its connection status
        if (partHoveredOver != null)
        {
            statusText.text = partHoveredOver.tag + ": " + connectedStatus;
        }
        // Otherwise, return a default message
        else
        {
            statusText.text = "Part not selected";
        }
    }

    public string GetStatus()
    {
        return connectedStatus;
    }
}
