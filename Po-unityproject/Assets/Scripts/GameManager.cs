using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform redBaseObject;
    public Transform blueBaseObject;
    private Vector3 placement;
    private Quaternion spin;
    void Start()
    {
        BaseCreator();       
    }

    void BaseCreator()
    {
        placement = new Vector3(Random.Range(-101, 101), Random.Range(-101, 101));
        spin = new Quaternion(0,0,0,0);
        Instantiate(redBaseObject,placement , spin , redBaseObject.transform).name = "RedBase";
        placement = new Vector3(Random.Range(-101, 101), Random.Range(-101, 101));
        Instantiate(blueBaseObject, placement, spin, redBaseObject.transform).name = "BlueBase";
    }
}
