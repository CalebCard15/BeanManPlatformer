﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public float xMargin = 1f;		        // Distance in the x axis the player can move before the camera follows.
	public float yMargin = 1f;		        // Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 2f;		        // How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 2f;		        // How smoothly the camera catches up with it's target movement in the y axis.
    public float teleSmoothX = 10f;         // How smoothly the camera catches up with it's target movement when teleporting in the x axis
    public float teleSmoothY = 10f;         // How smoothly the camera catches up with it's target movement when teleporting in the y axis
	public Vector2 maxXAndY;		        // The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY;		        // The minimum x and y coordinates the camera can have.


	private Transform player;		        // Reference to the player's transform.
    private PlayerControl playerControl;    // Reference to the player's contoller for knowing when the player is teleporting


	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
        playerControl = player.GetComponent<PlayerControl>();
      
	}


	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}


	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}


	void FixedUpdate ()
	{
        if(playerControl.isTeleporting)
        {
            TrackTeleport();
        }
        else
        {
            TrackPlayer();
        }
		
	}
	
	
	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		// If the player has moved beyond the x margin...
		if(CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);

		// If the player has moved beyond the y margin...
		if(CheckYMargin())
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}

	//Used when the player is teleporting to make the camera move to the player faster
	//This makes sure the player can see where they are going because the teleport moves the player very quickl
    void TrackTeleport()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        // If the player has moved beyond the x margin...
        if(CheckXMargin())
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, player.position.x, teleSmoothX * Time.deltaTime);

        // If the player has moved beyond the y margin...
        if(CheckYMargin())
            // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
            targetY = Mathf.Lerp(transform.position.y, player.position.y, teleSmoothY * Time.deltaTime);

        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

}
