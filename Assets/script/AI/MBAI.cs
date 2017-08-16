using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBAI : MonoBehaviour {

	public BattleSimulation BS;
	//use move in slot 1
	private int moveToUse=2;

	// Use this for initialization
	void Start () {
		
	}

	public void setAIBehavior()
	{
		BS.red1.selectMove(moveToUse);
	}

	public int getMoveToUse()
	{
		return moveToUse;
	}

	// Update is called once per frame
	//void Update () {
		
	//}
}
