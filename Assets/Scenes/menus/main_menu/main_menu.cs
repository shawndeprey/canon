using UnityEngine;
using System.Collections;

public class main_menu : MonoBehaviour {
	void Start () {
		GM.Init();
		GM.InitLevel();
	}

	public void NewGame () {
		FileManager.Reset();
		ContinueGame();
	}

	public void ContinueGame () {
		GM.LoadScene( FileManager.cache["game"]["current_scene"] );
	}

	public void ExitGame () {
		Application.Quit();
	}
}