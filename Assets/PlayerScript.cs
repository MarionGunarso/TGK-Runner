using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	public float jumpForce;
	public float speed;
	public bool  increasingSpeed;
	public float speedMax;
	public float speedIncrease;
	public float startTimeIncrease;
	public float intervalTimeIncrease;

	[HideInInspector]
	public bool jump = false; //condition to jump
	public bool doubleJump = false; // condition to doublejump
	public GameObject textGameOver;

	private Transform groundCheck; // helper transform to check whether object is grounded

	private bool grounded = false; //condition when grounded

	[HideInInspector]
	public bool gameOver = false;

	private float defaultSpeed;

	void Start () {
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

		//if player outside camera, game over
		if(this.transform.renderer.IsVisibleFrom(Camera.main)==false)
		{
			textGameOver.GetComponent<MeshRenderer>().enabled=true;
			gameOver=true;
		}
		//restart the game
		if(gameOver==true && Input.GetMouseButtonUp(0))
		{

			gameOver=false;
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
