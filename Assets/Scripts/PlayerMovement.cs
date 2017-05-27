using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	Vector3 worldPosition; // For movement
    Vector2 mapPosition;
 	public float speed;   // Speed of movement
    public GridMap map;
    bool flag = false;
     
    void Start () {
        // Take the initial position
        mapPosition = map.ToMapPosition(transform.position);
        worldPosition = map.ToWorldPosition(mapPosition);
        StartCoroutine(DetectInput());
    }

    void FixedUpdate () {
         transform.position = Vector3.MoveTowards(transform.position, worldPosition, Time.deltaTime * speed);
    }

    IEnumerator DetectInput() {
        while(true) {
            if(Input.GetKey(KeyCode.A) && map.ToWorldPosition(mapPosition) == worldPosition && !flag) {       // Left
               if(map.At(mapPosition + Vector2.left).IsWalkable()) {
                    mapPosition += Vector2.left;
                    worldPosition = map.ToWorldPosition(mapPosition);
                    flag = true;
               }
            }
            else if(Input.GetKey(KeyCode.D) &&  map.ToWorldPosition(mapPosition) == worldPosition && !flag) {        // Right
                if(map.At(mapPosition + Vector2.right).IsWalkable()) {
                    mapPosition += Vector2.right;
                    worldPosition = map.ToWorldPosition(mapPosition);
                    flag = true;
                }
            }
            else if(Input.GetKey(KeyCode.S) &&  map.ToWorldPosition(mapPosition) == worldPosition && !flag) {        // Up
                if(map.At(mapPosition + Vector2.up).IsWalkable()) {
                    mapPosition += Vector2.up;
                    worldPosition = map.ToWorldPosition(mapPosition);
                    flag = true;
                }
            }
            else if(Input.GetKey(KeyCode.W) &&  map.ToWorldPosition(mapPosition) == worldPosition && !flag) {        // Down
                if(map.At(mapPosition + Vector2.down).IsWalkable()) {
                    mapPosition += Vector2.down;
                    worldPosition = map.ToWorldPosition(mapPosition);
                    flag = true;
                }
            }

            if((transform.position - worldPosition).magnitude < 0.02) {
                flag = false;
            }
        
            yield return new WaitForSeconds(0.1f);
        }
    }
}
