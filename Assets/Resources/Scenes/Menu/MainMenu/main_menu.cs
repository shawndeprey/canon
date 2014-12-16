using UnityEngine;
using System.Collections;

public class main_menu : MonoBehaviour {
	void Start () {
		// Run initial load functionality for the game
		GM.FirstTimeInit();
	}

	public void NewGame () {
		// Rebuild the save file cache from the default json file
		FM.Reset();
		ContinueGame();
	}

	public void ContinueGame () {
		// Load the node set as the current user navigation node
		GM.LoadNode( GM.CurrentNode() );
	}

	public void ExitGame () {
		Application.Quit();
	}
}