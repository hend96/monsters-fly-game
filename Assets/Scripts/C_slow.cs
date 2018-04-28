using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_slow : MonoBehaviour {

    public static bool flag = false;
    public static float start = 10f;

	// Use this for initialization
	void Start () {

        C_slow.flag = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (C_slow.flag)
        {
            if ((int)C_slow.start >= 0)
            {
                C_slow.start -= Time.deltaTime;
            }

            if ((int)C_slow.start < 0)
            {
                C_slow.flag = false;
                speed.increase();
                C_slow.start =10f;
            }
        }
    }

}
