using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	Vector3 worldPosition; // For movement
    Vector2 mapPosition;
 	public float speed;   // Speed of movement
    public GridMap map;
     
    void Start () {
        // Take the initial position
        mapPosition = map.ToMapPosition(transform.position);
        worldPosition = map.ToWorldPosition(mapPosition);
    }

    void FixedUpdate () {
        if(Input.GetKey(KeyCode.A) && map.ToWorldPosition(mapPosition) == worldPosition) {        // Left
            mapPosition += Vector2.left;
            worldPosition = map.ToWorldPosition(mapPosition);
        }
        if(Input.GetKey(KeyCode.D) &&  map.ToWorldPosition(mapPosition) == worldPosition) {        // Right
            mapPosition += Vector2.right;
            worldPosition = map.ToWorldPosition(mapPosition);
        }
        if(Input.GetKey(KeyCode.S) &&  map.ToWorldPosition(mapPosition) == worldPosition) {        // Up
            mapPosition += Vector2.up;
            worldPosition = map.ToWorldPosition(mapPosition);
        }
        if(Input.GetKey(KeyCode.W) &&  map.ToWorldPosition(mapPosition) == worldPosition) {        // Down
            mapPosition += Vector2.down;
            worldPosition = map.ToWorldPosition(mapPosition);
        }
        transform.position = Vector3.MoveTowards(transform.position, worldPosition, Time.deltaTime * speed);    // Move there
    }
}
