using UnityEngine;
using System.Collections;

public class game3Ctrl : MonoBehaviour {
	public GameObject nextBtn;
	public Book book;

	static int score = 0;
	private int rosesCount = 14;

	public GameObject bar;
	private float barLenght;
	private RectTransform barTr;

	// Use this for initialization
	void Start () {
		nextBtn.SetActive(false);

		barTr = bar.GetComponent<RectTransform> ();
		barLenght = barTr.sizeDelta.x;
		barTr.sizeDelta = new Vector2 (0.0f, barTr.sizeDelta.y);
	}

	public void AddScore () {
		score++;
		SetBar ((float)score / rosesCount);
		if (score == rosesCount) {
			nextBtn.SetActive(true);
			book.ShowWon ();
		}
	}

	public void SetBar (float pr) {
		barTr.sizeDelta = new Vector2 (barLenght * pr, barTr.sizeDelta.y);
	}
}
