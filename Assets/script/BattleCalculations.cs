using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Battle calculations. Singleton: use .instance
/// </summary>
public class BattleCalculations : MonoBehaviour {

	public static BattleCalculations instance = null;

	void Awake ()
	{
		if (instance == null)
			//if not, set it to this.
			instance = this;
		//If instance already exists:
		else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

}
