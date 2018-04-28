using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RandomColor : MonoBehaviour {

    public List<Color> TintColors;
	void Start () {
        if(TintColors.Count > 0)
        {
            Color c = TintColors[UnityEngine.Random.Range(0, TintColors.Count)];
      
            GetComponent<Renderer>().material.color = c;
        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
