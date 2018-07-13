using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class GroundTile : SuperMono {

	public Sprite Surface;
	public Sprite Ground1;
	public Sprite Ground2;

	new public void Start () {
		base.Start();
		if (Physics2D.OverlapPoint (transform.position + Vector3.up)) {
			if (Random.value>0.5f) {
				spriteRenderer.sprite=Ground1;
			} else {
				spriteRenderer.sprite=Ground2;
			}
		} else {
			spriteRenderer.sprite=Surface;
		}
	}
	
	void Update () {
		
	}
}
