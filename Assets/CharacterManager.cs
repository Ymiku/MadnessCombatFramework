using UnityEngine;
using System.Collections;
[RequireComponent(typeof(InputManager),typeof(CharacterAttributes))]
public class CharacterManager : MonoBehaviour {
	public enum CharacterType
	{
		Player,
		Friend,
		Enemy,
		Boss
	}
	public CharacterType Type;
	private CharacterBase character;
	private CharacterAttributes characterAttributes;
	public LocalEventManager localEventManager;
	private PhysicsManager physicsManager;
	private InputManager inputManager;
	// Use this for initialization
	void Awake()
	{
		localEventManager = new LocalEventManager();
		physicsManager = transform.Find("DownCollider").GetComponent<PhysicsManager>();
		physicsManager.character = gameObject;
		characterAttributes = GetComponent<CharacterAttributes>();
		inputManager = GetComponent<InputManager>();
		inputManager.localEventManager = localEventManager;
		if(Type!=CharacterType.Player)
		{
			transform.Find("UpBody").GetComponent<AudioListener>().enabled = false;
			inputManager.enabled=false;
		}
		switch (Type) {
		case CharacterType.Player:
			character=new Player(gameObject);
			GameManager.Player=transform.Find("DownCollider").gameObject;
			break;
		case CharacterType.Enemy:
			character=new Enemy(gameObject);
			break;
		}
	}
	void Update()
	{
		character.Update();
	}
}
