using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour {

    public  float speed;
   

    int count1,wizard_index,count2;
    SpriteRenderer spriteR;
    Sprite[] wizard_imgs;
    Rigidbody2D rb;
    float d_height;
    GameObject wizard_fire;
    Vector3 dir;
    bool shooting;
    int shootCount;
    GameObject controller;

	// Use this for initialization
	void Start () {
		    count1 = 0;count2 = 1;wizard_index = 0;
        wizard_imgs = Resources.LoadAll<Sprite>("wizard");
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        wizard_fire = Resources.Load<GameObject>("prefabs/Wizard_Fire");
        rb.velocity = new Vector2(-speed,-speed);
        d_height = -33;
        shooting = false;
        controller = GameObject.Find("Controller");
	}
	

	void shoot()
	{
		shootCount = 0;
		shooting = true;
	}
	// Update is called once per frame
	void Update () {
		
      
       
      if(rb.velocity.y > 0 && transform.position.y >= d_height)
      {
      	rb.velocity = new Vector2(rb.velocity.x,-rb.velocity.y);
      	d_height = Random.value*25f + -33f;
      }
      if(rb.velocity.y < 0  && transform.position.y <= d_height)
      {
      	rb.velocity = new Vector2(rb.velocity.x,-rb.velocity.y);
      	d_height = Random.value*25f + -33f;
      }
      
      if(shooting)
      {
      	if(shootCount%10 == 0)
      	{
         dir = new Vector3(-10,0,0);
		     Instantiate(wizard_fire, transform.position + dir, Quaternion.identity);
         wizard_fire.GetComponent<WizardFire_Script>().vel = new Vector2(-50,0);
      	}
      	if(shootCount >= 99)
      	 shooting = false;
      }


      if(count1 == 0)
      {
        spriteR.sprite = wizard_imgs[wizard_index];
        wizard_index = (wizard_index+1)%6;
      }

      if(count2 == 0)
      {
      	
      	rb.velocity = new Vector2(speed, rb.velocity.y);
        speed *= -1;
      	shoot();
      }
      
      if(!controller.GetComponent<main>().paused)
      {
      count1 = (count1+1)%8;
      count2 = (count2+1)%200;
      shootCount = (shootCount+1)%100;
      }
      else
      {
        count1 = 1;
        count2 = 1;
        shootCount = 1;
      }

	}
}
