using UnityEngine;
using System.Collections;

public class pickUpSpawn : MonoBehaviour {

	public Transform[] pickUpSpawns;
	public GameObject pickUp;

	// Use this for initialization
	void Start () {
		spawn ();
	
	}


	void spawn()
	{
		for (int i = 0; i< pickUpSpawns.Length; i++) 
		{
			int pickUpFlip = Random.Range(0,2);
			if (pickUpFlip >0	)
				Instantiate(pickUp, pickUpSpawns[i].position, Quaternion.identity);
		
		}


	}


}
