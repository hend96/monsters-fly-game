using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {


    public static int movespeed = speed.value;

    private Vector3 userDirection = Vector3.right;

    private Rigidbody rbody;

    public void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }


    public void Update()
    {
        transform.Translate(-userDirection * 2 * speed.value * Time.deltaTime);
        transform.Rotate(Vector3.up, 40f * Time.deltaTime);
        // transform.position += Vector3.forward * Time.deltaTime;

    }
}
