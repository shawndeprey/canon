using UnityEngine;
using System.Collections;

public class SceneFading : MonoBehaviour {
	public Texture2D fadeOutTexture;
	private float fadeSpeed = 0.9f;
	private float alpha = 1.0f;
	private int fadeDir = -1;

	void OnGUI()
	{
		// fade out/in the alpha value using a direction, a speed and Time.deltaTime to convert the operation to seconds
		alpha += fadeDir * fadeSpeed * Time.deltaTime;

		// force (clamp) the number to be between 0 and 1 because GUI.color uses Alpha values between 0 and 1
		alpha = Mathf.Clamp01(alpha);

		// If the fading is in transition then draw GUI elements, otherwise send the GUI to the back
		if(alpha > 0) {
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.depth = -1000;																	// make the black texture render on top (drawn last)
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);		// draw the texture to fit the entire screen area
		} else {
			GUI.depth = 1000;
		}
	}

	// OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes.
	void OnLevelWasLoaded()
	{
		fadeDir = -1;
	}

	public void InitSceneTransition (int sceneIndex) {
		StartCoroutine( ChangeScene(sceneIndex) );
	}

	IEnumerator ChangeScene (int sceneIndex) {
		fadeDir = 1;
		yield return new WaitForSeconds( GM.fade.fadeSpeed );
		Application.LoadLevel( sceneIndex );
	}
}
