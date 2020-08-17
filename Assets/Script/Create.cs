using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Create : MonoBehaviour
{
  public CommandButtonScript CommandButton;
  public RectTransform contentRectTransform;
  public Button button;
  public string[] skillname;
  public Color[] buttonColors; //UnityのInspectorで設定
  public Text ExplainText;
  public Text CTText;
  private int CommandNum;
  private void Start()
  {
    for (int i = 1; i <= 30; i++)
    {
      CommandButton.Num = i;
      var obj = Instantiate(button, contentRectTransform);
      obj.GetComponentInChildren<Text>().text = skillname[i];
      obj.GetComponent<Image>().color = buttonColors[i];

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
    ExplainText.text = "敵1体に攻撃力×3.5のダメージを与える";
    CTText.text = "3";
    CommandNum = 1;
  }

  void Skill2()
  {
    ExplainText.text = "敵1体に攻撃力×1.2のダメージ　これをランダムに2~5回与える";
    CTText.text = "3";
    CommandNum = 2;
  }

  void Skill3()
  {
    ExplainText.text = "6Tの間、被ダメージを5割カット";
    CTText.text = "10";
    CommandNum = 3;
  }

  void Skill4()
  {
    ExplainText.text = "自分の体力を4割回復";
    CTText.text = "10";
    CommandNum = 4;
  }

  void Skill5()
  {
    ExplainText.text = "敵1体に攻撃力×3.5の貫通ダメージを与える";
    CTText.text = "4";
    CommandNum = 5;
  }

  void Skill6()
  {
    ExplainText.text = "敵1体に攻撃力×1.2の貫通ダメージ　これをランダムに2~5回与える";
    CTText.text = "4";
    CommandNum = 6;
  }

  void Skill7()
  {
    ExplainText.text = "敵1体に攻撃力×1.0のダメージ 敵がダメージカット展開中なら、代わりに攻撃力×4.0のダメージ";
    CTText.text = "3";
    CommandNum = 7;
  }

  void Skill8()
  {
    ExplainText.text = "敵全体に攻撃力×2.5のダメージを与える";
    CTText.text = "3";
    CommandNum = 8;
  }

  void Skill9()
  {
    ExplainText.text = "敵全体に攻撃力×2.5の貫通ダメージを与える";
    CTText.text = "3";
    CommandNum = 9;
  }

  void Skill10()
  {
    ExplainText.text = "4Tの間、自分の攻撃力×2.0";
    CTText.text = "8";
    CommandNum = 10;
  }

  void Skill11()
  {
    ExplainText.text = "4Tの間、自分の防御力×2.0";
    CTText.text = "8";
    CommandNum = 11;
  }

  void Skill12()
  {
    ExplainText.text = "4Tの間、被ダメージを8割カット";
    CTText.text = "10";
    CommandNum = 12;
  }

  void Skill13()
  {
    ExplainText.text = "自分の体力を7割回復";
    CTText.text = "12";
    CommandNum = 13;
  }

  void Skill14()
  {
    ExplainText.text = "3Tの間、敵全体の攻撃力を5割ダウン";
    CTText.text = "8";
    CommandNum = 14;
  }

  void Skill15()
  {
    ExplainText.text = "3Tの間、敵全体の防御力を5割ダウン";
    CTText.text = "8";
    CommandNum = 15;
  }

  void Skill16()
  {
    ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに4Tの間、ターン終了時に最大体力の5%のダメージを受ける毒を付与する";
    CTText.text = "5";
    CommandNum = 16;
  }

  void Skill17()
  {
    ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに4Tの間、ターン終了時に自分の攻撃力の10%のダメージを受ける火傷を付与する";
    CTText.text = "5";
    CommandNum = 17;
  }

  void Skill18()
  {
    ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに2Tの間、敵を沈黙状態にする";
    CTText.text = "5";
    CommandNum = 18;
  }

  void Skill19()
  {
    ExplainText.text = "敵1体に攻撃力×Xのダメージ Xは敵が受けている状態異常の数を3倍した数である";
    CTText.text = "3";
    CommandNum = 19;
  }

  void Skill20()
  {
    ExplainText.text = "4Tの間、自分の攻撃力×3.5";
    CTText.text = "10";
    CommandNum = 20;
  }

  void Skill21()
  {
    ExplainText.text = "4Tの間、自分の防御力×3.5";
    CTText.text = "9";
    CommandNum = 21;
  }

  void Skill22()
  {
    ExplainText.text = "2Tの間、被ダメージを10割カット";
    CTText.text = "10";
    CommandNum = 22;
  }

  void Skill23()
  {
    ExplainText.text = "自分の体力を10割回復";
    CTText.text = "14";
    CommandNum = 23;
  }

  void Skill24()
  {
    ExplainText.text = "2Tの間、敵全体の攻撃力を10割ダウン";
    CTText.text = "10";
    CommandNum = 24;
  }

  void Skill25()
  {
    ExplainText.text = "2Tの間、敵全体の防御力を10割ダウン";
    CTText.text = "3";
    CommandNum = 25;
  }

  void Skill26()
  {
    ExplainText.text = "敵全体に攻撃力×1.0のダメージを与える　さらに敵全体のバフを全て解除する";
    CTText.text = "3";
    CommandNum = 26;
  }

  void Skill27()
  {
    ExplainText.text = "4Tの間、自分の攻撃力×5.0";
    CTText.text = "12";
    CommandNum = 27;
  }

  void Skill28()
  {
    ExplainText.text = "4Tの間、通常攻撃による与ダメージだけ自分の体力を回復する";
    CTText.text = "10";
    CommandNum = 28;
  }

  void Skill29()
  {
    ExplainText.text = "敵1体に直前のターンに受けた被ダメージと同じダメージを与える";
    CTText.text = "6";
    CommandNum = 29;
  }

  void Skill30()
  {
    ExplainText.text = "敵1体に「自分のターン終了時、自分の体力の最大値を1割減らす」呪いを5T付与する";
    CTText.text = "10";
    CommandNum = 30;
  }
}