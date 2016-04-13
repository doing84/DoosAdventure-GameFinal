using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {

	//public instance variables
	public float speed;
	public Transform groundCheck;

	//GameObject scoreUI;

	private Animator _animator;
	private Rigidbody2D _rigidBody2d;
	private Transform _transform;
	private float _myWidth;
	private Vector3 currRot;
	private bool isGrounded;
	private bool isLeft;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
		this._rigidBody2d = gameObject.GetComponent<Rigidbody2D> ();
		this._myWidth = gameObject.GetComponent<SpriteRenderer> ().bounds.extents.x;
		this.isLeft = false;

		//get the score from TextUI
		//scoreUI = GameObject.FindWithTag("Score");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Check to see if there's ground in front of us before moving
		Vector2 lineCastPos = this._transform.position - this._transform.right * _myWidth;

		isGrounded = Physics2D.Linecast (this._transform.position, this.groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		Vector2 myVel = this._rigidBody2d.velocity;

		//If there's no ground, turn around
		if (!isGrounded) {
			if (isLeft) {
				_flip ();
				isLeft = false;
			} else {
				_flip ();
				isLeft = true;
			}
		}

		if (isLeft) {
			myVel.x = -speed;
		} else {
			myVel.x = speed;
		}

		this._rigidBody2d.velocity = myVel;	
	

	}

	private void _flip(){
		if (this.isLeft) {			
			Vector3 currRot = this._transform.eulerAngles;
			currRot.y += 180;
			this._transform.eulerAngles = currRot;
		} else {			
			Vector3 currRot = this._transform.eulerAngles;
			currRot.y -= 180;
			this._transform.eulerAngles = currRot;
		}
	}
}
