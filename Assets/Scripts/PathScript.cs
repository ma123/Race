using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathScript : MonoBehaviour {
	public GameObject lineDrawPrefabs;
	private bool isMousePressed;
	private GameObject lineDrawPrefab;

	private LineRenderer lineRenderer;
	private List<Vector2> drawPoints = new List<Vector2>();
	private Vector2 mousePos;
	private Vector2 startPos;	// Start position of line
	private Vector2 endPos;	// End position of line
	private LineRenderer line; // Reference to LineRenderer
	private bool drawPermision = true;
	
	void Start () {
		isMousePressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(drawPermision) {
			if(Input.GetMouseButtonDown(0)) {
				isMousePressed = true;

				lineDrawPrefab = GameObject.Instantiate(lineDrawPrefabs) as GameObject;
				lineRenderer = lineDrawPrefab.GetComponent<LineRenderer>();
				lineRenderer.SetVertexCount(0);
			} else if(Input.GetMouseButtonUp(0)) {
				// left mouse up, stop drawing
				isMousePressed = false;

				AddColliderToDraw();
				drawPoints.Clear ();
			}
			
			if(isMousePressed) {
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				if (!drawPoints.Contains (mousePos)) {
					drawPoints.Add (mousePos);
					lineRenderer.SetVertexCount (drawPoints.Count);
					lineRenderer.SetPosition(drawPoints.Count - 1, mousePos);
				}
			}
		}
	}

	public void AddColliderToDraw() {
		EdgeCollider2D col = new GameObject("Collider").AddComponent<EdgeCollider2D> ();
		//col.transform.parent = lineRenderer.transform; // Collider is added as child object of line

		col.points = drawPoints.ToArray();
	}

	public void SetDrawPermision(bool drawPermision) {
		this.drawPermision = drawPermision;
	}
}