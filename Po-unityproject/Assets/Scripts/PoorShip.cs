using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorShip : ShipScript
{
    // Start is called before the first frame update
    void Start()
    {
        SetBasePosition();
        gameManager = world.GetComponent<GameManager>();
        SetFollowPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("asteroid"))
        {
            Debug.Log("Pucia");
        }
    }
}
