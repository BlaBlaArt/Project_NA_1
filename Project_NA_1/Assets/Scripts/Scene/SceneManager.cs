using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public float SpeedRotation = 1;

    Vector2 mousPos;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            float mousePosition_x = Input.mousePosition.x;
            transform.Rotate(new Vector3(0, 0, mousPos.x - mousePosition_x) * SpeedRotation * Time.deltaTime);
        }
    }
}
