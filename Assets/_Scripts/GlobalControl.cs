using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GlobalControl : MonoBehaviour {

	public static GlobalControl Instance;

	public int Score;
	public int Level;
	public int Live;

	void Awake()
	{
		transform.parent = null;

		if (Instance == null) {
			DontDestroyOnLoad (transform.gameObject);
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
