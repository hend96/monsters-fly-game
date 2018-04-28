using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegPlane : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "cubeWall")
        {
            wall.WallMeshReder.Add(collision.gameObject);
        }
    }
}
