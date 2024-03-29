using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public float CamSpeed = 30f;
    public float ScrollSpeed = 5f;
    public float BoundaryOffSet = 10f;
    public float MinY = 10f;
    public float MaxY = 80f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }



        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - BoundaryOffSet)
        {
            transform.Translate(Vector3.forward * CamSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= BoundaryOffSet)
        {
            transform.Translate(-Vector3.forward * CamSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.height - BoundaryOffSet)
        {
            transform.Translate(Vector3.right * CamSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= BoundaryOffSet)
        {
            transform.Translate(Vector3.left * CamSpeed * Time.deltaTime, Space.World);
        }

        float scroll =  Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * ScrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, MinY, MaxY);

        transform.position = pos;
    }
}
