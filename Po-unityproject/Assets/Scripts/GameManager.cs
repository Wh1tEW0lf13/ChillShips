using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform redBaseObject;
    public Transform blueBaseObject;
    void Start()
    {
        Instantiate(redBaseObject).name = "RedBase";
        //Instantiate(blueBaseObject).name = "BlueBase";
    }
}
