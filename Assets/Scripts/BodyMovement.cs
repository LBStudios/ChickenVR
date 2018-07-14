using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour {
    public GameObject Head;
    public float NeckHeight;

    private float teleportationThreshold = 2;

    private Vector3 lastPosition;
	private float bodyHeight;

	// Use this for initialization
	void Start () {
		ResetBody();
	}

	// Update is called once per frame
	void Update () {
        // if the person teleports they should lose some food

        if(Input.GetKey(KeyCode.H)) {
            ResetBody();
        }

        transform.position = new Vector3(Head.transform.position.x, Head.transform.position.y - (bodyHeight/2) - NeckHeight, Head.transform.position.z);
		transform.eulerAngles = new Vector3(0, Head.transform.eulerAngles.y, 0);
	}

    private void LateUpdate() {
        lastPosition = transform.position;
    }

    private void ResetBody() {
        bodyHeight = Head.transform.position.y - NeckHeight;
        transform.localScale = new Vector3(bodyHeight, bodyHeight, bodyHeight);
    }
}