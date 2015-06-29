using UnityEngine;
using System.Collections;

public class OnGround : CharacterStatus {
	private enum Status
	{
		Normal,
		Attack,
		Dodge,
		BeHit,
	}
	private Status status;
	private float NextAttackTimeCount = 0;
	private CharacterBase characterBase;
	public OnGround(CharacterBase temp,string StatusTemp){
		characterBase = temp;
		switch (StatusTemp) {
		case "Noraml":
			status = Status.Normal;
			break;
		case "Attack":
			status = Status.Attack;
			break;
		case "Dodge":
			status = Status.Dodge;
			break;
		case "BeHit":
			status = Status.BeHit;
			break;
		}
	}
	public void Enter()
	{
		
	}
	public string Exit()
	{
		switch (status) {
		case Status.Attack:
			return "Attack";
			break;
		case Status.BeHit:
			return "BeHit";
			break;
		case Status.Dodge:
			return "Dodge";
			break;
		default:
			return "Normal";
			break;
		}
	}
	public void Attack()
	{
		if(status==Status.Normal||status==Status.Attack)
		{
			status=Status.Attack;
			characterBase.UpperAnim.CrossFade("Attack");
			EventManager.eventManager.DamageCheck(characterBase.equipmentStatus,characterBase.DownCollider.transform.position,characterBase.direct==CharacterBase.Direct.FaceRight?1:-1);
		}
	}
	public void Move(float x,float y){
		switch (status) {
		case Status.Attack:
			if(x==0&&y==0)
			{
				characterBase.FeetAnim.CrossFade("idle");
			}
			else
			{
				characterBase.FeetAnim.CrossFade("walk");
			}
			break;
		case Status.BeHit:
			characterBase.FeetAnim.CrossFade("idle");
			break;
		case Status.Dodge:
			characterBase.FeetAnim.CrossFade("idle");
			break;
		default:
			if(x==0&&y==0)
			{
				characterBase.UpperAnim.CrossFade("idle");
				characterBase.FeetAnim.CrossFade("idle");
			}
			else
			{
				characterBase.UpperAnim.CrossFade("walkidle");
				characterBase.FeetAnim.CrossFade("walk");
			}
			if(x>0&&characterBase.direct==CharacterBase.Direct.FaceLeft)
			{
				characterBase.FaceRight();
			}
			if(x<0&&characterBase.direct==CharacterBase.Direct.FaceRight)
			{
				characterBase.FaceLeft();
			}
			characterBase.DownCollider.rigidbody2D.velocity = new Vector2(x,y).normalized*characterBase.characterAttributes.Speed;
			break;
		}

	}
	public void Jump(){
		characterBase.UpperAnim.CrossFade("Jump");
		characterBase.UpBody.rigidbody2D.velocity = new Vector2(0,characterBase.characterAttributes.JumpSpeed);
		characterBase.localEventManager.ChangeToAir();
	}
	public void JumpForward(){
		characterBase.UpperAnim.CrossFade("Jump");
		float Speed = characterBase.characterAttributes.JumpSpeed;
		characterBase.UpBody.rigidbody2D.velocity = new Vector2(characterBase.direct==CharacterBase.Direct.FaceRight?Speed:-Speed,Speed);
		characterBase.localEventManager.ChangeToAir();
	}
	public void JumpBackward(){
		characterBase.UpperAnim.CrossFade("Jump");
		float Speed = characterBase.characterAttributes.JumpSpeed;
		characterBase.UpBody.rigidbody2D.velocity = new Vector2(characterBase.direct==CharacterBase.Direct.FaceRight?-Speed:Speed,Speed);
		characterBase.localEventManager.ChangeToAir();
	}
	public void DodgeForward(){
		
	}
	public void DodgeBackward(){
		
	}
	public void ThrowForward(){
		
	}
	public void ThrowBackward(){
		
	}
	public void SpecialForward(){
		
	}
	public void SpecialBackward(){
		
	}
	public void Update()
	{
		switch (status) {
		case Status.Attack:
			if(NextAttackTimeCount>0){NextAttackTimeCount-=Time.deltaTime;}
			if(!characterBase.UpperAnim.isPlaying)
			{
				status=Status.Normal;
			}
			break;
		case Status.BeHit:
			if(!characterBase.UpperAnim.isPlaying)
			{
				status=Status.Normal;
			}
			break;
		case Status.Dodge:
			if(!characterBase.UpperAnim.isPlaying)
			{
				status=Status.Normal;
			}
			break;
		default:

			break;
		}
	}
}
