using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleToWalk : MonoBehaviour
{

  public Animator animator;
  public float InputZ;
  public float InputX;
    // Start is called before the first frame update
    void Start()
    {
      //get the Animator
      animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
	InputZ= Input.GetAxis("Vertical");
    animator.SetFloat("InputZ",InputZ);
    }
}
