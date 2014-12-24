using UnityEngine;
using System.Collections;

public class CamShakeSimple : MonoBehaviour {

	Vector3 originalCameraPosition;
	
	float shakeAmt = 0;

	public GameObject spark;
	
	Camera mainCamera = Camera.main;

	void Start(){
		originalCameraPosition = mainCamera.transform.position;
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		
		shakeAmt = coll.relativeVelocity.magnitude * .0025f;
		InvokeRepeating("CameraShake", 0, .01f);
		Invoke("StopShaking", 0.3f);
		Instantiate(spark,transform.position,transform.rotation);
	}
	
	void CameraShake()
	{
		if(shakeAmt>0) 
		{
			float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			Vector3 pp = mainCamera.transform.position;
			pp.y+= quakeAmt; // can also add to x and/or z
			mainCamera.transform.position = pp;
		}
	}
	
	void StopShaking()
	{
		CancelInvoke("CameraShake");
		mainCamera.transform.position = originalCameraPosition;
	}
}
