using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class ShipKiller : ShipScript
{
    [SerializeField] public GameObject followedShip;
    GameObject child;
    [SerializeField] public bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        SetBasePosition();
        shipSpeed = 10f;
        gameManager = world.GetComponent<GameManager>();
        SetFollowPosition();
        x = followPosition.x;
        y = followPosition.y;

        child = transform.GetChild(0).gameObject;
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

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Blue")){
                print("destroy");
                Destroy(collision.gameObject);
            }
    }
    
    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Blue")){
                print("detect");
                followPosition = collision.transform.position;
                followedShip = collision.gameObject;
                isFollowing = true;
            }
    }
    
  void OnTriggerEnter2D(Collider2D collision){
        
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

    public void Detect(){
        isFollowing = true;
    }
}
