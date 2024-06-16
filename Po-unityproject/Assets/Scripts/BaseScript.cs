using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int iron = 0;
    [SerializeField] public int tytan = 0;
    public int stackShip = 15;
    public float timeShipSpawn = 0f;
    private int numbers = 0;
    [SerializeField] private GameObject redShipObject;
    [SerializeField] private GameObject blueShipObject;
    [SerializeField] private GameObject redFastShipObject;
    [SerializeField] private GameObject blueFastShipObject;
    [SerializeField] private GameObject redKillerShipObject;
    [SerializeField] private GameObject blueKillerShipObject;
    [SerializeField] private GameObject redBigShipObject;
    [SerializeField] private GameObject blueBigShipObject;
    GameManager gameManager;

    private void Start()
    {
        GameObject world = GameObject.Find("World");
        gameManager = world.GetComponent<GameManager>();
    }
    private void Update()
    {
        if (stackShip > 0)
        {
            ShipSpawner();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 6 || col.gameObject.layer == 8) // Sprawdza czy objekt z którym baza skolidowa³a jest shipem layer = 6 to ship, a 8 to shipKiller
        {
            GetResources(col);
        }
        if (iron >= 5)
        {
            stackShip++;
            iron -= 5;
        }
        LvlUp();
    }

    void ShipSpawner()  // Tworzenie statków
    {
        timeShipSpawn -= Time.deltaTime;    
        if (timeShipSpawn < 0)
        {
            string shipTag = "";
            int shipType;
            if (CompareTag("Red"))
               shipTag = "Red";
            else if (CompareTag("Blue"))
               shipTag = "Blue";

                switch (level)
                {
                    case (1):
                    PoorShipSpawner(shipTag);
                        break;
                    case (2):
                        shipType = Random.Range(1, 101);
                        if (shipType <= 50)
                        {
                            PoorShipSpawner(shipTag);
                        }
                        else if (shipType > 50 && shipType <= 75)
                        {
                            FastShipSpawner(shipTag);
                        }
                        else
                        {
                            BigShipSpawner(shipTag);
                        }
                        break;
                    case (3):
                        {
                            shipType = Random.Range(1, 101);
                            if (shipType <= 40)
                            {
                                PoorShipSpawner(shipTag);
                            }
                            else if (shipType > 40 && shipType <= 65)
                            {
                                FastShipSpawner(shipTag);
                            }
                            else if (shipType > 65 && shipType <= 90)
                            {
                                BigShipSpawner(shipTag);
                            }
                            else
                            {
                                KillerShipSpawner(shipTag);
                            }
                            break;
                        }
                    }
                stackShip--;
                timeShipSpawn = 4f;
            }
        }
    private void PoorShipSpawner(string tag)
    {
        if(tag == "Blue")
        {
            Instantiate(blueShipObject, transform.position, transform.rotation).name = tag + "Ship" + numbers;
            numbers++;
        }
        else if(tag == "Red")
        {
            Instantiate(redShipObject, transform.position, transform.rotation).name = tag + "Ship" + numbers;
            numbers++;
        }
    }
    private void BigShipSpawner(string tag)
    {
        if (tag == "Blue")
        {
            Instantiate(blueBigShipObject, transform.position, transform.rotation).name = tag + "Ship" + numbers;
            numbers++;
        }
        else if (tag == "Red")
        {
            Instantiate(redBigShipObject, transform.position, transform.rotation).name = tag + "Ship" + numbers;
            numbers++;
        }
    }
    private void FastShipSpawner(string tag)
    {
        if (tag == "Blue")
        {
            Instantiate(blueFastShipObject, transform.position, transform.rotation).name = tag + "Ship" + numbers;
            numbers++;
        }
        else if (tag == "Red")
        {
            Instantiate(redFastShipObject, transform.position, transform.rotation).name = tag + "Ship" + numbers;
            numbers++;
        }
    }
    private void KillerShipSpawner(string tag)
    {
        if (tag == "Blue")
        {
            Instantiate(blueKillerShipObject, transform.position, transform.rotation).name = tag + "Ship" + numbers;
            numbers++;
        }
        else if (tag == "Red")
        {
            Instantiate(redKillerShipObject, transform.position, transform.rotation).name = tag + "Ship" + numbers;
            numbers++;
        }
    }
    private void LvlUp(){   //Levelowanie bazy
        if (level == 1 && tytan >= 25)
        {
            level = 2;
        }
        else if (level == 2 && tytan >= 100)
        {
            level = 3;
        }
        else if (level == 3 && tytan >= 500)
        {
            level = 4;
            if (CompareTag("Red"))
            {
                gameManager.redPanel.gameObject.SetActive(true);
                Time.timeScale = 0;
                gameManager.AddToReport("Red", "Resources");
            }
            else if (CompareTag("Blue"))
            {
                gameManager.bluePanel.gameObject.SetActive(true);
                Time.timeScale = 0;
                gameManager.AddToReport("Blue", "Resources");
            }
        }

    }
    private void GetResources(Collider2D col){  //Zbieranie zasobów ze statków
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
                gameManager.loseCheck(col.gameObject.tag);  //Je¿eli statek przeciwnika wleci w bazê, to sprawdza czy czasem to nie by³ ostatni statek
            }
    }

}
