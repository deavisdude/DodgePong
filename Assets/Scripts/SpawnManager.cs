using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	
	public int speed;
	public GameObject fruit;
	public GameObject player; 
	GameObject NewFruit;
	
	void Awake () {
		InvokeRepeating("Spawn", 0, 10f);
	}

	void Spawn(){
		if(GameObject.Find("Player") != null){
			NewFruit = (GameObject) Instantiate(fruit, Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.Range(.5f, 1f), 10)), transform.rotation);
			NewFruit.rigidbody2D.AddForce((NewFruit.transform.position - player.transform.position)*speed);
		}
	}
}
