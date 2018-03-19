using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour {

	// Use this for initialization
    public Transform[] naviPoint;
	void Start () {
        
        naviPoint = GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
