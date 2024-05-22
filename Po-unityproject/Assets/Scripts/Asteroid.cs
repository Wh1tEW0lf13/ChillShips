using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int ironCapacity = 0;
    public int tytanCapacity = 0;
    GameManager gameManager;
    public Transform world;
    void Start()
    {
        gameManager = world.GetComponent<GameManager>();
        if(ironCapacity+tytanCapacity<=0)
            ResetPosition();   
    }
    private void ResetPosition()
    {

        transform.position = new Vector3(Random.Range(-gameManager.xSpawn, gameManager.xSpawn),Random.Range(-gameManager.ySpawn,gameManager.ySpawn));
        AsteroidCapacity();
    }
    private void AsteroidCapacity()
    {
        switch (Random.Range(0, 2))
        {
            case <= 0:
                tytanCapacity = Random.Range(5, 21);
                break;
            case >= 1:
                ironCapacity = Random.Range(5, 21);
                break;
        }
    }
}
