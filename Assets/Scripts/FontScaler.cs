using UnityEngine;
using System.Collections;

public class FontScaler : MonoBehaviour {
	
	void Start () 
	{
		GUIText text = GetComponent<GUIText>();
		text.fontSize = Screen.height / 20;
	}
}
