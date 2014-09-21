using UnityEngine;
using System.Collections;

public class CrouchButton : TouchLogicV2 {

	public bool pressed = false;

	Touch t;

	public override void Update(){
		base.Update();
		try{
			t = Input.GetTouch(currTouch);
			if(t.phase == TouchPhase.Moved && !this.guiTexture.HitTest(t.position)){
				pressed = false;
			}
		}catch(UnityException e){
			e.ToString();
		}
	}

	public override void OnTouchBegan(){
		//MovePlayer move = (MovePlayer) GameObject.Find("Player").GetComponent(typeof(MovePlayer));
		//move.crouching = true;
		pressed = true;
	}

	public override void OnTouchEnded(){
		pressed = false;
	}
}
