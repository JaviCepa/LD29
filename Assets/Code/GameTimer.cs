using UnityEngine;
using System.Collections;

public class GameTimer : SuperMono {

	TextMesh textMesh;

	new public void Start () {
		base.Start ();
		textMesh = GetComponent<TextMesh> ();
	}

	void Update () {
		if (state==GameStates.playing) {
			GetComponent<Renderer>().enabled=true;
			int seconds=60-Mathf.FloorToInt(gameTime % 61);
			string secondsText;
			if (seconds<10) {
				secondsText="0"+seconds;
			} else {
				secondsText=""+seconds;
			}
			textMesh.text = (2-Mathf.Floor (gameTime / 61)) + ":" + secondsText+" until dawn";
		} else {
			GetComponent<Renderer>().enabled=false;
		}
	}
}
