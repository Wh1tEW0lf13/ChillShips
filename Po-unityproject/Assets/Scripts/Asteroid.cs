using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int ironCapacity = 0;
    public int tytanCapacity = 0;
    public bool isEmpty;
    public bool isMining = false;
    private float timeToMove;
    GameManager gameManager;
    private int xSpawn, ySpawn;
    private GameObject world;
    void Start()
    {
        world = GameObject.Find("World");
        gameManager = world.GetComponent<GameManager>();
        xSpawn = gameManager.xSpawn;
        ySpawn = gameManager.ySpawn;
        AsteroidCapacity();
    }
    private void Update()
    {
        timeToMove -= Time.deltaTime;
        if (tytanCapacity + ironCapacity <= 0)
        {
            isEmpty = true;
            ResetPosition();
        }
        else
            isEmpty = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(timeToMove > 0)
        { 
            ResetPosition(); 
        }
    }
    private void ResetPosition()
    {
        timeToMove = 5f;
        transform.position = new Vector3(Random.Range(-xSpawn, xSpawn), Random.Range(-ySpawn, ySpawn));
        AsteroidCapacity();
    }
    private void AsteroidCapacity()
    {
        tytanCapacity = ironCapacity = 0;
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
