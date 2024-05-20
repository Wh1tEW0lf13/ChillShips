using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShip : ShipScript
{
    private Vector2 nearestAsteroid;
    public GameObject[] AllAsteroids;
    float distance;
    float nearestDistance = 10000;
    
    // Start is called before the first frame update
    void Start()
    {
        //shipSpeed - chcaiłbym tu zmienić wartość speed, ale w kalsie nadrzednej: [SerializeField] private float shipSpeed=3f;
        FindNearestAsteroid();
        followPosition = nearestAsteroid;
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
    }

    void FindNearestAsteroid(){
        AllAsteroids = GameObject.FindGameObjectsWithTag("asteroid");

        for(int i = 0; i < AllAsteroids.Length; i++){
            distance = Vector2.Distance(this.transform.position, AllAsteroids[i].transform.position);

            if(distance < nearestDistance){
                nearestAsteroid = AllAsteroids[i].transform.position;
                nearestDistance = distance;
            }
        }
    }
}

