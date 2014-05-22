using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

	// Use this for initialization
	private GameObject [] enemies;
	public float startSpawnAfter;
	public float spawnInterval;
	public int maxEnemyActive;
	int a;
	[HideInInspector]
	public int currActive;
	private float timeSpawn;
	void Start () {
		currActive = 0;
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		foreach (GameObject enemy in enemies)
		{
			enemy.GetComponent<MoveScript>().speed.x=0;
		}
		timeSpawn = spawnInterval;
		//Debug.Log(enemies.Length);
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(currActive);
		//Debug.Log(timeSpawn);
		if(startSpawnAfter>0)
		{
			startSpawnAfter-=Time.deltaTime;
		}
		else
		{
			if(timeSpawn>0)
			{
				timeSpawn-=Time.deltaTime;
			}
			else
			{

				if(currActive<maxEnemyActive)
				{
					do
					{
						a = Random.Range(0,enemies.Length);
						//Debug.Log(a);
					}while(enemies[a].GetComponent<MoveScript>().speed.x != 0);



					enemies[a].GetComponent<MoveScript>().DefaultSpeed();
					currActive++;
					timeSpawn = spawnInterval;
					

				}

			}
		}
	
	}
}
