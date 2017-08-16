using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGuiManager : MonoBehaviour,IBattleText,IBattleHealthDamage {

	public BasicCombative red1;
	public BasicCombative blue1;

	public PartySystem playerParty;
	public PartySystem otherParty;

	public Image red1GreenBar;
	public Image red1GrayBar;
	public Image red1RedBar;

	public Image blue1GreenBar;
	public Image blue1GrayBar;
	public Image blue1RedBar;

	public Text battleText;

	public Text userMoveText1;
	public Text userMoveText2;
	public Text userMoveText3;
	public Text userMoveText4;
	public Text userMoveText5;

	private int targetRed1HPGreen;
	private int targetRed1HPGray;
	private int targetRed1HPRed;
	private int rollAmountRed1=0;

	private int targetBlue1HPGreen;
	private int targetBlue1HPGray;
	private int targetBlue1HPRed;
	private int rollAmountBlue1=0;


	// Use this for initialization
	void Start () {
		red1 = playerParty.combative1;
		blue1 = otherParty.combative1;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (DoesHPDiffersFromTarget (targetRed1HPGreen, targetRed1HPGray, targetRed1HPRed, red1)) {
			rollHP (targetRed1HPGreen, red1.totalHealth, rollAmountRed1, red1GreenBar);
			rollHP (targetRed1HPGray, red1.totalHealth, rollAmountRed1, red1GrayBar);
			rollHP (targetRed1HPRed, red1.totalHealth, rollAmountRed1, red1RedBar);
			rollAmountRed1++;
		} 
		else {
			rollAmountRed1 = 0;
		}

		if (DoesHPDiffersFromTarget(targetBlue1HPGreen,targetBlue1HPGray,targetBlue1HPRed,blue1)) {
			rollHP (targetBlue1HPGreen,blue1.totalHealth,rollAmountBlue1,blue1GreenBar);
			rollHP (targetBlue1HPGray,blue1.totalHealth,rollAmountBlue1,blue1GrayBar);
			rollHP (targetBlue1HPRed,blue1.totalHealth,rollAmountBlue1,blue1RedBar);
			rollAmountBlue1++;
		}
		else{
			rollAmountBlue1 = 0;
		}
		
	}

	public void BattleTextToAdd(string s)
	{
		//add s to text event
	}

	public void FullHealthBarDamage01(int green,int gray,int red,int totalHP,string target)
	{
		if (target.Equals ("red1")) {
			targetRed1HPGreen=green;
			targetRed1HPGray = gray;
			targetRed1HPRed = red;
		}

		if (target.Equals ("blue1")) {
			targetBlue1HPGreen=green;
			targetBlue1HPGray = gray;
			targetBlue1HPRed = red;
		}
	}

	private void rollHP(int HP,int totalHP,int rollAmount,Image HPBar)
	{
		if (totalHP - rollAmount >= HP) {
			HPBar.transform.localScale = new Vector3 ((float)totalHP-rollAmount /totalHP, 1.0f, 1.0f);
		}

	}

	private void SetHPBar(int HP,int totalHP,Image HPBar)
	{

		HPBar.transform.localScale = new Vector3 ((float)HP /totalHP, 1.0f, 1.0f);

	}

	private bool DoesHPDiffersFromTarget(int green,int gray,int red,BasicCombative com)
	{
		if (green != com.battleHealthGreen) {
			return true;
		}
		if (gray != com.battleHealthGray) {
			return true;
		}
		if (red != com.battleHealthRed) {
			return true;
		}
		return false;
	}
}


