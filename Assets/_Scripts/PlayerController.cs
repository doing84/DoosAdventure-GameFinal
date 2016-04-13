/*----------------------------------------------------------------------------
Source file name: PlayerController.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 29, 2016
Program description: This is for the controlling of players including score, canvas UI
Revision history: 0.0 - set up
                  0.1 - made basic method
                  0.2 - Added player movement
                  0.3 - Added die and demange method
                  0.4 - Added hurt, lives and score
                  0.5 - Added sounds
                  0.6 - Fixed movement
                  0.7 - Added UI for game over, game clear, and pause
----------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Velocity range utility class
[System.Serializable]
public class VelocityRange
{
    //public instance variables
    public float minimum;
    public float maximum;

    // Constructor
    public VelocityRange(float minimum, float maximum)
    {
        this.minimum = minimum;
        this.maximum = maximum;
    }
}

public class PlayerController : MonoBehaviour {

    //Public variables
    public VelocityRange velocityRange;
    public float moveForce;
    public float jumpForce;
    public Transform groundCheck;
<<<<<<< HEAD
    public Text ScoreLabel;
<<<<<<< HEAD
=======
	public GameObject beamController;
	public GameObject beamController2;
	public GameObject beamPoint;
>>>>>>> parent of c58d3cc... Fixed game controller
=======
	public GameObject beamController;
	public GameObject beamController2;
	public GameObject beamPoint;
>>>>>>> refs/remotes/origin/master


    public bool canDoubleJump;
    //public Animation hurtAnim;

	public HUD hud;

    // PRIVATE Instance variables
    private Animator _animator;
    private float _move;
	private float _jump;
    private bool _facingRight;
    private Transform _transform;
    private Rigidbody2D _rigidBody2d;
    private bool _isGrounded;
	private bool _isTouchedSpring;

    //Set audio variables
    private AudioSource[] _audioSources;
    private AudioSource _jumpSound;
    private AudioSource _coinSound;
    private AudioSource _powerUpSound;
    private AudioSource _deadSound;
    private AudioSource _hurtSound;
    private AudioSource _gameover;
    private AudioSource _backSound;
    private AudioSource _gameClear;



    // Use this for initialization
    void Start()
    {
		
        //Initialize public instance variables
        this.velocityRange = new VelocityRange(300f, 10000f);
        

        //set private instance variables
        this._animator = gameObject.GetComponent<Animator>();
        this._transform = gameObject.GetComponent<Transform>();
        this._rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        this._move = 0f;
        this._facingRight = true;

<<<<<<< HEAD
        this.curHealth = this.maxHealth;

        // Setup AudioSources
        this._audioSources = gameObject.GetComponents<AudioSource>();
<<<<<<< HEAD
        this._jumpSound = this._audioSources[0];
        this._powerUpSound = this._audioSources[1];
        this._deadSound = this._audioSources[2];
        this._hurtSound = this._audioSources[3];
        this._coinSound = this._audioSources[4];
        this._gameover = this._audioSources[5];
        this._backSound = this._audioSources[6];
        this._gameClear = this._audioSources[7];

        this.GameoverUI.SetActive(false);
=======
		this._coinSound = this._audioSources[0];
		this._deadSound = this._audioSources[1];
		this._gameClear = this._audioSources[2];
		this._gameover = this._audioSources[3];
		this._hurtSound = this._audioSources[4];
		this._backSound = this._audioSources[5];
        this._jumpSound = this._audioSources[6];
        this._powerUpSound = this._audioSources[7];

        this.GameoverUI.SetActive(false);

		this._animator.SetBool("isTouchedSpring", false);
>>>>>>> parent of c58d3cc... Fixed game controller
=======
		this._animator.SetBool("isTouchedSpring", false);
>>>>>>> refs/remotes/origin/master
    }

    // Update is called once per frame
    void Update()
    {

        this._isGrounded = Physics2D.Linecast(
                            this._transform.position, 
                            this.groundCheck.position, 
                            1 << LayerMask.NameToLayer("Ground"));


	//	Debug.Log ("is touched spring?: " + this._isTouchedSpring);

        //get absolute value of velocity for game object
        float VelX = this._rigidBody2d.velocity.x;
        float VelY = this._rigidBody2d.velocity.y;

        this._animator.SetBool("isGrounded", this._isGrounded);
        this._animator.SetFloat("Speed", Mathf.Abs(this._rigidBody2d.velocity.x));


        this._move = Input.GetAxis("Horizontal");
		this._jump = Input.GetAxis("Vertical");
   
        //Move the player
        this._rigidBody2d.AddForce((Vector2.right * this.moveForce) * this._move);

        if (this._move < -0.1f)
        {

            this._facingRight = false;
            this._flip();
        }
        else if(this._move > 0.1f)
        {
            //this._rigidBody2d.AddForce(Vector2.right * this.moveForce * this._move);
            this._facingRight = true;
            this._flip();
        }
        

        if (VelX > this.velocityRange.maximum)
        {
            this._rigidBody2d.velocity = new Vector2(this.velocityRange.maximum, this._rigidBody2d.velocity.y);
        }
        if (VelX < -this.velocityRange.maximum)
        {
            this._rigidBody2d.velocity = new Vector2(-this.velocityRange.maximum, this._rigidBody2d.velocity.y);
        }

        if (VelY > this.velocityRange.maximum)
        {
            this._rigidBody2d.velocity = new Vector2(this._rigidBody2d.velocity.x, this.velocityRange.maximum);
        }
        if (VelY < -this.velocityRange.maximum)
        {
            this._rigidBody2d.velocity = new Vector2(this._rigidBody2d.velocity.x, -this.velocityRange.maximum);
        }

        //Jump 
		if (this._jump > 0)
        {


            if(this._isGrounded)
            {
                this._rigidBody2d.AddForce(Vector2.up * this.jumpForce);
                this.canDoubleJump = true;
            }
            else
            {
                if(this.canDoubleJump)
                {
                    this.canDoubleJump = false;
                    this._rigidBody2d.velocity = new Vector2(this._rigidBody2d.velocity.x, 0);
                    this._rigidBody2d.AddForce(Vector2.up * this.jumpForce / 1.95f);

                }
            }
<<<<<<< HEAD
            this._jumpSound.Play();
<<<<<<< HEAD


        }

        //this._checkBounds();

        if (this.curHealth > this.maxHealth)
        {
            this.curHealth = this.maxHealth;
        }

=======
        }

		if (Input.GetKeyDown ("space")) {			
			if (this._facingRight) {
				GameObject _beam = (GameObject)Instantiate (this.beamController);
				_beam.transform.position = this.beamPoint.transform.position;
			} else {
				GameObject _beam2 = (GameObject)Instantiate (this.beamController2);
				_beam2.transform.position = this.beamPoint.transform.position;
			}
		}

        //this._checkBounds();

        if (this.curHealth > this.maxHealth)
        {
            this.curHealth = this.maxHealth;
        }

>>>>>>> parent of c58d3cc... Fixed game controller
        if(this.curHealth <= 0)
        {
            Die();
        }
=======
			this.hud._audioSources [6].Play ();
        }

		if (Input.GetKeyDown ("space")) {			
			if (this._facingRight) {
				GameObject _beam = (GameObject)Instantiate (this.beamController);
				_beam.transform.position = this.beamPoint.transform.position;
			} else {
				GameObject _beam2 = (GameObject)Instantiate (this.beamController2);
				_beam2.transform.position = this.beamPoint.transform.position;
			}
		}
			
>>>>>>> refs/remotes/origin/master
    }

    private void _flip()
    {
        if (this._facingRight)
        {
            this._transform.localScale = new Vector2(1, 1);
        }
        else
        {
            this._transform.localScale = new Vector2(-1, 1);
        }
    }

    private void _checkBounds()
    {
        if (this._transform.position.y > 2300f)
        {
            this._transform.position = new Vector3(this._transform.position.x, 2300f, 0);
        }
        if (this._transform.position.x < -1200.9f)
        {
            this._transform.position = new Vector3(-146.7f, this._transform.position.y, 0);
        }
        if (this._transform.position.x > 1445.2f)
        {
            this._transform.position = new Vector3(1445.2f, this._transform.position.y, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Death"))
        {
<<<<<<< HEAD
            this._deadSound.Play();       
<<<<<<< HEAD
            this._transform.position = new Vector3(-133.9f, -157.4f, 0);
=======
            this._transform.position = new Vector3(-363f, -736f, 0);
>>>>>>> parent of c58d3cc... Fixed game controller
            this.curHealth -= 1;
=======
			this.hud._audioSources[1].Play();   
            this._transform.position = new Vector3(-363f, -736f, 0);
			this.hud.curHealth -= 1;
>>>>>>> refs/remotes/origin/master
        }

        if (col.gameObject.CompareTag("goldCoins"))
        {
<<<<<<< HEAD
<<<<<<< HEAD
            Debug.Log("Touch the gold coin");
=======
           // Debug.Log("Touch the gold coin");
>>>>>>> parent of c58d3cc... Fixed game controller
            this._coinSound.Play();
=======
           // Debug.Log("Touch the gold coin");
			this.hud._audioSources[0].Play();
>>>>>>> refs/remotes/origin/master
            Destroy(col.gameObject);
			this.hud.curScore += 200;
        }

        if (col.gameObject.CompareTag("bronzeCoins"))
        {
			this.hud._audioSources[0].Play();
            Destroy(col.gameObject);
			this.hud.curScore += 100;
        }

<<<<<<< HEAD
<<<<<<< HEAD
        if (col.gameObject.CompareTag("Enemy"))
=======
		if (col.gameObject.CompareTag("Star"))
		{
			this._coinSound.Play();
			Destroy(col.gameObject);
			this.score += 125;
		}

		if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("FrogEnemy") || col.gameObject.CompareTag("GhostEnemy"))
>>>>>>> parent of c58d3cc... Fixed game controller
=======
		if (col.gameObject.CompareTag("Star"))
		{
			this.hud._audioSources[0].Play();
			Destroy(col.gameObject);
			this.hud.curScore += 125;
		}

		if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("FrogEnemy") || col.gameObject.CompareTag("GhostEnemy"))
>>>>>>> refs/remotes/origin/master
        {
            Destroy(col.gameObject);
            this.Damage(1);
            gameObject.GetComponent<Animation>().Play("hurt");
            StartCoroutine(this.Knockback(0.02f, 50f, this._transform.position, -50f));
        }

        if (col.gameObject.CompareTag("final"))
        {
			this.hud.curLevel = 2;
			this.hud.GameClear ();
        }
    }
		

    public void Damage(int dmg)
    {
		
		this.hud.curHealth -= dmg;
		this.hud._audioSources[4].Play();
        //gameObject.GetComponent<Animation>().Play("hurt");
    }

    //When player hit the spikes, make the motion
    public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockbackDir, float knockFacing)
    {
        float timer = 0;

        while(knockDur > timer)
        {

            timer += Time.deltaTime;
            this._rigidBody2d.AddForce(new Vector3(knockbackDir.x * knockFacing, Mathf.Abs(knockbackDir.y) * knockPwr, transform.position.z));
        }

        yield return 0;
    }


}
