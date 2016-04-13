using UnityEngine;
using System.Collections;

public class FallingTileController : MonoBehaviour {

	//public instance variables
	public float fallDelay = 3f;

	//private instance variables
	private Rigidbody2D _rb2d;

	// Use this for initialization
	void Awake() {
		this._rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}


	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Invoke ("Fall", fallDelay);
		}

		if (other.gameObject.CompareTag ("Ground")) {
			Destroy (this.gameObject);
		}
	
	}
	
	// Update is called once per frame
	void Fall () {
		_rb2d.isKinematic = false;
	
	}
}
