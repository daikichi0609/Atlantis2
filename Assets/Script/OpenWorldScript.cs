using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWorldScript : MonoBehaviour {
	public BattleParam BattleParam;
	public GameObject Menu;
	public GameObject StatusMenu;
	public GameObject[] CommandMenu;
	public GameObject[] StarMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
            if (BattleParam.Stop)
            {
                BattleParam.Stop = false;
                Menu.SetActive(false);
            }
            else if (!BattleParam.Stop)
            {
                BattleParam.Stop = true;
                Menu.SetActive(true);
            }
        }
	}
	public void PushStatusMenu(){
		StatusMenu.SetActive(true);
		Menu.SetActive(false);
	}

	public void PushCommandMenu(){
		CommandMenu[0].SetActive(true);
		CommandMenu[1].SetActive(true);
		Menu.SetActive(false);
	}

	public void PushStarMenu(){
		StarMenu[0].SetActive(true);
		StarMenu[1].SetActive(true);
		Menu.SetActive(false);
	}
}
