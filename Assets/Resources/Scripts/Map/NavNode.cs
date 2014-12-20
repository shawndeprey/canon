using UnityEngine;
using System.Collections;

public class NavNode : MonoBehaviour {
	public string nodeName;
	private bool checkInput = false;
	private bool performedAction = false;

	void OnTriggerEnter2D () {
		GM.player.ToggleActionIndicator(true);
		checkInput = true;
	}

	void OnTriggerExit2D () {
		GM.player.ToggleActionIndicator(false);
		checkInput = false;
	}

	void Update () {
		// Animation Selection Logic
		if( !performedAction && checkInput && Input.GetKey("z") ) {
			performedAction = true;
			GM.player.ToggleActionIndicator(false);
			GM.LoadNode(nodeName);
		}
	}
}