using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraNew : MonoBehaviour // this is the same as saying to implement in java not extended
{
    // Start is called before the first frame update
    public Transform target_player;

    public Vector3 offset; //store how far away we should be.
    public bool useOffSetValues;
    public float rotateSpeed;
    public Transform Pivot;

    public float maxViewAngle;
    public float minViewAngle;

    public bool invertY;
    void Start()
    {
        if (!useOffSetValues)
        {
            offset = target_player.position - transform.position;
        }
        Pivot.transform.position = target_player.transform.position;
        Pivot.transform.parent = target_player.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // get x positon and mouse and rotate to target

        float horizontal = Input.GetAxis("Mouse X")*rotateSpeed; // get x position for mouse.
        target_player.Rotate(0, -horizontal, 0);


        //get the y pos of mouse and rotate based on pivot.
        float verticle = Input.GetAxis("Mouse Y") * rotateSpeed;

        if (invertY)
        {
            Pivot.Rotate(verticle, 0, 0);
        }
        else
        {
            Pivot.Rotate(-verticle, 0, 0);
        }
       



        //Limit the up/down camera rotation
        if (Pivot.rotation.eulerAngles.x >maxViewAngle  && Pivot.rotation.eulerAngles.x<180f)
        {

            Pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);        
        
        }

        if (Pivot.rotation.eulerAngles.x > 180f && Pivot.rotation.eulerAngles.x < 360+minViewAngle) //=> 315 due to 360-45
        {
            Pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);


        }

        // move camera based on horizontal & offset
        float desiredXAngle = Pivot.eulerAngles.x;
        float desiredYAngle = target_player.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target_player.position - (rotation*offset);
        
        
        if (transform.position.y < target_player.position.y) {

            transform.position = new Vector3(transform.position.x,target_player.position.y - .5f ,transform.position.z);
        
        }
        //transform.position = target_player.position - offset;
        transform.LookAt(target_player);
    }
}
