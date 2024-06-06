using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public GameObject basePos;
    public float shipSpeed;
    public int tytanCapacity = 0;
    public int ironCapacity = 0;
    public int Capacity = 10;
    public float x, y;
    public bool isComingBack = false;
    public Vector2 followPosition;
    public GameManager gameManager;
    public GameObject world;
    [SerializeField] private AudioClip boom;

    private void Start()
    {
        SetBasePosition();
        gameManager = world.GetComponent<GameManager>();
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
        if (transform.position.x == x && transform.position.y == y)
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
    public void SetFollowPosition()
    {
        followPosition = basePos.transform.position;
        while(followPosition.x>basePos.transform.position.x-5&& followPosition.x < basePos.transform.position.x + 5 || followPosition.y > basePos.transform.position.y - 5 && followPosition.y < basePos.transform.position.y + 5)
        {
            followPosition = new Vector2(Random.Range(-gameManager.xSpawn, gameManager.xSpawn), Random.Range(-gameManager.ySpawn, gameManager.ySpawn));
        }
    }
    public void ShipDestroyer(GameObject ship)
    {
            Destroy(ship.gameObject);
            AudioSource.PlayClipAtPoint(boom, ship.transform.position);
            gameManager.loseCheck(ship.tag);
    }
}
