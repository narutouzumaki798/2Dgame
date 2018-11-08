
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float speed;
    public GameObject over;

    Sprite[] walk_imgs,attack_imgs,idle_imgs,jump_attack_imgs;
    BoxCollider2D[] box;
    Sprite jump_img,down_img; 
    SpriteRenderer spriteR;
    int walk_index;
    int attack_index;
    int idle_index;
    int count1;
    int count2;
    bool walking;
    bool attacking;
    bool idle;
    bool onGround;
    bool down;
    bool attack_allowed;
    AudioSource attack_sound;
    Vector2 zero;
    GameObject controller;

	// Use this for initialization
	void Start () {
		walk_imgs = Resources.LoadAll<Sprite>("walk");
        jump_img = Resources.Load<Sprite>("sprite_4");
        down_img = Resources.Load<Sprite>("down_1");
        jump_attack_imgs = Resources.LoadAll<Sprite>("jump_attack");
        attack_imgs = Resources.LoadAll<Sprite>("attack");
        idle_imgs = Resources.LoadAll<Sprite>("idle");
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        box = GetComponents<BoxCollider2D>();
        zero = new Vector2(0,0);
        walk_index = 0;
        count1 = 0;
        count2 = 0;
        idle = true;
        walking = false;
        onGround = true;
        attack_allowed = true;
        down = false;
        attack_sound = GetComponent<AudioSource>();
        controller = GameObject.Find("Controller");
	}
	
	
    void OnCollisionEnter2D(Collision2D collider_info)
    {
        string s = collider_info.gameObject.name;
        int l = s.Length;
        if( l>=8 && s.Substring(0,8) == "platform" )
        {
         //Debug.Log("coll - ground");
         walking = true;
         onGround = true;
        } 
        if(l>=11 && s.Substring(0,11) == "Wizard_Fire")
        {
        	Time.timeScale = 0;
        	controller.GetComponent<main>().paused = true;
        	over.SetActive(true);
        }
    }

    void nearGround()
    {
    	  //Debug.Log("grounded");
          walking = true;

    }
    
    void reset()
    {
       attack_allowed = true;  attacking = false;
       if(onGround) idle = true;
    }

    void rest()
    {
       walking = true;
    }

	// Update is called once per frame
	void Update () {
       
		    float tempx = rb.velocity.x;
         	float tempy = rb.velocity.y;
            rb.velocity = new Vector2(0,tempy);
            Vector2 down_dir = new Vector2(0,-1);

            if(Physics2D.Raycast(transform.position, down_dir, 24) && rb.velocity.y < 0)
               nearGround();
         
		 if(Input.GetKey("left")  && (!attacking || !onGround) && !down)
         {
            rb.velocity = new Vector2(-speed,tempy);
            //attacking = false;
            idle = false; 
            if(onGround) walking = true;
         }
        
         if(Input.GetKey("right")  && (!attacking || !onGround) && !down)
         {
            rb.velocity = new Vector2(speed,tempy);
            //attacking = false;
            idle = false; 
            if(onGround) walking = true;
         }

         if(Input.GetKeyDown("left") || Input.GetKeyDown("right"))
            count1 = 0;

         if(Input.GetKey("up") && onGround && !attacking)
         {
            rb.velocity = new Vector2(tempx,90);
            spriteR.sprite = jump_img;
            walking = false; onGround = false; idle = false;
         }
         
         if(Input.GetKey("down") && onGround && !attacking)
         {
           box[0].enabled = false;
           spriteR.sprite = down_img; down = true;
           walking = false; idle = false;
         }
         if(Input.GetKeyUp("down"))
         {  down = false;
            box[0].enabled = true;
         }

         if(Input.GetKeyDown("x") && attack_allowed && !down)
         {
             attacking = true;
             attack_index = -1;
             walking = false; attack_allowed = false; idle = false;
             
         }

         if(rb.velocity == zero && !attacking && onGround && !down)
         {
              idle = true; walking = false;
         }


         if(count1 == 0)
         {
            if(walking)
            {
            spriteR.sprite = walk_imgs[walk_index];
            walk_index = (walk_index+1)%4;
            }
    

            if(idle)
            {
            spriteR.sprite = idle_imgs[idle_index];
            idle_index = (idle_index+1)%3;
            }
        }

        if(count2 == 0)
        {
            if(attacking)
            {
                attack_index = (attack_index+1)%5;
                if(onGround)
                spriteR.sprite = attack_imgs[attack_index];
                else
                spriteR.sprite = jump_attack_imgs[attack_index];
                if(attack_index == 0)
                {
                    attack_sound.Play();
                    GetComponent<ProjectileShooter>().Shoot();
                }
                if(attack_index == 1)
                {
                    reset();
                }

            }
        }
          
         // Debug.Log(onGround);
         
         if(!controller.GetComponent<main>().paused)
         { count1 = (count1+1)%15;
           count2 = (count2+1)%5;
         }
         else
         {
         	count1 = 1; count2 = 1;
         } 
   
    }
}