using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {
	public static SceneManager scene;
	public List<TiggerObject> tiggerObjectList = new List<TiggerObject>();
	public Transform[] EnterPosLMR = new Transform[3];
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

	}
	public void Enter(int dir)
	{
		switch (dir) {
		case -1:
			GameManager.Player.transform.position=EnterPosLMR[0].position;
			break;
		case 0:
			GameManager.Player.transform.position=EnterPosLMR[1].position;
			break;
		case 1:
			GameManager.Player.transform.position=EnterPosLMR[2].position;
			break;
		default:
			Transform DownObj = GameManager.Player.transform;
			Transform UpObj = DownObj.parent.Find("UpBody");
			float h = UpObj.position.y-DownObj.position.y;
			DownObj.position=EnterPosLMR[0].position;
			UpObj.position=new Vector3(DownObj.position.x,DownObj.position.y+h,DownObj.position.z);
			break;
		}
		for(int i = 0; i < tiggerObjectList.Count; i++) {
			EventManager.eventManager.TiggerCheckEvent+=tiggerObjectList[i].Check;
		}
	}
	public void Leave()
	{

		for(int i = 0; i < tiggerObjectList.Count; i++) {
			EventManager.eventManager.TiggerCheckEvent-=tiggerObjectList[i].Check;
		}
	}
	public void Reset()
	{

	}

}
