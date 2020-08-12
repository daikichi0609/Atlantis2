using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMenuScript : MonoBehaviour {

	public BattleParam BattleParam;
	public Text EffectText;
	public Text CommandNameText;
	public Text CommandText;
	private bool Leo;
	private bool Aries;
	private bool Sagittarius;
	public Button DecideButton;
	public GameObject[] StarMenu;
	public GameObject ResultMenu;
	public Image Starimage;
	private Sprite sprite;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			Leo = false;
			Aries = false;
			Sagittarius = false;
			ResultMenu.SetActive(false);
		}
		if(!Leo && !Aries && !Sagittarius){
			DecideButton.interactable = false;
		}else{
			DecideButton.interactable = true;
		}
	}

	public void PushLeoButton(){
		Leo = true;
		Aries = false;
		Sagittarius = false;
		EffectText.text = "基礎攻撃力を1.2倍にする";
		CommandNameText.text = "『アルギエバ』";
		CommandText.text = "しし座の力を借りて、相手に攻撃力×6.0のダメージ さらに3Tの間、敵の攻撃力を50%ダウンさせる";
	}

	public void PushAriesButton(){
		Leo = false;
		Aries = true;
		Sagittarius = false;
		EffectText.text = "基礎防御力を1.2倍にする";
		CommandNameText.text = "『バラニーコール』";
		CommandText.text = "おひつじ座の力を借りて、3Tの間、自分の防御力を3倍にする　その後、相手全体に自身の防御力×10のダメージ";
	}

	public void PushSagittariusButton(){
		Leo = false;
		Aries = false;
		Sagittarius = true;
		EffectText.text = "基礎体力を1.2倍にする";
		CommandNameText.text = "『カウスショット』";
		CommandText.text = "いて座の力を借りて、相手に攻撃力Xの貫通ダメージ その後、自分のHPをX回復 Xはこのとき自分が受けていたダメージ";
	}

	public void PushDecideButton(){

		StarMenu[0].SetActive(false);
		StarMenu[1].SetActive(false);
		ResultMenu.SetActive(true);

		if(Leo){
			BattleParam.Leo = true;
			BattleParam.Aries = false;
			BattleParam.Sagittarius = false;
			Leo = false;
			sprite = Resources.Load<Sprite>("shishiza");
	        Starimage = Starimage.GetComponent<Image>();
		    Starimage.sprite = sprite;
		}else if(Aries){
			BattleParam.Leo = false;
			BattleParam.Aries = true;
			BattleParam.Sagittarius = false;
			Aries = false;
			sprite = Resources.Load<Sprite>("ohitujiza");
	        Starimage = Starimage.GetComponent<Image>();
		    Starimage.sprite = sprite;
		}else if(Sagittarius){
			BattleParam.Leo = false;
			BattleParam.Aries = false;
			BattleParam.Sagittarius = true;
			Sagittarius = false;
			sprite = Resources.Load<Sprite>("iteza");
	        Starimage = Starimage.GetComponent<Image>();
		    Starimage.sprite = sprite;
		}
	}
}
