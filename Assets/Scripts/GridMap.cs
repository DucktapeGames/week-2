using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GridMap : MonoBehaviour {
	public int width;
	public int height;
	public float sideLength;
	public GridNode[,] grid;

	// Use this for initialization
	void Start () {
		grid = new GridNode[width, height];

		for(var i = 0; i < width; i++) {
			for(var j = 0; j < height; j++) {
				grid[i, j] = new GridNode();
				grid[i, j].type = GridNode.NodeType.Walkable;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Set (Vector2 pos, GridNode n) {
		grid [(int) pos.x, (int) pos.y] = n;
	}

	public GridNode At(Vector2 pos) {
		if(pos.x >= width || pos.y >= height || pos.x < 0 || pos.y < 0) {
			var emptyNode = new GridNode();
			emptyNode.type = GridNode.NodeType.Obstacle;
			return emptyNode;
		}
		return grid [(int) pos.x, (int) pos.y];
	}

	public Vector2 ToMapPosition(Vector3 worldPosition) {
        return new Vector2(
            (int) (((worldPosition.x - transform.position.x) / sideLength) + width * 0.5f),
            (int) (height * 0.5f - ((worldPosition.y - transform.position.y) / sideLength))
        );
    }

    public Vector3 ToWorldPosition(Vector2 mapPosition) {
        return new Vector3(
            transform.position.x + (mapPosition.x - width * 0.5f) * sideLength,
            transform.position.y + (height * 0.5f - mapPosition.y) * sideLength,
            0
        );
    }

	void OnDrawGizmos() {
		for(int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				Gizmos.DrawWireCube(ToWorldPosition(new Vector2(i, j)), Vector3.one * sideLength);
			}
		}
	}
}
