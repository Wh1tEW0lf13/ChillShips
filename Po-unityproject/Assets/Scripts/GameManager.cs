using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform redBaseObject;
    public Transform blueBaseObject;
    public Transform QuerryAstroid;
    public Transform TrapAsteroid;
    private Quaternion spin;
    public int asteroidQuantity;
    [Header("World Size")]
    public int xSpawn;
    public int ySpawn;
    [Header("EndGamePanel")]
    [SerializeField] public Canvas bluePanel;
    [SerializeField] public Canvas redPanel;
    
    void Start()
    {
        BaseCreator();
        AsteroidCreator();
        spin = new Quaternion(0, 0, 0, 0);

    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }      
    }
    void BaseCreator()
    {  
        Instantiate(redBaseObject, Placement(1,0) , spin).name = "RedBase";
        Instantiate(blueBaseObject, Placement(0,1), spin).name = "BlueBase";
    }
    void AsteroidCreator()
    {
        for(int i = 0; i < asteroidQuantity; i++)
        Instantiate(QuerryAstroid, Placement(), spin).name = "QuerryAsteroid" + i;
        for(int i = 0; i < asteroidQuantity/5; i++)
        Instantiate(TrapAsteroid, Placement(), spin).name = "TrapAsteroid" + i;
    }
    Vector3 Placement(int red, int blue)
    {
        return new Vector3(Random.Range(-xSpawn*red, xSpawn*blue), Random.Range(-ySpawn, ySpawn));
    }
    public Vector3 Placement()
    {
        return new Vector3(Random.Range(-xSpawn, xSpawn), Random.Range(-ySpawn, ySpawn));
    }
    public void loseCheck(string tag)
    {
        var numberOfObjects = GameObject.FindGameObjectsWithTag(tag).Length;
        GameObject red = GameObject.Find("RedBase");
        GameObject blue = GameObject.Find("BlueBase");
        if(tag == "Red")
        {
            if (red.GetComponent<BaseScript>().stackShip + numberOfObjects <= 2)
            {
                bluePanel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if(tag == "Blue")
        {
            if (blue.GetComponent<BaseScript>().stackShip + numberOfObjects <= 2)
            {
                redPanel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }

    }
}
