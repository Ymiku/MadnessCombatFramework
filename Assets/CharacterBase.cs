using UnityEngine;
using System.Collections;

public class CharacterBase {
	// Use this for initialization
	private SpriteRenderer HeadSprite;
	private SpriteRenderer BodySprite;
	internal GameObject DownCollider;
	internal GameObject UpBody;
	internal Animation UpperAnim;
	internal Animation FeetAnim;
	internal LocalEventManager localEventManager;
	internal CharacterAttributes characterAttributes;
	private CharacterStatus characterStatus;
	internal EquipmentStatus equipmentStatus;
	private enum PlayerStatus
	{
		OnGround,
		InAir,
		Climbing
	}
	internal enum Direct
	{
		FaceLeft,
		FaceRight,
		Other
	}
	internal Direct direct = Direct.FaceRight;
	private GameObject characterObj;
	public CharacterBase(GameObject This)
	{
		characterObj = This;
		UpBody = This.transform.Find("UpBody").gameObject;
		DownCollider = This.transform.Find("DownCollider").gameObject;
		UpperAnim = This.transform.Find("UpBody/Upper").GetComponent<Animation>();
		FeetAnim = This.transform.Find("UpBody/Upper/Feet").GetComponent<Animation>();
		HeadSprite = This.transform.Find("UpBody/Upper/Head").GetComponent<SpriteRenderer>();
		BodySprite = This.transform.Find("UpBody/Upper/Body").GetComponent<SpriteRenderer>();
		characterAttributes = This.GetComponent<CharacterAttributes>();
		localEventManager = This.GetComponent<CharacterManager>().localEventManager;
		equipmentStatus = new EquipmentStatus("EmptyHand","Small"){Range=new Vector2(1,1)};
		characterStatus = new InAir(this,"Normal");
		characterStatus.Enter();
		EventManager.eventManager.DamageCheckEvent+=DamageCheck;
		localEventManager.ChangeToAirEvent+=ChangeToAir;
		localEventManager.ChangeToGroundEvent+=ChangeToGround;
		localEventManager.JumpEvent += Jump;
		localEventManager.MoveEvent += Move;
		localEventManager.AttackEvent += Attack;
		localEventManager.JumpLeftwardEvent += JumpLeftward;
		localEventManager.JumpRightwardEvent += JumpRightward;
		localEventManager.DodgeLeftwardEvent += DodgeLeftward;
		localEventManager.DodgeRightwardEvent += DodgeRightward;
		localEventManager.ThrowLeftwardEvent += ThrowLeftward;
		localEventManager.ThrowRightwardEvent += ThrowRightward;
		localEventManager.SpecialLeftwardEvent += SpecialLeftward;
		localEventManager.SpecialRightwardEvent += SpecialRightward;
	}
	public void ChangeToGround()
	{
		string status = characterStatus.Exit();
		characterStatus = new OnGround(this,status);
		characterStatus.Enter();
	}
	public void ChangeToAir()
	{
		string status = characterStatus.Exit();
		characterStatus = new InAir(this,status);
		characterStatus.Enter();
	}
	public void FaceLeft()
	{
		UpBody.transform.localScale=new Vector3(-1f,1f,1f);
		HeadSprite.sprite = characterAttributes.LeftHead;
		BodySprite.sprite = characterAttributes.LeftBody;
		direct=Direct.FaceLeft;
	}
	public void FaceRight()
	{
		UpBody.transform.localScale=new Vector3(1f,1f,1f);
		HeadSprite.sprite = characterAttributes.RightHead;
		BodySprite.sprite = characterAttributes.RightBody;
		direct=Direct.FaceRight;
	}
	public void DamageCheck(EquipmentStatus Equip,Vector3 Pos,int Direct)
	{
		Vector3 MyPos = DownCollider.transform.position;
		switch (Equip.equipType) {
		case EquipmentStatus.EquipType.EmptyHand:
			if(Direct==1)
			{
				if(MyPos.x>Pos.x&&MyPos.x<Pos.x+Equip.Range.x&&MyPos.y>Pos.y-Equip.Range.y/2&&MyPos.y<Pos.y+Equip.Range.y/2)
				{

				}
			}
			else
			{
				if(MyPos.x>Pos.x-Equip.Range.x&&MyPos.x<Pos.x&&MyPos.y>Pos.y-Equip.Range.y/2&&MyPos.y<Pos.y+Equip.Range.y/2)
				{

				}
			}
			break;
		case EquipmentStatus.EquipType.Gun:

			break;
		case EquipmentStatus.EquipType.Sword:

			break;
		case EquipmentStatus.EquipType.Other:
			
			break;
		}
	}
	public void Attack()
	{
		characterStatus.Attack();
	}
	public void Move(float x,float y){
		characterStatus.Move(x,y);
	}
	public void Jump(){
		characterStatus.Jump();
	}
	public void JumpLeftward(){
		if(direct==Direct.FaceLeft){characterStatus.JumpForward();}
		else{characterStatus.JumpBackward();}
	}
	public void JumpRightward(){
		if(direct==Direct.FaceRight){characterStatus.JumpForward();}
		else{characterStatus.JumpBackward();}
	}
	public void DodgeLeftward(){
		if(direct==Direct.FaceLeft){characterStatus.DodgeForward();}
		else{characterStatus.DodgeBackward();}
	}
	public void DodgeRightward(){
		if(direct==Direct.FaceRight){characterStatus.DodgeForward();}
		else{characterStatus.DodgeBackward();}
	}
	public void ThrowLeftward(){
		if(direct==Direct.FaceLeft){characterStatus.ThrowForward();}
		else{characterStatus.ThrowBackward();}
	}
	public void ThrowRightward(){
		if(direct==Direct.FaceRight){characterStatus.ThrowForward();}
		else{characterStatus.ThrowBackward();}
	}
	public void SpecialLeftward(){
		if(direct==Direct.FaceLeft){characterStatus.SpecialForward();}
		else{characterStatus.SpecialBackward();}
	}
	public void SpecialRightward(){
		if(direct==Direct.FaceRight){characterStatus.SpecialForward();}
		else{characterStatus.SpecialBackward();}
	}
	public void Update () {
		characterStatus.Update();
	}
}
