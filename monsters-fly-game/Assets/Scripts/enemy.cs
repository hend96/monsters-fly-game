using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour {

    // Use this for initialization
    public Transform start;
    public Transform target;
    private NavMeshAgent nav;
    


	void Start () {
        target = GameObject.FindGameObjectWithTag("plane").transform;
        nav = this.gameObject.GetComponent<NavMeshAgent>();
       
        
       
	
        
    }
	
	// Update is called once per frame
	void Update () {
        float dis = Vector3.Distance(target.position, transform.position);
       // Debug.Log(dis);
       

        if (target)
        {
            nav.SetDestination(target.transform.position);

        }
       


		
	}
}
