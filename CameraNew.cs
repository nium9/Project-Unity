using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNew : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target_player;

    public Vector3 offset; //store how far away we should be.

    public bool useOffSetValues;

    public float rotateSpeed;

    void Start()
    {
        if (!useOffSetValues)
        {
            offset = target_player.position - transform.position;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // get x positon and mouse and rotate to target

        float horizontal = Input.GetAxis("Mouse X")*rotateSpeed; // get x position for mouse.
        target_player.Rotate(0, -horizontal, 0);

        float verticle = Input.GetAxis("Mouse Y") * rotateSpeed;
        target_player.Rotate(-verticle, 0, 0);

        // move camera based on horizontal & offset
        float desiredXAngle = target_player.eulerAngles.x;
        float desiredYAngle = target_player.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target_player.position - (rotation*offset); 

        //transform.position = target_player.position - offset;
        transform.LookAt(target_player);
    }
}
