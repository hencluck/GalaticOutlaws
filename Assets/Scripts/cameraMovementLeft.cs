using UnityEngine;
using System.Collections;

public class cameraMovementLeft : MonoBehaviour {

	float camSpeed = 10f;
	public GameObject mCamera;
	GameObject Player = GameObject.Find("playerprefab");
	void Start () {
		
		Playerwalk speedScript = Player.GetComponent<Playerwalk> ();
		camSpeed = speedScript.speed;

	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player"){
			mCamera.transform.Translate (Vector2.left*camSpeed*Time.deltaTime);
			Debug.LogError("Collide");
		}
		
	}


	/*void OnTriggerEnter2D(Collision2D _colInfo)
	{
		Playerwalk _Playerwalk = _colInfo.collider.GetComponent<Playerwalk>();
	     
		_Playerwalk.speed = 20f;

	}*/
}