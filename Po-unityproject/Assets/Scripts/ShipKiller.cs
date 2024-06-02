using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipKiller : ShipScript
{

    public string enemyTag;
    [SerializeField] public GameObject followedShip;
    [SerializeField] public bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("World");
        SetBasePosition();
        shipSpeed = 10f;
        gameManager = world.GetComponent<GameManager>();
        SetFollowPosition();
        x = followPosition.x;
        y = followPosition.y;

        //ustawienie poszukiwanego tagu na przeciwnika
        if(gameObject.tag == "Red"){enemyTag = "Blue";}
        else{enemyTag = "Red";}
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing && followedShip != null){
            Follow();
        }
        else{
            Move();
        }
        
    }

    //colider podstawowy - wielkosci sprita - sluzy do niszeczenia i bycia niszczonym
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag(enemyTag)){
                print("destroy");
                //warunek póki co nie pozwala zacząć przyjmowania surowców ponad górny limit, ale nie wyklucza ze zebrae za jedym podejsciem przekrocza ten limit
                if(ironCapacity + tytanCapacity < Capacity){
                    ironCapacity += collision.gameObject.GetComponent<ShipScript>().ironCapacity;
                    tytanCapacity += collision.gameObject.GetComponent<ShipScript>().tytanCapacity;
                }
                Destroy(collision.gameObject);
            }
    }

    void Follow(){
        transform.position = Vector2.MoveTowards(transform.position, followedShip.transform.position, shipSpeed * Time.deltaTime);
    }
}
