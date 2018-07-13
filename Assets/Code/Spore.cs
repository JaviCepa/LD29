using UnityEngine;
using System.Collections;

public class Spore : SuperMono {

	Vector3 speed;

	float timer=0;

	new public void Start () {
		base.Start ();
		transform.position = new Vector3 (transform.position.x, transform.position.y, 20);
		speed = Random.insideUnitCircle.normalized;
		if (speed.y < 0) {
			speed=new Vector3(speed.x, -speed.y, speed.z);
		}
		speed=new Vector3(speed.x, speed.y+2, speed.z);
		soundManager.Play ("Spore");
	}

	void Update () {
		speed -= Vector3.up * Time.deltaTime;
		transform.position += speed*Time.deltaTime;
		timer += Time.deltaTime;
		if (timer > 10) {
			Destroy(gameObject);
		}
	}
	
	void Damage() {
		Destroy (gameObject);
	}
}
