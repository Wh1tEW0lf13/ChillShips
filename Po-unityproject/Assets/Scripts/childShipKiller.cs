using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class childShipKiller : ShipKiller
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Blue")){
                print("destroy");
                Destroy(collision.gameObject);
            }
    }
    */
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Blue")){
                print("detect");
                transform.parent.GetComponent<ShipKiller>().followedShip = collision.gameObject;
                transform.parent.GetComponent<ShipKiller>().isFollowing = true;
            }
    }
    
}

