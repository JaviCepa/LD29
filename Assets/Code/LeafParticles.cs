using UnityEngine;
using System.Collections;

public class LeafParticles : SuperMono {

	public Sprite particle1, particle2, particle3;

	Vector3 speed;
	float lifeTime=2f;

	new public void Start () {
		base.Start ();
		if (Random.value > 0.5f) {
			spriteRenderer.sprite = particle1;
		} else if (Random.value > 0.5f) {
			spriteRenderer.sprite = particle2;
		} else {
			spriteRenderer.sprite = particle3;
		}
		speed = Random.insideUnitCircle*4;
	}
	
	void Update () {
		transform.position += speed * Time.deltaTime;
		speed += Vector3.down * Time.deltaTime * 4;
		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0)
        {
			Destroy(gameObject);
		}
	}
}
