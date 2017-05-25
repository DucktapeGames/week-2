using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public Vector2 target;
	public GridMap map;
	public float speed;

	private Animator animator;
	private List<Vector3> path;
	private Vector2 oldTarget;
	private int part;
	private Vector2 position;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		part = 0;
		oldTarget = target;
		position = map.ToMapPosition (transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (target != oldTarget) {
			path = FindPath ();
			part = 0;
		}

		if (part < path.Count) {
			var sqrDistance = (transform.position - path [part]).sqrMagnitude;

			if (sqrDistance > 1f) {
				transform.position += (path [part] - transform.position).normalized 
					* speed 
					* Time.deltaTime;
			} else {
				part++;
				position = map.ToMapPosition (transform.position);
			}
		}
	}

	// Implements A* to pathfind using Euclidian heuristics
	private List<Vector3> FindPath() {
		var pq = new List<Path> ();
		var visited = new HashSet<Vector2> ();
		var start = new Path (position, null, 1, 1 + (target - position).magnitude);
		var result = new List<Vector3> ();

		visited.Add (position);
		pq.Add (start);

		while (pq.Capacity > 0) {
			// Get the smallest
			var current = pq [0];
			var lastPos = current.head;

			//Check if path found
			if ((target - lastPos).sqrMagnitude == 0) {
				// Rebuild path as list of positions
				while (current != null) {
					// Inserts path to list from destination to origin
					path.Add (map.ToWorldPosition (current.head));
					current = current.tail;
				}

				// Invert the list to correct the order
				path.Reverse ();

				break;
			}

			// Order heap
			pq [0] = pq [pq.Count - 1];
			pq.RemoveAt (pq.Count - 1);
			SiftDown (pq);

			// Validate top coord
			if (lastPos.y - 1 >= 0) {
				var top = new Vector2 (lastPos.x, lastPos.y - 1);

				// Check if not visited and walkable
				if (!visited.Contains (top) && map.At (top).IsWalkable ()) {
					// Create path
					var estimate = current.length + 1 + (target - top).magnitude;
					var next = new Path (top, current, current.length + 1, estimate);

					//Add to heap
					pq.Add (next);

					//Order heap
					SiftUp(pq);
				}
			}

			// Validate left coord
			if (lastPos.x - 1 >= 0) {
				var left = new Vector2 (lastPos.x - 1, lastPos.y);

				// Check if not visited and walkable
				if (!visited.Contains (left) && map.At (left).IsWalkable ()) {
					// Create path
					var estimate = current.length + 1 + (target - left).magnitude;
					var next = new Path (left, current, current.length + 1, estimate);

					//Add to heap
					pq.Add (next);

					//Order heap
					SiftUp(pq);
				}
			}

			// Validate right coord
			if (lastPos.x + 1 < map.width) {
				var right = new Vector2 (lastPos.x + 1, lastPos.y);

				// Check if not visited and walkable
				if (!visited.Contains (right) && map.At (right).IsWalkable ()) {
					// Create path
					var estimate = current.length + 1 + (target - right).magnitude;
					var next = new Path (right, current, current.length + 1, estimate);

					//Add to heap
					pq.Add (next);

					//Order heap
					SiftUp(pq);
				}
			}

			// Validate bottom coord
			if (lastPos.y + 1 < map.height) {
				var bottom = new Vector2 (lastPos.x, lastPos.y + 1);

				// Check if not visited and walkable
				if (!visited.Contains (bottom) && map.At (bottom).IsWalkable ()) {
					// Create path
					var estimate = current.length + 1 + (target - bottom).magnitude;
					var next = new Path (bottom, current, current.length + 1, estimate);

					//Add to heap
					pq.Add (next);

					//Order heap
					SiftUp(pq);
				}
			}
		}

		return result;
	}

	// Priority queue methods

	private void Swap(List<Path> pq, int l, int r) {
		var tmp = pq [l];
		pq [l] = pq [r];
		pq [r] = tmp;
	}

	private void SiftDown(List<Path> pq) {
		var i = 0;
		var next = (2 * i) + 1;

		while (next < pq.Count && pq [i].estimate > pq [next].estimate) {
			Swap (pq, i, next);
			i = next;
			next = (2 * i) + 1;
		}
	}

	private void SiftUp(List<Path> pq) {
		var i = pq.Count - 1;
		var prev = (i - 1) / 2;

		while ( prev >= 0 && pq [i].estimate > pq [prev].estimate) {
			Swap (pq, i, prev);
			i = prev;
			prev = (i - 1) / 2;
		}
	}

	private class Path {
		public Vector2 head;
		public Path tail;
		public int length;
		public float estimate;

		public Path(Vector2 head, Path tail, int length, float estimate) {
			this.head = head;
			this.tail = tail;
			this.length = length;
			this.estimate = estimate;
		}
	}

	// End priority queue methods
}