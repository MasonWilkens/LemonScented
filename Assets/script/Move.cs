using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//<Summary>
//All moves
//<Summary>
public class Move : MonoBehaviour {

	public static Move instance = null;		//Allows other scripts to call functions.				

	public Text battleText;
	public int moveID;

	private int type;
	/// <summary>
	/// 1=physical
	/// 2=special
	/// 3=status
	/// </summary>
	private int catagory;
	private int pp;
	private int powerGreen;
	private int powerGray;
	private int powerRed;
	private int accuracy;
	private int priority;
	private int contact;//0=no 1=yes 2=wide
	private string visaName="";
	private string description;
	private bool secondEffect;


	/// <summary>
	///  0=single target opp
	/// 1=single target self
	/// 2=enviroment targeted
	/// 3=multitarget all but self
	/// 4=target both opp
	/// 5=
	/// </summary>
	private int targetSystem;

	/// <summary>
	/// 0=basicAttack
	/// 1=multiAttack
	/// 2=doubleAttack
	/// 3=selfStatus
	/// 4=OHKO
	/// 5=targetedStatus
	/// 6=chargeAttack
	/// 7=forceWithdrawMove
	/// 8=chargeAttackFirstTurnSelfStatus
	/// 9=jumpkickMissDamage
	/// 10=selfStatusOnConnectAfterAttack
	/// </summary>
	private int attackMethod;

	/// <summary>
	/// The addition effect.
	/// </summary>
	private EffEnum additionalEffect;
	private EffEnum additionalSecondEffect;

	/// <summary>
	/// The percent for effect.
	/// </summary>
	private float percentForEffect;
	private int percentForSecondEffect;
	/// <summary>
	/// The magnitude of the effect.
	/// </summary>
	private int magnitudeOfEffect;
	private int magnitudeOfSecondEffect;


	/*
	 * 1=normal
	 * 2=fire
	 * 3=water
	 * 4=electric
	 * 5=grass
	 * 6=ice
	 * 7=fighting
	 * 8=poison
	 * 9=ground
	 * 10=flying
	 * 11=psychic
	 * 12=bug
	 * 13=rock
	 * 14=ghost
	 * 15=dragon
	 * 16=dark
	 * 17=steel
	 * 18=fairy
	 * 0=typeless
	*/

	void Awake ()
	{
		//Check if there is already an instance of SoundManager
		if (instance == null)
			//if not, set it to this.
			instance = this;
		//If instance already exists:
		else if (instance != this)
			//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
			Destroy (gameObject);

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}

	/// <summary>
	/// Cleans the move info.
	/// </summary>
	public void cleanMoveInfo()
	{
		type = 0;
		catagory = 1;
		pp = 1;
		powerGreen = 0;
		powerGray = 0;
		powerRed = 0;
		accuracy = 0;
		priority = 0;
		visaName = "Nothing";
		description = "";
		targetSystem = 0;
		attackMethod = 0;
		secondEffect = false;
		genericUserEffector (null,0,0,0);
	}

