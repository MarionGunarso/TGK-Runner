using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{

	// Use this for initialization
	public int health;
	public int damageToPlayer;

	void Start ()
	{

	}

	void Damaged()
	{
		if(health>0)
		{
			health-=damageToPlayer;
		}

	}

	// Update is called once per frame
	void Update ()
	{

	}
}

