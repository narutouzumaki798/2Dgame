using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    GameObject fireball;
	// Use this for initialization
	void Start () {
		fireball = Resources.Load<GameObject>("prefabs/FireBall");
	}
	
	public void Shoot(){
        Instantiate(fireball, transform.position + (new Vector3(10,2,0)),Quaternion.identity);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
