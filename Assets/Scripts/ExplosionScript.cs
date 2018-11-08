using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {
 
    Sprite[] exp_imgs;
    SpriteRenderer spriteR;
    int exp_index;
    int count1;
	// Use this for initialization
	void Start () {
		exp_imgs = Resources.LoadAll<Sprite>("explosion");
		count1 = 0;
		spriteR = GetComponent<SpriteRenderer>();
		exp_index = 0;
	}
	
	void remove()
	{
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
		
		if(count1 == 0)
		{
			spriteR.sprite = exp_imgs[exp_index];
			exp_index = (exp_index+1)%8;
			if(exp_index == 7)
			remove();
		}

		count1 = (count1+1)%5;
	}
}
