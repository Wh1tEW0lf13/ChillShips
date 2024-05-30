using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShip : PoorShip
{
    private Vector2 nearestAsteroid;
    public GameObject[] AllAsteroids;
    float distance;
    float nearestDistance = 10000;
    
    // Start is called before the first frame update
    void Start()
    {
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

    void FindNearestAsteroid(){
        //Póki co działa na kady obiekt z tagiem, potem mozna to zmienic na wynajdywanie obiektow, albo tworzyc asteroidy juz z tagiem
        AllAsteroids = GameObject.FindGameObjectsWithTag("asteroid");

        for(int i = 0; i < AllAsteroids.Length; i++){
            //sprawdza czy wybrana asteroida jest zajęta
            if(!AllAsteroids[i].gameObject.GetComponent<Asteroid>().isMining)
                distance = Vector2.Distance(this.transform.position, AllAsteroids[i].transform.position);

                if(distance < nearestDistance){
                    nearestAsteroid = AllAsteroids[i].transform.position;
                    nearestDistance = distance;
            }
        }
        //daje zachowanie (przynajmiej auto powrot do bazy), gdy wszystkie asteroidy byly by zajete
        if(nearestAsteroid == null){isComingBack = true;}
    }

    //przeniesione z poor ship z wyłączeniem lotu do asteroidy (Fast ship i tak sobie poradzi) bez tego nie zaczyna wydobywać
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
    }
}

