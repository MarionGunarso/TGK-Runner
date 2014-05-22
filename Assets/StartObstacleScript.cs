using UnityEngine;
using System.Collections;

public class StartObstacleScript : MonoBehaviour {

	// Use this for initialization
	public float startObstacleAfter;
	//public TerrainScript [] terrainScripts; 
	public SpriteRenderer [] spriteRenderers;

	void Start () {
		foreach (SpriteRenderer spriteRenderer in spriteRenderers)
		{

			spriteRenderer.gameObject.GetComponent<TerrainScript>().enabled = false;
			
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(startObstacleAfter>0)
		{
			startObstacleAfter-=Time.deltaTime;
			//Debug.Log(startObstacleAfter);
		}
		else
		{
			foreach (SpriteRenderer spriteRenderer in spriteRenderers)
			{
				if(spriteRenderer.enabled == false)
				{
					spriteRenderer.gameObject.GetComponent<TerrainScript>().enabled = true;
				}
			}

		}
	
	}
}
