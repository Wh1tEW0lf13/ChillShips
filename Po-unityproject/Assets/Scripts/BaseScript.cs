using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public int level;
    public int iron;
    public int tytan;

    private void OnTriggerEnter2D(Collider2D ship)
    {
        if (ship.CompareTag(tag))
        {
            Object.Destroy(ship.gameObject);
        }
    }
}
