using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Speed : MonoBehaviour {


    public static bool flag = false;
    public static float start = 10f;

    // Use this for initialization
    void Start()
    {

        C_Speed.flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (C_Speed.flag)
        {
            if ((int)C_Speed.start >= 0)
            {
                C_Speed.start -= Time.deltaTime;
            }

            if ((int)C_Speed.start < 0)
            {
                C_Speed.flag = false;
                speed.decrease();
                C_Speed.start = 10f;
            }
        }
    }

}
