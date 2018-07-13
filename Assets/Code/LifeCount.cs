using UnityEngine;
using System.Collections;

public class LifeCount : SuperMono {

	public Sprite lifeOn, lifeOff;

	public int lifeValue=1;

	new public void Start () {
		base.Start ();
	}
	
	void Update () {
		if (player.health >= lifeValue) {
			spriteRenderer.sprite=lifeOn;
		} else {
			spriteRenderer.sprite=lifeOff;
		}
	}
}
