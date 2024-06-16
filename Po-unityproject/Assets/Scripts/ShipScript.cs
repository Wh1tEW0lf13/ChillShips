using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipScript : MonoBehaviour
{
    public GameObject basePos;
    public float shipSpeed;
    public int tytanCapacity = 0;
    public int ironCapacity = 0;
    [SerializeField]protected int Capacity;
    protected float x, y;
    public bool isComingBack = false;
    protected Vector2 followPosition;
    protected GameManager gameManager;
    protected GameObject world;
    [SerializeField] private AudioClip boom;

    private void Start()
    {
        SetBasePosition();  
        gameManager = world.GetComponent<GameManager>();
    }
    protected void Move(){ 
        if(isComingBack)
            transform.position = Vector2.MoveTowards(transform.position, basePos.transform.position, shipSpeed * Time.deltaTime);   //Wracanie dobazy
        else
            transform.position = Vector2.MoveTowards(transform.position, followPosition, shipSpeed * Time.deltaTime);   //udanie w stron� losowych koordynat�w
        if (transform.position.x == x && transform.position.y == y)
            isComingBack = true;
    }
    
    protected void Prepare(){   //Przygotowanie do odlotu
        world = GameObject.Find("World");
        SetBasePosition();
        gameManager = world.GetComponent<GameManager>();
        SetFollowPosition();
        x = followPosition.x;
        y = followPosition.y;
    }

    protected void SetBasePosition()    //Zapisuje pozycj� bazy, by statek wiedzia� gdzie ma wraca�
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
    protected void SetFollowPosition()  //Ustawia pozycj� w jak� ma si� uda� statek
    {
        followPosition = basePos.transform.position;
        while(followPosition.x>basePos.transform.position.x-5&& followPosition.x < basePos.transform.position.x + 5 || followPosition.y > basePos.transform.position.y - 5 && followPosition.y < basePos.transform.position.y + 5)  //jest to zrobione by statek nie wylosowa� pozycji na kt�rej znaduje si� baza
        {
            followPosition = new Vector2(Random.Range(-gameManager.xSpawn, gameManager.xSpawn), Random.Range(-gameManager.ySpawn, gameManager.ySpawn));
        }
    }
    protected void ShipDestroyer(GameObject ship)   //S�u�y do niszczenia statk�w
    {
        if(ship.tag=="Red")
        {
            gameManager.blueKillCount++;
        }
        else if(ship.tag=="Blue")
        {
            gameManager.redKillCount++;
        }
        Destroy(ship.gameObject);
        AudioSource.PlayClipAtPoint(boom, ship.transform.position); //Gdy statki na siebie wpadn� uruchamia si� wybuch
        gameManager.loseCheck(ship.tag);
    }
}
