using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCombative : MonoBehaviour {

	public int level;

	public string nickName;

	public int basicHealth;
	public int basicAttack;
	public int basicDef;
	public int basicSpecialAttack;
	public int basicSpecialDef;
	public int basicSpeed;

	public int effortHealth;
	public int effortAttack;
	public int effortDef;
	public int effortSpecialAttack;
	public int effortSpecialDef;
	public int effortSpeed;

	public int inhertHealth;
	public int inhertAttack;
	public int inhertDef;
	public int inhertSpecialAttack;
	public int inhertSpecialDef;
	public int inhertSpeed;

	public int totalHealth;
	public int totalAttack;
	public int totalDef;
	public int totalSpecialAttack;
	public int totalSpecialDef;
	public int totalSpeed;

	public int battleHealthGreen;
	public int battleHealthGray;
	public int battleHealthRed;
	public int battleLevel;

	public int move1;
	public int move2;
	public int move3;
	public int move4;
	public int move5;

	public int type1;
	public int type2;

	public bool isSwitchingOut;
	public int switchingNumber;

	private bool nextMoveCrit;

	private int toxicTimer=1;
	private int paraTimer=0;
	private int statusConPoison;
	private int statusConBurn;
	private int statusConFreeze;
	private int statusConPara;
	private int statusConSleep;
	private int statusConConfusion;

	private int statLevelAll;
	private int statLevelAtt;
	private int statLevelDef;
	private int statLevelSpAtt;
	private int statLevelSpDef;
	private int statLevelSpd;

	private int statLevelAcc;
	private int statLevelEvd;

	private int selectedMove;
	private int selectedMoveID;

	private int critMeter;

	private bool chargeUpMoveReady;

	public bool battleCndFlying;
	private int lastAmountOfDamageDealtGreen;
	private int lastAmountOfDamageDealtGray;
	private int lastAmountOfDamageDealtRed;
	private int lastAmountOfDamageTakenGreen;
	private int lastAmountOfDamageTakenGray;
	private int lastAmountOfDamageTakenRed;
	private int partyNumber;

	/// <summary>
	/// The locked out action. 0=free,1=move1,2,3,4,5,6=switch,7=nonstandared,8=charging,9=recharging
	/// </summary>
	public int lockedOutAction;

	public string nature;

	// Use this for initialization
	void Start () {
		totalHealth = (int)Mathf.Floor (((2 * basicHealth + inhertHealth + Mathf.Floor (effortHealth / 4)) * level) / 100) + level + 10;
		totalAttack = (int)Mathf.Floor ((Mathf.Floor (((2 * basicAttack + inhertAttack + Mathf.Floor (effortAttack / 4)) * level) / 100) + 5) * natureAttMod());
		totalDef = (int)Mathf.Floor ((Mathf.Floor (((2 * basicDef + inhertDef + Mathf.Floor (effortDef / 4)) * level) / 100) + 5) * natureDefMod());
		totalSpecialAttack = (int)Mathf.Floor ((Mathf.Floor (((2 * basicSpecialAttack + inhertSpecialAttack + Mathf.Floor (effortSpecialAttack / 4)) * level) / 100) + 5) * natureSpAttMod());
		totalSpecialDef = (int)Mathf.Floor ((Mathf.Floor (((2 * basicSpecialDef + inhertSpecialDef + Mathf.Floor (effortSpecialDef / 4)) * level) / 100) + 5) *natureSpDefMod() );
		totalSpeed = (int)Mathf.Floor ((Mathf.Floor (((2 * basicSpeed + inhertSpeed + Mathf.Floor (effortSpeed / 4)) * level) / 100) + 5) * natureSpeedMod());

		battleHealthGreen = totalHealth;
		battleHealthGray = totalHealth;
		battleHealthRed = totalHealth;
	}

	public void selectMove(int i)
	{
		if (i == 1) {selectedMove = 1;
		} else if (i == 2) {selectedMove = 2;
		} else if (i == 3) {selectedMove = 3;
		} else if (i == 4) {selectedMove = 4;
		} else if (i == 5) {selectedMove = 5;
		} else {selectedMove = 1;
		}

		preloadMove ();
		//(selectMove)
	}
	public void preloadMove()
	{
		int i;
		if (selectedMove == 1) {i = move1;
		} else if (selectedMove == 2) {i = move2;
		} else if (selectedMove == 3) {i = move3;
		} else if (selectedMove == 4) {i = move4;
		} else if (selectedMove == 5) {i = move5;
		} else {i = move1;
		}
		selectedMoveID = i;
		//Move.instance.parseMoveByNumber (i, 1, this.gameObject);
	}
	public int getSelectedMoveID()
	{
		return selectedMoveID;
	}

	public void randomSwitchOut()
	{
		isSwitchingOut = true;
		switchingNumber = Random.Range (1, 6);
		//TODO no self select
	}

	private float natureAttMod()
	{
		if (nature.Equals ("Adament")) {
			return 1.1f;
		} else if (nature.Equals ("Lonely")) {
			return 1.1f;
		} else if (nature.Equals ("Nuaghty")) {
			return 1.1f;
		} else if (nature.Equals ("Brave")) {
			return 1.1f;
		} else if (nature.Equals ("Bold")) {
			return 0.9f;
		} else if (nature.Equals ("Modest")) {
			return 0.9f;
		} else if (nature.Equals ("Calm")) {
			return 0.9f;
		} else if (nature.Equals ("Timid")) {
			return 0.9f;
		} else {
			return 1.0f;
		}
	}
	private float natureDefMod()
	{
		if (nature.Equals ("Bold")) {
			return 1.1f;
		} else if (nature.Equals ("Impish")) {
			return 1.1f;
		} else if (nature.Equals ("Lax")) {
			return 1.1f;
		} else if (nature.Equals ("Relaxed")) {
			return 1.1f;
		} else if (nature.Equals ("Lonely")) {
			return 0.9f;
		} else if (nature.Equals ("Mild")) {
			return 0.9f;
		} else if (nature.Equals ("Gentle")) {
			return 0.9f;
		} else if (nature.Equals ("Hasty")) {
			return 0.9f;
		} else {
			return 1.0f;
		}

	}
	private float natureSpAttMod()
	{
		if (nature.Equals ("Modest")) {
			return 1.1f;
		} else if (nature.Equals ("Mild")) {
			return 1.1f;
		} else if (nature.Equals ("Rash")) {
			return 1.1f;
		} else if (nature.Equals ("Quite")) {
			return 1.1f;
		} else if (nature.Equals ("Adament")) {
			return 0.9f;
		} else if (nature.Equals ("Impish")) {
			return 0.9f;
		} else if (nature.Equals ("Careful")) {
			return 0.9f;
		} else if (nature.Equals ("Jolly")) {
			return 0.9f;
		} else {
			return 1.0f;
		}
	}
	private float natureSpDefMod()
	{
		if (nature.Equals ("Calm")) {
			return 1.1f;
		} else if (nature.Equals ("Gentle")) {
			return 1.1f;
		} else if (nature.Equals ("Careful")) {
			return 1.1f;
		} else if (nature.Equals ("Sassy")) {
			return 1.1f;
		} else if (nature.Equals ("Naughty")) {
			return 0.9f;
		} else if (nature.Equals ("Lax")) {
			return 0.9f;
		} else if (nature.Equals ("Rash")) {
			return 0.9f;
		} else if (nature.Equals ("Naive")) {
			return 0.9f;
		} else {
			return 1.0f;
		}
	}
	private float natureSpeedMod()
	{
		if (nature.Equals ("Timid")) {
			return 1.1f;
		} else if (nature.Equals ("Hasty")) {
			return 1.1f;
		} else if (nature.Equals ("Jolly")) {
			return 1.1f;
		} else if (nature.Equals ("Naive")) {
			return 1.1f;
		} else if (nature.Equals ("Brave")) {
			return 0.9f;
		} else if (nature.Equals ("Relaxed")) {
			return 0.9f;
		} else if (nature.Equals ("Quite")) {
			return 0.9f;
		} else if (nature.Equals ("Sassy")) {
			return 0.9f;
		} else {
			return 1.0f;
		}
	}

	public void setStatusConPoison(int statusConPoison)
	{
		this.statusConPoison = statusConPoison;
		if (this.statusConPoison > 6) {
			this.statusConPoison = 6;
		}
	}
	public void setStatusConBurn(int statusConBurn)
	{
		this.statusConBurn = statusConBurn;
		if (this.statusConBurn > 6) {
			this.statusConBurn = 6;
		}
	}
	public void setStatusConFreeze(int statusConFreeze)
	{
		this.statusConFreeze = statusConFreeze;
		if (this.statusConFreeze > 6) {
			this.statusConFreeze = 6;
		}
	}
	public void setStatusConPara(int statusConPara)
	{
		this.statusConPara = statusConPara;
		if (this.statusConPara > 6) {
			this.statusConPara = 6;
		}
	}
	public void setStatusConSleep(int statusConSleep)
	{
		this.statusConSleep = statusConSleep;
		if (this.statusConSleep > 6) {
			this.statusConSleep = 6;
		}
	}
	public void setStatusConConfusion(int statusConConfusion)
	{
		this.statusConConfusion = statusConConfusion;
		if (this.statusConConfusion > 6) {
			this.statusConConfusion = 6;
		}
	}

	public void setStatLevelAll(int statLevelAll)
	{
		this.statLevelAll = statLevelAll;
	}
	public void setStatLevelAtt(int statLevelAtt)
	{
		this.statLevelAtt = statLevelAtt;
	}
	public void setStatLevelDef(int statLevelDef)
	{
		this.statLevelDef = statLevelDef;
	}
	public void setStatLevelSpAtt(int statLevelSpAtt)
	{
		this.statLevelSpAtt = statLevelSpAtt;
	}
	public void setStatLevelSpDef(int statLevelSpDef)
	{
		this.statLevelSpDef = statLevelSpDef;
	}
	public void setStatLevelSpd(int statLevelSpd)
	{
		this.statLevelSpd= statLevelSpd;
	}
	public void setStatLevelAcc(int statLevelAcc)
	{
		this.statLevelAcc= statLevelAcc;
	}
	public void setStatLevelEvd(int statLevelEvd)
	{
		this.statLevelEvd= statLevelEvd;
	}
	/// <summary>
	/// Sets the toxic timer.
	/// </summary>
	/// <param name="toxicTimer">Toxic timer.</param>
	public void setToxicTimer(int toxicTimer)
	{
		this.toxicTimer = toxicTimer;
	}
	public void setParaTimer(int paraTimer)
	{
		this.paraTimer = paraTimer;
	}
	public void setCritMeter(int critMeter)
	{
		this.critMeter = critMeter;
	}
	public void setChargeUpMoveReady(bool chargeUpMoveReady)
	{
		this.chargeUpMoveReady = chargeUpMoveReady;
	}
	public void setPartyNumber(int partyNumber)
	{
		this.partyNumber = partyNumber;
	}
	public void setBattleCndFlying(bool setBattleCndFlying)
	{
		this.battleCndFlying = !battleCndFlying;
	}

	public void setDamageTaken(int green,int gray,int red)
	{
		lastAmountOfDamageTakenGreen = green;
		lastAmountOfDamageTakenGray = gray;
		lastAmountOfDamageTakenRed = red;
	}

	public void setDamageDealt(int green,int gray,int red)
	{
		lastAmountOfDamageDealtGreen = green;
		lastAmountOfDamageDealtGray = gray;
		lastAmountOfDamageDealtRed = red;
	}


	public void flipNextMoveCrit()
	{
		nextMoveCrit = !nextMoveCrit;
	}
	public void flipBattleCndFlying()
	{
		battleCndFlying = !battleCndFlying;
	}

	public int getStatusConPoison()
	{
		return statusConPoison;
	}
	public int getStatusConBurn()
	{
		return statusConBurn;
	}
	public int getStatusConFreeze()
	{
		return statusConFreeze;
	}
	public int getStatusConPara()
	{
		return statusConPara;
	}
	public int getStatusConSleep()
	{
		return statusConSleep;
	}
	public int getStatusConConfusion()
	{
		return statusConConfusion;
	}

	public int getStatLevelAll()
	{
		return statLevelAll;
	}
	public int getStatLevelAtt()
	{
		return statLevelAtt;
	}
	public int getStatLevelDef()
	{
		return statLevelDef;
	}
	public int getStatLevelSpAtt()
	{
		return statLevelSpAtt;
	}
	public int getStatLevelSpDef()
	{
		return statLevelSpDef;
	}
	public int getStatLevelSpd()
	{
		return statLevelSpd;
	}
	public int getStatLevelAcc()
	{
		return statLevelAcc;
	}
	public int getStatLevelEvd()
	{
		return statLevelEvd;
	}

	public float getAttackDamageMod()
	{
		float mod = 1.0f;
		if (statLevelAtt > 0) {
			mod = mod*(1.0f+(statLevelAtt/4.0f));
		}
		else if(statLevelAtt<0){
			mod = mod /(1.0f+ (-statLevelAtt/4.0f));
		}

		if (statLevelAll > 0) {
			mod = mod*(1.0f+(statLevelAll/12.0f));
		}
		else if(statLevelAtt<0){
			mod = mod /(1.0f+ (-statLevelAll/12.0f));
		}
		return mod;
	}

	public float getSpecialAttackDamageMod()
	{
		float mod = 1.0f;
		if (statLevelAtt > 0) {
			mod = mod*(1.0f+(statLevelSpAtt/4.0f));
		}
		else if(statLevelAtt<0){
			mod = mod /(1.0f+ (-statLevelSpAtt/4.0f));
		}

		if (statLevelAll > 0) {
			mod = mod*(1.0f+(statLevelAll/12.0f));
		}
		else if(statLevelAtt<0){
			mod = mod /(1.0f+ (-statLevelAll/12.0f));
		}

		return mod;
	}

	public float getDefenseDamageMod()
	{
		float mod = 1.0f;
		if (statLevelDef > 0) {
			mod = mod*(1.0f+(statLevelDef/4.0f));
		}
		else if(statLevelDef<0){
			mod = mod /(1.0f+ (-statLevelDef/4.0f));
		}

		if (statLevelAll > 0) {
			mod = mod*(1.0f+(statLevelAll/12.0f));
		}
		else if(statLevelAtt<0){
			mod = mod /(1.0f+ (-statLevelAll/12.0f));
		}

		return mod;
	}
	/// <summary>
	/// Gets the special defense damage mod.
	/// </summary>
	/// <returns>The special defense damage mod.</returns>
	public float getSpecialDefenseDamageMod()
	{
		float mod = 1.0f;
		if (statLevelSpDef > 0) {
			mod = mod*(1.0f+(statLevelSpDef/4.0f));
		}
		else if(statLevelSpDef<0){
			mod = mod /(1.0f+ (-statLevelSpDef/4.0f));
		}

		if (statLevelAll > 0) {
			mod = mod*(1.0f+(statLevelAll/12.0f));
		}
		else if(statLevelAtt<0){
			mod = mod /(1.0f+ (-statLevelAll/12.0f));
		}

		return mod;
	}
	/// <summary>
	/// Gets the speed mod.
	/// </summary>
	/// <returns>The speed mod.</returns>
	public float getSpeedMod()
	{
		float mod = 1.0f;
		if (statLevelSpd > 0) {
			mod = mod*(1.0f+(statLevelSpd/4.0f));
		}
		else if(statLevelSpd<0){
			mod = mod /(1.0f+ (-statLevelSpd/4.0f));
		}

		if (statLevelAll > 0) {
			mod = mod*(1.0f+(statLevelAll/12.0f));
		}
		else if(statLevelAtt<0){
			mod = mod /(1.0f+ (-statLevelAll/12.0f));
		}

		return mod;
	}

	public float getAccMod()
	{
		float mod = 1.0f;
		if (statLevelAcc > 0) {
			mod = mod*(1.0f+(statLevelAcc/4.0f));
		}
		else if(statLevelAcc<0){
			mod = mod /(1.0f+ (-statLevelAcc/4.0f));
		}

		return mod;
	}

	public float getEvdMod()
	{
		float mod = 1.0f;
		if (statLevelEvd > 0) {
			mod = mod*(1.0f+(statLevelEvd/4.0f));
		}
		else if(statLevelEvd<0){
			mod = mod /(1.0f+ (-statLevelEvd/4.0f));
		}

		return mod;
	}
	/// <summary>
	/// Gets the toxic timer.
	/// </summary>
	/// <returns>The toxic timer.</returns>
	public int getToxicTimer()
	{
		return toxicTimer;
	}

	public int getParaTimer()
	{
		return paraTimer;
	}
		

	public int getCritMeter()
	{
		return critMeter;
	}

	public bool isNextMoveCrit()
	{
		return nextMoveCrit;
	}
	public bool isChargeUpMoveReady()
	{
		return chargeUpMoveReady;
	}
	public bool isBattleCndFlying()
	{
		return battleCndFlying;
	}

	public int getLastAmountOfDamageTakenGreen()
	{
		return lastAmountOfDamageTakenGreen;
	}
	public int getLastAmountOfDamageTakenGray()
	{
		return lastAmountOfDamageTakenGray;
	}
	public int getLastAmountOfDamageTakenRed()
	{
		return lastAmountOfDamageTakenRed;
	}
	public int getLastAmountOfDamageDealtGreen()
	{
		return lastAmountOfDamageDealtGreen;
	}
	public int getLastAmountOfDamageDealtGray()
	{
		return lastAmountOfDamageDealtGray;
	}
	public int getLastAmountOfDamageDealtRed()
	{
		return lastAmountOfDamageDealtRed;
	}

	public int getPartyNumber()
	{
		return partyNumber;
	}

	public int doesThisMoveHit(int moveID)
	{
		if (battleCndFlying) {
			print ("flying "+this.nickName);
			return 0;

			//if thunder return 2;
		}
		return 1;
	}
}
