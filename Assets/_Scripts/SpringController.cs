/*----------------------------------------------------------------------------
Source file name: SpringController.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 27, 2016
Program description: Make the high jumping when player touch the spring
Revision history: 0.0 - set up 
                  0.1 - made basic method
                  1.0 - Fixed the movement
----------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class SpringController : MonoBehaviour {

    //Declare public variables
    public float BounceForce = 5f;
	public Transform groundCheck;

    public PlayerController _Player;
    private Animator _animator;
    private Transform _transform;
	private Animator _playerAni;
	private bool _isGrounded;

    // Use this for initialization
    void Start () {
        //this._Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        //set private instance variables
        this._animator = gameObject.GetComponent<Animator>();
        this._transform = gameObject.GetComponent<Transform>();
		this._playerAni = _Player.GetComponents<Animator> ()[0];
    }
	
	// Update is called once per frame
	void Update () {
		
		this._isGrounded = Physics2D.Linecast(
			this._Player.transform.position, 
			this.groundCheck.position, 
			1 << LayerMask.NameToLayer("Ground"));
		
		this._playerAni.SetBool("isGrounded", _isGrounded);

	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            
			this._animator.SetBool("isHit", true);

            //if spring is facing left, player will jump in the left way
            if (this._transform.eulerAngles.z < 300)
            {
                Debug.Log("Facing Left");
                
                StartCoroutine(this._Player.Knockback(0.02f, BounceForce, this._Player.transform.position, -600));
            }
            //otherwise, player will jump in the right way
            else
            {
                Debug.Log("Facing Right");
                StartCoroutine(this._Player.Knockback(0.02f, BounceForce, this._Player.transform.position, -400));
            }

			StartCoroutine (_springBack (_animator));
            //this._animator.SetBool("isHit", false);
        }
    }


	IEnumerator _springBack(Animator spring)
	{
		yield return new WaitForSeconds (1.3f);

		spring.SetBool("isHit", false);
	}
}
