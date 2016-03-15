using UnityEngine;
using System.Collections;

public class Jumping : MonoBehaviour {

	public float jumpHeight;
	public int jumpCount = 0;
	public float jumpPower= 100f;
		// Use this for initialization
	void Start () {
		
	}
	
	 // Update is called once per frame
	void Update () {
		//Jumping Section
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
	
			if (jumpCount < 2) 
			{
				gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpPower);
				jumpCount = jumpCount + 1;
			}
			else if (jumpCount < 2)
			{
				gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpPower);
				jumpCount = jumpCount + 1;
			}
			
			     }
	}
	
	//this bit is to check if the object that collided with it has the ground tag
	void OnCollisionEnter2D(Collision2D col)
	 {
		if (col.gameObject.tag == "Ground") 
		{
			Debug.Log ("IMPACT");

			jumpCount = 0;
			      }

		if (col.gameObject.tag == "Moving Platform") 
		{
			Debug.Log ("IMPACT");

			jumpCount = 0;
		}
	}
}
