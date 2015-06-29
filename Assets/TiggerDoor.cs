using UnityEngine;
using System.Collections;

public class TiggerDoor : MonoBehaviour,TiggerObject {
	public Transform DoorPoint;
	private Vector3 DoorPos;
	private float Height = 5f;
	private float Speed = 4f;
	private float Range = 0.25f;
	public enum DoorStatus
	{
		Open,
		Close,
		Still
	}
	public DoorStatus Status=DoorStatus.Still;
	public enum DoorDirect
	{
		Left,
		Midium,
		Right
	}
	public DoorDirect doorDirect = DoorDirect.Left;
	// Use this for initialization
	void Awake () {
		DoorPos = transform.position;
		transform.parent.GetComponent<SceneManager>().tiggerObjectList.Add(this);
	}
	public void Check(Vector3 Pos)
	{
		if(doorDirect==DoorDirect.Midium)
		{
			if(Mathf.Abs(Pos.x-DoorPoint.position.x)<0.8&&Mathf.Abs(Pos.y-DoorPoint.position.y)<0.3)
			{
				Tigger();
			}
		}
		else if((Pos.x-DoorPoint.position.x)*(Pos.x-DoorPoint.position.x)+(Pos.y-DoorPoint.position.y)*(Pos.y-DoorPoint.position.y)<Range)
		{
			Tigger();
		}
	}
	public void Tigger()
	{
		GameManager.Scene[GameManager.ThisSceneNum].Leave();
		GameManager.InputEnable=false;
		Status=DoorStatus.Open;
		if(GameManager.gameMode==GameManager.GameMode.RandomMode)
		{
			RandomModeTigger();
		}
		if(GameManager.gameMode==GameManager.GameMode.StoryMode)
		{
			StoryModeTigger();
		}
	}
	private void StoryModeTigger()
	{

	}
	private void RandomModeTigger()
	{
		int directTemp;
		switch (doorDirect) {
		case DoorDirect.Left:
			directTemp=-1;
			break;
		case DoorDirect.Midium:
			directTemp=0;
			break;
		case DoorDirect.Right:
			directTemp=1;
			break;
		default:
			directTemp=10;
			break;
		}
		if(GameManager.direct==-directTemp)
		{
			StartCoroutine(ReturnToLast(directTemp)); 
		}
		else
		{
			StartCoroutine(EnterNew(directTemp));
		}
		GameManager.direct=directTemp;
	}
	IEnumerator ReturnToLast(int directTemp)
	{
		yield return new WaitForSeconds(1f);  
		GameManager.Scene[GameManager.LastSceneNum].Enter(-directTemp);
		int Temp = GameManager.ThisSceneNum;
		GameManager.ThisSceneNum = GameManager.LastSceneNum;
		GameManager.LastSceneNum = Temp;
		GameManager.InputEnable=true;
		Status=DoorStatus.Close;
	}
	IEnumerator EnterNew(int directTemp)
	{
		yield return new WaitForSeconds(1f);  
		GameManager.Scene[GameManager.LastSceneNum].Reset();

		GameManager.CreatScene().Enter(-directTemp);
		GameManager.InputEnable=true;
		Status=DoorStatus.Close;
	}
	private void DoorUpdate()
	{
		switch (Status) {
		case DoorStatus.Close:
			if(transform.position.y>DoorPos.y)
			{
				transform.Translate(0,-Speed*Time.deltaTime,0);
			}
			else
			{
				transform.position=DoorPos;
				Status=DoorStatus.Still;
			}
			break;
		case DoorStatus.Open:
			if(transform.position.y<DoorPos.y+Height)
			{
				transform.Translate(0,Speed*Time.deltaTime,0);
			}
			else
			{
				Status=DoorStatus.Still;
			}
			break;
		default:
			break;
		}
	}
	public void Enter()
	{
		transform.position=new Vector3(transform.position.x,transform.position.y+Height,transform.position.z);
		Status=DoorStatus.Close;
	}

	// Update is called once per frame
	void Update () {
		DoorUpdate();
	}
}
