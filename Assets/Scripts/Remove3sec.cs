using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove3sec : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("remove",5f);
	}
	
	void remove(){
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
