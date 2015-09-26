using UnityEngine;
using System.Collections;

public class PathScriptLine : MonoBehaviour {
	private Vector2 mousePos;
	private Vector2 startPos;	// Start position of line
	private Vector2 endPos;	// End position of line
	private LineRenderer line; // Reference to LineRenderer
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			if(line == null)
				createLine();
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				line.SetPosition(0,mousePos);
				startPos = mousePos;
		}
		else if(Input.GetMouseButtonUp(0))
		{
			if(line)
			{
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				line.SetPosition(1,mousePos);
				endPos = mousePos;
				addColliderToLine();
				line = null;
			}
		}
		else if(Input.GetMouseButton(0))
		{
			if(line)
			{
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				line.SetPosition(1,mousePos);
			}
		}
	}
	
	// Following method creates line runtime using Line Renderer component
	private void createLine()
	{
		line = new GameObject("Line").AddComponent<LineRenderer>();
		line.material =  new Material(Shader.Find("Diffuse"));
		line.SetVertexCount(2);
		line.SetWidth(0.1f,0.1f);
		line.SetColors(Color.white, Color.black);
		line.useWorldSpace = true;  
		DestroyObject (line,10f);
	}
	
	private void addColliderToLine()
	{
		BoxCollider2D col = new GameObject("Collider").AddComponent<BoxCollider2D> ();
		col.transform.parent = line.transform; // Collider is added as child object of line
		float lineLength = Vector2.Distance (startPos, endPos); // length of line
		col.size = new Vector2 (lineLength, 0.1f); // size of collider is set where X is length of line, Y is width of line
		Vector2 midPoint = (startPos + endPos)/2;
		col.transform.position = midPoint; // setting position of collider object
		// Following lines calculate the angle between startPos and endPos
		float angle = (Mathf.Abs (startPos.y - endPos.y) / Mathf.Abs (startPos.x - endPos.x));
		if((startPos.y<endPos.y && startPos.x>endPos.x) || (endPos.y<startPos.y && endPos.x>startPos.x))
		{
			angle*=-1;
		}
		angle = Mathf.Rad2Deg * Mathf.Atan (angle);
		col.transform.Rotate (0, 0, angle);
	}
}