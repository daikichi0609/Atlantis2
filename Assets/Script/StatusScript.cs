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

	// Use this for initialization
	void Start () {
		AtSlider.value = PlayerData.AtMagni;
		DfSlider.value = PlayerData.DfMagni;
		HPSlider.value = PlayerData.HPMagni;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerData.AtMagni = AtSlider.value;
		PlayerData.DfMagni = DfSlider.value;
		PlayerData.HPMagni = HPSlider.value;

		AtSliderValuechanged();
		DfSliderValuechanged();
		HPSliderValuechanged();
		
	}

	public void AtSliderValuechanged(){
		//Debug.Log(CalculateValue(AtSlider.value));
		//AtSlider.value = CalculateValue(AtSlider.value);
		if(AtSlider.value < 0.5f){
			AtSlider.value = 0.5f;
			AtText.text = "0.5";
			return;
		}
		AtText.text = PlayerData.AtMagni.ToString();
	}

	public void DfSliderValuechanged(){
		if(DfSlider.value < 0.5f){
			DfSlider.value = 0.5f;
			DfText.text = "0.5";
			return;
		}
		DfText.text = PlayerData.DfMagni.ToString();
	}

	public void HPSliderValuechanged(){
		if(HPSlider.value < 0.5f){
			HPSlider.value = 0.5f;
			HPText.text = "0.5";
			return;
		}
		HPText.text = PlayerData.HPMagni.ToString();
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