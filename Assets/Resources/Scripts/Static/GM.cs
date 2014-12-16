using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// Game Manager
public class GM : MonoBehaviour {
	public static GameObject playerPrefab;
	private static Dictionary<string, int> scenes = new Dictionary<string, int>();
	private static Player _player;
	public static Player player{ get{ return _player; } set{ _player = value; } }

	public static void FirstTimeInit () {
		// Load all needed JSON files from the HDD and cache them in memory
		FM.Load();

		// Cache the scene name mapping so we can call the build setting index by scene name
		CacheSceneNameMapping();

		// Load the player prefab from file and initialize it in game
		GM.playerPrefab = (GameObject)Instantiate( Resources.Load("Prefabs/Characters/Player/player") );

		// Map the actual player component to the GM.player namespace
		GM.player = GM.playerPrefab.GetComponent<Player>();

		// Move the player to the start position of the menu
		GM.player.transform.position = new Vector3(-5, 0, 0);

		// Ensure the player component parent game object is not destroyed when we change scenes
		DontDestroyOnLoad(GM.player.gameObject);
	}

	public static void LoadNode (string node_name) {
		// Cache the node we are moving to as the current node and save the game state
		FM.cache["game"]["current_node"] = node_name;
		FM.Save();

		// Get the scene name at the current node the player is at
		string scene_name = FM.nav["nodes"][node_name]["scene"];

		// Load the scene by index
		Application.LoadLevel( scenes[scene_name] );
	}

	public static string CurrentNode () {
		// Get the navigation node currently cached for the player
		return FM.Parse( FM.cache["game"]["current_node"] );
	}

	private static void CacheSceneNameMapping () {
		// These mappings map a string name to the scene index in the Unity build settings. This
		// ensures we can easily load a scene by a custom string name we give it.
		scenes.Add("main_menu", 0);
		scenes.Add("test_town", 1);
	}	
}