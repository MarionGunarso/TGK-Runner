using UnityEngine;
using System.Collections;

public class TerrainScript : MonoBehaviour {

	// Use this for initialization
	public SpriteRenderer renderThis;
	public SpriteRenderer renderHigh;
	public SpriteRenderer renderLow;
	public PolygonCollider2D colliderHigh;
	public PolygonCollider2D colliderLow;

	public bool noObstacle;
	public bool spawnHigh = false;
	public bool spawnLow = false;


	int a;
	bool bolehRandom = true;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(noObstacle == false)
		{
			if(renderThis.enabled==true)
			{
				if(bolehRandom == true)
				{
					a = Random.Range(1,5);
					//Debug.Log(a);
					bolehRandom = false;
				}
				
				if(a==1)
				{
					spawnHigh = true;
				}
				else if(a==2)
				{
					spawnLow = true;
				}
				
				if(spawnHigh == true)
				{
					renderHigh.enabled = true;
					colliderHigh.enabled = true;
					spawnHigh = false;
					
				}
				else if(spawnLow == true)
				{
					renderLow.enabled = true;
					colliderLow.enabled = true;
					spawnLow = false;
				}
			}
			else
			{
				renderHigh.enabled = false;
				renderLow.enabled = false;
				colliderHigh.enabled = false;
				colliderLow.enabled = false;
				
				bolehRandom = true;
				
			}
		}




	
	}
}
