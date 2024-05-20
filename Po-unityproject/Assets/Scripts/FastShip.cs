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
        //UPDATE: zmieniłem inspektorze, ale ostatecznie jakos przy spalnie sie to bedzie pewnie ustawiac
        // a tego troche nie kumam xDD

        setBasePosition();

        FindNearestAsteroid();
        followPosition = nearestAsteroid;
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
    }

    void FindNearestAsteroid(){
        //Póki co działa na kady obiekt z tagiem, potem mozna to zmienic na wynajdywanie obiektow, albo tworzyc asteroidy juz z tagiem
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

