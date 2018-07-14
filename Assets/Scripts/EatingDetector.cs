using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingDetector : MonoBehaviour {
    public List<AudioClip> EatingSounds;
    public List<AudioClip> DrinkingSounds;
    public List<AudioClip> WormEatingSounds;

    public bool TouchingFood = false;
    public bool TouchingWater = false;
    public bool TouchingWorm = false;

    private AudioSource audioSource;
    private int soundIndex = 0;

	// Use this for initialization
	void Awake () {
        // assign the audio source as itself
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Food") {
            // this variable is for use with health tracking
            TouchingFood = true;
            // select a random sound from the list of sounds and then play it
            soundIndex = Random.Range(1, EatingSounds.Count + 1);
            audioSource.PlayOneShot(EatingSounds[soundIndex]);
        }
        else if(other.gameObject.name == "Water") {
            TouchingWater = true;
            soundIndex = Random.Range(1, DrinkingSounds.Count + 1);
            audioSource.PlayOneShot(DrinkingSounds[soundIndex]);
        }
        else if(other.gameObject.name == "Worm") {
            TouchingWorm = true;
            soundIndex = Random.Range(1, WormEatingSounds.Count + 1);
            audioSource.PlayOneShot(WormEatingSounds[soundIndex]);
        }
    }

    void OnTriggerExit(Collider other) {
        TouchingFood = false;
        TouchingWater = false;
        TouchingWorm = false;
    }
}