using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int ironCapacity;
    public int tytanCapacity;
    void Start()
    {
        switch(Random.Range(0,1))
            {
            case <= 0:
                tytanCapacity = Random.Range(5, 21);
                break;
            case >= 1:
                ironCapacity = Random.Range(5, 21);
                break;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
