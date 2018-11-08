using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Script : MonoBehaviour {

  

    Sprite[] fire_imgs;
    int fire_index;
    SpriteRenderer spriteR;
    int count1;
    Rigidbody2D rb;
    GameObject exp;
    GameObject controller;

	// Use this for initialization
	void Start () {
		fire_imgs = Resources.LoadAll<Sprite>("Fireball");
		spriteR = gameObject.GetComponent<SpriteRenderer>() ;
		count1 = 0; fire_index = 0;
		exp = Resources.Load<GameObject>("prefabs/explosion");
		rb = GetComponent<Rigidbody2D>();
		controller = GameObject.Find("Controller");
	}
	
	void reset()
	{
		Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D collider_info)
	{
		Debug.Log(collider_info.gameObject.name);
		string s = collider_info.gameObject.name;
		if(s != "Player" && s!= "FireBall(Clone)")
		{
		  Instantiate(exp, transform.position, Quaternion.identity);
		  Destroy(gameObject);
	    }
	}

	// Update is called once per frame
	void Update () {
        
		rb.velocity = new Vector2(30,0);
		if(count1 == 0)
		{
            spriteR.sprite = fire_imgs[fire_index];
            fire_index = (fire_index+1)%23;
            if(fire_index == 22)
             reset();
		}
		if(!controller.GetComponent<main>().paused)
		count1 = (count1+1)%4;
		else
		count1 = 1;
	}
}
