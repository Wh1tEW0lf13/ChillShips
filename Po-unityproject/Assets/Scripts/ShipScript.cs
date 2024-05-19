using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public GameObject basePos;
    [SerializeField] private float shipSpeed=3f;
    public int tytanCapacity = 0;
    public int ironCapacity = 0;
    public int Capacity = 10;
    public bool isFull = false;

    private void Start()
    {
        if (CompareTag("Blue"))
        {
            basePos = GameObject.Find("BlueBase");
        }
        else if (CompareTag("Red"))
        {
            basePos = GameObject.Find("RedBase");
        }
    }
    void Update()
    {  
            transform.position = Vector2.MoveTowards(transform.position, basePos.transform.position, shipSpeed * Time.deltaTime);
    }
    


}
