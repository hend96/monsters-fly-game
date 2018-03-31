using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.name == "plane")
        {
            Destroy(this.gameObject);
        }
    }

}
