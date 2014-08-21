using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static float score = 0;
	public static float highscore = 0;
	public static float ScoreScale = 1;

	void Start () {
		highscore = PlayerPrefs.GetFloat("highscore");
	}

	void Update () {
		if(GameObject.Find("Player") != null){
			score += Time.deltaTime * ScoreScale;
			if(score > highscore)
				highscore = score;
			GameObject.FindGameObjectWithTag("scoreboard").guiText.text = ((int)score).ToString();
		}else{
			GameObject.FindGameObjectWithTag("scoreboard").guiText.text = "Final Score: "+((int)score).ToString();
			PlayerPrefs.SetFloat("highscore", highscore);
			GameObject.Find("RestartPrompt").guiText.enabled = true;
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel("proto");
				GameObject.Find("RestartPrompt").guiText.enabled = false;
				ScoreScale = 1;
				score = 0;
			}
		}
		GameObject.FindGameObjectWithTag("scoreboard").guiText.text += "\nHighscore: "+((int)highscore).ToString();
	}
}
