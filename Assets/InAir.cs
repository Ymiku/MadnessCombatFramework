using UnityEngine;
using System.Collections;

public class InAir : CharacterStatus {
	private enum Status
	{
		Normal,
		Attack,
		Dodge,
		BeHit,
	}
	private Status status;
	private CharacterBase characterBase;
	private bool JumpBool = false;
	public InAir(CharacterBase temp,string StatusTemp){
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

	}
	public void Move(float x,float y){
		characterBase.DownCollider.rigidbody2D.velocity = new Vector2(x,y).normalized*characterBase.characterAttributes.Speed/2f;
	}
	public void Jump(){
		if(!JumpBool)
		{
			characterBase.UpBody.rigidbody2D.velocity = new Vector2(0,characterBase.characterAttributes.JumpSpeed);
			JumpBool=true;
		}
	}
	public void JumpForward(){

	}
	public void JumpBackward(){

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

	}
}
