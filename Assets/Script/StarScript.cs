using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

    public BattleParam BattleParam;
    public GameObject UnStar;
    public GameObject Star;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (BattleParam.night)
        {
            Star.SetActive(true);
            UnStar.SetActive(false);
        }
        else if (!BattleParam.night)
        {
            UnStar.SetActive(true);
            Star.SetActive(false);
        }
    }
}
