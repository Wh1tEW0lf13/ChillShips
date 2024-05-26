using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipKiller : ShipScript
{
    [SerializeField] private GameObject followedShip;
    [SerializeField]private bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        SetBasePosition();
        shipSpeed = 10f;
        gameManager = world.GetComponent<GameManager>();
        SetFollowPosition();
        x = followPosition.x;
        y = followPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing){
            Follow();
        }
        else{
            Move();
        }
        
        if(followedShip == null){isFollowing = false;}
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Blue")){
                followedShip = collision.gameObject;
                isFollowing = true;
            }
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        print("destroy");
    }

/*    void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.GetComponent<CircleCollider2D>().GetType() == typeof(CircleCollider2D))
        {
             if(collision.gameObject.CompareTag("Blue")){
                followedShip = collision.gameObject;
                isFollowing = true;
            }
        }    
        
        else if (collision.GetComponent<BoxCollider2D>().GetType() == typeof(BoxCollider2D)){
            if(collision.gameObject.CompareTag("Blue")){
            print("destroy");
            isComingBack = true;
            isFollowing = false;
            }
        }
    }
    
*/
    void Follow(){
        transform.position = Vector2.MoveTowards(transform.position, followedShip.transform.position, shipSpeed * Time.deltaTime);
    }
}
