using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed;
    public float scrollSpeed;
    private float startPanSpeed;
    private float startScroolSpeed;
    Vector3 pos;

    private void Start()
    {
        startPanSpeed = panSpeed;
        startScroolSpeed = scrollSpeed;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            panSpeed = 2f*startPanSpeed;
        }
        else
        {
            panSpeed = startPanSpeed;
            scrollSpeed = startScroolSpeed;
        }
        pos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.z += scroll * scrollSpeed * Time.deltaTime;
        transform.position = pos;

    }
}
