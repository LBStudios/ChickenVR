using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// used for VR controller input
using HTC.UnityPlugin.Vive;

public class EggLaying : MonoBehaviour {
    public GameObject Egg;

    // how long the person has to wait in between laying eggs
    public float EggLayingDelay = 1;

    private bool inCoop = false;
    private float eggLayingTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // update the timer
        eggLayingTimer += Time.deltaTime;

        // we're using viveInput plugin for VR controller input
        if (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Trigger) || ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger)) {
            if (inCoop) {
                if (eggLayingTimer >= EggLayingDelay) {
                    layEgg();
                }
            }
        }
    }

    private void layEgg () {
        // instantiate the egg
        Instantiate(Egg, transform.position, transform.rotation);
    }

    private void OnTriggerEnter (Collider collision) {
        if(collision.gameObject.name == "Henhouse") {
            // when the player is 'colliding' with the coop, turn on this variable
            inCoop = true;
        }
    }

    private void OnTriggerExit (Collider collision) {
        if(collision.gameObject.name == "Henhouse") {
            inCoop = false;
        }
    }
}
