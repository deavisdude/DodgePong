using UnityEngine;
using System.Collections;

public class FruitPilot : MonoBehaviour {

	public float speed = 5f;
	public float increase=1.01f;

	void Update () {
		Vector2 vel = rigidbody2D.velocity;

		//Keep a constant speed
		this.rigidbody2D.velocity = rigidbody2D.velocity.normalized*speed*Time.deltaTime;

		//Prevent vertical-only bouncing
		if(vel.y > 5 || vel.y < -5){
			float adjust = Random.Range(0.0f, 1.0f);

			if(vel.x < 0 && vel.y < 0){
				rigidbody2D.AddForce(new Vector2(-adjust, adjust));
			}else if(vel.x < 0 && vel.y > 0){
				rigidbody2D.AddForce(new Vector2(-adjust, -adjust));
			}else if(vel.x > 0 && vel.y > 0){
				rigidbody2D.AddForce(new Vector2(adjust, -adjust));
			}else if(vel.x > 0 && vel.y < 0){
				rigidbody2D.AddForce(new Vector2(adjust, adjust));
			}else if(vel.y == 0){
				rigidbody2D.AddForce(new Vector2(0, adjust));
			}
		}
		rigidbody2D.angularVelocity += GameObject.Find("Player").rigidbody2D.velocity.y*10;
	}

	void OnCollisionEnter2D(Collision2D col){
		speed *= increase;
	}
}
