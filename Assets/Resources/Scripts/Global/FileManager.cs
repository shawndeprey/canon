using UnityEngine;
using System.Collections;
using SimpleJSON;

/*
	Access Cache: 	FileManager.cache["settings"]["volume"]
	Load Cache: 	FileManager.Load();
	Save Cache: 	FileManager.Save();
	Credit: 		http://wiki.unity3d.com/index.php/SimpleJSON
					http://stackoverflow.com/questions/21114891/save-changes-to-json-with-simplejson
*/

public class FileManager : MonoBehaviour {
	public static SimpleJSON.JSONNode cache;
	public static SimpleJSON.JSONNode nav;

	public static void Load () {
		string json = System.IO.File.ReadAllText(@".\Assets\Resources\Store\savefile.json");
		// Load and cache the game save file.
		FileManager.cache = JSON.Parse( json );

		json = System.IO.File.ReadAllText(@".\Assets\Resources\Store\navnodes.json");
		// Load and cache  the navigation file.
		FileManager.nav = JSON.Parse( json );
	}

	public static void Save () {
		System.IO.File.WriteAllText(@".\Assets\Resources\Store\savefile.json", FileManager.cache.ToString());
	}

	public static void Reset () {
		// Load the default JSON save data
		string json = System.IO.File.ReadAllText(@".\Assets\Resources\Store\defaults.json");

		// Parse the JSON file into the applications static cache.
		FileManager.cache = JSON.Parse(json);

		// Save the file to overwrite the old save file
		FileManager.Save();
	}

	public static void Log (string message) {
		#if UNITY_EDITOR
			Debug.Log(message);
		#else
			Application.ExternalCall("console.log", message);
		#endif
	}
}
