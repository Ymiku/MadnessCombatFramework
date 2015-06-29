using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {
	private int HalfWidth;
	private Vector2 LPos;
	private Vector2 LOldPos;
	private Vector2 RPos;
	private Vector2 ROldPos;
	private Vector2 MoveVector;
	public float LTimeCount;
	public float RTimeCount;
	public LocalEventManager localEventManager;
	// Use this for initialization
	void Start () {
		HalfWidth=Screen.width/2;
	}
	
	// Update is called once per frame
	void Update () {
		localEventManager.Move(0,0);
		if(LTimeCount>=0){LTimeCount+=Time.deltaTime;}
		if(RTimeCount>=0){RTimeCount+=Time.deltaTime;}
		if(Input.GetKeyDown(KeyCode.Z))
		{
			EventManager.eventManager.TiggerCheck(GameManager.Player.transform.position);
			localEventManager.Attack();
		}
		if(Input.GetButtonDown("Jump"))
		{
			localEventManager.Jump();
		}
		localEventManager.Move(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
		if(Input.touchCount == 1)
		{
			if(Input.GetTouch(0).phase==TouchPhase.Began)  
			{
				SetOldPos(Input.GetTouch(0).position);
			}
			SetPos(Input.GetTouch(0).position);
			if(Input.GetTouch(0).phase==TouchPhase.Ended) 
			{
				EndPos(Input.GetTouch(0).position,Input.GetTouch(0).phase==TouchPhase.Moved);
			}
		}
		else if(Input.touchCount > 1) 
		{
			if(Input.GetTouch(0).phase==TouchPhase.Began)  
			{  
				SetOldPos(Input.GetTouch(0).position);
			}  
			SetPos(Input.GetTouch(0).position);
			if(Input.GetTouch(0).phase==TouchPhase.Ended) 
			{
				EndPos(Input.GetTouch(0).position,Input.GetTouch(0).phase==TouchPhase.Moved);
			}
			if(Input.GetTouch(1).phase==TouchPhase.Began)  
			{  
				SetOldPos(Input.GetTouch(1).position);
			}  
			SetPos(Input.GetTouch(1).position);
			if(Input.GetTouch(1).phase==TouchPhase.Ended) 
			{
				EndPos(Input.GetTouch(1).position,Input.GetTouch(1).phase==TouchPhase.Moved);
			}
		}
	}
	private void SetOldPos(Vector2 Pos)
	{
		if(Pos.x>HalfWidth)
		{
			ROldPos = Pos;
			RTimeCount = 0;
		}
		else
		{
			LOldPos = Pos;
			LTimeCount = 0;
		}
	}
	private void SetPos(Vector2 Pos)
	{
		if(Pos.x>HalfWidth)
		{
			RPos = Pos;
			localEventManager.Attack();
		}
		else
		{
			LPos = Pos;
			MoveVector = LPos - LOldPos;
			localEventManager.Move(MoveVector.x,MoveVector.y);
		}
	}
	private void EndPos(Vector2 Pos,bool Moved)
	{
		if(Pos.x>HalfWidth)
		{
			if(!Moved){return;}
			if(Pos.x-ROldPos.x>0)
			{
				if(Pos.y-ROldPos.y>0)
				{
					localEventManager.ThrowRightward();
				}
				else
				{
					localEventManager.SpecialRightward();
				}
			}
			else
			{
				if(Pos.y-ROldPos.y>0)
				{
					localEventManager.ThrowLeftward();
				}
				else
				{
					localEventManager.SpecialLeftward();
				}
			}
			RTimeCount=-1f;
		}
		else
		{
			if(!Moved){return;}
			if(Pos.x-LOldPos.x>0)
			{
				if(Pos.y-LOldPos.y>0)
				{
					localEventManager.JumpRightward();
				}
				else
				{
					localEventManager.DodgeRightward();
				}
			}
			else
			{
				if(Pos.y-LOldPos.y>0)
				{
					localEventManager.JumpLeftward();
				}
				else
				{
					localEventManager.DodgeLeftward();
				}
			}
			LTimeCount=-1f;
		}

	}
}
