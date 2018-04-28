using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move3 : MonoBehaviour
{

    public static int movespeed = speed.value;
    private Vector3 userDirection = Vector3.right;

    private Rigidbody rbody;

    public float thrust=5;
    public Rigidbody rb;

   /* public void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rbody.AddForce(transform.forward * thrust);
    }*/
    public void Update()
    {
        transform.Translate(-userDirection * 2 * speed.value * Time.deltaTime);
        transform.Rotate(Vector3.up, 40f * Time.deltaTime);
        // transform.position += Vector3.forward * Time.deltaTime;

    }
    /*
    void ApplyForce(Rigidbody body)
    {
        Vector3 direction = body.transform.position - transform.position;
        body.AddForceAtPosition(direction.normalized, transform.position);
    }
    void onMouseDown()
    {
        rbody.AddForce(-transform.forward * 500);
    }
    public void Update()
    {
     //  transform.Translate(userDirection * 2*speed.value * Time.deltaTime);
       // transform.Rotate(Vector3.up, 40f * Time.deltaTime);
        
        transform.Rotate(Vector3.up, 40f * Time.deltaTime);


        // transform.position += Vector3.forward * Time.deltaTime;

    }*/
}
