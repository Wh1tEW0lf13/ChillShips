using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public int level = 1;
    public int iron = 0;
    public int tytan = 0;
    public int stackShip = 5;
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
        if (iron >= 250)
        {
            stackShip++;
            iron -= 250;
        }
        if (level == 1 && tytan >= 1000)
        {
            level = 2;
            tytan -= 1000;
        }
        else if(level == 2 && tytan >= 2000)
        {
            level = 3;
            tytan -= 2000;
        }
        else if(level == 3 && tytan >= 3000)
        {
            level = 4;
            tytan -= 3000;
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
                timeShipSpawn = 5f;
            }
            else if (CompareTag("Blue"))
            {
                Instantiate(blueShipObject, transform.position, transform.rotation).name = tag + "Ship" + numbers;
                numbers++;
                timeShipSpawn = 5f;
            }
        }
    }
}
