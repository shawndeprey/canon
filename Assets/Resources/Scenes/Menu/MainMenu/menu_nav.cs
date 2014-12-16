using UnityEngine;
using System.Collections;

public class menu_nav : MonoBehaviour {
	private bool checkActionStatus = false;
	private bool performedAction = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!performedAction && checkActionStatus && Input.GetKey("z")){
			performedAction = true;
			print("actioned");
		}
	}

	void OnTriggerEnter2D () {
		print("entered");
		checkActionStatus = true;
		GM.player.ToggleActionIndicator(true);
	}

	void OnTriggerExit2D () {
		print("exit");
		checkActionStatus = false;
		GM.player.ToggleActionIndicator(false);
	}
}
