using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFire_Script : MonoBehaviour {
      
    public Vector2 vel;

    Sprite[] wizard_fire_imgs;
    SpriteRenderer spriteR;
    Rigidbody2D rb;
    int count1,wizard_fire_index;
    GameObject controller;

	// Use this for initialization
	void Start () {
		wizard_fire_imgs = Resources.LoadAll<Sprite>("wizard_attack");
		spriteR = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        wizard_fire_index = 0; count1 = 0;
        controller = GameObject.Find("Controller");
	}
	
	void OnCollisionEnter2D(Collision2D collider_info)
	{
		string s = collider_info.gameObject.name;
		int l = s.Length;
		if(s != "Player")
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		   
       rb.velocity = vel;
       if(count1 == 0)
       {
       	 spriteR.sprite = wizard_fire_imgs[wizard_fire_index];
       	 wizard_fire_index = (wizard_fire_index+1)%4;
       }

       if(!controller.GetComponent<main>().paused)
       count1 = (count1+1)%5;
       else 
       count1 = 1;

	}
}
