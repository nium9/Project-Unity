using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollowKeepCenter: MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(Target);
    }
}
