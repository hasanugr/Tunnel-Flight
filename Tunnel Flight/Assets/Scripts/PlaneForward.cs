using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneForward : MonoBehaviour
{
    public float forceMult = 2000;
    private Rigidbody rb;
    private float normalSpeed;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Time.deltaTime * forceMult;
        normalSpeed = rb.velocity.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity.z + " < " + normalSpeed);
        if (rb.velocity.z < normalSpeed)
        {
            //Debug.Log("Fixed.!!!");
            rb.velocity = transform.forward * Time.deltaTime * forceMult;
        }
    }

}
