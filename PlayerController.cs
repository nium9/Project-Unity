using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;

    private Vector3 moveDirection;


    public Animator anim;

    public Transform pivot; //  alright so basically we where using this as the pivot which would cause huge issues now we are setting the pivot manually it will look better ie roattion
    public float rotateSpeed;

    public GameObject PlayerModel;
    // Start is called before the first frame update
    void Start()
    {
        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {


        /* old
        theRB.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed, theRB.velocity.y ,Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetButtonDown("Jump")) // ie if space button is clicked
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        }
        */

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
         
        float yStore = moveDirection.y;
        moveDirection = (transform.forward*Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal")); // ie change position facing.
        moveDirection = moveDirection.normalized *  moveSpeed;
        moveDirection.y = yStore;
        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);


            if (Input.GetButtonDown("Jump")) // ie if space button is clicked
            {
                moveDirection.y = jumpForce;

            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale); // dont need time.deltatime due to gravityScale
        controller.Move(moveDirection * Time.deltaTime);// the reason for time .deltatime is show it doesnt do the movement every frame if it does it like that then it becomes sparactic


        // Move the player in different direction based on look direction ie 360` degree movement
        if (Input.GetAxis("Horizontal")!= 0 || (Input.GetAxis("Vertical")!=0)) // when the x and y is not stationary 
        {
            transform.rotation = Quaternion.Euler(0f,pivot.rotation.eulerAngles.y,0f);    // move the character rotation based on the y pos
            Quaternion newRotation = Quaternion.LookRotation(new Vector3 (moveDirection.x,0,moveDirection.z));// to help not to snap position.
            PlayerModel.transform.rotation = Quaternion.Slerp(PlayerModel.transform.rotation,newRotation,rotateSpeed * Time.deltaTime); // slerp is fast snap rotation - ie interplation but based on arc
        }
        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical"))  + Mathf.Abs(Input.GetAxis("Horizontal")))  );
    
    
    }
}
