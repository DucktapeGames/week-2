using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

	public Vector2 target;
	public GridMap map;
	public float speed;
	public float movementEpsilon;
	public bool drawDebugPath;

	private int part;
	private bool shouldMove;
	private Animator animator;
	private List<Vector2> path;
	private Vector2 oldTarget;
	private Vector2 position;
	private Vector3 nextPoint;

	public bool HasReachedWaypoint () {
		if (path != null && path.Count > 0) {
			return part == path.Count;
		}

		return false;
	}

	public void Stop () {
		shouldMove = false;
	}

	public void Begin () {
		shouldMove = true;
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		part = 0;
		position = map.ToMapPosition(transform.position);
		shouldMove = true;
		oldTarget = new Vector2(-1, -1);
	}
	
	// Update is called once per frame
	void Update () {
		if(shouldMove) {
			if(target != oldTarget) {
				path = FindPath ();
				part = 0;
				oldTarget = target;
				nextPoint = map.ToWorldPosition(path[part]);
			}

			if(drawDebugPath) {
				Debug.DrawRay(transform.position, nextPoint - transform.position);
				for(int i = part + 1; i < path.Count; i++) {
					Debug.DrawRay(map.ToWorldPosition(path[i - 1]), map.ToWorldPosition(path[i]) - map.ToWorldPosition(path[i - 1]));
				}
			}

			if(path != null && part < path.Count) {
				var sqrDistance = (transform.position - nextPoint).sqrMagnitude;

				if (sqrDistance > movementEpsilon) {
					transform.position += (nextPoint - transform.position).normalized
					* speed
					* Time.deltaTime;
				} else {
					position = path[part];
					part++;
					
					if(part < path.Count) {
						nextPoint = map.ToWorldPosition(path[part]);
					}
				}
			}
		}
	}

	// Implements A* to pathfind using Euclidian heuristics
	private List<Vector2> FindPath() {
		var pq = new List<Path> ();
		var visited = new HashSet<Vector2> ();
		var start = new Path (position, null, 0, (target - position).magnitude);
		var result = new List<Vector2> ();
		Path best = null;

		pq.Add (start);

		while (pq.Count > 0) {
			// Get the smallest
			var current = pq[0];
			var lastPos = current.head;

			// Track visited
			visited.Add(lastPos);

			// Order heap
			pq[0] = pq[pq.Count - 1];
			pq.RemoveAt(pq.Count - 1);
			SiftDown(pq);

			// Bound tree when estimate is not better the best solution so far
			if(best == null || current.estimate < best.estimate) {

				// Check if path found
				if(target == lastPos) {
					best = current;
				}

				// Validate top coord
				if(lastPos.y - 1 >= 0) {
					var top = new Vector2(lastPos.x, lastPos.y - 1);

					// Check if not visited and walkable
					if(!visited.Contains(top) && map.At(top).IsWalkable()) {
						// Create path
						var estimate = current.length + 1 + (target - top).magnitude;
						var next = new Path (top, current, current.length + 1, estimate);

						//Add to heap
						pq.Add(next);

						//Order heap
						SiftUp(pq);
					}
				}

				// Validate left coord
				if(lastPos.x - 1 >= 0) {
					var left = new Vector2 (lastPos.x - 1, lastPos.y);

					// Check if not visited and walkable
					if(!visited.Contains(left) && map.At(left).IsWalkable()) {
						// Create path
						var estimate = current.length + 1 + (target - left).magnitude;
						var next = new Path(left, current, current.length + 1, estimate);

						//Add to heap
						pq.Add (next);

						//Order heap
						SiftUp(pq);
					}
				}

				// Validate right coord
				if(lastPos.x + 1 < map.width) {
					var right = new Vector2(lastPos.x + 1, lastPos.y);

					// Check if not visited and walkable
					if (!visited.Contains(right) && map.At(right).IsWalkable()) {
						// Create path
						var estimate = current.length + 1 + (target - right).magnitude;
						var next = new Path(right, current, current.length + 1, estimate);

						//Add to heap
						pq.Add(next);

						//Order heap
						SiftUp(pq);
					}
				}

				// Validate bottom coord
				if(lastPos.y + 1 < map.height) {
					var bottom = new Vector2 (lastPos.x, lastPos.y + 1);

					// Check if not visited and walkable
					if(!visited.Contains(bottom) && map.At(bottom).IsWalkable()) {
						// Create path
						var estimate = current.length + 1 + (target - bottom).magnitude;
						var next = new Path(bottom, current, current.length + 1, estimate);

						//Add to heap
						pq.Add(next);

						//Order heap
						SiftUp(pq);
					}
				}
			}
		}

		// Rebuild path as list of positions
		while(best != null) {
			//Debug.Log(best.head);
			// Inserts path to list from destination to origin
			result.Add(best.head);
			best = best.tail;
		}

		// Remove starting position from path. We are already there
		result.RemoveAt(result.Count -1);

		// Invert the list to correct the order
		result.Reverse();

		return result;
	}

	// -- Start priority queue methods -- //
	private void Swap(List<Path> pq, int l, int r) {
		var tmp = pq [l];
		pq [l] = pq [r];
		pq [r] = tmp;
	}

	private void SiftDown(List<Path> pq) {
		var i = 0;
		var l = (2 * i) + 1;
		var r = l + 1;
		var s = r < pq.Count && pq[r].estimate < pq[l].estimate ? r : l;

		while (s < pq.Count && pq[i].estimate > pq[s].estimate) {
			Swap (pq, i, s);
			i = s;
			l = (2 * i) + 1;
			r = l + 1;
			s = r < pq.Count && pq[r].estimate < pq[l].estimate ? r : l;
		}
	}

	private void SiftUp(List<Path> pq) {
		var i = pq.Count - 1;
		var prev = (i - 1) / 2;

		while ( prev >= 0 && pq [i].estimate < pq [prev].estimate) {
			Swap (pq, i, prev);
			i = prev;
			prev = (i - 1) / 2;
		}
	}
	// -- End priority queue methods -- //

	// Linked list data stucture that track a path
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
}