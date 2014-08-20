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
		crouchingScale = new Vector3(this.transform.localScale.x,(this.transform.localScale.y)*0.5f, this.transform.localScale.z);
	}

	void Update () {
		acc = new Vector2(speed*Input.GetAxis("Horizontal")*Time.deltaTime, 0);
		transform.position += (Vector3) acc;
		acc= new Vector2();

		if(Input.GetButtonDown("Jump") && transform.position.y < -3.7){
			rigidbody2D.AddForce(new Vector2(0, jumpPower));
		}

		if(Input.GetButton("Crouch")){
			transform.localScale = crouchingScale;
		}else{
			transform.localScale = normalScale;
		}
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
