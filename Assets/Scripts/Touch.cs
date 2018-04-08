using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    public GameObject myHeart;
    public GameObject myPlane;

   /* public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "plane")
        {
            //Destroy(this.gameObject);
            myHeart.SetActive(false);
        }
    }
    */

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "plane")
        {
            // this.GetComponent<SphereCollider>().enabled = false;
            myHeart.SetActive(false);
            heart.increase();
        }
    }
}
