using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeEffect{


	public const int normal=1;
	public const int fire=2;
	public const int water=3;
	public const int electric=4;
	public const int grass=5;
	public const int ice=6;
	public const int fighting=7;
	public const int poison=8;
	public const int ground=9;
	public const int flying=10;
	public const int psychic=11;
	public const int bug=12;
	public const int rock=13;
	public const int ghost=14;
	public const int dragon=15;
	public const int dark=16;
	public const int steel=17;
	public const int fairy=18;
	public const int typeless=0;

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

	public float typeEffectiveness(TypeEnum attType,TypeEnum defType)
	{
		if (TypeEnum.normal.Equals(attType)) {
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
}
	
public enum TypeEnum{

	normal,fire,water,electric,grass,ice,fighting,
	poison,ground,flying,psychic,bug,
	rock,ghost,dragon,dark,steel,fairy,
	typeless

};