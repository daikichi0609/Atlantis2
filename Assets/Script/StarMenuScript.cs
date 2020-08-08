using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMenuScript : MonoBehaviour {

	public Text ExplainText;
	public Text CommandText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PushLeoButton(){
		ExplainText.text = "基礎攻撃力を1.2倍にする";
		CommandText.text = "攻撃力×6.0のダメージ 与えたダメージの2割を反動で受ける";
	}

	public void PushAriesButton(){
		ExplainText.text = "基礎防御力を1.2倍にする";
		CommandText.text = "防御力×3.0（3T）その後、ダメージを受けた回数が10回以上なら、敵全体に自身の防御力×10のダメージ";
	}

	public void PushSagittariusButton(){
		ExplainText.text = "基礎体力を1.2倍にする";
		CommandText.text = "敵1体に攻撃力Xの貫通ダメージ 自分のHPをX回復 Xはこのとき自分が受けていたダメージ";
	}
}
