﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void startlever1()
	{
		SceneManager.LoadScene ("lever1");
	}
	public void exit()
	{
		SceneManager.LoadScene ("menu");
	}
	public void exit0()
	{
		SceneManager.LoadScene ("menu");
	}
}
