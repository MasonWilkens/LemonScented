using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyGUI : MonoBehaviour {

	[SerializeField] private PartySystem PS;

	[SerializeField] private Image cbHealthBarGreen1;
	[SerializeField] private Image cbHealthBarGray1;
	[SerializeField] private Image cbHealthBarRed1;
	[SerializeField] private Text cbNickName1;

	[SerializeField] private Image cbHealthBarGreen2;
	[SerializeField] private Image cbHealthBarGray2;
	[SerializeField] private Image cbHealthBarRed2;
	[SerializeField] private Text cbNickName2;

	[SerializeField] private Image cbHealthBarGreen3;
	[SerializeField] private Image cbHealthBarGray3;
	[SerializeField] private Image cbHealthBarRed3;
	[SerializeField] private Text cbNickName3;

	[SerializeField] private Image cbHealthBarGreen4;
	[SerializeField] private Image cbHealthBarGray4;
	[SerializeField] private Image cbHealthBarRed4;
	[SerializeField] private Text cbNickName4;

	[SerializeField] private Image cbHealthBarGreen5;
	[SerializeField] private Image cbHealthBarGray5;
	[SerializeField] private Image cbHealthBarRed5;
	[SerializeField] private Text cbNickName5;

	[SerializeField] private Image cbHealthBarGreen6;
	[SerializeField] private Image cbHealthBarGray6;
	[SerializeField] private Image cbHealthBarRed6;
	[SerializeField] private Text cbNickName6;

	void Start () {
		
		cbNickName1.text = PS.combative1.nickName;
		cbNickName2.text = PS.combative2.nickName;
		cbNickName3.text = PS.combative3.nickName;
		cbNickName4.text = PS.combative4.nickName;
		cbNickName5.text = PS.combative5.nickName;
		cbNickName6.text = PS.combative6.nickName;

	}
	
	// Update is called once per frame
	void Update () {
		changeHealth (PS.combative1,cbHealthBarGreen1,cbHealthBarGray1,cbHealthBarRed1);
		changeHealth (PS.combative2,cbHealthBarGreen2,cbHealthBarGray2,cbHealthBarRed2);
		changeHealth (PS.combative3,cbHealthBarGreen3,cbHealthBarGray3,cbHealthBarRed3);
		changeHealth (PS.combative4,cbHealthBarGreen4,cbHealthBarGray4,cbHealthBarRed4);
		changeHealth (PS.combative5,cbHealthBarGreen5,cbHealthBarGray5,cbHealthBarRed5);
		changeHealth (PS.combative6,cbHealthBarGreen6,cbHealthBarGray6,cbHealthBarRed6);
		
	}

	private void changeHealth(BasicCombative effected,Image greenBar,Image grayBar,Image redBar)
	{
		greenBar.transform.localScale = new Vector3((float)effected.battleHealthGreen / effected.totalHealth,1.0f,1.0f);
		grayBar.transform.localScale = new Vector3((float)effected.battleHealthGray / effected.totalHealth,1.0f,1.0f);
		redBar.transform.localScale = new Vector3((float)effected.battleHealthRed / effected.totalHealth,1.0f,1.0f);


	}
}
