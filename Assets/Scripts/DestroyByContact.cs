using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Boundaries") {
			return;
		} else {
			//Check who it touched
			Debug.Log (other.name);

			//Destroys the bolt
			Destroy (other.gameObject);

			//Destroys the asteroid
			Destroy (gameObject);
		}
	}
}
