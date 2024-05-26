using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorShip : ShipScript
{
    public Asteroid asteroid;
    [SerializeField] private float miningTime = 1f;
    [SerializeField] private bool isMining;
    void Start()
    {
        SetBasePosition();
        gameManager = world.GetComponent<GameManager>();
        SetFollowPosition();
        x = followPosition.x;
        y = followPosition.y;
    }

    // Update is called once per frame
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
    }
    public void IsMining()
    {
        miningTime -= Time.deltaTime;
        if (Capacity <= ironCapacity + tytanCapacity || asteroid.isEmpty)
        {
            isComingBack = true;
            asteroid.isMining = false;
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
