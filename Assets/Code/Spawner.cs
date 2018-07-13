using UnityEngine;
using System.Collections;

public class Spawner : SuperMono {

	public GameObject[] catalog;
	public float delayBetweenSpawns;
	public bool fireAtStart=false;
	public float acceleration=0;
	float delaypenalty=0;

	float currentTime=0;

	new public void Start () {
		base.Start ();
		currentTime = delayBetweenSpawns;
	}

	void Update () {
		if (state==GameStates.playing) {
			currentTime += Time.deltaTime;
			delaypenalty += acceleration/60f * Time.deltaTime;
			if (currentTime>Mathf.Max(delayBetweenSpawns-delaypenalty,1.5f)) {
				Spawn();
				currentTime=0;
			}
		}
	}

	void Spawn() {
		GameObject selection=catalog[Random.Range(0,catalog.Length )];
		Instantiate (selection, transform.position+Vector3.forward*0.1f, Quaternion.identity);
	}
}