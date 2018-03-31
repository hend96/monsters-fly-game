using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class plane : MonoBehaviour {

    const int Left_mouse=0;
    private Vector3 yourPoint;

    Vector3 lBound = new Vector3(-70, 0, 0);
    Vector3 rBound = new Vector3(70, 0, 0);


    Vector3 right = new Vector3(1, 0, 0);
    Vector3 left = new Vector3(-1, 0, 0);

    bool makeChange = false;


	// Use this for initialization
	void Start () {
        yourPoint = transform.position;
        makeChange = false;
	}

    void CreateBubble(float x,float y,float z)
    {
        Vector3 v = new Vector3(x, y, z);
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/point.prefab", typeof(GameObject));
        GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;
        clone.AddComponent<Rigidbody>();
        makeChange = true;
      //  clone.transform.position = new Vector3(x, y, z);
    }

	// Update is called once per frame
	void Update () {

        //
        if (Input.GetKey("right") && transform.position.x < rBound.x)
        {
            transform.Translate(right*speed.value);
            
            CreateBubble(transform.position.x +10, transform.position.y-3, transform.position.z);
        }

        if (Input.GetKey("left") && transform.position.x > lBound.x)
        {
            transform.Translate(left*speed.value);
            CreateBubble(transform.position.x + 10, transform.position.y - 3, transform.position.z);
        }

        if (Input.GetKey("up"))
        {
            transform.Translate(0,-1*speed.value,0);
        }
         if (Input.GetKey("down"))
        {
            transform.Translate(0,1*speed.value,0);
        }
	}
	}
