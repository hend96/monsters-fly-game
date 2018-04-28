using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour {

    public static int movespeed = speed.value;
    private Vector3 userDirection = Vector3.left;
    private Rigidbody rbody;

    public void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        transform.Translate(-userDirection * 2*speed.value * Time.deltaTime);
        transform.Rotate(Vector3.up, 40f * Time.deltaTime);
         /* float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal")
        //rbody.AddForceAtPosition(direction.normalized, transform.position);
        rbody.AddForce(6 * 2 * speed.value * Time.deltaTime,
        0f, 9 * 2 * speed.value * Time.deltaTime, transform.position);*/
      //  transform.Rotate(Vector3.up, 40f * Time.deltaTime);
        // transform.position += Vector3.forward * Time.deltaTime;

    }
}
