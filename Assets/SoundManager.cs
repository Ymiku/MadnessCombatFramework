using UnityEngine;
//using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioClip[] OtherAudioClip;
	public AudioClip[] SwordAudioClip;
	public AudioClip[] GunAudioClip;
	public static SoundManager soundManager
	{
		get{
			if(soundManager==null)
			{
				soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
			}
			return soundManager;
		}
		set{
			soundManager = value;
		}
	}

}
