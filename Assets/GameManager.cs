using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameObject Player;
	public enum GameMode
	{
		StoryMode,
		RandomMode
	}
	public static GameMode gameMode=GameMode.RandomMode;
	public static bool InputEnable=true;
	public static int direct = 10;
	public SceneManager[] _Scene;
	public static SceneManager[] Scene;
	public static int SceneCount;
	public static int ThisSceneNum = 0;
	public static int LastSceneNum = 0;
	void Start () {
		Scene = _Scene;
		SceneCount = Scene.Length;
		if(gameMode==GameMode.RandomMode)
		{
			ThisSceneNum = Random.Range(0,SceneCount);
			Scene[ThisSceneNum].Enter(100);
		}
	}
	public static SceneManager CreatScene()
	{
		GameManager.LastSceneNum=GameManager.ThisSceneNum;
		do {
			ThisSceneNum = Random.Range(0,SceneCount);
		} while (ThisSceneNum==LastSceneNum);
		return Scene[ThisSceneNum];
	}
	// Update is called once per frame
	void Update () {

	}
}
