using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartySystem : MonoBehaviour {

	public BasicCombative combative1;
	public BasicCombative combative2;
	public BasicCombative combative3;
	public BasicCombative combative4;
	public BasicCombative combative5;
	public BasicCombative combative6;

	void Start()
	{
		combative1.setPartyNumber (1);
		combative2.setPartyNumber (2);
		combative3.setPartyNumber (3);
		combative4.setPartyNumber (4);
		combative5.setPartyNumber (5);
		combative6.setPartyNumber (6);

	}
}
