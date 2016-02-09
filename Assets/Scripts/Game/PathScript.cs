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
	private Color c1;
	private Color c2;
	private Color c3;
	private Color c4;
	private GameObject inkBarObject;
	private GameObject soundsAndMusic;
	
	void Start () {
		inkBarObject = GameObject.FindGameObjectWithTag ("InkBarReact");
		soundsAndMusic = GameObject.FindGameObjectWithTag ("SoundsAndMusic");
		lineStack = inkBarObject.GetComponent<InkBarScript> ().GetInkStack();
		isMousePressed = false;
		c1 = new Color32 (254,224,32,200);
		c2 = new Color32 (178,2,25,200);
		c3 = new Color32 (0,156,184,255); 
		c4 = new Color32 (0,102,51,255);
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
						lineRenderer.SetColors (c1, c2);
					} else {
						soundsAndMusic.GetComponent<SoundsAndMusicScript>().NoInkAudio(transform);
					}
				} else if (Input.GetMouseButtonUp (0)) {
					isMousePressed = false;
					if (drawPoints.Count > 0) { // pokial je drawPoint prazdny collider sa nevytvara
						AddColliderToDraw (); // pridanie collideru pre ciaru
					}
					drawPoints.Clear ();
					inkBarObject.GetComponent<InkBarScript> ().Hit (lineLength);
					if (lineRenderer != null) { // po navrate z pauzy do hry hadzalo problem
						lineRenderer.SetColors (c3, c4);
					}

					lineStack -= lineLength; // odpocitanie od zasobniku
					lineLength = 0f; // vynulovanie dlzky ciary pre meranie novej ciary
				}
				
				if (isMousePressed) {
					mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					if (!drawPoints.Contains (mousePos)) {
						drawPoints.Add (mousePos);
						lineRenderer.SetVertexCount (drawPoints.Count);
						lineRenderer.SetPosition (drawPoints.Count - 1, mousePos);
						if (drawPoints.Count >= 2) {
							lineLength += Vector2.Distance (drawPoints [drawPoints.Count - 2], mousePos); // length of line
						}
					}
				} 
		}
	}

	public void AddColliderToDraw() {
		EdgeCollider2D col = new GameObject("EdgeCollider").AddComponent<EdgeCollider2D> ();
		col.tag = "LineDraw";
		col.transform.parent = lineDrawPrefab.transform;

		//col.transform.parent = lineRenderer.transform; // Collider is added as child object of line

		col.points = drawPoints.ToArray();
	}
}

/*public Color c1 = Color.white;
public Color c2 = new Color(1, 1, 1, 0);
void Start() {
	LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
	lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
	lineRenderer.SetColors(c1, c2);
}*/