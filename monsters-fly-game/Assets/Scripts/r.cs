using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r : MonoBehaviour {



    public GameObject myMoney;
    public GameObject myPlane;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "plane")
        {
            // this.GetComponent<SphereCollider>().enabled = false;
            myMoney.SetActive(false);
            money.increase();
        }
    }

	
}
