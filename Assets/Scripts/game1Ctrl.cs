using UnityEngine;
using System.Collections;

public class game1Ctrl : MonoBehaviour {
	public GameObject nextBtn;
	public Book book;
	static int score = 0;

	public void AddScore() {
		score++;
		if (score == 3) {
			win ();
		}
	}

	// Use this for initialization
	void Start () {
		nextBtn.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void win () {
		nextBtn.SetActive(true);
		book.ShowWon ();
	}
}
