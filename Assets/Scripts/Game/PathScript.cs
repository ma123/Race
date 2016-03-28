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
	private float lineLength = 0f; 
	public float lineStack = 0f;
	private Color c1, c2;
	private GameObject inkBarObject;
	private GameObject soundsAndMusic;
	private GameObject oldEdge = null;
	private int edgeCounter = 0;
	
	void Start () {
		inkBarObject = GameObject.FindGameObjectWithTag ("InkBarReact");
		soundsAndMusic = GameObject.FindGameObjectWithTag ("SoundsAndMusic");
		lineStack = inkBarObject.GetComponent<InkBarScript> ().GetInkStack();
		isMousePressed = false;
		c1 = new Color32 (0,156,184,255); 
		c2 = new Color32 (0,102,51,255);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale != 0) {
			lineStack = inkBarObject.GetComponent<InkBarScript> ().GetInkStack();

				if (Input.GetMouseButtonDown (0)) {
					if (lineStack > 0f) {
						isMousePressed = true;

						lineDrawPrefab = GameObject.Instantiate (lineDrawPrefabs) as GameObject;
						lineRenderer = lineDrawPrefab.GetComponent<LineRenderer> ();
						lineRenderer.SetVertexCount (0);
					    drawPoints.RemoveRange(0,drawPoints.Count);  // pridane
					    lineRenderer.SetColors (c1, c2);
					} else {
						soundsAndMusic.GetComponent<SoundsAndMusicScript>().NoInkAudio(transform);
					}
				} else if (Input.GetMouseButtonUp (0)) {
			    	edgeCounter++;
				    isMousePressed = false;
					drawPoints.Clear ();
				}
				
				if (isMousePressed) {
					if (lineStack > 0f) {
						mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						if (!drawPoints.Contains (mousePos)) {
							drawPoints.Add (mousePos);
							lineRenderer.SetVertexCount (drawPoints.Count);
							lineRenderer.SetPosition (drawPoints.Count - 1, mousePos);
							if (drawPoints.Count >= 2) {
								lineLength = Vector2.Distance (drawPoints [drawPoints.Count - 2], mousePos); // length of line
							    inkBarObject.GetComponent<InkBarScript> ().Hit (lineLength);
							    lineStack -= lineLength;
							    
							    AddColliderToDraw();
							}
						}
					} 
				} 
		}
	}

	public void AddColliderToDraw() {
		if(oldEdge != null) {
			if(oldEdge.name == "EdgeCollider" + edgeCounter) {
			   Destroy (oldEdge);
			}
		}
		GameObject col = new GameObject("EdgeCollider" + edgeCounter);//.AddComponent<EdgeCollider2D> ();
		col.AddComponent<EdgeCollider2D>();
		col.tag = "LineDraw";
		col.transform.parent = lineDrawPrefab.transform;
		col.GetComponent<EdgeCollider2D>().points = drawPoints.ToArray();
		oldEdge = col;
	}
}
