using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Create : MonoBehaviour
{
  public PlayerData PlayerData;
  public CommandDecideScript DecideScript;
  public CommandButtonScript CommandButton;
  public RectTransform contentRectTransform;
  public GameObject[] CommandMenu;
  public GameObject CommandDecideMenu;
  public Button button;
  public Text ExplainText;
  public Text CTText;
  private int CommandNum;
  private void Start()
  {
    for (int i = 1; i <= 30; i++)
    {
      CommandButton.Num = i;
      var obj = Instantiate(button, contentRectTransform);
      obj.GetComponentInChildren<Text>().text = PlayerData.skillname[i];
      obj.GetComponent<Image>().color = PlayerData.buttonColors[i];

      switch (i)
      {
        case 1:
          obj.onClick.AddListener(Skill1);
          break;
        case 2:
          obj.onClick.AddListener(Skill2);
          break;
        case 3:
          obj.onClick.AddListener(Skill3);
          break;
        case 4:
          obj.onClick.AddListener(Skill4);
          break;
        case 5:
          obj.onClick.AddListener(Skill5);
          break;
        case 6:
          obj.onClick.AddListener(Skill6);
          break;
        case 7:
          obj.onClick.AddListener(Skill7);
          break;
        case 8:
          obj.onClick.AddListener(Skill8);
          break;
        case 9:
          obj.onClick.AddListener(Skill9);
          break;
        case 10:
          obj.onClick.AddListener(Skill10);
          break;
        case 11:
          obj.onClick.AddListener(Skill11);
          break;
        case 12:
          obj.onClick.AddListener(Skill12);
          break;
        case 13:
          obj.onClick.AddListener(Skill13);
          break;
        case 14:
          obj.onClick.AddListener(Skill14);
          break;
        case 15:
          obj.onClick.AddListener(Skill15);
          break;
        case 16:
          obj.onClick.AddListener(Skill16);
          break;
        case 17:
          obj.onClick.AddListener(Skill17);
          break;
        case 18:
          obj.onClick.AddListener(Skill18);
          break;
        case 19:
          obj.onClick.AddListener(Skill19);
          break;
        case 20:
          obj.onClick.AddListener(Skill20);
          break;
        case 21:
          obj.onClick.AddListener(Skill21);
          break;
        case 22:
          obj.onClick.AddListener(Skill22);
          break;
        case 23:
          obj.onClick.AddListener(Skill23);
          break;
        case 24:
          obj.onClick.AddListener(Skill24);
          break;
        case 25:
          obj.onClick.AddListener(Skill25);
          break;
        case 26:
          obj.onClick.AddListener(Skill26);
          break;
        case 27:
          obj.onClick.AddListener(Skill27);
          break;
        case 28:
          obj.onClick.AddListener(Skill28);
          break;
        case 29:
          obj.onClick.AddListener(Skill29);
          break;
        case 30:
          obj.onClick.AddListener(Skill30);
          break;
      }
    }
  }

  void Skill1()
  {
    if (CommandNum == 1)
    {
      OnCommandDecideMenu();
    }
    ExplainText.text = "敵1体に攻撃力×3.5のダメージを与える";
    CTText.text = "3";
    CommandNum = 1;
  }

  void Skill2()
  {
    if (CommandNum == 2)
    {
      OnCommandDecideMenu();
    }
    ExplainText.text = "敵1体に攻撃力×1.2のダメージ\nこれをランダムに2~5回与える";
    CTText.text = "3";
    CommandNum = 2;
  }

  void Skill3()
  {
    if (CommandNum == 3)
    {
      OnCommandDecideMenu();
    }
    ExplainText.text = "6Tの間、被ダメージを5割カット";
    CTText.text = "10";
    CommandNum = 3;
  }

  void Skill4()
  {
    if (CommandNum == 4)
    {
      OnCommandDecideMenu();
    }
    ExplainText.text = "自分の体力を4割回復";
    CTText.text = "10";
    CommandNum = 4;
  }

  void Skill5()
  {
    if (CommandNum == 5)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 3)
    {
      ExplainText.text = "Lv3以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵1体に攻撃力×3.5の貫通ダメージを与える";
      CTText.text = "4";
      CommandNum = 5;
    }
  }

  void Skill6()
  {
    if (CommandNum == 6)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 3)
    {
      ExplainText.text = "Lv3以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵1体に攻撃力×1.2の貫通ダメージ\nこれをランダムに2~5回与える";
      CTText.text = "4";
      CommandNum = 6;
    }
  }

  void Skill7()
  {
    if (CommandNum == 7)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 3)
    {
      ExplainText.text = "Lv3以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵1体に攻撃力×1.0のダメージ\n敵がダメージカット展開中なら、代わりに攻撃力×4.0のダメージ";
      CTText.text = "3";
      CommandNum = 7;
    }
  }

  void Skill8()
  {
    if (CommandNum == 8)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 5)
    {
      ExplainText.text = "Lv5以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵全体に攻撃力×2.5のダメージを与える";
      CTText.text = "4";
      CommandNum = 8;
    }
  }

  void Skill9()
  {
    if (CommandNum == 9)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 5)
    {
      ExplainText.text = "Lv5以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵全体に攻撃力×2.5の貫通ダメージを与える";
      CTText.text = "5";
      CommandNum = 9;
    }
  }

  void Skill10()
  {
    if (CommandNum == 10)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 6)
    {
      ExplainText.text = "Lv6以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "4Tの間、自分の攻撃力×2.0";
      CTText.text = "8";
      CommandNum = 10;
    }
  }

  void Skill11()
  {
    if (CommandNum == 11)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 6)
    {
      ExplainText.text = "Lv6以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "4Tの間、自分の防御力×2.0";
      CTText.text = "8";
      CommandNum = 11;
    }
  }

  void Skill12()
  {
    if (CommandNum == 12)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 6)
    {
      ExplainText.text = "Lv6以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "4Tの間、被ダメージを8割カット";
      CTText.text = "10";
      CommandNum = 12;
    }
  }

  void Skill13()
  {
    if (CommandNum == 13)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 6)
    {
      ExplainText.text = "Lv6以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "自分の体力を7割回復";
      CTText.text = "12";
      CommandNum = 13;
    }
  }

  void Skill14()
  {
    if (CommandNum == 14)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 8)
    {
      ExplainText.text = "Lv8以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "3Tの間、敵全体の攻撃力を5割ダウン";
      CTText.text = "6";
      CommandNum = 14;
    }
  }

  void Skill15()
  {
    if (CommandNum == 15)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 8)
    {
      ExplainText.text = "Lv8以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "3Tの間、敵全体の防御力を5割ダウン";
      CTText.text = "6";
      CommandNum = 15;
    }
  }

  void Skill16()
  {
    if (CommandNum == 16)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 10)
    {
      ExplainText.text = "Lv10以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵1体に攻撃力×1.0のダメージ\nさらに4Tの間、ターン終了時に最大体力の5%のダメージを受ける毒を付与する";
      CTText.text = "6";
      CommandNum = 16;
    }
  }

  void Skill17()
  {
    if (CommandNum == 17)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 10)
    {
      ExplainText.text = "Lv10以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵1体に攻撃力×1.0のダメージ\nさらに4Tの間、ターン終了時に自分の攻撃力の10%のダメージを受ける火傷を付与する";
      CTText.text = "6";
      CommandNum = 17;
    }
  }

  void Skill18()
  {
    if (CommandNum == 18)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 10)
    {
      ExplainText.text = "Lv10以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵1体に攻撃力×1.0のダメージ\nさらに2Tの間、敵を沈黙状態にする";
      CTText.text = "6";
      CommandNum = 18;
    }
  }

  void Skill19()
  {
    if (CommandNum == 19)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 10)
    {
      ExplainText.text = "Lv10以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵1体に攻撃力×3Xのダメージ\nXはその敵が受けている状態異常の数である";
      CTText.text = "3";
      CommandNum = 19;
    }
  }

  void Skill20()
  {
    if (CommandNum == 20)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 15)
    {
      ExplainText.text = "Lv15以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "4Tの間、自分の攻撃力×3.5";
      CTText.text = "9";
      CommandNum = 20;
    }
  }

  void Skill21()
  {
    if (CommandNum == 21)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 15)
    {
      ExplainText.text = "Lv15以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "4Tの間、自分の防御力×3.5";
      CTText.text = "9";
      CommandNum = 21;
    }
  }

  void Skill22()
  {
    if (CommandNum == 22)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 15)
    {
      ExplainText.text = "Lv15以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "2Tの間、被ダメージを10割カット";
      CTText.text = "10";
      CommandNum = 22;
    }
  }

  void Skill23()
  {
    if (CommandNum == 23)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 15)
    {
      ExplainText.text = "Lv15以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "自分の体力を10割回復";
      CTText.text = "14";
      CommandNum = 23;
    }
  }

  void Skill24()
  {
    if (CommandNum == 24)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 18)
    {
      ExplainText.text = "Lv18以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "2Tの間、敵全体の攻撃力を10割ダウン";
      CTText.text = "10";
      CommandNum = 24;
    }
  }

  void Skill25()
  {
    if (CommandNum == 25)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 18)
    {
      ExplainText.text = "Lv18以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "2Tの間、敵全体の防御力を10割ダウン";
      CTText.text = "10";
      CommandNum = 25;
    }
  }

  void Skill26()
  {
    if (CommandNum == 26)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 21)
    {
      ExplainText.text = "Lv21以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵全体に攻撃力×1.0のダメージを与える\nさらに敵全体のバフを全て解除する";
      CTText.text = "3";
      CommandNum = 26;
    }
  }

  void Skill27()
  {
    if (CommandNum == 27)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 24)
    {
      ExplainText.text = "Lv24以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "4Tの間、自分の攻撃力×5.0";
      CTText.text = "10";
      CommandNum = 27;
    }
  }

  void Skill28()
  {
    if (CommandNum == 28)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 27)
    {
      ExplainText.text = "Lv27以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "4Tの間、通常攻撃による与ダメージだけ自分の体力を回復する";
      CTText.text = "10";
      CommandNum = 28;
    }
  }

  void Skill29()
  {
    if (CommandNum == 29)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 27)
    {
      ExplainText.text = "Lv27以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵1体に直前のターンに受けた被ダメージと同じダメージを与える";
      CTText.text = "6";
      CommandNum = 29;
    }
  }

  void Skill30()
  {
    if (CommandNum == 30)
    {
      OnCommandDecideMenu();
      return;
    }
    else if (PlayerData.Lv < 30)
    {
      ExplainText.text = "Lv30以上で解放";
      CTText.text = "-";
      CommandNum = 0;
      return;
    }
    else
    {
      ExplainText.text = "敵1体に「自分のターン終了時、自分の体力の最大値を1割減らす」呪いを5T付与する";
      CTText.text = "8";
      CommandNum = 30;
    }
  }

  public void OnCommandDecideMenu()
  {
    DecideScript.CommandNum = CommandNum;
    CommandNum = 0;
    ExplainText.text = "";
    CTText.text = "-";
    CommandDecideMenu.SetActive(true);
    CommandMenu[0].SetActive(false);
    CommandMenu[1].SetActive(false);
  }


}