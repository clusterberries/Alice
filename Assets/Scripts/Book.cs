﻿using UnityEngine;
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

	// Use this for initialization
	void Start () {
        page = 0;
		blur = Camera.main.GetComponent<Blur> ();
		blur.iterations = 0;
		wonTr = youWon.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (effect) {
			int iterations = (int) Mathf.Round( effecttimer * (-5.0f) + 10.0f ) * 2;

			blur.iterations = iterations <= 10 ? iterations : 20 - iterations;
			effecttimer -= Time.deltaTime;
			
			if (effecttimer < 0) {
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

		for (int i = 0; i < pages.GetLength(0); i++) {
			if (i == page)
				pages[i].SetActive (true);
			else
				pages[i].SetActive (false);
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

	public void ShowWon() {
		showWon = true;
	}
}