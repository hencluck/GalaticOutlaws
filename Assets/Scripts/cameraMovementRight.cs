using UnityEngine;
using System.Collections;

public class cameraMovementRight : MonoBehaviour {


	float camSpeed = 10f;
	public GameObject mCamera;

	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {



}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player"){
			mCamera.transform.Translate (Vector2.right*camSpeed*Time.deltaTime);
		}
			
		}
}