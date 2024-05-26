using System.Collections;
using System.Collections.Generic;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Blue")){
                print("detect");
                followedShip = collision.gameObject;
                isFollowing = true;
            }
    }
}

