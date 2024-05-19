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
    public bool isComingBack = false;
    public Vector2 followPosition;

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
        followPosition = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
        Debug.Log(followPosition);
    }
    void Update()
    {  
        if(isComingBack)
            transform.position = Vector2.MoveTowards(transform.position, basePos.transform.position, shipSpeed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, followPosition, shipSpeed * Time.deltaTime);
        if (transform.position.x == followPosition.x && transform.position.y == followPosition.y)
            isComingBack = true;
    }
    
    
}
