using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEngine.UI;

public class finish : MonoBehaviour {

    public AudioSource sourceFire;
    public AudioSource congratulation;

	// Use this for initialization
	void Start () {
        Vector3 v = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);

        UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Perfabs/fireWork.prefab", typeof(GameObject));

        GameObject clone = Instantiate(prefab, v, Quaternion.identity) as GameObject;

        Instantiate(prefab, new Vector3(transform.position.x - 30, transform.position.y - 30, transform.position.z), Quaternion.identity) ;
        Instantiate(prefab, new Vector3(transform.position.x + 30, transform.position.y - 30, transform.position.z), Quaternion.identity) ;
        Instantiate(prefab, new Vector3(transform.position.x -30, transform.position.y+ 30, transform.position.z), Quaternion.identity);
        Instantiate(prefab, new Vector3(transform.position.x + 30, transform.position.y + 30, transform.position.z), Quaternion.identity);

        Instantiate(prefab, new Vector3(transform.position.x, transform.position.y - 30, transform.position.z - 30), Quaternion.identity);
        Instantiate(prefab, new Vector3(transform.position.x, transform.position.y - 30, transform.position.z + 30), Quaternion.identity);
        Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 30, transform.position.z - 30), Quaternion.identity);
        Instantiate(prefab, new Vector3(transform.position.x , transform.position.y + 30, transform.position.z+ 30), Quaternion.identity);
        
        
        clone.SetActive(true);
        this.sourceFire.Play();
        congratulation.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            Application.LoadLevel("menu");

        }
	}
}
