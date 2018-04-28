using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBall : MonoBehaviour {

    public static int movespeed = 7*speed.value;
    private Vector3 userDirection = Vector3.left;
    public void Start()
    {
    }
    public void Update()
    {
        movespeed = 7 * speed.value;
        transform.Translate(userDirection * movespeed * Time.deltaTime);
        transform.Rotate(Vector3.up, 40f * Time.deltaTime);
        // transform.position += Vector3.forward * Time.deltaTime;

    }
}
