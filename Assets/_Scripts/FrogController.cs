using UnityEngine;
using System.Collections;

public class FrogController : MonoBehaviour {
	//public instance variables
	public GameObject frog;

	//private instance variables
	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {

		this._transform = gameObject.GetComponent<Transform> ();

		Instantiate (this.frog, new Vector2 (this._transform.position.x, this._transform.position.y+10), Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
