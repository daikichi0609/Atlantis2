using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenWorldScript : MonoBehaviour
{
  public BattleParam BattleParam;
  public GameObject Menu;
  private bool MenuOn;
  public GameObject StatusMenu;
  private bool StatusMenuOn;
  public GameObject[] CommandMenu;
  private bool CommandMenuOn;
  public GameObject[] StarMenu;
  private bool StarMenuOn;
  public PlayerData PlayerData;
  public Text LvText;
  public Text ATText;
  public Text DFText;
  public Text HPText;
  public Text[] CommandText;
  public GameObject StarObject;
  public Image Starimage;
  private Sprite sprite;
  public Text StarText;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      if (MenuOn)
      {
        BattleParam.Stop = false;
        Menu.SetActive(false);
        MenuOn = false;
        return;
      }
      else if (StatusMenuOn)
      {
        StatusMenu.SetActive(false);
        StatusMenuOn = false;
        Menu.SetActive(true);
        MenuOn = true;
        CalculateStatus();
        return;
      }
      else if (CommandMenuOn)
      {
        CommandMenu[0].SetActive(false);
        CommandMenu[1].SetActive(false);
        CommandMenuOn = false;
        Menu.SetActive(true);
        MenuOn = true;
        return;
      }
      else if (StarMenuOn)
      {
        StarMenu[0].SetActive(false);
        StarMenu[1].SetActive(false);
        StarMenuOn = false;
        Menu.SetActive(true);
        MenuOn = true;
        CalculateStatus();
        return;
      }
      else
      {
        if (!BattleParam.Stop)
        {
          BattleParam.Stop = true;
          Menu.SetActive(true);
          MenuOn = true;
          return;
        }
      }
    }
    LvText.text = PlayerData.Lv.ToString();
    ATText.text = PlayerData.AT.ToString();
    DFText.text = PlayerData.DF.ToString();
    HPText.text = PlayerData.HP.ToString();

    if (BattleParam.Leo || BattleParam.Aries || BattleParam.Sagittarius)
    {
      StarObject.SetActive(true);
      if (BattleParam.Leo)
      {
        sprite = Resources.Load<Sprite>("Leo");
        Starimage = Starimage.GetComponent<Image>();
        Starimage.sprite = sprite;
        StarText.text = "Leo";
      }
      else if (BattleParam.Aries)
      {
        sprite = Resources.Load<Sprite>("Aries");
        Starimage = Starimage.GetComponent<Image>();
        Starimage.sprite = sprite;
        StarText.text = "Aries";
      }
      else if (BattleParam.Sagittarius)
      {
        sprite = Resources.Load<Sprite>("Sagittarius");
        Starimage = Starimage.GetComponent<Image>();
        Starimage.sprite = sprite;
        StarText.text = "Sagittarius";
      }


    }
  }
  public void PushStatusMenu()
  {
    StatusMenu.SetActive(true);
    StatusMenuOn = true;
    Menu.SetActive(false);
    MenuOn = false;
  }

  public void PushCommandMenu()
  {
    CommandMenu[0].SetActive(true);
    CommandMenu[1].SetActive(true);
    CommandMenuOn = true;
    Menu.SetActive(false);
    MenuOn = false;
  }

  public void PushStarMenu()
  {
    StarMenu[0].SetActive(true);
    StarMenu[1].SetActive(true);
    StarMenuOn = true;
    Menu.SetActive(false);
    MenuOn = false;
  }

  public void PushReverseButton()
  {
    BattleParam.Stop = false;
    Menu.SetActive(false);
    MenuOn = false;
  }

  public void CalculateStatus()
  {
    PlayerData.BasicAt = 100 + (PlayerData.Lv - 1) * 2;
    PlayerData.BasicDf = 50 + (PlayerData.Lv - 1) * 1;
    PlayerData.BasicHP = 500 + (PlayerData.Lv - 1) * 5;

    if (BattleParam.Leo)
    {
      PlayerData.BasicAt = (int)(PlayerData.BasicAt * 1.2);
    }
    else if (BattleParam.Aries)
    {
      PlayerData.BasicDf = (int)(PlayerData.BasicDf * 1.2);
    }
    else if (BattleParam.Sagittarius)
    {
      PlayerData.BasicHP = (int)(PlayerData.BasicHP * 1.2);
    }

    PlayerData.AT = (int)(PlayerData.BasicAt * PlayerData.AtMagni);
    PlayerData.DF = (int)(PlayerData.BasicDf * PlayerData.DfMagni);
    PlayerData.HP = (int)(PlayerData.BasicHP * PlayerData.HPMagni);

  }
}
