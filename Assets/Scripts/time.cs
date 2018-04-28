using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class time : MonoBehaviour {

    static public float value = 60f;
    public AudioSource source;
    public Text timeText;
    public Text heartText;
    public GameObject myPlane;
    
	// Use this for initialization
	void Start () {
		
	}

    public static  void increase()
    {
        //int val = (int)value;
        time.value = 60f;
    }

	// Update is called once per frame
	void Update () {

        if (value > 0)
        {
            value -= Time.deltaTime;
            timeText.text = (int)value + "";

            if (timeText.text=="14")
            {
                source.Play();
            }
            
        }
        if (value <= 0)
        {
            heart.decrease();
            value= 60f;
            timeText.text = time.value + "";
            heartText.text = heart.value + "";

            Vector3 v = new Vector3(myPlane.transform.position.x, myPlane.transform.position.y + 20, myPlane.transform.position.z);

            Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/timeOut.prefab", typeof(GameObject));

            GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;
            /*
            Vector3 temp = plane.defaultVector;
            myPlane.transform.position = temp;
             */
        }

	}
}
