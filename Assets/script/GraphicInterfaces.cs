using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleText
{
	void BattleTextToAdd(string s);
}

public interface IBattleHealthDamage
{
	void FullHealthBarDamage01(int green,int gray,int red,int totalHP,string target);
}
