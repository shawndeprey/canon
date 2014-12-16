using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

	void Start () {
		// Initialize the player position based on the node they are moving to
		// First we get the node the player is currently at
		string current = GM.CurrentNode();

		// Then we get the position data for that node from the nav file
		int x = FM.ParseInt( FM.nav["nodes"][current]["x"] );
		int y = FM.ParseInt( FM.nav["nodes"][current]["y"] );
		int facing = FM.ParseInt( FM.nav["nodes"][current]["facing"] );

		// We then set the direction the player is facing based on the node data
		GM.player.SetFacing( facing );

		// We also set the x/y position of the player based on the node data
		GM.player.transform.position = new Vector3(x, y, 0);

		// Finally we run the init callback so maps can do their individual initialization
		Init();
	}

	protected virtual void Init () { }
}
