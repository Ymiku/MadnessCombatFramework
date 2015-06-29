using UnityEngine;
using System.Collections;

public class CharacterAttributes : MonoBehaviour {
	private int MaxHealth = 3;
	public int Health = 3;
	public int Strength = 1;
	public int Speed = 3;
	public int JumpSpeed = 6;
	public int intelligence = 100;
	[SerializeField]
	internal Sprite LeftHead;
	[SerializeField]
	internal Sprite RightHead;
	[SerializeField]
	internal Sprite LeftBody;
	[SerializeField]
	internal Sprite RightBody;
	// Use this for initialization
	void Start () {
		MaxHealth = Health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
