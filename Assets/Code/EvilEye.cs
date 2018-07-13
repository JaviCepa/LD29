using UnityEngine;
using System.Collections;

public class EvilEye : SuperMono {

	public int EvilSize=0;
	bool alive=true;
	
	new public void Start () {
		base.Start ();
		evilEye = this;
	}

	void Update () {
		transform.localScale = Vector3.one * (2+EvilSize*4/16f);
		if (state==GameStates.win)
        {
			transform.localScale *= 0.95f;
			if (alive)
            {
				Die();
			}
		}
	}

	void Die() {
		for (int i = 0; i < 50; i++) {
			Instantiate(leafParticle, transform.position+Random.insideUnitSphere*1-Vector3.forward*2, Quaternion.identity);
		}
		alive = false;
		Destroy (gameObject, 2);
	}
}
