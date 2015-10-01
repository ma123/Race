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
	public float lineStack = 100f;
	public GameObject inkStackObject;
	
	void Start () {
		inkStackObject = GameObject.FindGameObjectWithTag ("InkStack");
		inkStackObject.GetComponent<InkStackScript> ().SetInkStack (lineStack);
		isMousePressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale != 0) {
			if(lineStack >= 0f) {
				if(Input.GetMouseButtonDown(0)) {
					isMousePressed = true;

					lineDrawPrefab = GameObject.Instantiate(lineDrawPrefabs) as GameObject;
					lineRenderer = lineDrawPrefab.GetComponent<LineRenderer>();
					lineRenderer.SetVertexCount(0);

				} else if(Input.GetMouseButtonUp(0)) {
					isMousePressed = false;
					if(drawPoints.Count > 0) { // pokial je drawPoint prazdny collider sa nevytvara
						AddColliderToDraw(); // pridanie collideru pre ciaru
					}
					inkStackObject.GetComponent<InkStackScript>().Hit(lineLength);

					lineStack -= lineLength; // odpocitanie od zasobniku
					lineLength = 0f; // vynulovanie dlzky ciary pre meranie novej ciary
					drawPoints.Clear ();
				}
				
				if(isMousePressed) {
					mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					if (!drawPoints.Contains (mousePos)) {
						drawPoints.Add (mousePos);
						lineRenderer.SetVertexCount (drawPoints.Count);
						lineRenderer.SetPosition(drawPoints.Count - 1, mousePos);
						if(drawPoints.Count >= 2) {
							lineLength += Vector2.Distance (drawPoints[drawPoints.Count - 2], mousePos); // length of line
						}
					}
				}
			}
		}
	}

	public void AddColliderToDraw() {
		EdgeCollider2D col = new GameObject("Collider").AddComponent<EdgeCollider2D> ();
		//col.transform.parent = lineRenderer.transform; // Collider is added as child object of line

		col.points = drawPoints.ToArray();
	}
}