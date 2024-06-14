using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorShip : ShipScript
{
    public Asteroid asteroid;
    protected float miningTime = 1f;
    public bool isMining;
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
        if(!col.CompareTag(gameObject.tag) && col.gameObject.layer == 6 && !col.gameObject.GetComponent<PoorShip>().isMining)
        {
            ShipDestroyer(col.gameObject);
        }
        
    }


    public void IsMining()
    {
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
