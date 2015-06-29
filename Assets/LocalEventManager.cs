using UnityEngine;
using System.Collections;

public class LocalEventManager {
	public delegate void ChangeStatus();

	public event ChangeStatus ChangeToGroundEvent;
	public event ChangeStatus ChangeToAirEvent;
	public void ChangeToAir(){ChangeToAirEvent();}
	public void BackToGround(){ChangeToGroundEvent();}

	public delegate void TouchEventHandler();
	public event TouchEventHandler JumpEvent;
	public event TouchEventHandler AttackEvent;
	public void Jump(){
		if(GameManager.InputEnable)JumpEvent();
	}
	public void Attack(){if(GameManager.InputEnable)AttackEvent();}

	public delegate void SlipEventHandler();
	public event SlipEventHandler JumpLeftwardEvent;
	public event SlipEventHandler JumpRightwardEvent;
	public event SlipEventHandler DodgeLeftwardEvent;
	public event SlipEventHandler DodgeRightwardEvent;
	public event SlipEventHandler ThrowLeftwardEvent;
	public event SlipEventHandler ThrowRightwardEvent;
	public event SlipEventHandler SpecialLeftwardEvent;
	public event SlipEventHandler SpecialRightwardEvent;
	public void JumpLeftward(){if(GameManager.InputEnable)JumpLeftwardEvent();}
	public void JumpRightward(){if(GameManager.InputEnable)JumpRightwardEvent();}
	public void DodgeLeftward(){if(GameManager.InputEnable)DodgeLeftwardEvent();}
	public void DodgeRightward(){if(GameManager.InputEnable)DodgeRightwardEvent();}
	public void ThrowLeftward(){if(GameManager.InputEnable)ThrowLeftwardEvent();}
	public void ThrowRightward(){if(GameManager.InputEnable)ThrowRightwardEvent();}
	public void SpecialLeftward(){if(GameManager.InputEnable)SpecialLeftwardEvent();}
	public void SpecialRightward(){if(GameManager.InputEnable)SpecialRightwardEvent();}

	public delegate void MoveEventHandler(float x,float y);
	public event MoveEventHandler MoveEvent;
	public void Move(float x,float y){
		if(GameManager.InputEnable)
		{MoveEvent(x,y);}else{MoveEvent(0,0);}
	}
}
