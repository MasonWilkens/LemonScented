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

	private TypeEnum type;
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
	private AttackMethodEnum attackMethod;

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
		type = TypeEnum.typeless;
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
		attackMethod = AttackMethodEnum.basicAttack;
		secondEffect = false;
		genericUserEffector (null,0,0,0);
	}

	public void parseMoveByNumber(int numberID,int varient,BasicCombative go)
	{

		cleanMoveInfo ();
		moveID = numberID;
		if (numberID == 1) {
			type = TypeEnum.normal;
			catagory = 1;
			pp = 35;
			powerGreen = 40;
			powerGray = 30;
			powerRed = 20;
			accuracy = 100;
			priority = 0;
			visaName = "Pound";
			description = "The target is physically pounded with a long tail, a foreleg, or the like.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 2) {
			type = TypeEnum.fighting;
			catagory = 1;
			pp = 25;
			powerGreen = 50;
			powerGray = 25;
			powerRed = 20;
			accuracy = 100;
			priority = 0;
			visaName = "Karate Chop";
			description = "The target is attacked with a sharp chop. Critical hits land more easily.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.CRITUP1,0,0);
		}
		else if (numberID == 3) {
			//print ("Double Slap");
			type = TypeEnum.normal;
			catagory = 1;
			pp = 15;
			powerGreen = 15;
			powerGray = 7;
			powerRed = 3;
			accuracy = 85;
			priority = 0;
			visaName = "Double Slap";
			description = "The target is slapped repeatedly, back and forth, two to five times in a row.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.multiAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);

		}
		else if (numberID == 4) {
			//print ("Comet Punch");
			type = TypeEnum.normal;
			catagory = 1;
			pp = 15;
			powerGreen = 18;
			powerGray = 10;
			powerRed = 8;
			accuracy = 85;
			priority = 0;
			visaName = "Comet Punch";
			description = "The target is hit with a flurry of punches that strike two to five times in a row.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.multiAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 5) {
			//print ("Mega Punch");
			type = TypeEnum.normal;
			catagory = 1;
			pp = 20;
			powerGreen = 80;
			powerGray = 70;
			powerRed = 60;
			accuracy = 85;
			priority = 0;
			visaName = "Mega Punch";
			description = "The target is slugged by a punch thrown with muscle-packed power.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 6) {
			//TODO incorperate pay day effect
			type = TypeEnum.normal;
			catagory = 1;
			pp = 20;
			powerGreen = 40;
			powerGray = 40;
			powerRed = 40;
			accuracy = 100;
			priority = 0;
			visaName = "Pay Day";
			description = "Numerous coins are hurled at the target to inflict damage. Money is earned after the battle.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 7) {
			type = TypeEnum.fire;
			catagory = 1;
			pp = 15;
			powerGreen = 75;
			powerGray = 75;
			powerRed = 75;
			accuracy = 100;
			priority = 0;
			visaName = "Fire Punch";
			description = "The target is punched with a fiery fist. This may also leave the target with a burn.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.BURN,50,1);
		}
		else if (numberID == 8) {
			type = TypeEnum.ice;
			catagory = 1;
			pp = 15;
			powerGreen = 75;
			powerGray = 75;
			powerRed = 75;
			accuracy = 100;
			priority = 0;
			visaName = "Ice Punch";
			description = "The target is punched with an icy fist. This may also leave the target frozen.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.FREEZE,50,1);
		}
		else if (numberID == 9) {
			type = TypeEnum.electric;
			catagory = 1;
			pp = 15;
			powerGreen = 75;
			powerGray = 75;
			powerRed = 75;
			accuracy = 100;
			priority = 0;
			visaName = "Thunder Punch";
			description = "The target is punched with an electrified fist. This may also leave the target with paralysis.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.PARA,50,1);
		}
		else if (numberID == 10) {
			type = TypeEnum.normal;
			catagory = 1;
			pp = 35;
			powerGreen = 40;
			powerGray = 40;
			powerRed = 40;
			accuracy = 100;
			priority = 0;
			visaName = "Scratch";
			description = "Hard, pointed, sharp claws rake the target to inflict damage.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 11) {
			type = TypeEnum.normal;
			catagory = 1;
			pp = 30;
			powerGreen = 55;
			powerGray = 55;
			powerRed = 55;
			accuracy = 100;
			priority = 0;
			visaName = "Vice Grip";
			description = "The target is gripped and squeezed from both sides to inflict damage.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 12) {
			type = TypeEnum.normal;
			catagory = 1;
			pp = 5;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 0;
			priority = 0;
			visaName = "Guillotine";
			description = "A vicious, tearing attack with big pincers. The target faints instantly if this attack hits.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.OHKO;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 13) { 
			type = TypeEnum.normal;
			catagory = 2;
			pp = 10;
			powerGreen = 80;
			powerGray = 80;
			powerRed = 80;
			accuracy = 100;
			priority = 0;
			visaName = "Razor Wind";
			description = "In this two-turn attack, blades of wind hit opposing Pokémon on the second turn. Critical hits land more easily.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.chargeAttack;
			genericUserEffector (go,EffEnum.CRITUP1,0,0);
		}
		else if (numberID == 14) {
			type = TypeEnum.normal;
			catagory = 3;
			pp = 20;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 100;
			priority = 0;
			visaName = "Swords Dance";
			description = "A frenetic dance to uplift the fighting spirit. This sharply raises the user's Attack stat.";
			targetSystem = 1;
			attackMethod = AttackMethodEnum.selfStatus;
			genericUserEffector (go,EffEnum.STATATT,100,4);
		}
		else if (numberID == 15) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =30;
			powerGreen = 50;
			powerGray = 50;
			powerRed = 50;
			accuracy = 95;
			priority = 0;
			visaName = "Cut";
			description = "The target is cut with a scythe or claw.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 16) {
			type = TypeEnum.flying;
			catagory = 2;
			pp =35;
			powerGreen = 40;
			powerGray = 40;
			powerRed = 40;
			accuracy = 100;
			priority = 0;
			visaName = "Gust";
			description = "A gust of wind is whipped up by wings and launched at the target to inflict damage.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 17) {
			type = TypeEnum.flying;
			catagory = 1;
			pp =35;
			powerGreen = 60;
			powerGray = 60;
			powerRed = 60;
			accuracy = 100;
			priority = 0;
			visaName = "Wing Attack";
			description = "The target is struck with large, imposing wings spread wide to inflict damage.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 18) {
			type = TypeEnum.normal;
			catagory = 3;
			pp =20;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 0;
			priority = -1;
			visaName = "Whirlwind";
			description = "The target is blown away, and a different Pokémon is dragged out. In the wild, this ends a battle against a single Pokémon.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.forceWithdrawMove;
			genericUserEffector (go,EffEnum.RANDOMWITHDRAW,0,0);
		}
		else if (numberID == 19) {
			type = TypeEnum.flying;
			catagory = 1;
			pp =15;
			powerGreen = 90;
			powerGray = 90;
			powerRed = 90;
			accuracy = 95;
			priority = 0;
			visaName = "Fly";
			description = "The user soars and then strikes its target on the next turn.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.chargeAttackFirstTurnSelfStatus;
			genericUserEffector (go,EffEnum.FLIGHT,0,0);
		}
		else if (numberID == 20) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =20;
			powerGreen = 15;
			powerGray = 15;
			powerRed = 15;
			accuracy = 85;
			priority = 0;
			visaName = "Bind";
			description = "Things such as long bodies or tentacles are used to bind and squeeze the target for four to five turns.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 21) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =20;
			powerGreen = 80;
			powerGray = 80;
			powerRed = 80;
			accuracy = 75;
			priority = 0;
			visaName = "Slam";
			description = "The target is slammed with a long tail, vines, or the like to inflict damage.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 22) {
			type = TypeEnum.grass;
			catagory = 1;
			pp =25;
			powerGreen = 45;
			powerGray = 45;
			powerRed = 45;
			accuracy = 100;
			priority = 0;
			visaName = "Vine Whip";
			description = "The target is struck with slender, whiplike vines to inflict damage.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 23) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =20;
			powerGreen = 65;
			powerGray = 65;
			powerRed = 65;
			accuracy = 100;
			priority = 0;
			visaName = "Stomp";
			description = "The target is stomped with a big foot. This may also make the target flinch.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 24) {
			type = TypeEnum.fighting;
			catagory = 1;
			pp =30;
			powerGreen = 30;
			powerGray = 15;
			powerRed = 10;
			accuracy = 100;
			priority = 0;
			visaName = "Double Kick";
			description = "The target is quickly kicked twice in succession using both feet.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.doubleAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 25) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =5;
			powerGreen = 120;
			powerGray = 120;
			powerRed = 120;
			accuracy = 75;
			priority = 0;
			visaName = "Mega Kick";
			description = "The target is attacked by a kick launched with muscle-packed power.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 26) {
			type = TypeEnum.fighting;
			catagory = 1;
			pp =10;
			powerGreen = 100;
			powerGray = 50;
			powerRed = 40;
			accuracy = 95;
			priority = 0;
			visaName = "Jump Kick";
			description = "The user jumps up high, then strikes with a kick. If the kick misses, the user hurts itself.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.jumpkickMissDamage;
			genericUserEffector (go,EffEnum.NONE,0,0,EffEnum.CRASHDAMAGEHALF,0,0);
			secondEffect = true;
		}
		else if (numberID == 27) {
			type = TypeEnum.fighting;
			catagory = 1;
			pp =15;
			powerGreen = 60;
			powerGray = 30;
			powerRed = 25;
			accuracy = 85;
			priority = 0;
			visaName = "Rolling Kick";
			description = "The user lashes out with a quick, spinning kick. This may also make the target flinch.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 28) {
			type = TypeEnum.ground;
			catagory = 1;
			pp =15;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 100;
			priority = 0;
			visaName = "Sand Attack";
			description = "Sand is hurled in the target's face, reducing the target's accuracy.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.targetedStatus;
			genericUserEffector (go,EffEnum.STATACC,100,-2);
		}
		else if (numberID == 29) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =15;
			powerGreen = 70;
			powerGray = 70;
			powerRed = 70;
			accuracy = 100;
			priority = 0;
			visaName = "Headbutt";
			description = "The user sticks out its head and attacks by charging straight into the target. This may also make the target flinch.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 30) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =25;
			powerGreen = 65;
			powerGray = 65;
			powerRed = 65;
			accuracy = 100;
			priority = 0;
			visaName = "Horn Attack";
			description = "The target is jabbed with a sharply pointed horn to inflict damage.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 31) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =20;
			powerGreen = 15;
			powerGray =15 ;
			powerRed = 15;
			accuracy = 85;
			priority = 0;
			visaName = "Fury Attack";
			description = "The target is jabbed repeatedly with a horn or beak two to five times in a row.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.multiAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 32) {
			type = TypeEnum.normal;
			catagory = 1;
			pp = 5;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 0;
			priority = 0;
			visaName = "Horn Drill";
			description = "The user stabs the target with a horn that rotates like a drill. The target faints instantly if this attack hits.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.OHKO;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 33) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =35;
			powerGreen = 40;
			powerGray = 40;
			powerRed = 40;
			accuracy = 100;
			priority = 0;
			visaName = "Tackle";
			description = "A physical attack in which the user charges and slams into the target with its whole body.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 34) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =15;
			powerGreen = 85;
			powerGray = 85;
			powerRed = 85;
			accuracy = 100;
			priority = 0;
			visaName = "Body Slam";
			description = "The user drops onto the target with its full body weight. This may also leave the target with paralysis.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack; 
			genericUserEffector (go,EffEnum.PARA,75,1);
		}
		else if (numberID == 35) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =20;
			powerGreen = 15;
			powerGray = 15;
			powerRed = 15;
			accuracy = 90;
			priority = 0;
			visaName = "Wrap";
			description = "A long body, vines, or the like are used to wrap and squeeze the target for four to five turns.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 36) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =20;
			powerGreen = 90;
			powerGray = 90;
			powerRed = 90;
			accuracy = 85;
			priority = 0;
			visaName = "Take Down";
			description = "A reckless, full-body charge attack for slamming into the target. This also damages the user a little.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.selfStatusOnConnectAfterAttack;
			genericUserEffector (go,EffEnum.RECOILQUARTER,0,0);
		}
		else if (numberID == 37) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =10;
			powerGreen = 120;
			powerGray = 120;
			powerRed = 120;
			accuracy = 100;
			priority = 0;
			visaName = "Thrash";//TODO code attackMethod and frenzy mechanic
			description = "The user rampages and attacks for two to three turns. The user then becomes confused.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 38) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =15;
			powerGreen = 120;
			powerGray = 120;
			powerRed = 120;
			accuracy = 100;
			priority = 0;
			visaName = "Double-Edge";
			description = "A reckless, life-risking tackle. This also damages the user quite a lot.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.selfStatusOnConnectAfterAttack;
			genericUserEffector (go,EffEnum.RECOILTHIRD,0,0);
		}
		else if (numberID == 39) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =30;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 100;
			priority = 0;
			visaName = "Tail Whip";
			description = "The user wags its tail cutely, making opposing Pokémon less wary and lowering their Defense stat.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.targetedStatus;
			genericUserEffector (go,EffEnum.STATDEF,100,-2);

		}
		else if (numberID == 40) {
			type = TypeEnum.poison;
			catagory = 1;
			pp =35;
			powerGreen = 15;
			powerGray = 15;
			powerRed = 15;
			accuracy = 100;
			priority = 0;
			visaName = "Poison Sting";
			description = "The user stabs the target with a poisonous stinger. This may also poison the target.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.POISON,100,1);
		}
		else if (numberID == 41) {
			type = TypeEnum.bug;
			catagory = 1;
			pp =30;
			powerGreen = 25;
			powerGray = 25;
			powerRed = 25;
			accuracy = 100;
			priority = 0;
			visaName = "Twineedle";
			description = "The user damages the target twice in succession by jabbing it with two spikes. This may also poison the target.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.doubleAttack;
			genericUserEffector (go, EffEnum.POISON, 50, 1);
		}
		else if (numberID == 42) {
			type = TypeEnum.bug;
			catagory = 1;
			pp =20;
			powerGreen = 25;
			powerGray =25 ;
			powerRed = 25;
			accuracy = 95;
			priority = 0;
			visaName = "Pin Missile";
			description = "Sharp spikes are shot at the target in rapid succession. They hit two to five times in a row.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.multiAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 43) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =30;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 100;
			priority = 0;
			visaName = "Leer";
			description = "The user gives opposing Pokémon an intimidating leer that lowers the Defense stat.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.targetedStatus;
			genericUserEffector (go,EffEnum.STATDEF,100,-2);
		}
		else if (numberID == 44) {
			type = TypeEnum.dark;
			catagory = 1;
			pp =25;
			powerGreen = 65;
			powerGray = 65;
			powerRed = 65;
			accuracy = 100;
			priority = 0;
			visaName = "Bite";
			description = "The target is bitten with viciously sharp fangs. This may also make the target flinch.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.basicAttack;
			genericUserEffector (go,EffEnum.NONE,0,0);
		}
		else if (numberID == 45) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =40;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 100;
			priority = 0;
			visaName = "Growl";
			description = "The user growls in an endearing way, making opposing Pokémon less wary. This lowers their Attack stat.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.targetedStatus;
			genericUserEffector (go,EffEnum.STATATT,100,-2);
		}
		else if (numberID == 46) {
			type = TypeEnum.normal;
			catagory = 3;
			pp =20;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 0;
			priority = -1;
			visaName = "Roar";
			description = "The target is scared off, and a different Pokémon is dragged out. In the wild, this ends a battle against a single Pokémon.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.forceWithdrawMove;
			genericUserEffector (go,EffEnum.RANDOMWITHDRAW,0,0);
		}
		else if (numberID == 47) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =15;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 55;
			priority = 0;
			visaName = "Sing";
			description = "A soothing lullaby is sung in a calming voice that puts the target into a deep slumber.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.targetedStatus;
			genericUserEffector (go,EffEnum.SLEEP,100,2);
		}
		else if (numberID == 48) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =20;
			powerGreen = 0;
			powerGray = 0;
			powerRed = 0;
			accuracy = 55;
			priority = 0;
			visaName = "Supersonic";
			description = "The user generates odd sound waves from its body that confuse the target.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.targetedStatus;
			genericUserEffector (go,EffEnum.CONFUSION,100,2);
		}
		else if (numberID == 49) {
			type = TypeEnum.normal;
			catagory = 1;
			pp =20;
			powerGreen = 20;
			powerGray = 20;
			powerRed = 20;
			accuracy = 90;
			priority = 0;
			visaName = "Super Boom";
			description = "The target is hit with a destructive shock wave that always inflicts 20 HP damage.";
			targetSystem = 0;
			attackMethod = AttackMethodEnum.flatAttack;
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

	/// <summary>
	/// Sets generic effector
	/// </summary>
	/// <param name="go">Go.</param>
	/// <param name="additionalEffect">Additional effect.</param>
	/// <param name="percentForEffect">Percent for effect.</param>
	/// <param name="magnitudeOfEffect">Magnitude of effect.</param>
	/// <param name="additionalSecondEffect">Additional second effect.</param>
	/// <param name="percentForSecondEffect">Percent for second effect.</param>
	/// <param name="magnitudeOfSecondEffect">Magnitude of second effect.</param>
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
		if (attackMethod == AttackMethodEnum.basicAttack) {
			basicAttack (user, target);
		} 
		else if (attackMethod == AttackMethodEnum.multiAttack) {
			multiAttack (user, target);
		}
		else if (attackMethod == AttackMethodEnum.doubleAttack) {
			doubleAttack (user, target);
		}
		else if (attackMethod == AttackMethodEnum.selfStatus) {
			selfStatus (user);
		}
		else if (attackMethod == AttackMethodEnum.OHKO) {
			OHKOAttack (user, target);
		}
		else if (attackMethod == AttackMethodEnum.targetedStatus) {
			targetedStatus (user, target);
		}
		else if (attackMethod == AttackMethodEnum.chargeAttack) {
			chargeAttack (user, target);
		}
		else if (attackMethod == AttackMethodEnum.forceWithdrawMove) {
			forceWithdrawStatus (user, target);
		}
		else if (attackMethod == AttackMethodEnum.chargeAttackFirstTurnSelfStatus) {
			chargeAttackFirstTurnSelfStatus (user, target);
		}
		else if (attackMethod == AttackMethodEnum.jumpkickMissDamage) {
			jumpAttack (user, target);
		}
		else if (attackMethod == AttackMethodEnum.selfStatusOnConnectAfterAttack) {
			selfStatusOnConnectAfterAttack (user, target);
		}
		else if (attackMethod == AttackMethodEnum.flatAttack) {
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
	public float calculateMoveEffectiveness(TypeEnum type1,TypeEnum type2)
	{
		float modifier = 1.0f;
		modifier *= TypeEffect.typeEffectiveness (Move.instance.getType(),type1);
		modifier *= TypeEffect.typeEffectiveness (Move.instance.getType(),type2);

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
