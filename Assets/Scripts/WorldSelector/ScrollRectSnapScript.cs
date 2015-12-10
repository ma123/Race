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
	// Use this for initialization
	void Start () {
		int bttnLength = bttns.Length;
		distance = new float[bttnLength];

		bttnDistance = (int) Mathf.Abs (bttns[1].GetComponent<RectTransform>().anchoredPosition.x - bttns[0].GetComponent<RectTransform>().anchoredPosition.x);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
