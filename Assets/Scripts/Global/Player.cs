using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private float walkSpeed = 4;
	private Animator anim;
	private string currentAnim = "idle_down";
	public string currentNode = "main_menu_1";

	void Start () {
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		// Animation Selection Logic
		if( IsMoving() ) {
			if(Input.GetKey("left")) {
				currentAnim = "run_left";
			} else
			if(Input.GetKey("right")) {
				currentAnim = "run_right";
			} else
			if(Input.GetKey("down")) {
				currentAnim = "run_down";
			} else
			if(Input.GetKey("up")) {
				currentAnim = "run_up";
			}
		} else {
			currentAnim = currentAnim.Replace("run", "idle");
		}
			
		// Send the current animation to the animator
		anim.Play(currentAnim);
	}

	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * walkSpeed, 0.8f), Mathf.Lerp(0, Input.GetAxis("Vertical") * walkSpeed, 0.8f));
	}

	private bool IsMoving () {
		return (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("down") || Input.GetKey("up"));
	}

	public void MoveToNode (string name) {
		currentNode = name;
		// Load the correct scene
	}

	public void SetFacing (int direction) {
		if(direction == 0) {
			currentAnim = "idle_up";
		} else
		if(direction == 1) {
			currentAnim = "idle_right";
		} else
		if(direction == 2) {
			currentAnim = "idle_down";
		} else
		if(direction == 3) {
			currentAnim = "idle_left";
		}
	}
}