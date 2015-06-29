using UnityEngine;
using System.Collections;

public class GravityManager : MonoBehaviour {
	public GameObject UpBodyObj;
	public delegate void ChangeStatusDelegate();
	public ChangeStatusDelegate BackToGround;
	public ChangeStatusDelegate Jump;
	// Use this for initialization
	void Start () {


	}
	

	void Update () {
		UpBodyObj.transform.position=new Vector3(transform.position.x,UpBodyObj.transform.position.y,0);
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject==UpBodyObj)
		{
			BackToGround();
		}
	}


	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject==UpBodyObj)
		{
			UpBodyObj.rigidbody2D.gravityScale=1;
		}
	}
}
