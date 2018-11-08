using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    
    public Transform player;
    public Vector3 off; 
    public Camera cam;
    public float cam_zoom;
	// Use this for initialization
	void Start () {
		    //cam.orthographic = true;
       		
	}
	
	// Update is called once per frame
	void Update () {
		cam.orthographicSize = cam_zoom;
		transform.position = player.position + off;
	}
}
