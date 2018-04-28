using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour {

    private GameObject wayPoint;

    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("plane");
    }
    void OnTriggerEnter(Collider other)
    {
        // Destroy(other.gameObject);
        Debug.Log("Building111");
        // Instantiate(expl, transform.position, transform.rotation);
        if (other.gameObject.CompareTag("monster"))
        {
            Debug.Log("Building");
            //Destroy(other.gameObject);
            //other.gameObject.transform.Rotate(new Vector3(100, 10, 10) * Time.deltaTime);
            //  other.gameObject.transform.Translate(new Vector3(0, 0, 0) + transform.position);
            //Instantiate(player, other.transform.position, other.transform.rotation);

            Destroy(other.gameObject);
            Destroy(this);
        }

    }
}
