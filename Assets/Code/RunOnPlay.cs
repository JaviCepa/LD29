using UnityEngine;
using System.Collections;

public class RunOnPlay : SuperMono {

	float timer=0;

	void Update () {
		if (state==GameStates.playing) {
			timer+=Time.deltaTime;
			GetComponent<Renderer>().enabled=Mathf.Floor(timer*8)%2==0;
			if (timer>2) {
				GetComponent<Renderer>().enabled=false;
			}
		} else {
			GetComponent<Renderer>().enabled=false;
		}
	}
}
