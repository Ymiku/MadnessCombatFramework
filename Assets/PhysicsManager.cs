using UnityEngine;
using System.Collections;

public class PhysicsManager : MonoBehaviour {
	public GameObject character;
	[SerializeField]
	private Transform UpBodyTrans;
	[SerializeField]
	private Transform DownColliderTrans;
	[SerializeField]
	private float Distance;
	private enum PlayerStatus
	{
		OnGround,
		InAir,
		Climbing
	}
	CharacterManager characterManager;
	[SerializeField]
	private PlayerStatus playerStatus;
	// Use this for initialization

	void Start () {
		UpBodyTrans = character.transform.Find("UpBody");
		DownColliderTrans = character.transform.Find("DownCollider");
		playerStatus = PlayerStatus.InAir;
		Distance = 1000;
		characterManager = character.GetComponent<CharacterManager>();
		characterManager.localEventManager.ChangeToAirEvent+= delegate {playerStatus = PlayerStatus.InAir;};
		characterManager.localEventManager.ChangeToGroundEvent+= delegate {playerStatus = PlayerStatus.OnGround;};
	}

	void Update () {
		switch (playerStatus) {
		case PlayerStatus.OnGround:
			UpBodyTrans.position=new Vector3(transform.position.x,DownColliderTrans.position.y+Distance,DownColliderTrans.position.y);
			break;
		case PlayerStatus.InAir:
			if(Distance<100)
			{
				if(UpBodyTrans.position.y-DownColliderTrans.position.y<Distance)
				{
					characterManager.localEventManager.BackToGround();
					UpBodyTrans.position=new Vector3(transform.position.x,DownColliderTrans.position.y+Distance,DownColliderTrans.position.y);
				}
				else
				{
					UpBodyTrans.position=new Vector3(transform.position.x,UpBodyTrans.position.y,DownColliderTrans.position.y);
				}
			}
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if((Distance>100)&&(collider.transform==UpBodyTrans))
		{
			Distance = UpBodyTrans.position.y-DownColliderTrans.position.y;
		}
	}
}
