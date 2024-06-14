using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FastShip : PoorShip
{
    private Vector2 nearestAsteroid;
    private GameObject[] AllAsteroids;
    private float distance;
    private float nearestDistance = 1000000000;
    
    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("World");
        SetBasePosition();
        gameManager = world.GetComponent<GameManager>();
        FindNearestAsteroid();
        followPosition = nearestAsteroid;
        x = followPosition.x;
        y = followPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMining&&!isComingBack)
            IsMining();
        if(!isMining)
            Move();
    }

    private void FindNearestAsteroid(){
        //Póki co działa na kady obiekt z tagiem, potem mozna to zmienic na wynajdywanie obiektow, albo tworzyc asteroidy juz z tagiem
        AllAsteroids = GameObject.FindGameObjectsWithTag("asteroid");

        for(int i = 0; i < AllAsteroids.Length; i++){
            //sprawdza czy wybrana asteroida jest zajęta
            if(!AllAsteroids[i].gameObject.GetComponent<Asteroid>().isMining)
                distance = Vector2.Distance(this.transform.position, AllAsteroids[i].transform.position);
                //znajdowanie najblizszej
                if(distance < nearestDistance){
                    nearestAsteroid = AllAsteroids[i].transform.position;
                    nearestDistance = distance;
            }
        }
        //daje zachowanie (przynajmiej auto powrot do bazy), gdy wszystkie asteroidy byly by zajete
        if(nearestAsteroid == null){isComingBack = true;}
    }


    /*
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("asteroid"))
        {
            asteroid = col.GetComponent<Asteroid>();
            if (!isComingBack && !asteroid.isMining)
            {
                print("ast");
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
}

