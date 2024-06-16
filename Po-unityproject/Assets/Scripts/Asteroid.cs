using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int ironCapacity = 0;
    public int tytanCapacity = 0;
    public bool isEmpty;
    public bool isMining = false;
    private float timeToMove = 2f;
    GameManager gameManager;
    private int xSpawn, ySpawn;
    private GameObject world;
    void Start()
    {
        world = GameObject.Find("World");
        gameManager = world.GetComponent<GameManager>();    //Odow³anie siê do œwiata po to by mieæ dostêp do wielkoœci œwiata, by móc losowaæ swoj¹ pozycjê
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
    private void ResetPosition()    //Ustawia now¹ pozycjê
    {
        timeToMove = 5f;    //Jest to po to, ¿e jak siê zrespi na innym obiekcie, ma czas na zmianê pozycji
        transform.position = new Vector3(Random.Range(-xSpawn, xSpawn), Random.Range(-ySpawn, ySpawn)); //losowanie gdzie ma siê pojawiæ
        AsteroidCapacity();
    }
    private void AsteroidCapacity() // losuje jakie materia³y ma mieæ w sobie
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
