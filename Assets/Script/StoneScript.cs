using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour {

    public PlayerData PlayerData;
    public BattleParam BattleParam;

    public GameObject SunStone;
    public GameObject MoonStone;
    public GameObject UnStar;
    public GameObject Star;

    public GameObject LeoUI;
    public GameObject AriesUI;
    public GameObject SagittariusUI;

    public Material morningsky;
    public Material nightsky;

    public GameObject Light;
    public GameObject DarkLight;
    public GameObject[] morning;
    public GameObject[] night;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerData.maxHp >= 15)
        {
            if (BattleParam.night)
            {
                MoonStone.SetActive(true);
                SunStone.SetActive(false);
            }
            else
            {
                SunStone.SetActive(true);
                MoonStone.SetActive(false);
            }
        }
        else
        {
            SunStone.SetActive(false);
            MoonStone.SetActive(false);
        }

        if (BattleParam.night)
        {
            DarkLight.SetActive(true);
            Light.SetActive(false);
            RenderSettings.skybox = nightsky;
            UnStar.SetActive(false);
            if (BattleParam.StartUnStar)
            {
                Star.SetActive(true);
            }
            night[0].SetActive(true);
            night[1].SetActive(true);
            morning[0].SetActive(false);
            morning[1].SetActive(false);
        }
        else if(!BattleParam.night)
        {
            Light.SetActive(true);
            DarkLight.SetActive(false);
            RenderSettings.skybox = morningsky;
            UnStar.SetActive(true);
            Star.SetActive(false);
            morning[0].SetActive(true);
            morning[1].SetActive(true);
            night[0].SetActive(false);
            night[1].SetActive(false);
        }

        if (!BattleParam.Stop)
        {
            if (BattleParam.Leo)
            {
                LeoUI.SetActive(true);
                AriesUI.SetActive(false);
                SagittariusUI.SetActive(false);
            }
            if (BattleParam.Aries)
            {
                AriesUI.SetActive(true);
                LeoUI.SetActive(false);
                SagittariusUI.SetActive(false);
            }
            if (BattleParam.Sagittarius)
            {
                SagittariusUI.SetActive(true);
                LeoUI.SetActive(false);
                AriesUI.SetActive(false);
            }
        }
    }
}
