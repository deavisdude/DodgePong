using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public GameObject exPrefab;

	public int speed = 5;
	public float jumpPower = 400f;
	Vector2 acc;

	Vector3 normalScale;
	Vector3 crouchingScale;

	void Start(){
		normalScale = this.transform.localScale;
		crouchingScale = new Vector3(this.transform.localScale.x*0.63f,(this.transform.localScale.y)*0.63f, this.transform.localScale.z);
	}

	void Update () {
		acc = new Vector2(speed*Input.GetAxis("Horizontal")*Time.deltaTime, 0);
		for(int i=0; i<Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			if(touch.phase != TouchPhase.Ended){
				if(touch.position.x > 400){
					acc = new Vector2(speed*Time.deltaTime, 0);
				}else if(touch.position.x <200){
					acc = new Vector2(-speed*Time.deltaTime, 0);
				}
			}

			if(touch.phase == TouchPhase.Moved && touch.deltaPosition.y > 20 && rigidbody2D.velocity.y == 0){
				rigidbody2D.AddForce(new Vector2(0, jumpPower));
			}
		}
	
		if(Input.GetButton("Crouch")){
			transform.localScale = crouchingScale;
			acc*=0.63f;
		}else{
			transform.localScale = normalScale;
			if(Input.GetButtonDown("Jump") && rigidbody2D.velocity.y == 0){
				rigidbody2D.AddForce(new Vector2(0, jumpPower));
			}
		}
		transform.position += (Vector3) acc;
		acc= new Vector2();
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "apple"){
			Instantiate(exPrefab, this.transform.position, this.transform.rotation);
			Destroy(this.gameObject);
			for(int i=0; i < GameObject.FindGameObjectsWithTag("apple").Length; i++){
				Destroy((GameObject) GameObject.FindGameObjectsWithTag("apple").GetValue(i));
			}
		}
	}

}
