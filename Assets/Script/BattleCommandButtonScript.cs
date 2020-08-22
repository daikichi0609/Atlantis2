using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommandButtonScript : MonoBehaviour
{
  public PlayerData PlayerData;
  public BattleSystemScript BattleSystem;
  public Button Button;
  public int Num;

  // Use this for initialization
  void Start()
  {
    Button.GetComponentInChildren<Text>().text = PlayerData.skillname[PlayerData.CommandNum[Num]];
    Button.GetComponent<Image>().color = PlayerData.buttonColors[PlayerData.CommandNum[Num]];
    switch (PlayerData.CommandNum[Num])
    {
      case 1:
        Button.onClick.AddListener(BattleSystem.Skill1);
        break;
      case 2:
        Button.onClick.AddListener(BattleSystem.Skill2);
        break;
      case 3:
        Button.onClick.AddListener(BattleSystem.Skill3);
        break;
      case 4:
        Button.onClick.AddListener(BattleSystem.Skill4);
        break;
      case 5:
        Button.onClick.AddListener(BattleSystem.Skill5);
        break;
      case 6:
        Button.onClick.AddListener(BattleSystem.Skill6);
        break;
      case 7:
        Button.onClick.AddListener(BattleSystem.Skill7);
        break;
      case 8:
        Button.onClick.AddListener(BattleSystem.Skill8);
        break;
      case 9:
        Button.onClick.AddListener(BattleSystem.Skill9);
        break;
      case 10:
        Button.onClick.AddListener(BattleSystem.Skill10);
        break;
      case 11:
        Button.onClick.AddListener(BattleSystem.Skill11);
        break;
      case 12:
        Button.onClick.AddListener(BattleSystem.Skill12);
        break;
      case 13:
        Button.onClick.AddListener(BattleSystem.Skill13);
        break;
      case 14:
        Button.onClick.AddListener(BattleSystem.Skill14);
        break;
      case 15:
        Button.onClick.AddListener(BattleSystem.Skill15);
        break;
      case 16:
        Button.onClick.AddListener(BattleSystem.Skill16);
        break;
      case 17:
        Button.onClick.AddListener(BattleSystem.Skill17);
        break;
      case 18:
        Button.onClick.AddListener(BattleSystem.Skill18);
        break;
      case 19:
        Button.onClick.AddListener(BattleSystem.Skill19);
        break;
      case 20:
        Button.onClick.AddListener(BattleSystem.Skill20);
        break;
      case 21:
        Button.onClick.AddListener(BattleSystem.Skill21);
        break;
      case 22:
        Button.onClick.AddListener(BattleSystem.Skill22);
        break;
      case 23:
        Button.onClick.AddListener(BattleSystem.Skill23);
        break;
      case 24:
        Button.onClick.AddListener(BattleSystem.Skill24);
        break;
      case 25:
        Button.onClick.AddListener(BattleSystem.Skill25);
        break;
      case 26:
        Button.onClick.AddListener(BattleSystem.Skill26);
        break;
      case 27:
        Button.onClick.AddListener(BattleSystem.Skill27);
        break;
      case 28:
        Button.onClick.AddListener(BattleSystem.Skill28);
        break;
      case 29:
        Button.onClick.AddListener(BattleSystem.Skill29);
        break;
      case 30:
        Button.onClick.AddListener(BattleSystem.Skill30);
        break;
    }
  }

  // Update is called once per frame
  void Update()
  {

  }


}
