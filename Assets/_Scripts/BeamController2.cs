using UnityEngine;
using System.Collections;

public class BeamController2 : MonoBehaviour {
	//public instance variables
	public float speed;
	public GameObject Explosion;

	//GameObject scoreUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 position = transform.position;

		position = new Vector2 (position.x - this.speed, position.y);
		//Debug.Log ("here :"+position.y);
		transform.position = position;

		//	Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));

			if (transform.position.x < -1123) {
				Destroy (gameObject);
			}
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Ground")) {
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("Star")) {
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("FrogEnemy")) {
			PlayExplosion ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("GhostEnemy")) {
			PlayExplosion ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

	void PlayExplosion(){
		GameObject _explosion = (GameObject)Instantiate (Explosion);

		_explosion.transform.position = transform.position;
	}
}
