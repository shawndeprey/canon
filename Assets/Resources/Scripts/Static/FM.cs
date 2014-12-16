using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;

// http://wiki.unity3d.com/index.php/SimpleJSON
// http://stackoverflow.com/questions/21114891/save-changes-to-json-with-simplejson

// File Manager
public class FM : MonoBehaviour {
	public static SimpleJSON.JSONNode cache;
	public static SimpleJSON.JSONNode nav;

	public static void Load () {
		// Load from file the json for the save file
		string json = System.IO.File.ReadAllText(@".\Assets\Resources\Store\savefile.json");

		// Parse and cache the game save file.
		FM.cache = JSON.Parse( json );

		// Load from file the json for the nav file
		json = System.IO.File.ReadAllText(@".\Assets\Resources\Store\navnodes.json");

		// Parse and cache  the navigation file.
		FM.nav = JSON.Parse( json );
	}

	public static void Save () {
		// Write the cached save file to the HDD
		System.IO.File.WriteAllText(@".\Assets\Resources\Store\savefile.json", FM.cache.ToString());
	}

	public static void Reset () {
		// Load the default JSON save data
		string json = System.IO.File.ReadAllText(@".\Assets\Resources\Store\defaults.json");

		// Parse the JSON file into the applications static cache.
		FM.cache = JSON.Parse(json);

		// Save the file to overwrite the old save file
		FM.Save();
	}

	public static string Parse (SimpleJSON.JSONNode node) {
		return node.ToString().Replace("\"", "");
	}

	public static int ParseInt (SimpleJSON.JSONNode node) {
		return Convert.ToInt32( FM.Parse(node) );
	}
}