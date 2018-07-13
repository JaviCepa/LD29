using UnityEngine;
using System.Collections;

public class Shoots : MonoBehaviour {

	public GameObject bullet;
	public float rateOfFire=2;

	float shootTimer;

	void Start () {
		shootTimer = rateOfFire;
	}

	void Update () {
		shootTimer -= Time.deltaTime;
		if (shootTimer <= 0) {
			shootTimer+=rateOfFire;
			Instantiate(bullet, transform.position, Quaternion.identity);
		}
	}
}
