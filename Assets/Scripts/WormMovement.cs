using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour {
	/* This script is attached to the worm and will follow the player around at a set speed */

	// public variables to set some of the position data
	public float HandHeight = -0.2f; // relative to the player's head
	public float RotationSpeed = 0.5f;

	// this is the player so that the worm can follow them
	public Transform PlayerPosition;

	private float teleportationDelay = 15;
	private float teleportationTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame, which should be 90 fps but varies when the computer is too slow
	void FixedUpdate () {
		teleportationTimer += Time.deltaTime;

		if (teleportationTimer >= teleportationDelay) {
			moveHand();
			teleportationTimer = 0;
		}

		// rotate the hand in the direction set by the position
		transform.Rotate(Vector3.up * RotationSpeed);
	}

	void moveHand () {
		// go to a random point on the map
		transform.position = new Vector3(
			PlayerPosition.position.x - 2,
			PlayerPosition.position.y + 1.5f,
			PlayerPosition.position.z - 2
		);
	}
}
