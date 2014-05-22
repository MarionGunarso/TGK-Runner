using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	public bool gameOver;
	public TextMesh textGameOver;
	public MeshRenderer meshRendererOver;

	void Start () {
		gameOver = false;
		meshRendererOver.enabled = false;
	}


	// Update is called once per frame
	void Update () {
		if(gameOver == true)
		{
			meshRendererOver.enabled = true;
		}
		//if player outside camera, game over
		if(this.transform.renderer.IsVisibleFrom(Camera.main)==false)
		{

			gameOver=true;
		}
	
	}

	void OnCollisionEnter2D(Collision2D otherCollider)
	{
		if(otherCollider.gameObject.tag == "obstacle")
		{
			if(otherCollider.gameObject.GetComponent<ObstacleScript>().dangerous == true)
			{
				gameOver = true;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(otherCollider.gameObject.tag == "enemy")
		{
			gameOver = true;
		}
	}
}
