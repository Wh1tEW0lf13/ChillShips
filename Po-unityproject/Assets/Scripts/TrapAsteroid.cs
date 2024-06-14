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
            Destroy(collision.gameObject);
            ResetPosition();
            AudioSource.PlayClipAtPoint(boom, transform.position);
            gameManager.loseCheck(collision.tag);
            if(collision.CompareTag("Red"))
            {
                GameManager.asteroidKillCountRed++;
            }
            else
            {
                GameManager.asteroidKillCountBlue++;
            }
        }
        
    }
    private void ResetPosition()
    {
        transform.position = new Vector3(Random.Range(-xSpawn, xSpawn), Random.Range(-ySpawn, ySpawn));
    }
}
