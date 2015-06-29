using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {
	public Transform Player;
	float devHeight = 720f;
	float devWidth = 1280f;
	Ray[] ScreenRay = new Ray[4];
	private bool ChangeScene = true;
	public float Height = 1f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
		ChangeScene=true;
		CameraLerp();
	}

	void CameraLerp()
	{
		ScreenRay[0] = camera.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height));
		//Debug.DrawRay(ScreenRay[0].origin,ScreenRay[0].direction*100,Color.black);
		ScreenRay[1] = camera.ScreenPointToRay(new Vector2(Screen.width/2,0));
		ScreenRay[2] = camera.ScreenPointToRay(new Vector2(0,Screen.height/2));
		ScreenRay[3] = camera.ScreenPointToRay(new Vector2(Screen.width,Screen.height/2));
		if(ChangeScene)
		{
			transform.position=new Vector3(Player.position.x,Player.position.y+Height,transform.position.z);
			ChangeScene=false;
		}
		else
		{
			transform.position=new Vector3(
				Player.position.x<transform.position.x?
				(Physics.Raycast(ScreenRay[2])?Player.position.x:transform.position.x):
				(Physics.Raycast(ScreenRay[3])?Player.position.x:transform.position.x),
				Player.position.y+Height<transform.position.y?
				(Physics.Raycast(ScreenRay[1])?Player.position.y+Height:transform.position.y):
				(Physics.Raycast(ScreenRay[0])?Player.position.y+Height:transform.position.y),
				transform.position.z);
		}
	}
	void Adapt()
	{
		this.GetComponent<Camera>().orthographicSize *= (1280f/Screen.width);
	}
}
