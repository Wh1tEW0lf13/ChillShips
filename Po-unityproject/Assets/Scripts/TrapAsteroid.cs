using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAsteroid : MonoBehaviour
{
    GameManager gameManager;
    public AudioClip boom;
    private GameObject world;
    int xSpawn, ySpawn;

    private void Start()
    {
        world = GameObject.Find("World");
        gameManager = world.GetComponent<GameManager>();
        xSpawn = gameManager.xSpawn;
        ySpawn = gameManager.ySpawn;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==0)
            ResetPosition();
        else
        {
            DestroyShip(collision.gameObject);
        }
        
    }
    private void ResetPosition()
    {
        transform.position = new Vector3(Random.Range(-xSpawn, xSpawn), Random.Range(-ySpawn, ySpawn));
    }
    private void DestroyShip(GameObject shipInfo)
    {
        Destroy(shipInfo.gameObject);
        gameManager.loseCheck(shipInfo.gameObject.tag);
        ResetPosition();
        AudioSource.PlayClipAtPoint(boom, transform.position);
        gameManager.loseCheck(shipInfo.tag);
        if (shipInfo.CompareTag("Red"))
        {
            GameManager.asteroidKillCountRed++;
        }
        else
        {
            GameManager.asteroidKillCountBlue++;
        }
    }
}
