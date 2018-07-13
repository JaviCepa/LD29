using UnityEngine;
using System.Collections;

public class Bullet : SuperMono {

	public float travelSpeed=5;

	Vector3 speed;

	new public void Start () {
		base.Start ();
		speed = (Vector2)(player.transform.position - transform.position);
		speed = speed.normalized;
		soundManager.Play ("Bullet");
	}

	void Update () {
		transform.position += speed * Time.deltaTime;
	}

	void Damage() {
		Destroy (gameObject);
	}
}
