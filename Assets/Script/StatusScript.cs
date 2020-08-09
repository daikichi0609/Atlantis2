using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour {
	public BattleParam BattleParam;
    public PlayerData PlayerData;
	public Slider AtSlider;
	public Slider DfSlider;
	public Slider HPSlider;
	public Text AtText;
	public Text DfText;
	public Text HPText;
	public Text SPText;
	private float atmagni;
	private float dfmagni;
	private float hpmagni;

	// Use this for initialization
	void Start () {
		atmagni = PlayerData.AtMagni;
		dfmagni = PlayerData.DfMagni;
		hpmagni = PlayerData.HPMagni;

		AtSlider.value = atmagni;
		DfSlider.value = dfmagni;
		HPSlider.value = hpmagni;
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerData.SP == 0){
			
		}
		else{
			atmagni = AtSlider.value;
		    dfmagni = DfSlider.value;
		    hpmagni = HPSlider.value;
		}

		if(atmagni - PlayerData.AtMagni >= 0.05f){
			PlayerData.AtMagni = atmagni;
			PlayerData.SP --;
		}else if(atmagni - PlayerData.AtMagni <= -0.05f){
			PlayerData.AtMagni = atmagni;
			PlayerData.SP ++;
		}

		Debug.Log(atmagni);

		AtSliderValuechanged();
		DfSliderValuechanged();
		HPSliderValuechanged();
		SPText.text = PlayerData.SP.ToString();
	}

	public void AtSliderValuechanged(){
		//Debug.Log(CalculateValue(AtSlider.value));
		//AtSlider.value = CalculateValue(AtSlider.value);
		if(AtSlider.value < 0.5f){
			AtSlider.value = 0.5f;
			AtText.text = "0.50";
			return;
		}
		AtText.text = PlayerData.AtMagni.ToString("f2");
	}

	public void DfSliderValuechanged(){
		if(DfSlider.value < 0.5f){
			DfSlider.value = 0.5f;
			DfText.text = "0.50";
			return;
		}
		DfText.text = PlayerData.DfMagni.ToString("f2");
	}

	public void HPSliderValuechanged(){
		if(HPSlider.value < 0.5f){
			HPSlider.value = 0.5f;
			HPText.text = "0.50";
			return;
		}
		HPText.text = PlayerData.HPMagni.ToString("f2");
	}

	/*public float CalculateValue(float value){
		float minDif = 10000;
		for(int i = 0; i < 50; i++){
			float x = (float)i * 0.05f + 0.5f;
			float y = Mathf.Abs(value - x);
			if(minDif > y){
				minDif = y;
			}
		}
		return minDif;
	}*/
}