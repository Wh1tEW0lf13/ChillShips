using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    private int level = 1;
    [SerializeField] private int iron = 0;
    [SerializeField] private int tytan = 0;
    public int stackShip = 15;
    public float timeShipSpawn = 0f;
    private int numbers = 0;
    public GameObject redShipObject;
    public GameObject blueShipObject;
    GameManager gameManager;

    private void Start()
    {
        GameObject world = GameObject.Find("World");
        gameManager = world.GetComponent<GameManager>();
    }
    private void Update()
    {
        if(stackShip>0)
        {
            ShipSpawner();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 6)
        {
            ShipScript shipCapacity = col.GetComponent<ShipScript>();
            if (col.CompareTag(tag))
            {
                if (shipCapacity.isComingBack)
                {
                    iron += shipCapacity.ironCapacity / 2;
                    tytan += shipCapacity.tytanCapacity / 2;
                    stackShip++;
                    Destroy(col.gameObject);
                }
            }
            else
            {
                iron += shipCapacity.ironCapacity / 2;
                tytan += shipCapacity.tytanCapacity / 2;
                stackShip++;
                Destroy(col.gameObject);
                gameManager.loseCheck(col.gameObject.tag);
            }
        }
        if (iron >= 5)
        {
            stackShip++;
            iron -= 5;
        }
        if (level == 1 && tytan >= 25)
        {
            level = 2;
            tytan -= 25;
        }
        else if(level == 2 && tytan >= 100)
        {
            level = 3;
            tytan -= 100;
        }
        else if(level == 3 && tytan >= 500)
        {
            level = 4;
            tytan -= 5000;
            if(CompareTag("Red"))
            {
                gameManager.redPanel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else if(CompareTag("Blue"))
            {
                gameManager.bluePanel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
            
    }
    void ShipSpawner()
    {
        timeShipSpawn -= Time.deltaTime;
        if(timeShipSpawn<0)
        {
            stackShip--;
            if (CompareTag("Red"))
            {
                Instantiate(redShipObject,transform.position,transform.rotation).name = tag + "Ship" + numbers;
                numbers++;
                timeShipSpawn = 4f;
            }
            else if (CompareTag("Blue"))
            {
                Instantiate(blueShipObject, transform.position, transform.rotation).name = tag + "Ship" + numbers;
                numbers++;
                timeShipSpawn = 4f;
            }
        }
    }
}
