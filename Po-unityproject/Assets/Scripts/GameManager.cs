using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private static float simulationTime = 0f;
    public static int asteroidKillCountRed = 0;
    public static int asteroidKillCountBlue = 0;
    private static int asteroidRatio = 10;

    void Start()
    {
        BaseCreator();
        AsteroidCreator();
        spin = new Quaternion(0, 0, 0, 0);
        asteroidKillCountRed = 0;
        asteroidKillCountBlue = 0;
        simulationTime = 0f;
        ShipKiller.blueKillCount = 0;
        ShipKiller.redKillCount = 0;

    }

    private void Update()
    {
        simulationTime += Time.deltaTime;
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
        for(int i = 0; i < asteroidQuantity/asteroidRatio; i++)
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
                AddToReport("Blue", "Killed Enemy");
            }
        }
        else if(tag == "Blue")
        {
            if (blue.GetComponent<BaseScript>().stackShip + numberOfObjects <= 2)
            {
                redPanel.gameObject.SetActive(true);
                Time.timeScale = 0;
                AddToReport("Red", "Killed Enemy");
            }
        }


    }

    //Funkcja Add report tworzy podsumowanie kazdej symulacji w celu ułatwienia zebrania danych do sprawozdania
    public static void AddToReport(string winner, string winCase)
    {
        string filePath = "Report.txt";

        try
        {
            // Sprawdzanie czy plik istnieje
            bool fileExists = File.Exists(filePath);

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                //Dodanie nagłówków
                if (!fileExists)
                {
                    sw.WriteLine("winner,winCase,blueKills,redKills,asteroidKillsBlue,asteroidKillsRed,blueTytan,redTytan,simulationTime");
                }

                //Zbuduj nowy wiersz z danych
                string newRow = $"{winner},{winCase},{ShipKiller.blueKillCount},{ShipKiller.redKillCount},{asteroidKillCountBlue},{asteroidKillCountRed},{GameObject.Find("BlueBase").GetComponent<BaseScript>().tytan},{GameObject.Find("RedBase").GetComponent<BaseScript>().tytan},{simulationTime}";
                sw.WriteLine(newRow);
            }

            print("Dane zostały pomyślnie dodane do pliku");
            SceneManager.LoadScene("Simulation");
            Time.timeScale = 100;
        }
        catch (System.Exception ex)
        {
            print("Wystąpił błąd: " + ex.Message);
        }
    }
}
