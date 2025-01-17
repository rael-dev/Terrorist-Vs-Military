﻿using UnityEngine;
using System.Collections;

/*
 * Author: Israel Anthony
 * Purpose: Handles the playing of the walkie talkie communications during certain events.
 * Caveats: None
 */ 
public class CommunicationTrigger : MonoBehaviour 
{
	private BehaviourManager behaviourMngr; 

	private bool nearVictory = true;
	public AudioClip nearVictoryCall;
	private bool reinforcementCall = false;
	public AudioClip reinforcements;
	private bool respond = false;
	public AudioClip reinforcementsResponse;
	private bool victoryPlay = true;
	public AudioClip victory;

	// Use this for initialization
	void Start () 
	{
		GameObject sceneMngr = GameObject.Find("SceneManager");
		if(null == sceneMngr)
		{
			Debug.Log("Error in " + gameObject.name + 
				": Requires a SceneManager object in the scene.");
			Debug.Break();
		}
		behaviourMngr = sceneMngr.GetComponent<BehaviourManager>();
	}


	// Update is called once per frame
	void Update () 
	{
		CheckCount ();
	}


	/// <summary>
	/// Checks the count of insurgents and plays clips based upon it.
	/// </summary>
	void CheckCount()
	{
		if (nearVictory)
		{
			if (behaviourMngr.insurgentCount == 3) 
			{
				gameObject.GetComponent<AudioSource> ().PlayOneShot (nearVictoryCall);
				behaviourMngr.autoSpawnInsurgent = false;
				reinforcementCall = true;
				nearVictory = false;
			}
		}

		if (reinforcementCall) 
		{
			if (behaviourMngr.insurgentCount >= 15) 
			{
				gameObject.GetComponent<AudioSource> ().PlayOneShot (reinforcements);
				reinforcementCall = false;
				nearVictory = true;
				respond = true;
			}
		}

		if (respond) 
		{
			if (behaviourMngr.insurgentCount == 17) 
			{
				behaviourMngr.autoSpawnSoldier = true;
				gameObject.GetComponent<AudioSource> ().PlayOneShot (reinforcementsResponse);
				respond = false;
			}
		}

		if (victoryPlay) 
		{
			if (behaviourMngr.insurgentCount == 0) 
			{
				behaviourMngr.autoSpawnInsurgent = false;
				behaviourMngr.autoSpawnSoldier = false;
				gameObject.GetComponent<AudioSource> ().PlayOneShot (victory);
				victoryPlay = false;
			}
		}
	}
}
