using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonScript : MonoBehaviour
{

  public PlayerData PlayerData;
  public int Num;
  public Button Button;
  public Color blackcolor;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    switch (Num)
    {
      case 5:
      case 6:
      case 7:
        if (PlayerData.Lv < 3)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;

      case 8:
      case 9:
        if (PlayerData.Lv < 5)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;

      case 10:
      case 11:
      case 12:
      case 13:
        if (PlayerData.Lv < 6)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;

      case 14:
      case 15:
        if (PlayerData.Lv < 8)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;

      case 16:
      case 17:
      case 18:
      case 19:
        if (PlayerData.Lv < 10)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;

      case 20:
      case 21:
      case 22:
      case 23:
        if (PlayerData.Lv < 15)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;

      case 24:
      case 25:
        if (PlayerData.Lv < 18)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;

      case 26:
        if (PlayerData.Lv < 21)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;

      case 27:
        if (PlayerData.Lv < 24)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;

      case 28:
      case 29:
        if (PlayerData.Lv < 27)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;

      case 30:
        if (PlayerData.Lv < 30)
        {
          Button.GetComponent<Image>().color = blackcolor;
        }
        break;
    }

    if (PlayerData.CommandNum[1] == Num)
    {
      Button.interactable = false;
      return;
    }
    if (PlayerData.CommandNum[2] == Num)
    {
      Button.interactable = false;
      return;
    }
    if (PlayerData.CommandNum[3] == Num)
    {
      Button.interactable = false;
      return;
    }
    if (PlayerData.CommandNum[4] == Num)
    {
      Button.interactable = false;
      return;
    }
    else
    {
      Button.interactable = true;
    }
  }


}
