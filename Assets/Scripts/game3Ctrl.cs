using UnityEngine;
using System.Collections;

public class game3Ctrl : MonoBehaviour {
	public GameObject nextBtn;
	public Book book;

	static int score = 0;
	private int rosesCount = 14;

	// Use this for initialization
	void Start () {
		nextBtn.SetActive(false);
	}

	public void AddScore () {
		score++;
		if (score == rosesCount) {
			nextBtn.SetActive(true);
			book.ShowWon ();
		}
	}
}
