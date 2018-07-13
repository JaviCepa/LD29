using UnityEngine;
using System.Collections;

public class Scissors : SuperMono {

	new public void Start () {
		base.Start();
	}
	
	public void Update () {
		if (state==GameStates.win) {
			GetComponent<Renderer>().enabled=false;
		}
	}
}
