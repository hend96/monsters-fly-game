using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour {


    public Collider coll;


    void Start()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.isKinematic = true;
        }

    }
}
