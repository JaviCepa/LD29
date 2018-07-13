using UnityEngine;
using System.Collections;

public class SuperMono : MonoBehaviour {

	[HideInInspector]public SpriteRenderer spriteRenderer;
	public static Player player;
	public static EvilEye evilEye;
	public static SoundManager soundManager;
	public static float gameTime=0, gameDuration;
	public static GameStates state=GameStates.ready;
	public static GameObject leafParticle;

	public void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

}
public enum GameStates {ready, playing, gameover, win}