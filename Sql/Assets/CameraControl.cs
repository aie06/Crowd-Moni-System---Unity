using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector2 bounds;
    public Vector2 zoomLimit;

    Vector3 pos;
    Vector3 startPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.transform.position;
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 dir = startPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos += dir;

            pos.x = Mathf.Clamp(pos.x, -bounds.x, bounds.x);
            pos.y = Mathf.Clamp(pos.y, -bounds.y, bounds.y);

            Camera.main.transform.position = pos;
        }

        Zoom(Input.GetAxis("Mouse ScrollWheel") * 2);

    }

    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize-increment, zoomLimit.x, zoomLimit.y);
    }
}
