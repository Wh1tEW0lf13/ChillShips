using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    GameObject basePos;
    [SerializeField] private GameObject target;
    [SerializeField] private float shipSpeed=3f;

    private void Start()
    {
        basePos = GameObject.Find("RedBase");
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, basePos.transform.position, shipSpeed*Time.deltaTime);

        Vector3 Look = transform.InverseTransformDirection(target.transform.position);
        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg-90;

        transform.Rotate(0, 0, Angle);
    }


}
