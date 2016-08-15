using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Boundaries") {
			return;
		} else {
			Instantiate (explosion, transform.position, transform.rotation);

			if (other.tag == "Player") {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			}
			//Destroys the bolt
			Destroy (other.gameObject);

			//Destroys the asteroid
			Destroy (gameObject);
		}
	}
}
