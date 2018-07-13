using UnityEngine;
using System.Collections;

public class ClearOnPlay : SuperMono {

	void Update () {
		if (state!=GameStates.ready) {
			Destroy(gameObject);
		}
	}
}
