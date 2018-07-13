using UnityEngine;
using System.Collections;

public class Root : SuperMono {
	
	public Sprite spriteA, spriteB, spriteC;
	public Sprite deadA, deadB;

	GameObject seed;
	bool alive=true;

	new public void Start () {
		base.Start ();
		if (Random.value < 0.5f) {
			spriteRenderer.sprite = spriteA;
		} else if (Random.value < 0.5f) {
			spriteRenderer.sprite = spriteB;
		} else {
			spriteRenderer.sprite = spriteC;
		}
	}

	void Update () {
		if (state == GameStates.win && alive) {
			Die ();
		}
	}

	void Damage() {
		seed.SendMessage("Damage");
	}

	void Die() {
		alive = false;
		GetComponent<Collider2D>().enabled = false;
		if (Random.value < 0.5f) {
			spriteRenderer.sprite = deadA;
		} else {
			spriteRenderer.sprite = deadB;
		}
		if (state != GameStates.win) {
			Destroy (gameObject, 1);
		} else {

		}
	}

	void SetSeed(GameObject seedid) {
		seed = seedid;
	}
}
