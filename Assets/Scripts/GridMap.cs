using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GridMap : MonoBehaviour {
	public int width;
	public int height;
	public float sideLength;
	public Dictionary<string, GridNode> nodes;

	private GridNode[,] grid;

	// Use this for initialization
	void Start () {
		grid = new GridNode[width, height];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Set (Vector2 pos, GridNode n) {
		grid [(int) pos.x, (int) pos.y] = n;
	}

	public GridNode At(Vector2 pos) {
		return grid [(int) pos.x, (int) pos.y];
	}

	public Vector2 ToMapPosition(Vector3 worldPosition) {
		return new Vector2(
			Mathf.Floor(worldPosition.x + 0.5f * width * sideLength + transform.position.x),
			Mathf.Floor(worldPosition.y - 0.5f * height * sideLength + transform.position.y)
		);
	}

	public Vector3 ToWorldPosition(Vector2 mapPosition) {
		return new Vector3(
			(mapPosition.x + transform.position.x - 0.5f * width) * sideLength,
			(mapPosition.y + transform.position.y - 0.5f * height) * sideLength,
			0
		);
	}
}
