using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toturial : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A))
        {
            Destroy(gameObject);
        }
    }
}
