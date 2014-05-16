using UnityEngine;
using System.Collections;

public class DistanceScript : MonoBehaviour
{

	public int distance;
	public int plusDistance;
	public float intervalPlusDistance;

	public PlayerScript playerScript;

	private TextMesh textMesh;
	// Use this for initialization
	void Start ()
	{
		distance = 0;
		textMesh = GetComponent<TextMesh>();
		InvokeRepeating("TambahDistance",0,intervalPlusDistance);
	}

	void TambahDistance()
	{
		if(playerScript.gameOver==false)
		{
			distance+=plusDistance;
			textMesh.text = distance.ToString();
		}

	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}

