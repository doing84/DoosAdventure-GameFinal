using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {
	//public instance variables
	public GameObject ghost;

	//private instance variables
	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();

		Instantiate (this.ghost, new Vector2 (this._transform.position.x, this._transform.position.y+55), Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
