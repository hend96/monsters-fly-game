using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour {

    static public float value = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (value > 0)
        {
            value -= Time.deltaTime;
            if (value <= 0)
            {
              //  destroy();
            }
        }
	}
}
