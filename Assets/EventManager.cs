using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager{
	public List<Player> PlayerList;
	public List<Enemy> EnemyList;
	private EventManager(){}
	private static EventManager _eventManager;
	public static EventManager eventManager
	{
		get{
			if(_eventManager==null){_eventManager = new EventManager();}
			return _eventManager;
		}
	}
	public delegate void DamageCheckEventHandler(EquipmentStatus Equip,Vector3 Pos,int Direct);
	public event DamageCheckEventHandler DamageCheckEvent;
	public void DamageCheck(EquipmentStatus Equip,Vector3 Pos,int Direct)
	{
		DamageCheckEvent(Equip,Pos,Direct);
	}
	public delegate void TiggerCheckEventHandler(Vector3 Pos);
	public event TiggerCheckEventHandler TiggerCheckEvent;
	public void TiggerCheck(Vector3 Pos)
	{
		if(GameManager.InputEnable)
		{
			TiggerCheckEvent(Pos);
		}
	}
}
