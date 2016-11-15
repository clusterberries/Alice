using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class Book : MonoBehaviour {
    public int page;
    public GameObject[] pages;

	public GameObject youWon;
	private Transform wonTr = null;
	private bool showWon = false;

	private bool effect = false;
	private float effecttimer = 2;
	private Blur blur;

	private AudioSource forestAudio;

	// Use this for initialization
	void Start () {
        page = 0;
		blur = Camera.main.GetComponent<Blur> ();
		blur.iterations = 0;
		wonTr = youWon.GetComponent<Transform> ();
		AudioSource[] audios = GetComponents<AudioSource>();
		forestAudio = audios[1];
	}
	
	// Update is called once per frame
	void Update () {
		if (effect) {
			// Calculate value of current iteration
			int iterations = (int) Mathf.Round( effecttimer * (-5.0f) + 10.0f ) * 2;
			// If iterations less than 10 that means blur is getting more intense. 
			// Otherwise it should decrease.
			blur.iterations = iterations <= 10 ? iterations : 20 - iterations;
			effecttimer -= Time.deltaTime;
			
			if (effecttimer < 0) {
				playAudio ();
				effect = false;
				effecttimer = 2;

				blur.iterations = 0;
				blur.enabled = false;
			} else if (effecttimer <= 1) {
				switchPage();
			}
		}

		if (showWon && wonTr.localScale.x < 100) {
			float val = wonTr.localScale.x + 1.0f;
			wonTr.localScale = new Vector3 (val, val, 100.0f);
		}
	}

	private void switchPage() {
		if (showWon) {
			showWon = false;
			wonTr.localScale = new Vector3 (0.0f, 0.0f, 100.0f);
		}

		if (page == 1 || (page >= 4 && page <= 7)) {
			forestAudio.Play ();
		} else {
			forestAudio.Stop ();
		}

		for (int i = 0; i < pages.GetLength(0); i++) {
			pages [i].SetActive (i == page);
		}
	}

	private void playAudio() {
		for (int i = 0; i < pages.GetLength(0); i++) {
			AudioSource[] audio = pages [i].GetComponents<AudioSource> ();
			if (audio.GetLength (0) != 0) {
				if (i == page) {
					audio[0].Play ();
				} else {
					audio[0].Stop ();
				}
			}
		}
	}

	public void NextPage() {
		page++;
		effect = true;
		blur.enabled = true;
	}

	public void PrevPage() {
		page--;
		effect = true;
		blur.enabled = true;
	}

	public void ExitGame() {
		 Application.Quit();
	}

	public void GoTo(int newPage) {
		page = newPage;
		effect = true;
		blur.enabled = true;
	}

	public void ShowWon() {
		showWon = true;
	}
}
