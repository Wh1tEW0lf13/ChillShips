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
    
    void Start()
    {
        BaseCreator();
        AsteroidCreator();
    }

    void BaseCreator()
    { 
        spin = new Quaternion(0,0,0,0);
        Instantiate(redBaseObject, Placement() , spin).name = "RedBase";
        Instantiate(blueBaseObject, Placement(), spin).name = "BlueBase";
    }
    void AsteroidCreator()
    {
        for(int i = 0; i < asteroidQuantity; i++)
        Instantiate(QuerryAstroid, Placement(), spin).name = "QuerryAsteroid" + i;
        for(int i = 0; i < asteroidQuantity/5; i++)
        Instantiate(TrapAsteroid, Placement(), spin).name = "TrapAsteroid" + i;
    }
    Vector3 Placement()
    {
        return new Vector3(Random.Range(-xSpawn, xSpawn), Random.Range(-ySpawn, ySpawn));
    }
}
