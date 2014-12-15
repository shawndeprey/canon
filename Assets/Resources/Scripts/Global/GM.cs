using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GM : MonoBehaviour {
	public static GameObject playerPrefab;
	private static Dictionary<string, int> scenes = new Dictionary<string, int>();
	private static Player _player;
	public static Player player{ get{ return _player; } set{ _player = value; } }

	public static void Init () {
		FileManager.Load();
		CacheSceneNameMapping();
		GM.playerPrefab = (GameObject)Instantiate( Resources.Load("Prefabs/Characters/Player/player") );
		GM.player = GM.playerPrefab.GetComponent<Player>();
		DontDestroyOnLoad(GM.player.gameObject);
	}

	public static void InitLevel () {
		int x = Convert.ToInt32( FileManager.nav["nodes"][player.currentNode]["x"].ToString().Replace("\"", "") );
		int y = Convert.ToInt32( FileManager.nav["nodes"][player.currentNode]["y"].ToString().Replace("\"", "") );
		int facing = Convert.ToInt32( FileManager.nav["nodes"][player.currentNode]["facing"].ToString().Replace("\"", "") );
		player.SetFacing( facing );
		player.transform.position = new Vector3(x, y, 0);
	}

	public static void LoadScene (string name) {
		// Cache data and save when changing scenes
		FileManager.cache["game"]["current_scene"] = name;
		FileManager.Save();

		// Load the scene by index
		Application.LoadLevel(scenes[name]);
	}

	private static void CacheSceneNameMapping () {
		scenes.Add("main_menu", 0);
		scenes.Add("test_town", 1);
	}	
}