	public void parseMoveByNumber(int numberID,int varient,BasicCombative go)
	{
		cleanMoveInfo ();
		moveID = numberID;
		if (numberID == 1) {
			type = 1;
			catagory = 1;
			pp = 35;
			powerGreen = 40;
			powerGray = 30;
			powerRed = 20;
			accuracy = 100;
			priority = 0;
			visaName = "Pound";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 2) {
			type = 7;
			catagory = 1;
			pp = 25;
			powerGreen = 50;
			powerGray = 25;
			powerRed = 20;
			accuracy = 100;
			priority = 0;
			visaName = "Karate Chop";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.CRITUP1,0,0);
		}
		else if (numberID == 3) {
			//print ("Double Slap");
			type = 1;
			catagory = 1;
			pp = 15;
			powerGreen = 15;
			powerGray = 7;
			powerRed = 3;
			accuracy = 85;
			priority = 0;
			visaName = "Double Slap";
			description = "";
			targetSystem = 0;
			attackMethod = 1;
			genericUserEffector (go,EffEnum.NONE,0,0);

		}
		else if (numberID == 4) {
			//print ("Comet Punch");
			type = 1;
			catagory = 1;
			pp = 15;
			powerGreen = 18;
			powerGray = 10;
			powerRed = 8;
			accuracy = 85;
			priority = 0;
			visaName = "Comet Punch";
			description = "";
			targetSystem = 0;
			attackMethod = 1;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 5) {
			//print ("Mega Punch");
			type = 1;
			catagory = 1;
			pp = 20;
			powerGreen = 80;
			powerGray = 70;
			powerRed = 60;
			accuracy = 85;
			priority = 0;
			visaName = "Mega Punch";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 6) {
			//TODO incorperate pay day effect
			type = 1;
			catagory = 1;
			pp = 20;
			powerGreen = 40;
			powerGray = 40;
			powerRed = 40;
			accuracy = 100;
			priority = 0;
			visaName = "Pay Day";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 7) {
			type = 2;
			catagory = 1;
			pp = 15;
			powerGreen = 75;
			powerGray = 75;
			powerRed = 75;
			accuracy = 100;
			priority = 0;
			visaName = "Fire Punch";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.BURN,50,1);
		}
		else if (numberID == 8) {
			type = 1;
			catagory = 1;
			pp = 15;
			powerGreen = 75;
			powerGray = 75;
			powerRed = 75;
			accuracy = 100;
			priority = 0;
			visaName = "Ice Punch";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.FREEZE,50,1);
		}
		else if (numberID == 9) {
			type = 1;
			catagory = 1;
			pp = 15;
			powerGreen = 75;
			powerGray = 75;
			powerRed = 75;
			accuracy = 100;
			priority = 0;
			visaName = "Thunder Punch";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.PARA,50,1);
		}
		else if (numberID == 10) {
			type = 1;
			catagory = 1;
			pp = 35;
			powerGreen = 40;
			powerGray = 40;
			powerRed = 40;
			accuracy = 100;
			priority = 0;
			visaName = "Scratch";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 11) {
			type = 1;
			catagory = 1;
			pp = 30;
			powerGreen = 55;
			powerGray = 55;
			powerRed = 55;
			accuracy = 100;
			priority = 0;
			visaName = "Vice Grip";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 12) {
			type = 1;
			catagory = 1;
			pp = 5;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 0;
			priority = 0;
			visaName = "Guillotine";
			description = "";
			targetSystem = 0;
			attackMethod = 4;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 13) { 
			type = 1;
			catagory = 2;
			pp = 10;
			powerGreen = 80;
			powerGray = 80;
			powerRed = 80;
			accuracy = 100;
			priority = 0;
			visaName = "Razor Wind";
			description = "";
			targetSystem = 0;
			attackMethod = 6;
			genericUserEffector (go,EffEnum.CRITUP1,0,0);
		}
		else if (numberID == 14) {
			type = 1;
			catagory = 3;
			pp = 20;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 100;
			priority = 0;
			visaName = "Swords Dance";
			description = "";
			targetSystem = 1;
			attackMethod = 3;
			genericUserEffector (go,EffEnum.STATATT,100,4);
		}
		else if (numberID == 15) {
			type = 1;
			catagory = 1;
			pp =30;
			powerGreen = 50;
			powerGray = 50;
			powerRed = 50;
			accuracy = 95;
			priority = 0;
			visaName = "Cut";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 16) {
			type = 1;
			catagory = 2;
			pp =35;
			powerGreen = 40;
			powerGray = 40;
			powerRed = 40;
			accuracy = 100;
			priority = 0;
			visaName = "Gust";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 17) {
			type = 1;
			catagory = 1;
			pp =35;
			powerGreen = 60;
			powerGray = 60;
			powerRed = 60;
			accuracy = 100;
			priority = 0;
			visaName = "Wing Attack";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 18) {
			type = 1;
			catagory = 3;
			pp =20;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 0;
			priority = -1;
			visaName = "Whirlwind";
			description = "";
			targetSystem = 0;
			attackMethod = 7;
			genericUserEffector (go,EffEnum.RANDOMWITHDRAW,0,0);
		}
		else if (numberID == 19) {
			type = 1;
			catagory = 1;
			pp =15;
			powerGreen = 90;
			powerGray = 90;
			powerRed = 90;
			accuracy = 95;
			priority = 0;
			visaName = "Fly";
			description = "";
			targetSystem = 0;
			attackMethod = 8;
			genericUserEffector (go,EffEnum.FLIGHT,0,0);
		}
		else if (numberID == 20) {
			type = 1;
			catagory = 1;
			pp =20;
			powerGreen = 15;
			powerGray = 15;
			powerRed = 15;
			accuracy = 85;
			priority = 0;
			visaName = "Bind";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 21) {
			type = 1;
			catagory = 1;
			pp =20;
			powerGreen = 80;
			powerGray = 80;
			powerRed = 80;
			accuracy = 75;
			priority = 0;
			visaName = "Slam";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 22) {
			type = 1;
			catagory = 1;
			pp =25;
			powerGreen = 45;
			powerGray = 45;
			powerRed = 45;
			accuracy = 100;
			priority = 0;
			visaName = "Vine Whip";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 23) {
			type = 1;
			catagory = 1;
			pp =20;
			powerGreen = 65;
			powerGray = 65;
			powerRed = 65;
			accuracy = 100;
			priority = 0;
			visaName = "Stomp";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 24) {
			type = 7;
			catagory = 1;
			pp =30;
			powerGreen = 30;
			powerGray = 15;
			powerRed = 10;
			accuracy = 100;
			priority = 0;
			visaName = "Double Kick";
			description = "";
			targetSystem = 0;
			attackMethod = 2;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 25) {
			type = 1;
			catagory = 1;
			pp =5;
			powerGreen = 120;
			powerGray = 120;
			powerRed = 120;
			accuracy = 75;
			priority = 0;
			visaName = "Mega Kick";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 26) {
			type = 1;
			catagory = 1;
			pp =10;
			powerGreen = 100;
			powerGray = 50;
			powerRed = 40;
			accuracy = 95;
			priority = 0;
			visaName = "Jump Kick";
			description = "";
			targetSystem = 0;
			attackMethod = 9;
			genericUserEffector (go,EffEnum.NONE,0,0,EffEnum.CRASHDAMAGEHALF,0,0);
			secondEffect = true;
		}
		else if (numberID == 27) {
			type = 1;
			catagory = 1;
			pp =15;
			powerGreen = 60;
			powerGray = 30;
			powerRed = 25;
			accuracy = 85;
			priority = 0;
			visaName = "Rolling Kick";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 28) {
			type = 1;
			catagory = 1;
			pp =15;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 100;
			priority = 0;
			visaName = "Sand Attack";
			description = "";
			targetSystem = 0;
			attackMethod = 5;
			genericUserEffector (go,EffEnum.STATACC,100,-2);
		}
		else if (numberID == 29) {
			type = 1;
			catagory = 1;
			pp =15;
			powerGreen = 70;
			powerGray = 70;
			powerRed = 70;
			accuracy = 100;
			priority = 0;
			visaName = "Headbutt";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 30) {
			type = 1;
			catagory = 1;
			pp =25;
			powerGreen = 65;
			powerGray = 65;
			powerRed = 65;
			accuracy = 100;
			priority = 0;
			visaName = "Horn Attack";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 31) {
			type = 1;
			catagory = 1;
			pp =20;
			powerGreen = 15;
			powerGray =15 ;
			powerRed = 15;
			accuracy = 85;
			priority = 0;
			visaName = "Fury Attack";
			description = "";
			targetSystem = 0;
			attackMethod = 1;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 32) {
			type = 1;
			catagory = 1;
			pp = 5;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 0;
			priority = 0;
			visaName = "Horn Drill";
			description = "";
			targetSystem = 0;
			attackMethod = 4;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 33) {
			type = 1;
			catagory = 1;
			pp =35;
			powerGreen = 40;
			powerGray = 40;
			powerRed = 40;
			accuracy = 100;
			priority = 0;
			visaName = "Tackle";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 34) {
			type = 1;
			catagory = 1;
			pp =15;
			powerGreen = 85;
			powerGray = 85;
			powerRed = 85;
			accuracy = 100;
			priority = 0;
			visaName = "Body Slam";
			description = "";
			targetSystem = 0;
			attackMethod = 0; 
			genericUserEffector (go,EffEnum.PARA,75,1);
		}
		else if (numberID == 35) {
			type = 1;
			catagory = 1;
			pp =20;
			powerGreen = 15;
			powerGray = 15;
			powerRed = 15;
			accuracy = 90;
			priority = 0;
			visaName = "Wrap";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 36) {
			type = 1;
			catagory = 1;
			pp =20;
			powerGreen = 90;
			powerGray = 90;
			powerRed = 90;
			accuracy = 85;
			priority = 0;
			visaName = "Take Down";
			description = "";
			targetSystem = 0;
			attackMethod = 10;
			genericUserEffector (go,EffEnum.RECOILQUARTER,0,0);
		}
		else if (numberID == 37) {
			type = 1;
			catagory = 1;
			pp =10;
			powerGreen = 120;
			powerGray = 120;
			powerRed = 120;
			accuracy = 100;
			priority = 0;
			visaName = "Thrash";//TODO code attackMethod and frenzy mechanic
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 38) {
			type = 1;
			catagory = 1;
			pp =15;
			powerGreen = 120;
			powerGray = 120;
			powerRed = 120;
			accuracy = 100;
			priority = 0;
			visaName = "Double-Edge";
			description = "";
			targetSystem = 0;
			attackMethod = 10;
			genericUserEffector (go,EffEnum.RECOILTHIRD,0,0);
		}
		else if (numberID == 39) {
			type = 1;
			catagory = 1;
			pp =30;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 100;
			priority = 0;
			visaName = "Tail Whip";
			description = "";
			targetSystem = 0;
			attackMethod = 5;
			genericUserEffector (go,EffEnum.STATDEF,100,-2);

		}
		else if (numberID == 40) {
			type = 8;
			catagory = 1;
			pp =35;
			powerGreen = 15;
			powerGray = 15;
			powerRed = 15;
			accuracy = 100;
			priority = 0;
			visaName = "Poison Sting";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.POISON,100,1);
		}
		else if (numberID == 41) {
			type = 12;
			catagory = 1;
			pp =30;
			powerGreen = 25;
			powerGray = 25;
			powerRed = 25;
			accuracy = 100;
			priority = 0;
			visaName = "Twineedle";
			description = "";
			targetSystem = 0;
			attackMethod = 2;
			genericUserEffector (go, EffEnum.POISON, 50, 1);
		}
		else if (numberID == 42) {
			type = 12;
			catagory = 1;
			pp =20;
			powerGreen = 25;
			powerGray =25 ;
			powerRed = 25;
			accuracy = 95;
			priority = 0;
			visaName = "Pin Missile";
			description = "";
			targetSystem = 0;
			attackMethod = 1;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 43) {
			type = 1;
			catagory = 1;
			pp =30;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 100;
			priority = 0;
			visaName = "Leer";
			description = "";
			targetSystem = 0;
			attackMethod = 5;
			genericUserEffector (go,EffEnum.STATDEF,100,-2);
		}
		else if (numberID == 44) {
			type = 16;
			catagory = 1;
			pp =25;
			powerGreen = 65;
			powerGray = 65;
			powerRed = 65;
			accuracy = 100;
			priority = 0;
			visaName = "Bite";
			description = "";
			targetSystem = 0;
			attackMethod = 0;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 45) {
			type = 1;
			catagory = 1;
			pp =40;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 100;
			priority = 0;
			visaName = "Growl";
			description = "";
			targetSystem = 0;
			attackMethod = 5;
			genericUserEffector (go,EffEnum.STATATT,100,-2);
		}
		else if (numberID == 46) {
			type = 1;
			catagory = 3;
			pp =20;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 0;
			priority = -1;
			visaName = "Roar";
			description = "";
			targetSystem = 0;
			attackMethod = 7;
			genericUserEffector (go,EffEnum.RANDOMWITHDRAW,0,0);
		}
		else if (numberID == 47) {
			type = 1;
			catagory = 1;
			pp =15;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 55;
			priority = 0;
			visaName = "Sing";
			description = "";
			targetSystem = 0;
			attackMethod = 5;
			genericUserEffector (go,EffEnum.SLEEP,100,2);
		}
		else if (numberID == 48) {
			type = 1;
			catagory = 1;
			pp =20;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 55;
			priority = 0;
			visaName = "Supersonic";
			description = "";
			targetSystem = 0;
			attackMethod = 5;
			genericUserEffector (go,EffEnum.CONFUSION,100,2);
		}
		else if (numberID == 49) {
			type = 1;
			catagory = 1;
			pp =20;
			powerGreen = 20;
			powerGray = 20;
			powerRed = 20;
			accuracy = 90;
			priority = 0;
			visaName = "Super Boom";
			description = "";
			targetSystem = 0;
			attackMethod = 11;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 50) {

		}
		else if (numberID == 51) {

		}
		else if (numberID == 52) {

		}
		else if (numberID == 53) {
			
		}
		else if (numberID == 54) {

		}
		else if (numberID == 55) {

		}
		else if (numberID == 56) {

		}
		else if (numberID == 57) {

		}
		else if (numberID == 58) {

		}
		else if (numberID == 59) {

		}
		else if (numberID == 60) {

		}
		else if (numberID == 61) {

		}

	}

	/// <summary>
	/// Additional effect numbers:
	/// 0=none
	/// 1=burn
	/// 2=freeze
	/// 3=para
	/// 4=poison
	/// 5=all stat
	/// 6=attack stat
	/// 7=defense stat
	/// 8=SpAtt stat
	/// 9=SpDef stat
	/// 10=Speed stat
	/// 11=Flinch
	/// 12=Crit+1
	/// 13=accuracy stat
	/// 14=evasion stat
	/// 15=random withdraw
	/// 16=flight
	/// 17=recoil 25%
	/// </summary>
	/// <param name="go">Go.</param>
	/// <param name="additionalEffect">Additional effect number.</param>
	/// <param name="percentForEffect">Percent for effect to take place.</param>
	/// <param name="magnitudeOfEffect">Magnitude of effect. (stats are 1-2 ratio)</param>
	private void genericUserEffector(BasicCombative go,EffEnum additionalEffect,int percentForEffect,int magnitudeOfEffect)
	{
		this.additionalEffect = additionalEffect;
		this.percentForEffect = percentForEffect;
		this.magnitudeOfEffect = magnitudeOfEffect;

		return;
	}

	private void genericUserEffector(BasicCombative go,EffEnum additionalEffect,int percentForEffect,int magnitudeOfEffect,EffEnum additionalSecondEffect,int percentForSecondEffect,int magnitudeOfSecondEffect)
	{
		this.additionalEffect = additionalEffect;
		this.percentForEffect = percentForEffect;
		this.magnitudeOfEffect = magnitudeOfEffect;
		this.additionalSecondEffect = additionalSecondEffect;
		this.percentForSecondEffect = percentForSecondEffect;
		this.magnitudeOfSecondEffect = magnitudeOfSecondEffect;


		return;
	}

	private void genericTargetEffector(BasicCombative go,int additionalEffect,int percentForEffect,int magnitudeOfEffect)
	{
		//this.additionalEffect = additionalEffect;
		//this.percentForEffect = percentForEffect;
		//this.magnitudeOfEffect = magnitudeOfEffect;

		return;
	}

	/// <summary>
	/// The move methods
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void combativeRoundUserToTargetDamage(BasicCombative user,BasicCombative target)
	{
		Move.instance.parseMoveByNumber(user.getSelectedMoveID(),1,user);
		if (attackMethod == 0) {
			basicAttack (user, target);
		} 
		else if (attackMethod == 1) {
			multiAttack (user, target);
		}
		else if (attackMethod == 2) {
			doubleAttack (user, target);
		}
		else if (attackMethod == 3) {
			selfStatus (user);
		}
		else if (attackMethod == 4) {
			OHKOAttack (user, target);
		}
		else if (attackMethod == 5) {
			targetedStatus (user, target);
		}
		else if (attackMethod == 6) {
			chargeAttack (user, target);
		}
		else if (attackMethod == 7) {
			forceWithdrawStatus (user, target);
		}
		else if (attackMethod == 8) {
			chargeAttackFirstTurnSelfStatus (user, target);
		}
		else if (attackMethod == 9) {
			jumpAttack (user, target);
		}
		else if (attackMethod == 10) {
			selfStatusOnConnectAfterAttack (user, target);
		}
		else if (attackMethod == 11) {
			flatAttack(user, target);
		}


		endOfMoveWrapUp (user);

	}

	/// <summary>
	/// Gets the modifiers for move effectiveness*STAB
	/// </summary>
	/// <returns>The modifiers.</returns>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	private float getModifiers(BasicCombative user,BasicCombative target)
	{
		return calculateMoveEffectiveness(target.type1,target.type2)*sameTypeAdvantageBonus(user);
	}
	/// <summary>
	/// attackMethod 0, basic attack with one hit towards 1 target
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void basicAttack(BasicCombative user,BasicCombative target){
		
		if (accuracyCheck (Move.instance.getAccuracy (),user.getAccMod()/target.getEvdMod(),target) == 0) {
			attack (user,target,getModifiers(user,target));
			effectPlacement (getModifiers(user,target),target,100.0f);
			battleText.text += "\n" + user.nickName + " Uses " + Move.instance.getVisaName ();//rev
		} 
		else {
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nThe attack missed";//rev
		}
	}
	/// <summary>
	/// attackMethod 1, multi attack with 2-5 hits towards 1 target
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void multiAttack(BasicCombative user,BasicCombative target)
	{
		//Move.instance.parseMoveByNumber(user.getSelectedMoveID(),1,user);
		if (accuracyCheck (Move.instance.getAccuracy (),user.getAccMod()/target.getEvdMod(),target) == 0) {
			int hitCount = Random.Range (2,5);
			int i=0;
			while(i<hitCount){
				attack (user,target,getModifiers(user,target));
				effectPlacement (getModifiers(user,target),target,100.0f);
				i++;
			}
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nHit "+i+" times";//rev
		}
		else {
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nThe attack missed";//rev
		}

	}
	/// <summary>
	/// attackMethod 2, multi attack with 2 hits towards 1 target
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void doubleAttack(BasicCombative user,BasicCombative target)
	{
		//Move.instance.parseMoveByNumber(user.getSelectedMoveID(),1,user);
		if (accuracyCheck (Move.instance.getAccuracy (),user.getAccMod()/target.getEvdMod(),target) == 0) {
			int hitCount = 2;
			int i=0;
			while(i<hitCount){
				attack (user,target,getModifiers(user,target));
				effectPlacement (getModifiers(user,target),target,100.0f);
				i++;
			}
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nHit "+i+" times";//rev
		}
		else {
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nThe attack missed";//rev
		}

	}
	/// <summary>
	/// attackMethod 3, applies an additional effect to user.
	/// </summary>
	/// <param name="user">User.</param>
	public void selfStatus(BasicCombative user){

		battleText.text += "\n" + user.nickName + " Uses " + Move.instance.getVisaName ();//rev
		effectPlacement (1.0f,user,0.0f);
	}

	/// <summary>
	/// attackMethod 4, OHKOs the target.
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void OHKOAttack(BasicCombative user,BasicCombative target)
	{
		if (user.isNextMoveCrit ()) {
			target.battleHealthGreen = 0;
			target.battleHealthGray = 0;
			target.battleHealthRed = 0;
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nOHKO";//rev
		} 
		else {
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nBut it failed";//rev
		}

	}

	/// <summary>
	/// attackMethod 5, applies addition effect to the target.
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void targetedStatus(BasicCombative user,BasicCombative target)
	{
		if (accuracyCheck (Move.instance.getAccuracy (),user.getAccMod()/target.getEvdMod(),target) == 0) {
			effectPlacement (1.0f,target,0.0f);
			battleText.text += "\n" + user.nickName + " Uses " + Move.instance.getVisaName ();//rev
		} 
		else {
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nThe attack missed";//rev
		}
	}

	/// <summary>
	/// attackMethod 6, Charges the attack.
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void chargeAttack(BasicCombative user,BasicCombative target)
	{
		if (user.isChargeUpMoveReady ()) {
			
			basicAttack (user, target);//has effect placement

			user.setChargeUpMoveReady (false);

		} 
		else {
			user.setChargeUpMoveReady (true);
			//effectPlacement (modifier,target,100.0f);
			battleText.text += "\n"+user.nickName+" Charges "+Move.instance.getVisaName();//rev
		}
	}

	/// <summary>
	/// Forces the withdraw status.
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void forceWithdrawStatus(BasicCombative user,BasicCombative target)
	{
		
		effectPlacement (1.0f,target,0.0f);
		battleText.text += "\n" + user.nickName + " Uses " + Move.instance.getVisaName ();//rev

	}

	/// <summary>
	/// Charges the attack. on first turn self status.
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void chargeAttackFirstTurnSelfStatus(BasicCombative user,BasicCombative target)
	{
		if (user.isChargeUpMoveReady ()) {
			if (accuracyCheck (Move.instance.getAccuracy (), user.getAccMod () / target.getEvdMod (), target) == 0) {
				attack (user, target,getModifiers(user,target));
			}
			battleText.text += "\n" + user.nickName + " Uses " + Move.instance.getVisaName ();//rev
			effectPlacement (1.0f,user,100.0f);
			user.setChargeUpMoveReady (false);
		}
		else {
			user.setChargeUpMoveReady (true);
			effectPlacement (1.0f,user,100.0f);
			battleText.text += "\n"+user.nickName+" Charges "+Move.instance.getVisaName();//rev
		}
	}

	public void jumpAttack(BasicCombative user,BasicCombative target){

		//Move.instance.parseMoveByNumber(user.getSelectedMoveID(),1,user);

		if (accuracyCheck (Move.instance.getAccuracy (),user.getAccMod()/target.getEvdMod(),target) == 0) {
			attack (user,target,getModifiers(user,target));
			battleText.text += "\n" + user.nickName + " Uses " + Move.instance.getVisaName ();//rev
		} 
		else {
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nThe attack missed and crashed";//rev
			if (secondEffect) {
				
				swapEffectPlacements ();
				effectPlacement (1.0f,user,100.0f);
			}
		}
	}

	public void selfStatusOnConnectAfterAttack(BasicCombative user,BasicCombative target)
	{
		if (accuracyCheck (Move.instance.getAccuracy (),user.getAccMod()/target.getEvdMod(),target) == 0) {
			attack (user,target,getModifiers(user,target));
			battleText.text += "\n" + user.nickName + " Uses " + Move.instance.getVisaName ();//rev
			effectPlacement (1.0f,user,100.0f);//recoil,power up
		} 
		else {
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nThe attack missed";//rev
		}
	}


	public void flatAttack(BasicCombative user,BasicCombative target){

		if (accuracyCheck (Move.instance.getAccuracy (),user.getAccMod()/target.getEvdMod(),target) == 0) {
			
			target.battleHealthGreen -= powerGreen;
			target.battleHealthGray -= powerGray;
			target.battleHealthRed -= powerRed;


			effectPlacement (getModifiers(user,target),target,100.0f);
			battleText.text += "\n" + user.nickName + " Uses " + Move.instance.getVisaName ();//rev
		} 
		else {
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nThe attack missed";//rev
		}
	}
		

	/// <summary>
	/// Attack the specified user and target with modifier
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void attack(BasicCombative user,BasicCombative target,float modifier)
	{

		if (catagory == 1) {
			physicalDamage (user, target, modifier);
		}
		else if (catagory == 2) {
			specialDamage(user, target, modifier);
		}

		//effectPlacement (modifier,target,100.0f);
	}

	/// <summary>
	/// Attack the specified user and target. modifier is 1.0f
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	public void attack(BasicCombative user,BasicCombative target)
	{

		if (catagory == 1) {
			physicalDamage (user, target, 1.0f);
		}
		else if (catagory == 2) {
			specialDamage(user, target, 1.0f);
		}

		//effectPlacement (modifier,target,100.0f);
	}
	/// <summary>
	/// damage by physical source, att to def
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	/// <param name="modifier">Modifier.</param>
	private void physicalDamage(BasicCombative user,BasicCombative target,float modifier)
	{
		float rNumb = Random.Range (0.85f, 1.0f);
		int greenDamage=(int)(baseDamageCalculation (user.level, Move.instance.getPowerGreen (),
			(int)(user.totalAttack*user.getAttackDamageMod()), (int)(target.totalDef*target.getDefenseDamageMod())) * rNumb * modifier*critMod(user)) + 1;
		int grayDamage=(int)(baseDamageCalculation (user.level, Move.instance.getPowerGray (),
			(int)(user.totalAttack*user.getAttackDamageMod()), (int)(target.totalDef*target.getDefenseDamageMod())) * rNumb * modifier*critMod(user)) + 1;
		int redDamage=(int)(baseDamageCalculation (user.level, Move.instance.getPowerRed (),
			(int)(user.totalAttack*user.getAttackDamageMod()), (int)(target.totalDef*target.getDefenseDamageMod())) * rNumb * modifier*critMod(user)) + 1;

		target.battleHealthGreen -= greenDamage;
		target.battleHealthGray -= grayDamage;
		target.battleHealthRed -= redDamage;

		target.setDamageTaken (greenDamage,grayDamage,redDamage);
		user.setDamageDealt(greenDamage,grayDamage,redDamage);
	}
	/// <summary>
	/// damage by special source, spAtt to spDef
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	/// <param name="modifier">Modifier.</param>
	private void specialDamage(BasicCombative user,BasicCombative target,float modifier)
	{
		float rNumb = Random.Range (0.85f, 1.0f);
		int greenDamage=(int)(baseDamageCalculation (user.level, Move.instance.getPowerGreen (),
			(int)(user.totalSpecialAttack*user.getSpecialAttackDamageMod()), (int)(target.totalSpecialDef*target.getSpecialDefenseDamageMod())) * rNumb * modifier*critMod(user)) + 1;
		int grayDamage=(int)(baseDamageCalculation (user.level, Move.instance.getPowerGray (), 
			(int)(user.totalSpecialAttack*user.getSpecialAttackDamageMod()), (int)(target.totalSpecialDef*target.getSpecialDefenseDamageMod())) * rNumb * modifier*critMod(user)) + 1;
		int redDamage=(int)(baseDamageCalculation (user.level, Move.instance.getPowerRed (),
			(int)(user.totalSpecialAttack*user.getSpecialAttackDamageMod()), (int)(target.totalSpecialDef*target.getSpecialDefenseDamageMod())) * rNumb * modifier*critMod(user)) + 1;

		target.battleHealthGreen -= greenDamage;
		target.battleHealthGray -= grayDamage;
		target.battleHealthRed -= redDamage;

		target.setDamageTaken (greenDamage,grayDamage,redDamage);
		user.setDamageDealt(greenDamage,grayDamage,redDamage);
	}


	public float critMod(BasicCombative user)
	{
		if (user.isNextMoveCrit ()) {
			return 1.5f;
		}
		return 1.0f;
	}

	private void swapEffectPlacements()
	{
		additionalEffect = additionalSecondEffect;
		magnitudeOfEffect = magnitudeOfSecondEffect;
		percentForEffect = percentForSecondEffect;
	}

	/// <summary>
	/// The addition effect. Stat effects are in increments of 2.
	/// </summary>
	/// <param name="modifier">Modifier Number.</param>
	/// <param name="target">Target.</param>
	/// <param name="highRoll">High roll.</param>
	public void effectPlacement(float modifier,BasicCombative target,float highRoll)
	{
		float roll = Random.Range (0.0f, highRoll);
		float scaledPercent=percentForEffect * modifier + roll;
		float multiplier = 1.0f;

		if (scaledPercent>= 100.0f) {
			if (scaledPercent > 200.0f) {
				multiplier = 1.5f;
				if (scaledPercent > 400.0f) {
					multiplier = 2.0f;
					if (scaledPercent > 800.0f) {
						multiplier = 2.5f;
					}
				}
			}
			magnitudeOfEffect = (int)(magnitudeOfEffect * multiplier);
			print (additionalEffect+" type effect taken: " + scaledPercent + " with strength: " + magnitudeOfEffect);
		} 
		else if(scaledPercent< 100.0f){
			magnitudeOfEffect=(int)(0.5*magnitudeOfEffect);
		}

		if (additionalEffect == EffEnum.NONE) {
		} 
		else if (additionalEffect == EffEnum.BURN) {//burn
			target.setStatusConBurn(target.getStatusConBurn()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.FREEZE) {//freeze
			target.setStatusConFreeze(target.getStatusConFreeze()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.PARA) {//para
			target.setStatusConPara(target.getStatusConPara()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.POISON) {//poison
			target.setStatusConPoison(target.getStatusConPoison()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.STATALL) {//All
			target.setStatLevelAll (target.getStatLevelAll()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.STATATT) {//Att
			target.setStatLevelAtt (target.getStatLevelAtt()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.STATDEF) {//def
			target.setStatLevelDef (target.getStatLevelDef()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.STATSPATT) {//spAtt
			target.setStatLevelSpAtt (target.getStatLevelSpAtt()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.STATSPDEF) {//spDef
			target.setStatLevelSpDef (target.getStatLevelSpDef()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.STATSPEED) {//speed
			target.setStatLevelSpd (target.getStatLevelSpd()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.FLINCH) {//flinch
		}
		else if (additionalEffect == EffEnum.CRITUP1) {//extra crit charge
			target.setCritMeter (target.getCritMeter () + 1);
		}
		else if (additionalEffect == EffEnum.STATACC) {//Accuracy
			target.setStatLevelAcc (target.getStatLevelAcc()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.STATEVASION) {//Evasion
			target.setStatLevelEvd (target.getStatLevelEvd()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.RANDOMWITHDRAW) {//withdraw randomly
			target.randomSwitchOut();
		}
		else if (additionalEffect == EffEnum.FLIGHT) {//flying
			if (target.isBattleCndFlying ()) {
				target.setBattleCndFlying (false);
			} else {
				target.setBattleCndFlying (true);
			}
		}
		else if (additionalEffect == EffEnum.RECOILQUARTER) {//recoil 25% green
			target.battleHealthGreen-=(int)(target.getLastAmountOfDamageDealtGreen()/4.0f);
		}
		else if (additionalEffect == EffEnum.RECOILTHIRD) {//recoil 33% green
			target.battleHealthGreen-=(int)(target.getLastAmountOfDamageDealtGreen()/3.0f);
		}
		else if (additionalEffect == EffEnum.SLEEP) {//sleep
			target.setStatusConSleep(target.getStatusConSleep()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.CONFUSION) {//confusion
			target.setStatusConConfusion(target.getStatusConConfusion()+magnitudeOfEffect);
		}
		else if (additionalEffect == EffEnum.CRASHDAMAGEHALF) {
			target.battleHealthGreen = target.battleHealthGreen / 2;
		}

	}

	public int baseDamageCalculation(int level,int movePower,int attack,int otherDef)
	{
		//* Random.Range (0.85f, 1.0f)
		int dNumb=(int)(((((2 * level) / 5 + 2) * movePower * attack / otherDef) / 50 + 2) );
		return dNumb;
	}

	/// <summary>
	/// A routine of methods called at the end of a move.
	/// </summary>
	/// <param name="user">User.</param>
	public void endOfMoveWrapUp(BasicCombative user)
	{
		if (user.isNextMoveCrit ()) {
			user.setCritMeter (0);
			user.flipNextMoveCrit ();
		}

		user.setCritMeter (user.getCritMeter () + 1);
	}

	/// <summary>
	/// Calculates the move effectiveness.
	/// * 1=normal
	/// * 2=fire
	///	* 3=water
	///	* 4=electric
	///	* 5=grass
	///	* 6=ice
	///	* 7=fighting
	///	* 8=poison
	///	* 9=ground
	///	* 10=flying
	///	* 11=psychic
	///	* 12=bug
	///	* 13=rock
	///	* 14=ghost
	///	* 15=dragon
	///	* 16=dark
	///	* 17=steel
	///	* 18=fairy
	///	* 0=typeless
	/// </summary>
	/// <returns>The move effectiveness.</returns>
	/// <param name="type1">Type1.</param>
	/// <param name="type2">Type2.</param>
	public float calculateMoveEffectiveness(int type1,int type2)
	{
		float modifier = 1.0f;
		modifier *= typeEffectiveness (Move.instance.getType(),type1);
		modifier *= typeEffectiveness (Move.instance.getType(),type2);

		return modifier;
	}

	/// <summary>
	/// Calculates what the same type advatage bonus should be
	/// </summary>
	/// <returns>The type advantage bonus.</returns>
	/// <param name="user">User.</param>
	public float sameTypeAdvantageBonus(BasicCombative user)
	{
		if (Move.instance.getType () == user.type1) {
			return 1.5f;
		}

		if (Move.instance.getType () == user.type2) {
			return 1.5f;
		}

		return 1.0f;
	}

	public float typeEffectiveness(int attType,int defType)
	{
		if (attType == 1) {
			if (defType == 13) {return 0.5f;} 
			else if (defType == 14) {return 0.0f;}
			else if (defType == 17) {return 0.5f;}
		}
		else if (attType == 2) {
			if (defType == 2) {return 0.5f;} 
			else if (defType == 3) {return 0.5f;}
			else if (defType == 5) {return 2.0f;}
			else if (defType == 6) {return 2.0f;}
			else if (defType == 12) {return 2.0f;}
			else if (defType == 13) {return 0.5f;}
			else if (defType == 15) {return 0.5f;}
			else if (defType == 17) {return 2.0f;}

		}
		else if (attType == 3) {
			if (defType == 2) {return 2.0f;} 
			else if (defType == 3) {return 0.5f;}
			else if (defType == 5) {return 0.5f;}
			else if (defType == 9) {return 2.0f;}
			else if (defType == 13) {return 2.0f;}
			else if (defType == 15) {return 0.5f;}

		}
		else if (attType == 4) {
			if (defType == 3) {return 2.0f;} 
			else if (defType == 4) {return 0.5f;}
			else if (defType == 5) {return 0.5f;}
			else if (defType == 9) {return 0.0f;}
			else if (defType == 10) {return 2.0f;}
			else if (defType == 15) {return 0.5f;}

		}
		else if (attType == 5) {
			if (defType == 2) {return 0.5f;} 
			else if (defType == 3) {return 2.0f;}
			else if (defType == 5) {return 0.5f;}
			else if (defType == 8) {return 0.5f;}
			else if (defType == 9) {return 2.0f;}
			else if (defType == 10) {return 0.5f;}
			else if (defType == 12) {return 0.5f;}
			else if (defType == 13) {return 1.0f;}
			else if (defType == 15) {return 0.5f;}
			else if (defType == 17) {return 0.5f;}

		}
		else if (attType == 6) {
			if (defType == 2) {return 0.5f;} 
			else if (defType == 3) {return 0.5f;}
			else if (defType == 5) {return 2.0f;}
			else if (defType == 6) {return 0.5f;}
			else if (defType == 9) {return 2.0f;}
			else if (defType == 10) {return 2.0f;}
			else if (defType == 15) {return 0.5f;}

		}
		else if (attType == 7) {
			if (defType == 1) {return 2.0f;} 
			else if (defType == 6) {return 2.0f;}
			else if (defType == 8) {return 0.5f;}
			else if (defType == 10) {return 0.5f;}
			else if (defType == 11) {return 0.5f;}
			else if (defType == 12) {return 0.5f;}
			else if (defType == 13) {return 2.0f;}
			else if (defType == 14) {return 0.0f;}
			else if (defType == 16) {return 2.0f;}
			else if (defType == 17) {return 2.0f;}
			else if (defType == 18) {return 0.5f;}

		}
		else if (attType == 8) {
			if (defType == 5) {return 2.0f;} 
			else if (defType == 8) {return 0.5f;}
			else if (defType == 9) {return 0.5f;}
			else if (defType == 13) {return 0.5f;}
			else if (defType == 14) {return 0.5f;}
			else if (defType == 17) {return 0.0f;}
			else if (defType == 14) {return 2.0f;}

		}
		else if (attType == 9) {
			if (defType == 2) {return 2.0f;} 
			else if (defType == 4) {return 2.0f;}
			else if (defType == 5) {return 0.5f;}
			else if (defType == 8) {return 2.0f;}
			else if (defType == 10) {return 0.0f;}
			else if (defType == 12) {return 0.5f;}
			else if (defType == 13) {return 2.0f;}
			else if (defType == 17) {return 2.0f;}

		}
		else if (attType == 10) {
			if (defType == 4) {return 0.5f;} 
			else if (defType == 5) {return 2.0f;}
			else if (defType == 7) {return 2.0f;}
			else if (defType == 12) {return 2.0f;}
			else if (defType == 13) {return 0.5f;}
			else if (defType == 17) {return 0.5f;}

		}
		else if (attType == 11) {
			if (defType == 7) {return 2.0f;} 
			else if (defType == 8) {return 2.0f;}
			else if (defType == 11) {return 0.5f;}
			else if (defType == 16) {return 0.0f;}
			else if (defType == 17) {return 0.5f;}

		}
		else if (attType == 12) {
			if (defType == 2) {return 0.5f;} 
			else if (defType == 5) {return 2.0f;}
			else if (defType == 7) {return 0.5f;}
			else if (defType == 8) {return 0.5f;}
			else if (defType == 10) {return 0.5f;}
			else if (defType == 11) {return 2.0f;}
			else if (defType == 14) {return 0.5f;}
			else if (defType == 16) {return 2.0f;}
			else if (defType == 17) {return 0.5f;}
			else if (defType == 18) {return 0.5f;}

		}
		else if (attType == 13) {
			if (defType == 2) {return 2.0f;} 
			else if (defType == 6) {return 2.0f;}
			else if (defType == 7) {return 0.5f;}
			else if (defType == 9) {return 0.5f;}
			else if (defType == 10) {return 2.0f;}
			else if (defType == 12) {return 2.0f;}
			else if (defType == 17) {return 0.5f;}

		}
		else if (attType == 14) {
			if (defType == 1) {return 0.0f;} 
			else if (defType == 11) {return 2.0f;}
			else if (defType == 14) {return 2.0f;}
			else if (defType == 16) {return 0.5f;}

		}
		else if (attType == 15) {
			if (defType == 15) {return 2.0f;} 
			else if (defType == 16) {return 0.5f;}
			else if (defType == 17) {return 0.0f;}

		}
		else if (attType == 16) {
			if (defType == 7) {return 0.5f;} 
			else if (defType == 11) {return 2.0f;}
			else if (defType == 14) {return 2.0f;}
			else if (defType == 16) {return 0.5f;}
			else if (defType == 18) {return 0.5f;}

		}
		else if (attType == 17) {
			if (defType == 2) {return 0.5f;} 
			else if (defType == 3) {return 0.5f;}
			else if (defType == 4) {return 0.5f;}
			else if (defType == 6) {return 2.0f;}
			else if (defType == 13) {return 2.0f;}
			else if (defType == 17) {return 0.5f;}
			else if (defType == 18) {return 2.0f;}

		}
		else if (attType == 18) {
			if (defType == 2) {return 0.5f;} 
			else if (defType == 7) {return 2.0f;}
			else if (defType == 8) {return 0.5f;}
			else if (defType == 15) {return 2.0f;}
			else if (defType == 16) {return 2.0f;}
			else if (defType == 17) {return 0.5f;}

		}


		return 1.0f;
	}

	private int accuracyCheck(int acc,float accMod,BasicCombative target)
	{
		if (acc*accMod*target.doesThisMoveHit(moveID) - Random.Range (0.0f, 100.0f) < 0.0f) {
			return 1;
		}

		return 0;
	}

	public int getType()
	{
		return type;
	}

	public int getCatagory()
	{
		return catagory;
	}

	public int getPP()
	{
		return pp;
	}

	public string getDescription()
	{
		return description;
	}

	public int getPowerGreen()
	{
		return powerGreen;
	}

	public int getPowerGray()
	{
		return powerGray;
	}

	public int getPowerRed()
	{
		return powerRed;
	}

	public int getAccuracy()
	{
		return accuracy;
	}

	public int getPriority()
	{
		return priority;
	}

	public string getVisaName()
	{
		return visaName;
	}
	public int getTargetSystem()
	{
		return targetSystem;
	}


}
/*
public enum AdditionEffect{NONE,BURN,PARA,FREEZE,POISON,SLEEP,CONFUSION,STATATT,STATDEF,STATSPATT
,STATSPDEF,STATSPEED,STATALL,STATACC,STATEVASION,FLINCH,CRITUP1,CRITUPx2,RANDOMWITHDRAW,RECOILTHIRD,RECOILQUARTER
,FLIGHT};*/