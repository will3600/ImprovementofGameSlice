using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    // Time for animation to take place
    private float animationDuration = 1.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

	// Use this for initialization
	void Start ()
    {
        // Finds the players position 
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        // The StartOffset value, the cameras position less the lookAt position
        startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Starts the camera further behind from the characters position
        moveVector = lookAt.position + startOffset;

        // Permanent X position of the camera
        moveVector.x = 0;

        // Y position can only move within two meters
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if (transition > 1.0f)
        {
            // Normal gameplay camera throughout game
            transform.position = moveVector;
        }
        else
        {
            // Animation for camera at start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            // The camera descending on the character
            transition += Time.deltaTime * 1 / animationDuration;
            // Camera moving back to the normal position
            transform.LookAt(lookAt.position + Vector3.up);
        }
	}
}
