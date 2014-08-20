using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;

	void Start () {
	
	}

	void Update () {
		if(GameObject.Find("Player") != null){
			score = (int)Time.timeSinceLevelLoad;
			GameObject.FindGameObjectWithTag("scoreboard").guiText.text = score.ToString();
		}else{
			GameObject.FindGameObjectWithTag("scoreboard").guiText.text = "Final Score: "+score.ToString();
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel("proto");
			}
		}

	}
}
