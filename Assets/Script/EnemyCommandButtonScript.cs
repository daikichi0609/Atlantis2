using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCommandButtonScript : MonoBehaviour {
	public string Name;
	public Text CT;
	public Text EnemyCommandexplanation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Name = this.GetComponentInChildren<Text>().text;
	}

	public void PushEnemyCommandButton(){

		
		if(Name == "ラフスラッシュ"){
			EnemyCommandexplanation.text = "攻撃力×2のダメージ　低確率で代わりに攻撃力×4のダメージ";
			CT.text = "CT：3";
		}
		else if(Name == "レイジ"){
			EnemyCommandexplanation.text = "4Tの間、攻撃力×2.0";
			CT.text = "CT：10";
		}
		else{
            EnemyCommandexplanation.text = "";
			CT.text = "";
		}
		
	}
}
