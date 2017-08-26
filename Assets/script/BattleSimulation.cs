 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSimulation : MonoBehaviour {

	//TODO
	//get mach icons for burn,freeze,para, and poison
	//get crit system made

	public BasicCombative red1;
	public BasicCombative blue1;//player

	public PartySystem redPS;
	public PartySystem bluePS;

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

	public int[] commandList;
	public Ticket[] ticketList=new Ticket[100];

	private int ticketCounter;
	private int ticketStubs;

	public class Ticket
	{
		int priority;
		int speed;
		public int orderNumber;

		/// <summary>
		/// 1: player user-target (target can be self)
		/// 2: player auto selected move
		/// 3: environment-user (damage by status condition)
		/// 4: end of round health recover
		/// 5: switch
		/// <summary>
		int actionType;

		public BasicCombative user;
		public BasicCombative target;

		public Ticket()
		{
			priority=0;
			speed=0;
			actionType=0;
			user=null;
			target=null;
		}
			
		/// <summary>
		/// Be sure to have Move.instance set to the correct move for user
		/// ActionType range
		/// 1: player user-target (target can be self)
		/// 2: player user-environment (effect field conditions, ect)
		/// 3: environment-user (damage by status condition) <summary>
		/// 4: end of turn 1/16th green heal
		/// 5: switching, priority 8
		/// <summary>
		public Ticket(BasicCombative user,BasicCombative target,int actionType,float speedMod)
		{
			this.actionType=actionType;
			if(actionType==1)
			{
				priority=Move.instance.getPriority();
				speed=(int)(user.totalSpeed*speedMod);
			}
			else if(actionType==2)
			{
				priority=Move.instance.getPriority();
				speed=(int)(user.totalSpeed*speedMod);
			}
			else if(actionType==3)
			{
				priority=-3;
				speed=(int)(user.totalSpeed*speedMod);
			}
			else if(actionType==4)
			{
				priority=-7;
				speed=(int)(user.totalSpeed*speedMod);
			}
			else if(actionType==5)
			{
				
				priority=8;
				speed=(int)(user.totalSpeed*speedMod);
			}

			this.user=user;
			this.target=target;
		}

		public void setTicketFromRaw(int priority,int speed,int actionType)
		{
			this.priority = priority;
			this.speed = speed;
			this.actionType = actionType;
		}

		public void setTicketFromTicket(Ticket t)
		{
			this.priority = t.priority;
			this.speed = t.speed;
			this.actionType = t.actionType;
		}

		/*Sets this ticket values to 0
		*/
		public void wipeThisTicket()
		{
			this.priority = 0;
			this.speed = 0;
			this.actionType = 0;
		}

		public int getPriority()
		{
			return priority;
		}

		public int getSpeed()
		{
			return speed;
		}

		public int getActionType()
		{
			return actionType;
		}

		public void setSpeed(int speed)
		{
			this.speed = speed;
		}

		public void setActionType(int actionType)
		{
			this.actionType = actionType;
		}

		public string toString()
		{
			string s;

			if (actionType == 1) {
				s = "AT1: " + user.nickName + " to " + target.nickName;
			} 
			else if (actionType == 2) {
				s = "AT2: " + user.nickName + " to ENVIRO";
			}
			else if (actionType == 3) {
				s = "AT3: " + "ENVIRO to "+ user.nickName;
			}
			else if (actionType == 4) {
				s = "AT4: EOR 1/16 grayHeal for " + user.nickName;
			}
			else if (actionType == 5) {
				s = "AT5: Switching out " + user.nickName;
			}
			else{
				s = "AT"+actionType+": Unknown Action. user:" + user.nickName+" target:"+target.nickName;
			}

			s += " taken at priority " + priority + " with effective speed " + speed+" ordering "+orderNumber+"\n";

			return s;

		}

	}

	// Use this for initialization
	void Start () {
		while(ticketCounter < ticketList.Length) {
			ticketList[ticketCounter]=new Ticket();
			ticketCounter++;
		}
		ticketCounter = 0;

		moveButtonText ();
	}

	// Update is called once per frame
	void Update () {
		red1GreenBar.transform.localScale = new Vector3((float)red1.battleHealthGreen / red1.totalHealth,1.0f,1.0f);
		red1GrayBar.transform.localScale = new Vector3((float)red1.battleHealthGray / red1.totalHealth,1.0f,1.0f);
		red1RedBar.transform.localScale = new Vector3((float)red1.battleHealthRed / red1.totalHealth,1.0f,1.0f);

		blue1GreenBar.transform.localScale = new Vector3((float)blue1.battleHealthGreen / blue1.totalHealth,1.0f,1.0f);
		blue1GrayBar.transform.localScale = new Vector3((float)blue1.battleHealthGray / blue1.totalHealth,1.0f,1.0f);
		blue1RedBar.transform.localScale = new Vector3((float)blue1.battleHealthRed / blue1.totalHealth,1.0f,1.0f);

		if (red1.battleHealthGreen<0) {
			red1.battleHealthGreen = 0;
		}

		if (blue1.battleHealthGreen<0) {
			blue1.battleHealthGreen = 0;
		}

		if (red1.battleHealthGreen > red1.battleHealthGray) {
			red1.battleHealthGray = 0;
		}

		if (blue1.battleHealthGreen > blue1.battleHealthGray) {
			blue1.battleHealthGray = 0;
		}

		if (red1.battleHealthGray > red1.battleHealthRed) {
			red1.battleHealthRed = 0;
		}

		if (blue1.battleHealthGray > blue1.battleHealthRed) {
			blue1.battleHealthRed = 0;
		}
	}
	/// <summary>
	/// Switchs the out red1.
	/// </summary>
	/// <param name="i">The index.</param>
	public void switchOutRed1(int i)
	{
		red1.isSwitchingOut = true;
		red1.switchingNumber = i;
	}
	/// <summary>
	/// Switchs the out blue1.
	/// </summary>
	/// <param name="i">The index.</param>
	public void switchOutBlue1(int i)
	{
		blue1.isSwitchingOut = true;
		blue1.switchingNumber = i;
	}
	/// <summary>
	/// Selects the move for red1.
	/// </summary>
	/// <param name="i">The index.</param>
	public void selectMoveRed1(int i){
		red1.selectMove (i);
	}
	/// <summary>
	/// Selects the move for blue1.
	/// </summary>
	/// <param name="i">The index.</param>
	public void selectMoveBlue1(int i){
		blue1.selectMove (i);
	}
    
	/// <summary>
	/// ALMIGHTY insert sort
	/// </summary>
	/// <param name="i">The index. All tickets after i are sorted</param>
	public void sortTickets(int i)
	{
		int j = 0;
		Ticket tempTicket = new Ticket ();

		while(i<ticketList.Length)
		{
			ticketList[i].orderNumber=ticketList[i].getPriority()*10000+ticketList[i].getSpeed();
			tempTicket=ticketList[i];
			for(j=i;j!=0&&tempTicket.orderNumber>ticketList[j-1].orderNumber;j--)
			{
				ticketList[j]=ticketList[j-1];
			}

			ticketList[j]=tempTicket;

			if(i!=ticketList.Length)
			{
				i++;
			}
		}
	}


	/// <summary>
	/// Executes the round.
	/// </summary>
	/// <param name="k">The number of tickets processed</param>
	public void executeRound(int k)
	{

		startOfRoundTickets ();



		for (int commandInterval = 0; commandInterval < ticketList.Length; commandInterval++) {
			processNextTicket (commandInterval);
		}

		endOfRoundCleanUp ();
	}

	public void nextTicket()
	{
		if (ticketStubs == 0) {
			startOfRoundTickets ();
		}

		processNextTicket (ticketStubs);

		ticketStubs++;
		if(ticketStubs==ticketList.Length)
		{
			print ("EOR");
			endOfRoundCleanUp ();
		}
	}

	/// <summary>
	/// Starts of the round ticket generation.
	/// </summary>
	private void startOfRoundTickets()
	{
		combatTicket (red1,blue1);
		combatTicket (blue1,red1);

		endOfTurnStatusTickets (red1);
		endOfTurnStatusTickets (blue1);

		endOfTurnGrayRecoverTicket (red1);
		endOfTurnGrayRecoverTicket (blue1);
		sortTickets (0);
	}

	/// <summary>
	/// Cleans up tickets for next round and refreshes move list in case of switch.
	/// </summary>
	private void endOfRoundCleanUp()
	{
		for (int commandInterval = 0; commandInterval < ticketList.Length; commandInterval++) {
			ticketList [commandInterval].wipeThisTicket ();
		}
		ticketCounter = 0;
		ticketStubs = 0;
		moveButtonText ();//refresh move list
	}

	/// <summary>
	/// Processes the next ticket.
	/// </summary>
	/// <param name="commandInterval">Command interval. The Current index of the Tickets</param>
	private void processNextTicket(int commandInterval)
	{
		while (ticketList [commandInterval].getActionType () == 0 && commandInterval < ticketList.Length) {
			commandInterval++;
			ticketStubs++;
		}


		if (ticketList [commandInterval].getActionType () != 0) {
			if (ticketList [commandInterval].getActionType () == 1) {
				Move.instance.combativeRoundUserToTargetDamage (ticketList [commandInterval].user, ticketList [commandInterval].target);
				//print("BAS attack "+ticketList [commandInterval].user.nickName);
			} else if (ticketList [commandInterval].getActionType () == 3) {
				endOfTurnStatus (ticketList [commandInterval].user);
				//print("EOR status "+ticketList [commandInterval].user.nickName);
			} else if (ticketList [commandInterval].getActionType () == 4) {
				endOfTurnGrayRecover (ticketList [commandInterval].user);
				//print("EOR heal "+ticketList [commandInterval].user.nickName);
			} else if (ticketList [commandInterval].getActionType () == 5) {

				//print ("Switching By Ticket");
			}

			switchInCheck (commandInterval);

			print (ticketList [commandInterval].toString ());
			//do command
		}

	}

	private void switchInCheck(int commandInterval)
	{
		if (ticketList [commandInterval].user.isSwitchingOut) {
			BasicCombative switchOut = ticketList [commandInterval].user;
			BasicCombative switchIn = switchSwap (ticketList [commandInterval].user);
			print ("Switching Out " + switchOut.nickName + " In " + switchIn.nickName);
			relinkTicketsOnSwitch (switchOut, switchIn, commandInterval);
			sortTickets (commandInterval);//Refactor tickets
		}

		if (ticketList [commandInterval].target.isSwitchingOut) {
			BasicCombative switchOut = ticketList [commandInterval].target;
			BasicCombative switchIn = switchSwap (ticketList [commandInterval].target);
			print ("Switching Out " + switchOut.nickName + " In " + switchIn.nickName);
			relinkTicketsOnSwitch (switchOut, switchIn, commandInterval);
			sortTickets (commandInterval);//Refactor tickets
		}
	}

	/// <summary>
	/// Relinks the tickets on switch.
	/// </summary>
	/// <param name="user">Who is switching out.</param>
	/// <param name="switchIn">Switch in combative.</param>
	/// <param name="commandInterval">Command interval for ticket.</param>
	private void relinkTicketsOnSwitch(BasicCombative switchOut,BasicCombative switchIn,int commandInterval)
	{
		for (; commandInterval < ticketList.Length; commandInterval++) {

			if (ticketList [commandInterval].target != null) {
				if (ticketList [commandInterval].target.Equals (switchOut)) {
					ticketList [commandInterval].target = switchIn;
				}
			}

			if (ticketList [commandInterval].user != null) {
				if (ticketList [commandInterval].user.Equals (switchOut)) {
					if (ticketList [commandInterval].getActionType () == 1) {
						ticketList [commandInterval].setActionType (0);//effectively removes attacks from combative who already switched out
					}
					ticketList [commandInterval].user = switchIn;
					ticketList [commandInterval].setSpeed ((int)(switchIn.totalSpeed*switchIn.getSpeedMod()));//set ticket speed to new speed
				}
			}

		}
	}

	/// <summary>
	/// Creates and adds a combat action1 ticket to the ticketList.
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="target">Target.</param>
	private void combatTicket(BasicCombative user,BasicCombative target)
	{
		if (user.lockedOutAction == 0) {
			if (!user.isSwitchingOut) {
				if (user.getStatusConPara () > 0) {

					user.setParaTimer (user.getParaTimer () + Random.Range (0, user.getStatusConPara ()));
				}

				if (user.getParaTimer () <= 4) {
					Move.instance.parseMoveByNumber (user.getSelectedMoveID (), 1, user);
					if (Move.instance.getTargetSystem () == 0) {
						ticketList [ticketCounter] = new Ticket (user, target, 1, user.getSpeedMod ());
					} else if (Move.instance.getTargetSystem () == 1) {
						ticketList [ticketCounter] = new Ticket (user, target, 1, user.getSpeedMod ());
					}
					ticketCounter++;
				} else {
					user.setParaTimer (0);
					battleText.text += "\n" + user.nickName + " is fully paralysis";
				}

			} else {
				ticketList [ticketCounter] = new Ticket (user, target, 5, user.getSpeedMod ());//switch ticket
				ticketCounter++;
			}
		} 
		else if (user.lockedOutAction == 6) {//force switch
			ticketList [ticketCounter] = new Ticket (user, target, 5, user.getSpeedMod ());//switch ticket
			ticketCounter++;
		}
		else {//forced move
			user.selectMove(user.lockedOutAction);//lock move choice

			if (user.getStatusConPara () > 0) {

				user.setParaTimer (user.getParaTimer () + Random.Range (0, user.getStatusConPara ()));
			}

			if (user.getParaTimer () <= 4) {
				Move.instance.parseMoveByNumber (user.getSelectedMoveID (), 1, user);
				if (Move.instance.getTargetSystem () == 0) {
					ticketList [ticketCounter] = new Ticket (user, target, 1, user.getSpeedMod ());
				} else if (Move.instance.getTargetSystem () == 1) {
					ticketList [ticketCounter] = new Ticket (user, target, 1, user.getSpeedMod ());
				}
				ticketCounter++;
			} else {
				user.setParaTimer (0);
				battleText.text += "\n" + user.nickName + " is fully paralysis";
			}
		}

	}


	/// <summary>
	/// Switchs the user by number.
	/// </summary>
	/// <param name="user">User.</param>
	private BasicCombative switchSwap(BasicCombative user)
	{
		user.isSwitchingOut = false;//this way no auto switch on re-enter
		if (red1.Equals (user)) {
			if (red1.switchingNumber == 1) {
				red1 = redPS.combative1;
			} else if (red1.switchingNumber == 2) {
				red1 = redPS.combative2;
			} else if (red1.switchingNumber == 3) {
				red1 = redPS.combative3;
			} else if (red1.switchingNumber == 4) {
				red1 = redPS.combative4;
			} else if (red1.switchingNumber == 5) {
				red1 = redPS.combative5;
			} else if (red1.switchingNumber == 6) {
				red1 = redPS.combative6;
			} else {
				print ("red switch not viable: "+red1.switchingNumber);
			}
			return red1;
		} 
		else if (blue1.Equals (user)) {
			if (blue1.switchingNumber == 1) {
				blue1 = bluePS.combative1;
			} else if (blue1.switchingNumber == 2) {
				blue1 = bluePS.combative2;
			} else if (blue1.switchingNumber == 3) {
				blue1 = bluePS.combative3;
			} else if (blue1.switchingNumber == 4) {
				blue1 = bluePS.combative4;
			} else if (blue1.switchingNumber == 5) {
				blue1 = bluePS.combative5;
			} else if (blue1.switchingNumber == 6) {
				blue1 = bluePS.combative6;
			} else {
				print ("blue switch not viable: "+blue1.switchingNumber);
			}
			return blue1;
		}
		return user;
	}

	/// <summary>
	/// Generates status tickets for user
	/// </summary>
	/// <param name="user">User.</param>
	private void endOfTurnStatusTickets(BasicCombative user){
		ticketList [ticketCounter] = new Ticket (user, user, 3, user.getSpeedMod());
		ticketCounter++;
	}
	/// <summary>
	/// Creates and adds a action4 ticket to the ticketList.
	/// </summary>
	/// <param name="user">User.</param>
	private void endOfTurnGrayRecoverTicket(BasicCombative user)
	{
		//user.battleHealthGreen += Mathf.CeilToInt (user.totalHealth / 16.0f);
		ticketList [ticketCounter] = new Ticket (user, user, 4, user.getSpeedMod());
		ticketCounter++;
	}
	/// <summary>
	/// heals target green health by 1/16th
	/// </summary>
	/// <param name="user">User.</param>
	private void endOfTurnGrayRecover(BasicCombative user)
	{
		if (user.getStatusConPoison () <= 0) {
			user.battleHealthGreen += Mathf.CeilToInt (user.totalHealth / 16.0f);
			if (user.battleHealthGreen > user.battleHealthGray) {
				user.battleHealthGreen = user.battleHealthGray;
			}
		}

	}
	/// <summary>
	/// Applies effects of status at end of turn.
	/// </summary>
	/// <param name="user">User.</param>
	private void endOfTurnStatus(BasicCombative user){
		
		if (user.getStatusConBurn () > 0) {

			if (user.getStatusConBurn () == 1) {
				removePercentHealth (user,1.0f/16.0f);
			}
			else if (user.getStatusConBurn () == 2) {
				removePercentHealth (user,1.5f/16.0f);
			}
			else if (user.getStatusConBurn () > 2) {
				removePercentHealth (user,2.0f/16.0f);
			}
		}
			
		if (user.getStatusConPoison () > 0) {//poisoned
			if (user.getStatusConPoison () == 1) {
				removePercentHealth (user,1.0f/16.0f);
			}
			else if (user.getStatusConPoison () == 2) {
				removePercentHealth (user,user.getToxicTimer()/16.0f,user.getToxicTimer()/32.0f,user.getToxicTimer()/64.0f);
				user.setToxicTimer (user.getToxicTimer ()+1);

			}
			else if (user.getStatusConPoison () == 3) {
				removePercentHealth (user,user.getToxicTimer()/16.0f,user.getToxicTimer()/32.0f,user.getToxicTimer()/64.0f);
				user.setToxicTimer (user.getToxicTimer ()+1);

			}
			else if (user.getStatusConPoison () == 4) {
				removePercentHealth (user,user.getToxicTimer()/16.0f,user.getToxicTimer()/32.0f,user.getToxicTimer()/64.0f);
				user.setToxicTimer (user.getToxicTimer ()+1);

			}
			else if (user.getStatusConPoison () == 5) {
				removePercentHealth (user,user.getToxicTimer()/16.0f,user.getToxicTimer()/32.0f,user.getToxicTimer()/64.0f);
				user.setToxicTimer (user.getToxicTimer ()*2);

			}
			else if (user.getStatusConPoison () == 6) {
				removePercentHealth (user,user.getToxicTimer()/16.0f,user.getToxicTimer()/32.0f,user.getToxicTimer()/64.0f);
				user.setToxicTimer (user.getToxicTimer ()*2);

			}
		}
	}
	/// <summary>
	/// Removes the percent health from user.
	/// </summary>
	/// <param name="user">User.</param>
	/// <param name="percentage">Percentage.</param>
	private void removePercentHealth(BasicCombative user,float percentageGreen,float percentageGray,float percentageRed){
		user.battleHealthGreen -= Mathf.CeilToInt (user.totalHealth *percentageGreen);
		user.battleHealthGray -= Mathf.CeilToInt (user.totalHealth *percentageGray);
		user.battleHealthRed -= Mathf.CeilToInt (user.totalHealth *percentageRed);
	}

	private void removePercentHealth(BasicCombative user,float percentageGreen){
		user.battleHealthGreen -= Mathf.CeilToInt (user.totalHealth *percentageGreen);
		if (user.battleHealthGreen > user.battleHealthGray) {
			user.battleHealthGreen = user.battleHealthGray;
		}
	}

	private void moveButtonText()
	{
		Move.instance.parseMoveByNumber (blue1.move1, 1, blue1);
		userMoveText1.text=Move.instance.getVisaName();
		Move.instance.parseMoveByNumber (blue1.move2, 1, blue1);
		userMoveText2.text=Move.instance.getVisaName();
		Move.instance.parseMoveByNumber (blue1.move3, 1, blue1);
		userMoveText3.text=Move.instance.getVisaName();
		Move.instance.parseMoveByNumber (blue1.move4, 1, blue1);
		userMoveText4.text=Move.instance.getVisaName();
		Move.instance.parseMoveByNumber (blue1.move5, 1, blue1);
		userMoveText5.text=Move.instance.getVisaName();
	}

	/*
	public void combativeRoundUserToTargetDamage(BasicCombative user,BasicCombative target)
	{
		Move.instance.parseMoveByNumber(user.getSelectedMoveID(),1,user);
		float rNumb = Random.Range (0.85f, 1.0f);
		float modifier = calculateMoveEffectiveness(target.type1,target.type2);
		string effectiveText="";

		if (accuracyCheck (Move.instance.getAccuracy ()) == 0) {
			target.battleHealthGreen -= (int)(baseDamageCalculation (user.level, Move.instance.getPowerGreen (), user.basicAttack, target.basicDef) * rNumb * modifier);
			target.battleHealthGray -= (int)(baseDamageCalculation (user.level, Move.instance.getPowerGray (), user.basicAttack, target.basicDef) * rNumb * modifier);
			target.battleHealthRed -= (int)(baseDamageCalculation (user.level, Move.instance.getPowerRed (), user.basicAttack, target.basicDef) * rNumb * modifier);

			if (modifier > 1.0f) {
				effectiveText = "super effective :" + modifier;
			} else if (modifier == 0) {
				effectiveText = "no effect :" + modifier;
			} else if (modifier < 1.0) {
				effectiveText = "not very effective :" + modifier;
			} else if (modifier == 1.0) {
				effectiveText = "regular effective :" + modifier;
			}

			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nit's "+effectiveText;

		} 
		else {
			battleText.text += "\n"+user.nickName+" Uses "+Move.instance.getVisaName()+"\nThe attack missed";
		}
			
	}*/
	/*
	public int baseDamageCalculation(int level,int movePower,int attack,int otherDef)
	{
		//* Random.Range (0.85f, 1.0f)
		int dNumb=(int)(((((2 * level) / 5 + 2) * movePower * attack / otherDef) / 50 + 2) );
		return dNumb;
	}*/
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

	public float calculateMoveEffectiveness(int type1,int type2)
	{
		float modifier = 1.0f;
		modifier *= typeEffectiveness (Move.instance.getType(),type1);
		modifier *= typeEffectiveness (Move.instance.getType(),type2);

		return modifier;
	}*/
	/*
	
	*/
	/*
	private int accuracyCheck(int acc)
	{
		if (acc - Random.Range (0, 100) < 0) {
			return 1;
		}

		return 0;
	}
	*/
	/*
	public void combativeRoundRed()
	{
		Move.instance.parseMoveByNumber(red1.getSelectedMoveID(),1,red1);
		//print (baseDamageCalculation (blue1.level,100,blue1.basicAttack,red1.basicDef));
		string effectiveText="";
		float rNumb = Random.Range (0.85f, 1.0f);
		float modifier = calculateMoveEffectiveness(blue1.type1,blue1.type2);

		blue1.battleHealthGreen -= (int)(baseDamageCalculation (red1.level, Move.instance.getPowerGreen(), red1.basicAttack, blue1.basicDef)*rNumb*modifier);
		blue1.battleHealthGray -= (int)(baseDamageCalculation (red1.level, Move.instance.getPowerGray(), red1.basicAttack, blue1.basicDef)*rNumb*modifier);
		blue1.battleHealthRed -= (int)(baseDamageCalculation (red1.level, Move.instance.getPowerRed(), red1.basicAttack, blue1.basicDef)*rNumb*modifier);


		if (modifier > 1.0f) {
			effectiveText="super effective :" + modifier;
		} else if (modifier == 0) {
			effectiveText="no effect :"+modifier;
		}else if (modifier < 1.0) {
			effectiveText="not very effective :"+modifier;
		}else if (modifier == 1.0) {
			effectiveText="regular effective :"+modifier;
		}

		battleText.text = red1.nickName+" Uses "+Move.instance.getVisaName()+"\nit's "+effectiveText;
	}*/
	//public void TypeText(){
		
	//}
}
