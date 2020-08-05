using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;

    private Vector3 moveDirection;

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
       

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal")); // ie change position facing.
        moveDirection = moveDirection.normalized * moveSpeed;
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
     */

    }

}
