using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class plane : MonoBehaviour {

    const int Left_mouse=0;
    private Vector3 yourPoint;

    Vector3 lBound = new Vector3(-20, 0, 0);
    Vector3 rBound = new Vector3(130, 0, 0);

    Vector3 downBound = new Vector3(0, 0, 40);
    Vector3 upBound = new Vector3(0, 0, 192);

    Vector3 right = new Vector3(1, 0, 0);
    Vector3 left = new Vector3(-1, 0, 0);

    bool makeChange = false;


	// Use this for initialization
	void Start () {
        yourPoint = transform.position;
       
	}

    void CreateBubble(float x,float y,float z)
    {
        Vector3 v = new Vector3(x, y, z);
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/point.prefab", typeof(GameObject));
        Instantiate(prefab, v, Quaternion.identity);
       //GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;
       // clone.AddComponent<Rigidbody>();
      
      //  clone.transform.position = new Vector3(x, y, z);
    }

	// Update is called once per frame
	void Update () {

        //
        if (Input.GetKey("right") && transform.position.x < rBound.x)
        {
            CreateBubble(transform.position.x , transform.position.y - 1.5f, transform.position.z);
            transform.Translate(right*speed.value);
           
        }

        if (Input.GetKey("left") && transform.position.x > lBound.x)
        {
            CreateBubble(transform.position.x , transform.position.y-1.5f, transform.position.z);
            transform.Translate(left*speed.value);
           
        }

        if (Input.GetKey("up") && transform.position.z<upBound.z)
        {
            CreateBubble(transform.position.x, transform.position.y-1.5f, transform.position.z );
            transform.Translate(0,-1*speed.value,0);
            
        }

        if (Input.GetKey("down") && transform.position.z > downBound.z)
        {
            CreateBubble(transform.position.x, transform.position.y - 1.5f, transform.position.z);
            transform.Translate(0,1*speed.value,0);
          
        }
	}
	}
