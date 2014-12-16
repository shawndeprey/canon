using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private float walkSpeed = 4;
	private Animator anim;
	private string currentAnim = "idle_down";

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
		// Perform character movement
		MovePlayer();
	}

	private void MovePlayer () {
		float horizontal = 0;
		float vertical = 0;

		if( IsMoving() ) {
			if(Input.GetKey("left")) {
				horizontal = -1;
			}

			if(Input.GetKey("right")) {
				horizontal = 1;
			}

			if(Input.GetKey("down")) {
				vertical = -1;
			}

			if(Input.GetKey("up")) {
				vertical = 1;
			}

			// Correct diagnal movement logical error common with top down 2D movement systems 
			if( (Input.GetKey("down") && Input.GetKey("right")) || (Input.GetKey("down") && Input.GetKey("left")) || (Input.GetKey("up") && Input.GetKey("right")) || (Input.GetKey("up") && Input.GetKey("left")) ) {
				vertical = vertical / 1.25f;
				horizontal = horizontal / 1.25f;
			}
		}

		rigidbody2D.velocity = new Vector2(Mathf.Lerp(0, horizontal * walkSpeed, 0.8f), Mathf.Lerp(0, vertical * walkSpeed, 0.8f));
	}

	private bool IsMoving () {
		return (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("down") || Input.GetKey("up"));
	}

	public void ToggleActionIndicator (bool status) {
		transform.Find("ActionIndicator").gameObject.SetActive(status);
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