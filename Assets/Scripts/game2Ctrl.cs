using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class game2Ctrl : MonoBehaviour {
	public GameObject ring;
	public GameObject nextBtn;
	public Book book;

	public GameObject bar;
	private float barLenght;
	private RectTransform barTr;

	private bool gameInProgress = true;

	private static int score = 0;
	private float ringsCount = 10.0f;

	// Use this for initialization
	void Start () {
		barTr = bar.GetComponent<RectTransform> ();
		barLenght = barTr.sizeDelta.x;
		barTr.sizeDelta = new Vector2 (0.0f, barTr.sizeDelta.y);

		nextBtn.SetActive(false);

		StartCoroutine (SpawnRings());
	}

	IEnumerator SpawnRings () {
		while (gameInProgress) {
			Vector3 spawnPosition = new Vector3(0, 0, -3);
			Quaternion spawnRotation = Quaternion.identity;
			GameObject newRing = Instantiate(ring, spawnPosition, spawnRotation) as GameObject;
			newRing.transform.parent = gameObject.transform;

			yield return new WaitForSeconds(2);
		}
	}

	public void SetScore () {
		score++;
		SetBar ((float)score / ringsCount);
		if (score == (int)ringsCount) {
			gameInProgress = false;
			nextBtn.SetActive(true);
			book.ShowWon ();
		}
	}

	public void SetBar (float pr) {
		barTr.sizeDelta = new Vector2 (Mathf.Min(barLenght * pr, barLenght), barTr.sizeDelta.y);
	}
}
