using UnityEngine;

public class GridNode {
	public Sprite sprite;
	public NodeType type;

	public bool IsWalkable() {
		return type == NodeType.Walkable;
	}

	public enum NodeType {
		Walkable,
		Obstacle
	}
}
