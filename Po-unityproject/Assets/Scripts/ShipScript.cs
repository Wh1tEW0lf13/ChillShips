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
    private int x, y;
    public bool isComingBack = false;
    public Vector2 followPosition;
    GameManager gameManager;
    public Transform world;

    private void Start()
    {
        SetBasePosition();
        gameManager = world.GetComponent<GameManager>();
        followPosition = new Vector2(Random.Range(-gameManager.xSpawn, gameManager.xSpawn), Random.Range(-gameManager.ySpawn, gameManager.ySpawn)); 
        // Trzeba póŸniej zrobiæ, ¿eby nie losowa³ koordynatów za blisko bazy.
    }
    void Update()
    {  
        Move();
    }


    public void Move(){
        if(isComingBack)
            transform.position = Vector2.MoveTowards(transform.position, basePos.transform.position, shipSpeed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, followPosition, shipSpeed * Time.deltaTime);
        if (transform.position.x == followPosition.x && transform.position.y == followPosition.y)
            isComingBack = true;
    }

    public void SetBasePosition(){
        if (CompareTag("Blue"))
        {
            basePos = GameObject.Find("BlueBase");
        }
        else if (CompareTag("Red"))
        {
            basePos = GameObject.Find("RedBase");
        }
    }
    
    
}
