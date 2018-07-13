using UnityEngine;
using System.Collections;

public class Moon : SuperMono {

	public GameObject WinText;
    Vector3 startPosition;

	new public void Start () {
		base.Start();
        startPosition = transform.position;
        gameTime = 0;
		gameDuration = 60 * 3;
	}

	void Update () {
		if (state==GameStates.playing) {
			gameTime += Time.deltaTime;
			transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.right * 26f, gameTime / gameDuration);
			if (gameTime >= gameDuration) {
				Win();
			}
		}
		if (gameTime > gameDuration) {
			gameTime=gameDuration;
		}
	}

	void Win() {
		if (state != GameStates.win) {
			soundManager.Stop();
			soundManager.Play ("WinTheme");
		}
		Camera.main.backgroundColor = new Color (212f/255f,233f/255f,144f/255f);
		Instantiate (WinText, new Vector3(0,5,0), Quaternion.identity);
		state = GameStates.win;
	}
}
