using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour {

	public float MoveSpeed = 1f;
	public float JumpForce = 1f;
	public int counter;

	private bool isGrounded;
	private Animator _animator;
	private ParallaxController _parallaxController;
	private bool faceRight;

	public float fireDelay = 0.25f;
	private float cooldownTimer = 0;

	public AudioClip Run;
	public AudioClip Jumping;
	public AudioClip Shooting;
	
	void Awake()
	{
		_animator = GetComponent<Animator> ();
		_parallaxController = GetComponent<ParallaxController> ();
	}

	void Start()
	{
		isGrounded = true;
		_animator.SetBool ("isGrounded", isGrounded);
		faceRight = true;

	}

	void Update()
	{
		float x = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (x, 0f);
		_parallaxController.Scroll (movement *= -1);
		cooldownTimer -= Time.deltaTime;
	}

	void FixedUpdate () 
	{


		if (isGrounded == true) 
		{
			if (Input.GetKey (KeyCode.Space)) 
			{
				Shoot ();
			}
			if(Input.anyKey == false) 
			{
				Idle();
			}
			if(Input.GetKey (KeyCode.LeftArrow)) 
			{
				WalkLeft();
			}
			if(Input.GetKey (KeyCode.RightArrow)) 
			{
				WalkRight();
			}
			if(Input.GetKey (KeyCode.UpArrow)) 
			{
				JumpUp();
			}
		}
		else if(Input.GetKey (KeyCode.Space))
		{
			JumpShoot();
		}
	}

	void WalkLeft()
	{
		transform.position -=new Vector3 (MoveSpeed * Time.deltaTime, 0.0f, 0.0f);
		//_animator.SetTrigger("runLeft");
		_animator.SetBool ("isGrounded", true);
		_animator.Play ("MegaRun");
		faceRight = false;
		SoundManager.instance.RandomizeSfx (Run);
	}
	void WalkRight()
	{
		transform.position +=new Vector3 (MoveSpeed * Time.deltaTime, 0.0f, 0.0f);
		//_animator.SetTrigger("runRight");
		_animator.SetBool ("isGrounded", true);
		_animator.Play ("MegaRun");
		faceRight = true;
		SoundManager.instance.RandomizeSfx (Run);
	}
	void JumpUp()
	{
		//_animator.SetTrigger ("jump");
		_animator.SetBool ("isGrounded", false);
		transform.position +=new Vector3 (0.0f, JumpForce * Time.deltaTime, 0.0f);

		if (faceRight == true) 
		{
			_animator.Play ("MegaJump");
			SoundManager.instance.RandomizeSfx (Jumping);
		} 
		else 
		{
			_animator.Play ("MegaJump");//flip animation
			SoundManager.instance.RandomizeSfx (Jumping);
		}
	}
	void JumpShoot()
	{
		print ("Shoot");
		//_animator.SetTrigger ("jumpShoot");
		_animator.SetBool ("isGrounded", false);
		_animator.Play ("MegaJumpShoot");
		SoundManager.instance.RandomizeSfx (Shooting);
	}
	void Shoot()
	{
		print ("Shoot");

		cooldownTimer = fireDelay;


		//_animator.SetTrigger ("shoot");
		_animator.SetBool ("isGrounded", true);
		_animator.Play ("MegaShoot");
		SoundManager.instance.RandomizeSfx (Shooting);
	}
	void Idle()
	{
		//_animator.SetTrigger ("idle");
		_animator.SetBool ("isGrounded", true);
		_animator.Play ("MegaIdle");
	}
}