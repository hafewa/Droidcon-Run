using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public Vector3 amount;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (amount);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			GetComponent<Renderer>().enabled = false;
			GetComponent<AudioSource>().Play();
			Destroy(gameObject, 2);
			GameManager.get.score ++;
		}
	}
}
