using UnityEngine;
using System.Collections;

public class EquipmentStatus  {
	// Use this for initialization
	public bool IsArea;
	public GameObject BulletPrefab;
	public enum EquipType
	{
		EmptyHand,
		Sword,
		Gun,
		Other
	}
	public enum EquipSize
	{
		Small,
		Medium,
		Big
	}
	public EquipType equipType;
	public EquipSize equipSize;
	public float Length;
	public Vector2 Range;
	public EquipmentStatus(string ThisType,string ThisSize)
	{
		switch(ThisType) {
		case "EmptyHand":
			equipType=EquipType.EmptyHand;
			break;
		case "Sword":
			equipType=EquipType.Sword;
			break;
		case "Gun":
			equipType=EquipType.Gun;
			break;
		default:
			equipType=EquipType.Other;
			break;
		}
		switch (ThisSize) {
		case "Small":
			equipSize=EquipSize.Small;
			break;
		case "Medium":
			equipSize=EquipSize.Medium;
			break;
		case "Big":
			equipSize=EquipSize.Big;
			break;
		default:
			break;
		}
	}
	public void ChangeTo(EquipmentStatus temp)
	{
		equipType = temp.equipType;
		equipSize = temp.equipSize;
		Length = temp.Length;
		if(IsArea){Range = temp.Range;}
		else{BulletPrefab = temp.BulletPrefab;}
	}
}
