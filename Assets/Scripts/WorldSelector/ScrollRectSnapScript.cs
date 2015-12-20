using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollRectSnapScript : MonoBehaviour {
	public RectTransform panel;
	public Button[] bttns;
	public RectTransform center;

	private float[] distance;
	private bool dragging = false;
	private int bttnDistance;
	private int minBtnNum;

	void Start () {
		int bttnLength = bttns.Length;
		distance = new float[bttnLength];

		bttnDistance = (int) Mathf.Abs (bttns[1].GetComponent<RectTransform>().anchoredPosition.x - bttns[0].GetComponent<RectTransform>().anchoredPosition.x);
	}

	void Update () {
		for (int i = 0 ; i < bttns.Length; i++) {
			distance[i] = Mathf.Abs(center.transform.position.x - bttns[i].transform.position.x);
		}

		float minDistance = Mathf.Min (distance);

		for(int a = 0; a < bttns.Length; a++) {
			if(minDistance == distance[a]) {
				minBtnNum = a;
			}
		}

		if(!dragging) {
			LerpToBttn(minBtnNum * -bttnDistance);
		}
	} 

	void LerpToBttn(int position) {
		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 10f);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);
		panel.anchoredPosition = newPosition;
	}

	public void StartDrag() {
		dragging = true;
	}

	public void EndDrag() {
		dragging = false;
	}
}
