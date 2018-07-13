using UnityEngine;
using System.Collections;

public class Hazard : SuperMono {

	public int damage=1;

	new public void Start () {
		base.Start ();
	}

	void Update () {
		Collider2D[] hits=Physics2D.OverlapCircleAll(transform.position, 0.5f);
		Collider2D hit=null;
		foreach (var item in hits) {
			if (item.name=="Player") {
				hit=item;
			}
		}
		if (hit != null) {
			hit.gameObject.SendMessage("Damage", damage);
		}
		if (state == GameStates.win) {
			damage=0;
		}
	}
}
