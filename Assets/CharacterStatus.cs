using UnityEngine;
using System.Collections;

public interface CharacterStatus{
	void Enter();
	string Exit();
	void Attack();
	void Move(float x,float y);
	void Jump();
	void JumpForward();
	void JumpBackward();
	void DodgeForward();
	void DodgeBackward();
	void ThrowForward();
	void ThrowBackward();
	void SpecialForward();
	void SpecialBackward();
	void Update();
}
