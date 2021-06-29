using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Robot : MonoBehaviour
{

    Part_Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Robot_Toy"))
        {
            manager = GameObject.Find("Robot_Toy").GetComponent<Part_Manager>();
        }
        else
        {
            manager = GameObject.Find("Robot_Toy_Plus").GetComponent<Part_Manager>();
        }
    }

    public void ResetRobot()
    {
        manager.ResetParts();
    }
}
