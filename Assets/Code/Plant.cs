using UnityEngine;
using System.Collections;

public class Plant : SuperMono {

	public Sprite growing1, growing2;
	public Sprite mature1, mature2;

	bool mature=false;

	public int health=3;

	public float growTime=1;
	float currentTime=0;
	GameObject seed;

	new public void Start () {
		base.Start ();
	}
	
	void Update () {
		if (state == GameStates.win) {
			Die ();
		}

		currentTime += Time.deltaTime;
		if (currentTime < growTime) {
			if (Mathf.Floor (currentTime*2) % 2 == 0) {
					spriteRenderer.sprite = growing1;
			} else {
					spriteRenderer.sprite = growing2;
			}
		} else {
			if (!mature) {
				health+=2;
				mature=true;
			}
			if (Mathf.Floor (currentTime*2) % 2 == 0) {
				spriteRenderer.sprite = mature1;
			} else {
				spriteRenderer.sprite = mature2;
			}
		}
		if (health <= 0) {
			Die();
		}
	}

	void Damage() {
		health--;
	}

	void Die() {
		seed.SendMessage ("Die");
		for (int i = 0; i < 5; i++) {
			Instantiate(leafParticle, transform.position+Random.insideUnitSphere*0.5f+Vector3.forward*40, Quaternion.identity);
		}
		Destroy (gameObject);
	}

	void SetSeed(GameObject seedid) {
		seed = seedid;
	}
}
