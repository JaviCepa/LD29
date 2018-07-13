using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Seed : SuperMono {
	
	public GameObject plantType;
	public GameObject rootType;
	public float growRate=1;
	int dir=0;
	bool alive=true;
	bool born=false;

	GameObject currentRoot;
	GameObject plant;
	float currentTime=0;
	Vector3 tipPosition;
	List<GameObject> rootList;

	new public void Start () {
		base.Start ();
		currentRoot = gameObject;
		dir=(Random.value>0.5f)?1:-1;
		tipPosition = transform.position;
		rootList=new List<GameObject>();
	}

	void Update () {
		currentTime += Time.deltaTime;
		if (!born && !(Physics2D.OverlapPoint (tipPosition+Vector3.up*0.25f))) {
			Bloom();
			born=true;
		}
		if (currentTime>growRate && !born) {
			Grow();
			currentTime=0;
		}
		if (state == GameStates.win) {
			Die ();
		}
	}

	void Grow() {
		if (!born && state==GameStates.playing) {
			if (Random.value > 0.5f || !Physics2D.OverlapPoint (tipPosition) || tipPosition.y>0) {
				GrowUp ();
			} else {
				GrowSide ();
			}
		}
	}

	void GrowUp() {
		if (Physics2D.OverlapPoint (tipPosition)) {
			currentRoot = (GameObject)Instantiate (rootType);
			rootList.Add(currentRoot);
			currentRoot.transform.position = tipPosition + Vector3.up * 0.5f;
			currentRoot.SendMessage("SetSeed", gameObject);
			tipPosition = currentRoot.transform.position + Vector3.up * 0.5f;
		}
	}

	void GrowSide() {
		if (Physics2D.OverlapPoint (tipPosition + Vector3.right*dir)) {
			currentRoot = (GameObject)Instantiate (rootType);
			rootList.Add(currentRoot);
			currentRoot.transform.position = tipPosition + Vector3.right*dir * 0.5f;
			currentRoot.transform.Rotate(0,0,90);
			currentRoot.SendMessage("SetSeed", gameObject);
			tipPosition = currentRoot.transform.position + Vector3.right*dir * 0.5f;
		} else {
			GrowUp();
		}
	}

	void Bloom() {
		soundManager.Play ("Grow");
		evilEye.EvilSize++;
		GameObject newPlant=(GameObject)Instantiate (plantType, tipPosition+Vector3.up*0.5f-Vector3.forward, Quaternion.identity);
		newPlant.transform.localScale = new Vector3 (dir* Mathf.Abs(newPlant.transform.localScale.x), newPlant.transform.localScale.y, newPlant.transform.localScale.z);
		newPlant.SendMessage ("SetSeed", gameObject);
		plant = newPlant;
	}

	void Damage() {
		if (born && plant!=null) {
			plant.SendMessage("Damage");
		}
	}

	void Die() {
		if (alive) {
			evilEye.EvilSize--;
			Destroy(gameObject, 5);
			foreach (var root in rootList) {
				root.SendMessage ("Die");
			}
		}
		alive = false;
	}
}
