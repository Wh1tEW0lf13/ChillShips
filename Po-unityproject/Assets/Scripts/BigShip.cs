using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigShip : PoorShip
{
    private new float miningTime = 2f;
    void Start()
    {
        Prepare();
    }

    void Update()
    {
        Move();
        if (isMining&&!isComingBack)
            IsMining();
    }

    /*
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("asteroid"))
        {
            asteroid = col.GetComponent<Asteroid>();
            if (!isComingBack && !asteroid.isMining)
            {
                followPosition = col.transform.position;
                Vector2.MoveTowards(transform.position, followPosition, shipSpeed * Time.deltaTime);
                isMining = true;
                asteroid.isMining = true;
            }
        }
        if(!col.CompareTag(gameObject.tag) && col.gameObject.layer == 6)
        {
            ShipDestroyer(col.gameObject);
        }
    }
    */

    //polimorfyzm względem bazowej funkcji
    public new void IsMining()
    {
        
        //sprawdza czy jest w stanie zmieścić wszystkie surowce na raz
        //jezeli tak, pobiera je wszystkie
        if(asteroid.ironCapacity + asteroid.tytanCapacity <= Capacity - ironCapacity - tytanCapacity)
        {
            ironCapacity += asteroid.ironCapacity;
            tytanCapacity += asteroid.tytanCapacity;
            asteroid.ironCapacity = 0;
            asteroid.tytanCapacity = 0; 
            
            asteroid.isMining = false;
            isComingBack = true;
            isMining = false;
        }
        else{


            miningTime -= Time.deltaTime;
            if (Capacity <= ironCapacity + tytanCapacity || asteroid.isEmpty)
            {
                isComingBack = true;
                asteroid.isMining = false;
                isMining = false;
            } 
            if(asteroid.tytanCapacity>0&&miningTime<0)
            {
                tytanCapacity++;
                asteroid.tytanCapacity--;
                miningTime = 1f;
            }
            else if (asteroid.ironCapacity > 0 && miningTime < 0)
            {
                ironCapacity++;
                asteroid.ironCapacity--;
                miningTime = 1f;
            }
        }

    }

}
