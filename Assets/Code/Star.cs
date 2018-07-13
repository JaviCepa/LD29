using UnityEngine;
using System.Collections;

public class Star : SuperMono {

	public Sprite star1, star2, star3;

	// Use this for initialization
	new public void Start () {
		base.Start ();
		if (Random.value>0.5f) {
			spriteRenderer.sprite=star1;
		} else if (Random.value>0.5f) {
			spriteRenderer.sprite=star2;
		} else {
			spriteRenderer.sprite=star3;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
