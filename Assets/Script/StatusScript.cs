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
		AtText.text = PlayerData.AtMagni.ToString();
		DfText.text = PlayerData.DfMagni.ToString();
		HPText.text = PlayerData.HPMagni.ToString();
	}
}

