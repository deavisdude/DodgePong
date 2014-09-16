using UnityEngine;
using System.Collections;

public class JumpButton : TouchLogicV2 {
	public override void OnTouchBegan(){
		MovePlayer p = (MovePlayer) GameObject.Find("Player").GetComponent(typeof(MovePlayer));
		p.Jump();
	}
}
