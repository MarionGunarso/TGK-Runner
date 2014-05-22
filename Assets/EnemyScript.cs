using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization

	private Vector3 basePosition;
	public EnemySpawnerScript enemySpawnerScript;

	public MoveScript moveScript;
	[HideInInspector]
	//public bool active = false;


	void Start () {
		moveScript.speed.x = 0;
		Debug.Log("startenemy");
		basePosition = this.transform.position;

	}


	// Update is called once per frame
	void Update () {
		if(this.transform.position.x<-10)
		{
			//Debug.Log("disableobjek");
			moveScript.speed.x = 0;
			enemySpawnerScript.currActive--;
			transform.position = basePosition;
			Debug.Log("reset");

		}
	}
}
