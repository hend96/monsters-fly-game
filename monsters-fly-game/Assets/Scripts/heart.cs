using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour {

    static public int value = 3 ;

   public GameObject plane;
    public GameObject myHeart;

    static public void increase()
    {
        value++;
    }
    static public void decrease()
    {
        value--;
    }

	// Use this for initialization
	void Start () {
       // plane = GameObject.FindWithTag("plane");
       // hearts = GameObject.FindGameObjectsWithTag("heart");
	}

   
	// Update is called once per frame
	void Update () {
       
        
            if (plane.transform.position.z == transform.position.x
                || plane.transform.position.z == transform.position.y
                || plane.transform.position.z == transform.position.z
               || plane.transform.position.x == transform.position.x
                || plane.transform.position.x == transform.position.y
                || plane.transform.position.x == transform.position.z
                 || plane.transform.position.y == transform.position.x
                || plane.transform.position.y == transform.position.y
                || plane.transform.position.y == transform.position.z
                )
            {
                plane.transform.position = new Vector3(200,0,0);
                heart.increase();
                Destroy(this);
            }
        }
	}

