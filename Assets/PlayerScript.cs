using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	public float jumpForce;
	public float speed; // default speed
	public bool  increasingSpeed; // increase the speed or not

	public float speedMax; // speed Maximum
	public float speedIncrease; //amount of increasing speed
	public float startTimeIncrease; //increase speed after?
	public float intervalTimeIncrease; //increase speed every?

	public float speedToDefaultPos; // speed char kembali ke posisi semula
	[HideInInspector]
	public bool jump = false; //condition to jump
	public bool doubleJump = false; // condition to doublejump


	private Transform groundCheck; // helper transform to check whether object is grounded

	private bool grounded = false; //condition when grounded

	private GameOverScript gameOverScript;

	private Vector3 basePosition;

	private float defaultSpeed;

	void Start () {
		basePosition = this.transform.position;
		gameOverScript = GetComponent<GameOverScript>();
		defaultSpeed = speed;
		groundCheck = transform.Find("GroundCheck");
		if(increasingSpeed==true)
		{
			InvokeRepeating("SpeedIncrease",startTimeIncrease,intervalTimeIncrease);
		}

	
	}

	void SpeedIncrease()
	{
		if(speed<speedMax)
		{
			speed+=speedIncrease;
		}

	}

	public void AddSpeed(float a)
	{
		speed+=a;
	}
	int a = 0;
	// Update is called once per frame
	void Update () {

		if(this.transform.position.x < basePosition.x)
		{
			transform.Translate(speedToDefaultPos,0,0);
		}

		//Debug.Log(grounded);
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if( ( Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump") ) && grounded==true)
		{
			//can jump if grounded and mouse click
			jump = true;
		}
		if(a==0 && grounded==false && Input.GetMouseButtonDown(0) && jump==false)
		{
			doubleJump = true;
			a=1;
		}
		if(grounded==true)
		{
			a=0;
		}


		//restart the game
		if(gameOverScript.gameOver==true && Input.GetMouseButtonUp(0))
		{

			gameOverScript.gameOver=false;
			speed = defaultSpeed;
			Application.LoadLevel("runner");
		}
	
	}
	void FixedUpdate()
	{
		if(jump || doubleJump)
		{
			// Add a vertical force to the player.
			//rigidbody2D.AddForce(new Vector2(0f,jumpForce));
			rigidbody2D.velocity = new Vector2(0,jumpForce);
			if(jump==true)
			{
				jump = false;
			}
			else if(doubleJump==true)
			{
				doubleJump = false;
			}
			//jump = false;
			//doubleJump = false;
			//jump = false;

		}
	}
}
