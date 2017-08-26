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

	public static float typeEffectiveness(TypeEnum attType,TypeEnum defType)
	{
		if (attType == TypeEnum.normal) {
			if (defType == TypeEnum.rock) {return 0.5f;} 
			else if (defType == TypeEnum.ghost) {return 0.0f;}
			else if (defType == TypeEnum.steel) {return 0.5f;}
		}
		else if (attType == TypeEnum.fire) {
			if (defType == TypeEnum.fire) {return 0.5f;} 
			else if (defType == TypeEnum.water) {return 0.5f;}
			else if (defType == TypeEnum.grass) {return 2.0f;}
			else if (defType == TypeEnum.ice) {return 2.0f;}
			else if (defType == TypeEnum.bug) {return 2.0f;}
			else if (defType == TypeEnum.rock) {return 0.5f;}
			else if (defType == TypeEnum.dragon) {return 0.5f;}
			else if (defType == TypeEnum.steel) {return 2.0f;}

		}
		else if (attType == TypeEnum.water) {
			if (defType == TypeEnum.fire) {return 2.0f;} 
			else if (defType == TypeEnum.water) {return 0.5f;}
			else if (defType == TypeEnum.grass) {return 0.5f;}
			else if (defType == TypeEnum.ground) {return 2.0f;}
			else if (defType == TypeEnum.rock) {return 2.0f;}
			else if (defType == TypeEnum.dragon) {return 0.5f;}

		}
		else if (attType == TypeEnum.electric) {
			if (defType == TypeEnum.water) {return 2.0f;} 
			else if (defType == TypeEnum.electric) {return 0.5f;}
			else if (defType == TypeEnum.grass) {return 0.5f;}
			else if (defType == TypeEnum.ground) {return 0.0f;}
			else if (defType == TypeEnum.flying) {return 2.0f;}
			else if (defType == TypeEnum.dragon) {return 0.5f;}

		}
		else if (attType == TypeEnum.grass) {
			if (defType == TypeEnum.fire) {return 0.5f;} 
			else if (defType == TypeEnum.water) {return 2.0f;}
			else if (defType == TypeEnum.grass) {return 0.5f;}
			else if (defType == TypeEnum.poison) {return 0.5f;}
			else if (defType == TypeEnum.ground) {return 2.0f;}
			else if (defType == TypeEnum.flying) {return 0.5f;}
			else if (defType == TypeEnum.bug) {return 0.5f;}
			else if (defType == TypeEnum.rock) {return 2.0f;}
			else if (defType == TypeEnum.dragon) {return 0.5f;}
			else if (defType == TypeEnum.steel) {return 0.5f;}

		}
		else if (attType == TypeEnum.ice) {
			if (defType == TypeEnum.fire) {return 0.5f;} 
			else if (defType == TypeEnum.water) {return 0.5f;}
			else if (defType == TypeEnum.grass) {return 2.0f;}
			else if (defType == TypeEnum.ice) {return 0.5f;}
			else if (defType == TypeEnum.ground) {return 2.0f;}
			else if (defType == TypeEnum.flying) {return 2.0f;}
			else if (defType == TypeEnum.dragon) {return 0.5f;}

		}
		else if (attType == TypeEnum.fighting) {
			if (defType == TypeEnum.normal) {return 2.0f;} 
			else if (defType == TypeEnum.ice) {return 2.0f;}
			else if (defType == TypeEnum.poison) {return 0.5f;}
			else if (defType == TypeEnum.flying) {return 0.5f;}
			else if (defType == TypeEnum.psychic) {return 0.5f;}
			else if (defType == TypeEnum.bug) {return 0.5f;}
			else if (defType == TypeEnum.rock) {return 2.0f;}
			else if (defType == TypeEnum.ghost) {return 0.0f;}
			else if (defType == TypeEnum.dark) {return 2.0f;}
			else if (defType == TypeEnum.steel) {return 2.0f;}
			else if (defType == TypeEnum.fairy) {return 0.5f;}

		}
		else if (attType == TypeEnum.poison) {
			if (defType == TypeEnum.grass) {return 2.0f;} 
			else if (defType == TypeEnum.poison) {return 0.5f;}
			else if (defType == TypeEnum.ground) {return 0.5f;}
			else if (defType == TypeEnum.rock) {return 0.5f;}
			else if (defType == TypeEnum.ghost) {return 0.5f;}
			else if (defType == TypeEnum.steel) {return 0.0f;}
			else if (defType == TypeEnum.fairy) {return 2.0f;}

		}
		else if (attType == TypeEnum.ground) {
			if (defType == TypeEnum.fire) {return 2.0f;} 
			else if (defType == TypeEnum.electric) {return 2.0f;}
			else if (defType == TypeEnum.grass) {return 0.5f;}
			else if (defType == TypeEnum.poison) {return 2.0f;}
			else if (defType == TypeEnum.flying) {return 0.0f;}
			else if (defType == TypeEnum.bug) {return 0.5f;}
			else if (defType == TypeEnum.rock) {return 2.0f;}
			else if (defType == TypeEnum.steel) {return 2.0f;}

		}
		else if (attType == TypeEnum.flying) {
			if (defType == TypeEnum.electric) {return 0.5f;} 
			else if (defType == TypeEnum.grass) {return 2.0f;}
			else if (defType == TypeEnum.fighting) {return 2.0f;}
			else if (defType == TypeEnum.bug) {return 2.0f;}
			else if (defType == TypeEnum.rock) {return 0.5f;}
			else if (defType == TypeEnum.steel) {return 0.5f;}

		}
		else if (attType == TypeEnum.psychic) {
			if (defType == TypeEnum.fighting) {return 2.0f;} 
			else if (defType == TypeEnum.poison) {return 2.0f;}
			else if (defType == TypeEnum.psychic) {return 0.5f;}
			else if (defType == TypeEnum.dark) {return 0.0f;}
			else if (defType == TypeEnum.steel) {return 0.5f;}

		}
		else if (attType == TypeEnum.bug) {
			if (defType == TypeEnum.fire) {return 0.5f;} 
			else if (defType == TypeEnum.grass) {return 2.0f;}
			else if (defType == TypeEnum.fighting) {return 0.5f;}
			else if (defType == TypeEnum.poison) {return 0.5f;}
			else if (defType == TypeEnum.flying) {return 0.5f;}
			else if (defType == TypeEnum.psychic) {return 2.0f;}
			else if (defType == TypeEnum.ghost) {return 0.5f;}
			else if (defType == TypeEnum.dark) {return 2.0f;}
			else if (defType == TypeEnum.steel) {return 0.5f;}
			else if (defType == TypeEnum.fairy) {return 0.5f;}

		}
		else if (attType == TypeEnum.rock) {
			if (defType == TypeEnum.fire) {return 2.0f;} 
			else if (defType == TypeEnum.ice) {return 2.0f;}
			else if (defType == TypeEnum.fighting) {return 0.5f;}
			else if (defType == TypeEnum.ground) {return 0.5f;}
			else if (defType == TypeEnum.flying) {return 2.0f;}
			else if (defType == TypeEnum.bug) {return 2.0f;}
			else if (defType == TypeEnum.steel) {return 0.5f;}

		}
		else if (attType == TypeEnum.ghost) {
			if (defType == TypeEnum.normal) {return 0.0f;} 
			else if (defType == TypeEnum.psychic) {return 2.0f;}
			else if (defType == TypeEnum.ghost) {return 2.0f;}
			else if (defType == TypeEnum.dark) {return 0.5f;}

		}
		else if (attType == TypeEnum.dragon) {
			if (defType == TypeEnum.dragon) {return 2.0f;} 
			else if (defType == TypeEnum.dark) {return 0.5f;}
			else if (defType == TypeEnum.steel) {return 0.0f;}

		}
		else if (attType == TypeEnum.dark) {
			if (defType == TypeEnum.fighting) {return 0.5f;} 
			else if (defType == TypeEnum.psychic) {return 2.0f;}
			else if (defType == TypeEnum.ghost) {return 2.0f;}
			else if (defType == TypeEnum.dark) {return 0.5f;}
			else if (defType == TypeEnum.fairy) {return 0.5f;}

		}
		else if (attType == TypeEnum.steel) {
			if (defType == TypeEnum.fire) {return 0.5f;} 
			else if (defType == TypeEnum.water) {return 0.5f;}
			else if (defType == TypeEnum.electric) {return 0.5f;}
			else if (defType == TypeEnum.ice) {return 2.0f;}
			else if (defType == TypeEnum.rock) {return 2.0f;}
			else if (defType == TypeEnum.steel) {return 0.5f;}
			else if (defType == TypeEnum.fairy) {return 2.0f;}

		}
		else if (attType == TypeEnum.fairy) {
			if (defType == TypeEnum.fire) {return 0.5f;} 
			else if (defType == TypeEnum.fighting) {return 2.0f;}
			else if (defType == TypeEnum.poison) {return 0.5f;}
			else if (defType == TypeEnum.dragon) {return 2.0f;}
			else if (defType == TypeEnum.dark) {return 2.0f;}
			else if (defType == TypeEnum.steel) {return 0.5f;}

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