using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWorldScript : MonoBehaviour {
	public BattleParam BattleParam;
	public GameObject Menu;
	private bool MenuOn;
	public GameObject StatusMenu;
	private bool StatusMenuOn;
	public GameObject[] CommandMenu;
	private bool CommandMenuOn;
	public GameObject[] StarMenu;
	private bool StarMenuOn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
            if (MenuOn){
                BattleParam.Stop = false;
                Menu.SetActive(false);
				MenuOn = false;
            }
			else if(StatusMenuOn){
				StatusMenu.SetActive(false);
				StatusMenuOn = false;
				Menu.SetActive(true);
				MenuOn = true;
			}
			else if(CommandMenuOn){
				CommandMenu[0].SetActive(false);
				CommandMenu[1].SetActive(false);
				CommandMenuOn = false;
				Menu.SetActive(true);
				MenuOn = true;
			}
			else if(StarMenuOn){
				StarMenu[0].SetActive(false);
				StarMenu[1].SetActive(false);
				StarMenuOn = false;
				Menu.SetActive(true);
				MenuOn = true;
			}
			else{
                BattleParam.Stop = true;
                Menu.SetActive(true);
				MenuOn = true;
            }
        }


	}
	public void PushStatusMenu(){
		StatusMenu.SetActive(true);
		StatusMenuOn = true;
		Menu.SetActive(false);
		MenuOn = false;
	}

	public void PushCommandMenu(){
		CommandMenu[0].SetActive(true);
		CommandMenu[1].SetActive(true);
		CommandMenuOn = true;
		Menu.SetActive(false);
		MenuOn = false;
	}

	public void PushStarMenu(){
		StarMenu[0].SetActive(true);
		StarMenu[1].SetActive(true);
		StarMenuOn = true;
		Menu.SetActive(false);
		MenuOn = false;
	}

	public void PushReverseButton(){
		BattleParam.Stop = false;
        Menu.SetActive(false);
	    MenuOn = false;
	}
}
