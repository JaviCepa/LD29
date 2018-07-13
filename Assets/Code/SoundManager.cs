using UnityEngine;
using System.Collections;

public class SoundManager : SuperMono {

	public AudioClip[] audioClips;

	void Awake () {
		soundManager = this;
	}

	void Update() {
		foreach (var item in GetComponents<AudioSource>()) {
			if (item!=null && !item.isPlaying) {
				if (item.clip!=null && item.clip.name!="MainThemeLow") {
					Destroy (item);
				} else {
					if (item.enabled) {
						item.Play();
					}
				}
			}
		}
	}

	void PlayMainTheme() {
		Play ("MainThemeLow");
	}

	public void Play(string soundName) {
		AudioSource sound=gameObject.AddComponent<AudioSource>();
		foreach (var clip in audioClips) {
			if (clip.name==soundName) {
				sound.clip=clip;
				sound.Play();
			}
		}
	}

	public void Stop() {
		foreach (var item in GetComponents<AudioSource>()) {
			Destroy(item);
		}
	}
}
