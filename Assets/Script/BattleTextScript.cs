using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTextScript : MonoBehaviour
{

  public BattleParam BattleParam;
  public PlayerData PlayerData;
  public Player player;
  public Enemy[] enemy;
  public BattleCommandButtonScript[] ButtonScript;
  public BattleImageScript[] BattleImages;
  public Text ExplainText;
  public Text CTText;
  public Text[] Texts;
  public GameObject[] gb;
  public Image[] images;
  private Sprite sprite;
  public bool[] buff;
  public int Num;
  public int num;
  public int savenum;
  public Color[] Textcolor;

  //public Button[] Buttons;

  // Use this for initialization
  void Start()
  {
    buff[0] = true;
    buff[1] = true;
  }

  // Update is called once per frame
  void Update()
  {
    Images();
  }

  public void Images()
  {
    for (int i = 0; i <= 3; i++)
    {
      gb[i].SetActive(false);
    }
    Num = 0;
    /*if (player.atBufftime[1] != 0 || player.atBufftime[2] != 0 || player.atBufftime[3] != 0)
    {
      gb[Num].SetActive(true);
      sprite = Resources.Load<Sprite>("atbuff");
      images[Num] = images[Num].GetComponent<Image>();
      images[Num].sprite = sprite;
      Num++;
    }
    else if (player.atDeBufftime[1] != 0 || player.atDeBufftime[2] != 0 || player.atDeBufftime[3] != 0)
    {
      gb[Num].SetActive(true);
      sprite = Resources.Load<Sprite>("atdebuff");
      images[Num] = images[Num].GetComponent<Image>();
      images[Num].sprite = sprite;
      Num++;
    }
    else if (player.dfBufftime[1] != 0 || player.dfBufftime[2] != 0 || player.dfBufftime[3] != 0)
    {
      gb[Num].SetActive(true);
      sprite = Resources.Load<Sprite>("dfbuff");
      images[Num] = images[Num].GetComponent<Image>();
      images[Num].sprite = sprite;
      Num++;
    }
    else if (player.dfDeBufftime[1] != 0 || player.dfDeBufftime[2] != 0 || player.dfDeBufftime[3] != 0)
    {
      gb[Num].SetActive(true);
      sprite = Resources.Load<Sprite>("dfdebuff");
      images[Num] = images[Num].GetComponent<Image>();
      images[Num].sprite = sprite;
      Num++;
    }*/
    if (player.barriertime[1] != 0 || player.barriertime[2] != 0 || player.barriertime[3] != 0)
    {
      gb[Num].SetActive(true);
      sprite = Resources.Load<Sprite>("guard");
      images[Num] = images[Num].GetComponent<Image>();
      images[Num].sprite = sprite;
      BattleImages[Num].Num = 0;
      Num++;
    }
    if (player.poisontime != 0)
    {
      gb[Num].SetActive(true);
      sprite = Resources.Load<Sprite>("poison");
      images[Num] = images[Num].GetComponent<Image>();
      images[Num].sprite = sprite;
      BattleImages[Num].Num = 1;
      Num++;
    }
    if (player.burntime != 0)
    {
      gb[Num].SetActive(true);
      sprite = Resources.Load<Sprite>("burn");
      images[Num] = images[Num].GetComponent<Image>();
      images[Num].sprite = sprite;
      BattleImages[Num].Num = 2;
      Num++;
    }
    if (player.clamtime != 0)
    {
      gb[Num].SetActive(true);
      sprite = Resources.Load<Sprite>("clam");
      images[Num] = images[Num].GetComponent<Image>();
      images[Num].sprite = sprite;
      BattleImages[Num].Num = 3;
      Num++;
    }
  }

  public void EnemyText(int _Num)
  {
    if (savenum != _Num)
    {
      num = 0;
    }
    savenum = _Num;
    ExplainText.text = "";
    CTText.text = "";
    switch (num)
    {
      case 0:
        num = 1;
        Texts[3].text = enemy[_Num].name + "の攻撃バフ一覧";
        Texts[3].color = Textcolor[1];
        if (enemy[_Num].atBufftime[1] != 0 && enemy[_Num].atBufftime[2] != 0 && enemy[_Num].atBufftime[0] != 0)
        {
          Texts[0].text = "攻撃力×2（残り" + enemy[_Num].atBufftime[1].ToString() + "ターン）";
          Texts[1].text = "攻撃力×3.5（残り" + enemy[_Num].atBufftime[2].ToString() + "ターン）";
          Texts[2].text = "攻撃力1.2（残り" + enemy[_Num].atBufftime[0].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].atBufftime[1] != 0 && enemy[_Num].atBufftime[2] != 0)
        {
          Texts[0].text = "攻撃力×2（残り" + enemy[_Num].atBufftime[1].ToString() + "ターン）";
          Texts[1].text = "攻撃力×3.5（残り" + enemy[_Num].atBufftime[2].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].atBufftime[1] != 0 && enemy[_Num].atBufftime[3] != 0)
        {
          Texts[0].text = "攻撃力×2（残り" + enemy[_Num].atBufftime[1].ToString() + "ターン）";
          Texts[1].text = "攻撃力×1.2（残り" + enemy[_Num].atBufftime[3].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].atBufftime[2] != 0 && enemy[_Num].atBufftime[3] != 0)
        {
          Texts[0].text = "攻撃力×3.5（残り" + enemy[_Num].atBufftime[2].ToString() + "ターン）";
          Texts[1].text = "攻撃力×1.2（残り" + enemy[_Num].atBufftime[3].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].atBufftime[1] != 0)
        {
          Texts[0].text = "攻撃力×2（残り" + enemy[_Num].atBufftime[1].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].atBufftime[2] != 0)
        {
          Texts[0].text = "攻撃力×3.5（残り" + enemy[_Num].atBufftime[2].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].atBufftime[3] != 0)
        {
          Texts[0].text = "攻撃力×1.2（残り" + enemy[_Num].atBufftime[3].ToString() + "ターン）";
          return;
        }
        else
        {
          Texts[0].text = "なし";
        }
        break;

      case 1:
        num = 2;
        Texts[3].text = enemy[_Num].name + "の攻撃デバフ一覧";
        Texts[3].color = Textcolor[2];
        if (enemy[_Num].atDeBufftime[1] != 0 && enemy[_Num].atDeBufftime[2] != 0)
        {
          Texts[0].text = "攻撃力×0（残り" + enemy[_Num].atDeBufftime[2].ToString() + "ターン）";
          Texts[1].text = "攻撃力×0.5（残り" + enemy[_Num].atDeBufftime[1].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].atDeBufftime[1] != 0)
        {
          Texts[0].text = "攻撃力×0.5（残り" + enemy[_Num].atDeBufftime[1].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].atDeBufftime[2] != 0)
        {
          Texts[0].text = "攻撃力×0（残り" + enemy[_Num].atDeBufftime[2].ToString() + "ターン）";
          return;
        }
        else
        {
          Texts[0].text = "なし";
        }
        break;

      case 2:
        num = 3;
        Texts[3].text = enemy[_Num].name + "の防御バフ一覧";
        Texts[3].color = Textcolor[3];
        if (enemy[_Num].dfBufftime[1] != 0 && enemy[_Num].dfBufftime[2] != 0 && enemy[_Num].dfBufftime[0] != 0)
        {
          Texts[0].text = "防御力×2（残り" + enemy[_Num].dfBufftime[1].ToString() + "ターン）";
          Texts[1].text = "防御力×3.5（残り" + enemy[_Num].dfBufftime[2].ToString() + "ターン）";
          Texts[2].text = "防御力1.2（残り" + enemy[_Num].dfBufftime[0].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].dfBufftime[1] != 0 && enemy[_Num].dfBufftime[2] != 0)
        {
          Texts[0].text = "防御力×2（残り" + enemy[_Num].dfBufftime[1].ToString() + "ターン）";
          Texts[1].text = "防御力×3.5（残り" + enemy[_Num].dfBufftime[2].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].dfBufftime[1] != 0 && enemy[_Num].dfBufftime[3] != 0)
        {
          Texts[0].text = "防御力×2（残り" + enemy[_Num].dfBufftime[1].ToString() + "ターン）";
          Texts[1].text = "防御力×1.2（残り" + enemy[_Num].dfBufftime[3].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].dfBufftime[2] != 0 && enemy[_Num].dfBufftime[3] != 0)
        {
          Texts[0].text = "防御力×3.5（残り" + enemy[_Num].dfBufftime[2].ToString() + "ターン）";
          Texts[1].text = "防御力×1.2（残り" + enemy[_Num].dfBufftime[3].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].dfBufftime[1] != 0)
        {
          Texts[0].text = "防御力×2（残り" + enemy[_Num].dfBufftime[1].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].dfBufftime[2] != 0)
        {
          Texts[0].text = "防御力×3.5（残り" + enemy[_Num].dfBufftime[2].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].dfBufftime[3] != 0)
        {
          Texts[0].text = "防御力×1.2（残り" + enemy[_Num].dfBufftime[3].ToString() + "ターン）";
          return;
        }
        else
        {
          Texts[0].text = "なし";
        }
        break;

      case 3:
        num = 4;
        Texts[3].text = enemy[_Num].name + "の防御デバフ一覧";
        Texts[3].color = Textcolor[4];
        if (enemy[_Num].dfDeBufftime[1] != 0 && enemy[_Num].dfDeBufftime[2] != 0)
        {
          Texts[0].text = "防御力×0（残り" + enemy[_Num].dfDeBufftime[2].ToString() + "ターン）";
          Texts[1].text = "防御力×0.5（残り" + enemy[_Num].dfDeBufftime[1].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].dfDeBufftime[1] != 0)
        {
          Texts[0].text = "防御力×0.5（残り" + enemy[_Num].dfDeBufftime[1].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].dfDeBufftime[2] != 0)
        {
          Texts[0].text = "防御力×0（残り" + enemy[_Num].dfDeBufftime[2].ToString() + "ターン）";
          return;
        }
        else
        {
          Texts[0].text = "なし";
        }
        break;

      case 4:
        num = 5;
        ExplainText.text = "";
        CTText.text = "";
        Texts[3].text = enemy[_Num].name + "のダメージカット";
        Texts[3].color = Textcolor[6];
        if (enemy[_Num].barriertime[3] != 0)
        {
          Texts[0].text = "被ダメージを10割カット（残り" + enemy[_Num].barriertime[3].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].barriertime[2] != 0)
        {
          Texts[0].text = "被ダメージを8割カット（残り" + enemy[_Num].barriertime[2].ToString() + "ターン）";
          return;
        }
        else if (enemy[_Num].barriertime[1] != 0)
        {
          Texts[0].text = "被ダメージを5割カット（残り" + enemy[_Num].barriertime[1].ToString() + "ターン）";
          return;
        }
        break;

      case 5:
        num = 0;
        ExplainText.text = "";
        CTText.text = "";
        Texts[3].text = enemy[_Num].name + "の状態異常";
        Texts[3].color = Textcolor[5];
        if (enemy[_Num].poisontime != 0)
        {
          Texts[0].text = "毒（残り" + enemy[_Num].poisontime.ToString() + "ターン）";
          return;
        }
        if (enemy[_Num].burntime != 0)
        {
          Texts[0].text = "やけど（残り" + enemy[_Num].burntime.ToString() + "ターン）";
          return;
        }
        if (enemy[_Num].clamtime != 0)
        {
          Texts[0].text = "沈黙（残り" + enemy[_Num].clamtime.ToString() + "ターン）";
          return;
        }
        break;
    }
  }
  public void AtBuffText()
  {
    ExplainText.text = "";
    CTText.text = "";
    if (buff[0])
    {
      buff[0] = false;
      Texts[3].text = "攻撃バフ一覧";
      Texts[3].color = Textcolor[1];
      if (player.atBufftime[1] != 0 && player.atBufftime[2] != 0 && player.atBufftime[3] != 0)
      {
        Texts[0].text = "攻撃力×2（残り" + player.atBufftime[1].ToString() + "ターン）";
        Texts[1].text = "攻撃力×3.5（残り" + player.atBufftime[2].ToString() + "ターン）";
        Texts[2].text = "攻撃力×5（残り" + player.atBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.atBufftime[1] != 0 && player.atBufftime[2] != 0)
      {
        Texts[0].text = "攻撃力×2（残り" + player.atBufftime[1].ToString() + "ターン）";
        Texts[1].text = "攻撃力×3.5（残り" + player.atBufftime[2].ToString() + "ターン）";
        return;
      }
      else if (player.atBufftime[1] != 0 && player.atBufftime[3] != 0)
      {
        Texts[0].text = "攻撃力×2（残り" + player.atBufftime[1].ToString() + "ターン）";
        Texts[1].text = "攻撃力×5（残り" + player.atBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.atBufftime[2] != 0 && player.atBufftime[3] != 0)
      {
        Texts[0].text = "攻撃力×3.5（残り" + player.atBufftime[2].ToString() + "ターン）";
        Texts[1].text = "攻撃力×5（残り" + player.atBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.atBufftime[1] != 0)
      {
        Texts[0].text = "攻撃力×2（残り" + player.atBufftime[1].ToString() + "ターン）";
        return;
      }
      else if (player.atBufftime[2] != 0)
      {
        Texts[0].text = "攻撃力×3.5（残り" + player.atBufftime[2].ToString() + "ターン）";
        return;
      }
      else if (player.atBufftime[3] != 0)
      {
        Texts[0].text = "攻撃力×5（残り" + player.atBufftime[3].ToString() + "ターン）";
        return;
      }
      else
      {
        Texts[0].text = "なし";
      }
      return;
    }
    else if (!buff[0])
    {
      buff[0] = true;
      Texts[3].text = "攻撃デバフ一覧";
      Texts[3].color = Textcolor[2];
      if (player.atDeBufftime[1] != 0 && player.atDeBufftime[2] != 0 && player.atDeBufftime[3] != 0)
      {
        Texts[0].text = "攻撃力×0（残り" + player.atDeBufftime[2].ToString() + "ターン）";
        Texts[1].text = "攻撃力×0.5（残り" + player.atDeBufftime[1].ToString() + "ターン）";
        Texts[2].text = "攻撃力×0.8（残り" + player.atDeBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.atDeBufftime[1] != 0 && player.atDeBufftime[2] != 0)
      {
        Texts[0].text = "攻撃力×0（残り" + player.atDeBufftime[2].ToString() + "ターン）";
        Texts[1].text = "攻撃力×0.5（残り" + player.atDeBufftime[1].ToString() + "ターン）";
        return;
      }
      else if (player.atDeBufftime[1] != 0 && player.atDeBufftime[3] != 0)
      {
        Texts[0].text = "攻撃力×0.5（残り" + player.atDeBufftime[1].ToString() + "ターン）";
        Texts[1].text = "攻撃力×0.8（残り" + player.atDeBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.atDeBufftime[2] != 0 && player.atDeBufftime[3] != 0)
      {
        Texts[0].text = "攻撃力×0（残り" + player.atDeBufftime[2].ToString() + "ターン）";
        Texts[1].text = "攻撃力×0.8（残り" + player.atDeBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.atDeBufftime[1] != 0)
      {
        Texts[0].text = "攻撃力×0.5（残り" + player.atDeBufftime[1].ToString() + "ターン）";
        return;
      }
      else if (player.atDeBufftime[2] != 0)
      {
        Texts[0].text = "攻撃力×0（残り" + player.atDeBufftime[2].ToString() + "ターン）";
        return;
      }
      else if (player.atDeBufftime[3] != 0)
      {
        Texts[0].text = "攻撃力×0.8（残り" + player.atDeBufftime[3].ToString() + "ターン）";
        return;
      }
      else
      {
        Texts[0].text = "なし";
      }
    }
  }

  public void DfBuffText()
  {
    ExplainText.text = "";
    CTText.text = "";
    if (buff[1])
    {
      buff[1] = false;
      Texts[3].text = "防御バフ一覧";
      Texts[3].color = Textcolor[3];
      if (player.dfBufftime[1] != 0 && player.dfBufftime[2] != 0 && player.dfBufftime[3] != 0)
      {
        Texts[0].text = "防御力×2（残り" + player.dfBufftime[1].ToString() + "ターン）";
        Texts[1].text = "防御力×3.5（残り" + player.dfBufftime[2].ToString() + "ターン）";
        Texts[2].text = "防御力×5（残り" + player.dfBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.dfBufftime[1] != 0 && player.dfBufftime[2] != 0)
      {
        Texts[0].text = "防御力×2（残り" + player.dfBufftime[1].ToString() + "ターン）";
        Texts[1].text = "防御力×3.5（残り" + player.dfBufftime[2].ToString() + "ターン）";
        return;
      }
      else if (player.dfBufftime[1] != 0 && player.dfBufftime[3] != 0)
      {
        Texts[0].text = "防御力×2（残り" + player.dfBufftime[1].ToString() + "ターン）";
        Texts[1].text = "防御力×5（残り" + player.dfBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.dfBufftime[2] != 0 && player.dfBufftime[3] != 0)
      {
        Texts[0].text = "防御力×3.5（残り" + player.dfBufftime[2].ToString() + "ターン）";
        Texts[1].text = "防御力×5（残り" + player.dfBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.dfBufftime[1] != 0)
      {
        Texts[0].text = "防御力×2（残り" + player.dfBufftime[1].ToString() + "ターン）";
        return;
      }
      else if (player.dfBufftime[2] != 0)
      {
        Texts[0].text = "防御力×3.5（残り" + player.dfBufftime[2].ToString() + "ターン）";
        return;
      }
      else if (player.dfBufftime[3] != 0)
      {
        Texts[0].text = "防御力×5（残り" + player.dfBufftime[3].ToString() + "ターン）";
        return;
      }
      else
      {
        Texts[0].text = "なし";
      }
      return;
    }
    else if (!buff[1])
    {
      buff[1] = true;
      Texts[3].text = "防御デバフ一覧";
      Texts[3].color = Textcolor[4];
      if (player.dfDeBufftime[1] != 0 && player.dfDeBufftime[2] != 0 && player.dfDeBufftime[3] != 0)
      {
        Texts[0].text = "防御力×0（残り" + player.dfDeBufftime[2].ToString() + "ターン）";
        Texts[1].text = "防御力×0.5（残り" + player.dfDeBufftime[1].ToString() + "ターン）";
        Texts[2].text = "防御力×0.8（残り" + player.dfDeBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.dfDeBufftime[1] != 0 && player.dfDeBufftime[2] != 0)
      {
        Texts[0].text = "防御力×0（残り" + player.dfDeBufftime[2].ToString() + "ターン）";
        Texts[1].text = "防御力×0.5（残り" + player.dfDeBufftime[1].ToString() + "ターン）";
        return;
      }
      else if (player.dfDeBufftime[1] != 0 && player.dfDeBufftime[3] != 0)
      {
        Texts[0].text = "防御力×0.5（残り" + player.dfDeBufftime[1].ToString() + "ターン）";
        Texts[1].text = "防御力×0.8（残り" + player.dfDeBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.dfDeBufftime[2] != 0 && player.dfDeBufftime[3] != 0)
      {
        Texts[0].text = "防御力×0（残り" + player.dfDeBufftime[2].ToString() + "ターン）";
        Texts[1].text = "防御力×0.8（残り" + player.dfDeBufftime[3].ToString() + "ターン）";
        return;
      }
      else if (player.dfDeBufftime[1] != 0)
      {
        Texts[0].text = "防御力×0.5（残り" + player.dfDeBufftime[1].ToString() + "ターン）";
        return;
      }
      else if (player.dfDeBufftime[2] != 0)
      {
        Texts[0].text = "防御力×0（残り" + player.dfDeBufftime[2].ToString() + "ターン）";
        return;
      }
      else if (player.dfDeBufftime[3] != 0)
      {
        Texts[0].text = "防御力×0.8（残り" + player.dfDeBufftime[3].ToString() + "ターン）";
        return;
      }
      else
      {
        Texts[0].text = "なし";
      }
    }
  }

  public void GuardText()
  {
    ExplainText.text = "";
    CTText.text = "";
    Texts[3].text = "ダメージカット";
    Texts[3].color = Textcolor[6];
    if (player.barriertime[3] != 0)
    {
      Texts[0].text = "被ダメージを10割カット（残り" + player.barriertime[3].ToString() + "ターン）";
      return;
    }
    else if (player.barriertime[2] != 0)
    {
      Texts[0].text = "被ダメージを8割カット（残り" + player.barriertime[2].ToString() + "ターン）";
      return;
    }
    else if (player.barriertime[1] != 0)
    {
      Texts[0].text = "被ダメージを5割カット（残り" + player.barriertime[1].ToString() + "ターン）";
      return;
    }
  }

  public void PoisonText()
  {
    Debug.Log("a");
    ExplainText.text = "";
    CTText.text = "";
    Texts[3].text = "状態異常";
    Texts[3].color = Textcolor[5];
    if (player.poisontime != 0)
    {
      Texts[0].text = "毒（残り" + player.poisontime.ToString() + "ターン）";
    }
  }
  public void BurnText()
  {
    ExplainText.text = "";
    CTText.text = "";
    Texts[3].text = "状態異常";
    Texts[3].color = Textcolor[5];
    if (player.burntime != 0)
    {
      Texts[0].text = "やけど（残り" + player.burntime.ToString() + "ターン）";
    }
  }

  public void ClamText()
  {
    ExplainText.text = "";
    CTText.text = "";
    Texts[3].text = "状態異常";
    Texts[3].color = Textcolor[5];
    if (player.clamtime != 0)
    {
      Texts[0].text = "沈黙（残り" + player.clamtime.ToString() + "ターン）";
    }
  }

  public void ReadyAttackText()
  {
    ExplainText.text = "敵1体に攻撃力×1.0のダメージ";
    CTText.text = "";
    for (int i = 0; i <= 3; i++)
    {
      Texts[i].text = "";
    }
  }

  public void ReadyCommandText()
  {
    ExplainText.text = "コマンドを使う";
    CTText.text = "";
    for (int i = 0; i <= 3; i++)
    {
      Texts[i].text = "";
    }
  }

  public void ReadyStarText()
  {
    ExplainText.text = "スターコマンドを使う";
    CTText.text = "";
    for (int i = 0; i <= 3; i++)
    {
      Texts[i].text = "";
    }
  }

  public void CommandText1()
  {
    for (int i = 0; i <= 3; i++)
    {
      Texts[i].text = "";
    }
    switch ((PlayerData.CommandNum[ButtonScript[0].Num]))
    {
      case 1:
        ExplainText.text = "敵1体に攻撃力×3.5のダメージ";
        CTText.text = "CT：3";
        break;
      case 2:
        ExplainText.text = "敵1体に攻撃力×1.2のダメージ　これをランダムに2~5回あたえる";
        CTText.text = "CT：3";
        break;
      case 3:
        ExplainText.text = "6Tの間、被ダメージを5割カット";
        CTText.text = "CT：10";
        break;
      case 4:
        ExplainText.text = "自分の体力を4割回復";
        CTText.text = "CT：10";
        break;
      case 5:
        ExplainText.text = "敵1体に攻撃力×3.5の貫通ダメージ";
        CTText.text = "CT：4";
        break;
      case 6:
        ExplainText.text = "敵1体に攻撃力×1.2の貫通ダメージ　これをランダムに2~5回あたえる";
        CTText.text = "CT：4";
        break;
      case 7:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ 敵がダメージカット展開中なら、代わりに攻撃力×4.0のダメージ";
        CTText.text = "CT：3";
        break;
      case 8:
        ExplainText.text = "敵全体に攻撃力×2.5のダメージ";
        CTText.text = "CT：3";
        break;
      case 9:
        ExplainText.text = "敵全体に攻撃力×2.5の貫通ダメージ";
        CTText.text = "CT：4";
        break;
      case 10:
        ExplainText.text = "4Tの間、自分の攻撃力×2.0";
        CTText.text = "CT：8";
        break;
      case 11:
        ExplainText.text = "4Tの間、自分の防御力×2.0";
        CTText.text = "CT：8";
        break;
      case 12:
        ExplainText.text = "4Tの間、被ダメージを8割カット";
        CTText.text = "CT：10";
        break;
      case 13:
        ExplainText.text = "自分の体力を7割回復";
        CTText.text = "CT：12";
        break;
      case 14:
        ExplainText.text = "3Tの間、敵全体の攻撃力を5割ダウン";
        CTText.text = "CT：8";
        break;
      case 15:
        ExplainText.text = "3Tの間、敵全体の防御力を5割ダウン";
        CTText.text = "CT：8";
        break;
      case 16:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに4Tの間、ターン終了時に最大体力の10%のダメージを受ける毒をあたえる";
        CTText.text = "CT：5";
        break;
      case 17:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに4Tの間、ターン終了時に自分の攻撃力の20%のダメージを受ける火傷をあたえる";
        CTText.text = "CT：5";
        break;
      case 18:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに2Tの間、敵を沈黙状態にする";
        CTText.text = "CT：5";
        break;
      case 19:
        ExplainText.text = "敵1体に攻撃力×3Xのダメージ Xはその敵が受けている状態異常の数である";
        CTText.text = "CT：3";
        break;
      case 20:
        ExplainText.text = "4Tの間、自分の攻撃力×3.5";
        CTText.text = "CT：9";
        break;
      case 21:
        ExplainText.text = "4Tの間、自分の防御力×3.5";
        CTText.text = "CT：9";
        break;
      case 22:
        ExplainText.text = "2Tの間、被ダメージを10割カット";
        CTText.text = "CT：10";
        break;
      case 23:
        ExplainText.text = "自分の体力を10割回復";
        CTText.text = "CT：14";
        break;
      case 24:
        ExplainText.text = "2Tの間、敵全体の攻撃力を10割ダウン";
        CTText.text = "CT：10";
        break;
      case 25:
        ExplainText.text = "2Tの間、敵全体の防御力を10割ダウン";
        CTText.text = "CT：10";
        break;
      case 26:
        ExplainText.text = "敵全体に攻撃力×1.0のダメージ　さらに敵全体のバフを全て解除する";
        CTText.text = "CT：3";
        break;
      case 27:
        ExplainText.text = "4Tの間、自分の攻撃力×5.0";
        CTText.text = "CT：10";
        break;
      case 28:
        ExplainText.text = "4Tの間、通常攻撃による与ダメージだけ自分の体力を回復する";
        CTText.text = "CT：10";
        break;
      case 29:
        ExplainText.text = "敵1体に直前のターンに受けた被ダメージと同じダメージをあたえる";
        CTText.text = "CT：6";
        break;
      case 30:
        ExplainText.text = "敵1体に「5Tの間、ターン終了時に自分の体力の最大値を1割減らす」呪いをあたえる";
        CTText.text = "CT：8";
        break;
    }
  }
  public void CommandText2()
  {
    for (int i = 0; i <= 3; i++)
    {
      Texts[i].text = "";
    }
    switch ((PlayerData.CommandNum[ButtonScript[1].Num]))
    {
      case 1:
        ExplainText.text = "敵1体に攻撃力×3.5のダメージ";
        CTText.text = "CT：3";
        break;
      case 2:
        ExplainText.text = "敵1体に攻撃力×1.2のダメージ　これをランダムに2~5回あたえる";
        CTText.text = "CT：3";
        break;
      case 3:
        ExplainText.text = "6Tの間、被ダメージを5割カット";
        CTText.text = "CT：10";
        break;
      case 4:
        ExplainText.text = "自分の体力を4割回復";
        CTText.text = "CT：10";
        break;
      case 5:
        ExplainText.text = "敵1体に攻撃力×3.5の貫通ダメージ";
        CTText.text = "CT：4";
        break;
      case 6:
        ExplainText.text = "敵1体に攻撃力×1.2の貫通ダメージ　これをランダムに2~5回あたえる";
        CTText.text = "CT：4";
        break;
      case 7:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ 敵がダメージカット展開中なら、代わりに攻撃力×4.0のダメージ";
        CTText.text = "CT：3";
        break;
      case 8:
        ExplainText.text = "敵全体に攻撃力×2.5のダメージ";
        CTText.text = "CT：3";
        break;
      case 9:
        ExplainText.text = "敵全体に攻撃力×2.5の貫通ダメージ";
        CTText.text = "CT：4";
        break;
      case 10:
        ExplainText.text = "4Tの間、自分の攻撃力×2.0";
        CTText.text = "CT：8";
        break;
      case 11:
        ExplainText.text = "4Tの間、自分の防御力×2.0";
        CTText.text = "CT：8";
        break;
      case 12:
        ExplainText.text = "4Tの間、被ダメージを8割カット";
        CTText.text = "CT：10";
        break;
      case 13:
        ExplainText.text = "自分の体力を7割回復";
        CTText.text = "CT：12";
        break;
      case 14:
        ExplainText.text = "3Tの間、敵全体の攻撃力を5割ダウン";
        CTText.text = "CT：8";
        break;
      case 15:
        ExplainText.text = "3Tの間、敵全体の防御力を5割ダウン";
        CTText.text = "CT：8";
        break;
      case 16:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに4Tの間、ターン終了時に最大体力の5%のダメージを受ける毒をあたえる";
        CTText.text = "CT：5";
        break;
      case 17:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに4Tの間、ターン終了時に自分の攻撃力の10%のダメージを受ける火傷をあたえる";
        CTText.text = "CT：5";
        break;
      case 18:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに2Tの間、敵を沈黙状態にする";
        CTText.text = "CT：5";
        break;
      case 19:
        ExplainText.text = "敵1体に攻撃力×3Xのダメージ Xはその敵が受けている状態異常の数である";
        CTText.text = "CT：3";
        break;
      case 20:
        ExplainText.text = "4Tの間、自分の攻撃力×3.5";
        CTText.text = "CT：9";
        break;
      case 21:
        ExplainText.text = "4Tの間、自分の防御力×3.5";
        CTText.text = "CT：9";
        break;
      case 22:
        ExplainText.text = "2Tの間、被ダメージを10割カット";
        CTText.text = "CT：10";
        break;
      case 23:
        ExplainText.text = "自分の体力を10割回復";
        CTText.text = "CT：14";
        break;
      case 24:
        ExplainText.text = "2Tの間、敵全体の攻撃力を10割ダウン";
        CTText.text = "CT：10";
        break;
      case 25:
        ExplainText.text = "2Tの間、敵全体の防御力を10割ダウン";
        CTText.text = "CT：10";
        break;
      case 26:
        ExplainText.text = "敵全体に攻撃力×1.0のダメージ　さらに敵全体のバフを全て解除する";
        CTText.text = "CT：3";
        break;
      case 27:
        ExplainText.text = "4Tの間、自分の攻撃力×5.0";
        CTText.text = "CT：10";
        break;
      case 28:
        ExplainText.text = "4Tの間、通常攻撃による与ダメージだけ自分の体力を回復する";
        CTText.text = "CT：10";
        break;
      case 29:
        ExplainText.text = "敵1体に直前のターンに受けた被ダメージと同じダメージをあたえる";
        CTText.text = "CT：6";
        break;
      case 30:
        ExplainText.text = "敵1体に「5Tの間、ターン終了時に自分の体力の最大値を1割減らす」呪いをあたえる";
        CTText.text = "CT：8";
        break;
    }
  }
  public void CommandText3()
  {
    for (int i = 0; i <= 3; i++)
    {
      Texts[i].text = "";
    }
    switch ((PlayerData.CommandNum[ButtonScript[2].Num]))
    {
      case 1:
        ExplainText.text = "敵1体に攻撃力×3.5のダメージ";
        CTText.text = "CT：3";
        break;
      case 2:
        ExplainText.text = "敵1体に攻撃力×1.2のダメージ　これをランダムに2~5回あたえる";
        CTText.text = "CT：3";
        break;
      case 3:
        ExplainText.text = "6Tの間、被ダメージを5割カット";
        CTText.text = "CT：10";
        break;
      case 4:
        ExplainText.text = "自分の体力を4割回復";
        CTText.text = "CT：10";
        break;
      case 5:
        ExplainText.text = "敵1体に攻撃力×3.5の貫通ダメージ";
        CTText.text = "CT：4";
        break;
      case 6:
        ExplainText.text = "敵1体に攻撃力×1.2の貫通ダメージ　これをランダムに2~5回あたえる";
        CTText.text = "CT：4";
        break;
      case 7:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ 敵がダメージカット展開中なら、代わりに攻撃力×4.0のダメージ";
        CTText.text = "CT：3";
        break;
      case 8:
        ExplainText.text = "敵全体に攻撃力×2.5のダメージ";
        CTText.text = "CT：3";
        break;
      case 9:
        ExplainText.text = "敵全体に攻撃力×2.5の貫通ダメージ";
        CTText.text = "CT：4";
        break;
      case 10:
        ExplainText.text = "4Tの間、自分の攻撃力×2.0";
        CTText.text = "CT：8";
        break;
      case 11:
        ExplainText.text = "4Tの間、自分の防御力×2.0";
        CTText.text = "CT：8";
        break;
      case 12:
        ExplainText.text = "4Tの間、被ダメージを8割カット";
        CTText.text = "CT：10";
        break;
      case 13:
        ExplainText.text = "自分の体力を7割回復";
        CTText.text = "CT：12";
        break;
      case 14:
        ExplainText.text = "3Tの間、敵全体の攻撃力を5割ダウン";
        CTText.text = "CT：8";
        break;
      case 15:
        ExplainText.text = "3Tの間、敵全体の防御力を5割ダウン";
        CTText.text = "CT：8";
        break;
      case 16:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに4Tの間、ターン終了時に最大体力の5%のダメージを受ける毒をあたえる";
        CTText.text = "CT：5";
        break;
      case 17:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに4Tの間、ターン終了時に自分の攻撃力の10%のダメージを受ける火傷をあたえる";
        CTText.text = "CT：5";
        break;
      case 18:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに2Tの間、敵を沈黙状態にする";
        CTText.text = "CT：5";
        break;
      case 19:
        ExplainText.text = "敵1体に攻撃力×3Xのダメージ Xはその敵が受けている状態異常の数である";
        CTText.text = "CT：3";
        break;
      case 20:
        ExplainText.text = "4Tの間、自分の攻撃力×3.5";
        CTText.text = "CT：9";
        break;
      case 21:
        ExplainText.text = "4Tの間、自分の防御力×3.5";
        CTText.text = "CT：9";
        break;
      case 22:
        ExplainText.text = "2Tの間、被ダメージを10割カット";
        CTText.text = "CT：10";
        break;
      case 23:
        ExplainText.text = "自分の体力を10割回復";
        CTText.text = "CT：14";
        break;
      case 24:
        ExplainText.text = "2Tの間、敵全体の攻撃力を10割ダウン";
        CTText.text = "CT：10";
        break;
      case 25:
        ExplainText.text = "2Tの間、敵全体の防御力を10割ダウン";
        CTText.text = "CT：10";
        break;
      case 26:
        ExplainText.text = "敵全体に攻撃力×1.0のダメージ　さらに敵全体のバフを全て解除する";
        CTText.text = "CT：3";
        break;
      case 27:
        ExplainText.text = "4Tの間、自分の攻撃力×5.0";
        CTText.text = "CT：10";
        break;
      case 28:
        ExplainText.text = "4Tの間、通常攻撃による与ダメージだけ自分の体力を回復する";
        CTText.text = "CT：10";
        break;
      case 29:
        ExplainText.text = "敵1体に直前のターンに受けた被ダメージと同じダメージをあたえる";
        CTText.text = "CT：6";
        break;
      case 30:
        ExplainText.text = "敵1体に「5Tの間、ターン終了時に自分の体力の最大値を1割減らす」呪いをあたえる";
        CTText.text = "CT：8";
        break;
    }
  }


  public void CommandText4()
  {
    for (int i = 0; i <= 3; i++)
    {
      Texts[i].text = "";
    }
    switch ((PlayerData.CommandNum[ButtonScript[3].Num]))
    {
      case 1:
        ExplainText.text = "敵1体に攻撃力×3.5のダメージ";
        CTText.text = "CT：3";
        break;
      case 2:
        ExplainText.text = "敵1体に攻撃力×1.2のダメージ　これをランダムに2~5回あたえる";
        CTText.text = "CT：3";
        break;
      case 3:
        ExplainText.text = "6Tの間、被ダメージを5割カット";
        CTText.text = "CT：10";
        break;
      case 4:
        ExplainText.text = "自分の体力を4割回復";
        CTText.text = "CT：10";
        break;
      case 5:
        ExplainText.text = "敵1体に攻撃力×3.5の貫通ダメージ";
        CTText.text = "CT：4";
        break;
      case 6:
        ExplainText.text = "敵1体に攻撃力×1.2の貫通ダメージ　これをランダムに2~5回あたえる";
        CTText.text = "CT：4";
        break;
      case 7:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ 敵がダメージカット展開中なら、代わりに攻撃力×4.0のダメージ";
        CTText.text = "CT：3";
        break;
      case 8:
        ExplainText.text = "敵全体に攻撃力×2.5のダメージ";
        CTText.text = "CT：3";
        break;
      case 9:
        ExplainText.text = "敵全体に攻撃力×2.5の貫通ダメージ";
        CTText.text = "CT：4";
        break;
      case 10:
        ExplainText.text = "4Tの間、自分の攻撃力×2.0";
        CTText.text = "CT：8";
        break;
      case 11:
        ExplainText.text = "4Tの間、自分の防御力×2.0";
        CTText.text = "CT：8";
        break;
      case 12:
        ExplainText.text = "4Tの間、被ダメージを8割カット";
        CTText.text = "CT：10";
        break;
      case 13:
        ExplainText.text = "自分の体力を7割回復";
        CTText.text = "CT：12";
        break;
      case 14:
        ExplainText.text = "3Tの間、敵全体の攻撃力を5割ダウン";
        CTText.text = "CT：8";
        break;
      case 15:
        ExplainText.text = "3Tの間、敵全体の防御力を5割ダウン";
        CTText.text = "CT：8";
        break;
      case 16:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに4Tの間、ターン終了時に最大体力の5%のダメージを受ける毒をあたえる";
        CTText.text = "CT：5";
        break;
      case 17:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに4Tの間、ターン終了時に自分の攻撃力の10%のダメージを受ける火傷をあたえる";
        CTText.text = "CT：5";
        break;
      case 18:
        ExplainText.text = "敵1体に攻撃力×1.0のダメージ　さらに2Tの間、敵を沈黙状態にする";
        CTText.text = "CT：5";
        break;
      case 19:
        ExplainText.text = "敵1体に攻撃力×3Xのダメージ Xはその敵が受けている状態異常の数である";
        CTText.text = "CT：3";
        break;
      case 20:
        ExplainText.text = "4Tの間、自分の攻撃力×3.5";
        CTText.text = "CT：9";
        break;
      case 21:
        ExplainText.text = "4Tの間、自分の防御力×3.5";
        CTText.text = "CT：9";
        break;
      case 22:
        ExplainText.text = "2Tの間、被ダメージを10割カット";
        CTText.text = "CT：10";
        break;
      case 23:
        ExplainText.text = "自分の体力を10割回復";
        CTText.text = "CT：14";
        break;
      case 24:
        ExplainText.text = "2Tの間、敵全体の攻撃力を10割ダウン";
        CTText.text = "CT：10";
        break;
      case 25:
        ExplainText.text = "2Tの間、敵全体の防御力を10割ダウン";
        CTText.text = "CT：10";
        break;
      case 26:
        ExplainText.text = "敵全体に攻撃力×1.0のダメージ　さらに敵全体のバフを全て解除する";
        CTText.text = "CT：3";
        break;
      case 27:
        ExplainText.text = "4Tの間、自分の攻撃力×5.0";
        CTText.text = "CT：10";
        break;
      case 28:
        ExplainText.text = "4Tの間、通常攻撃による与ダメージだけ自分の体力を回復する";
        CTText.text = "CT：10";
        break;
      case 29:
        ExplainText.text = "敵1体に直前のターンに受けた被ダメージと同じダメージをあたえる";
        CTText.text = "CT：6";
        break;
      case 30:
        ExplainText.text = "敵1体に「5Tの間、ターン終了時に自分の体力の最大値を1割減らす」呪いをあたえる";
        CTText.text = "CT：8";
        break;
    }
  }

  public void StarText()
  {
    for (int i = 0; i <= 3; i++)
    {
      Texts[i].text = "";
    }
    if (BattleParam.Leo)
    {
      ExplainText.text = "しし座の力を借りて、相手に攻撃力×6.0のダメージ さらに3Tの間、敵の攻撃力を50%ダウンさせる";
    }
    else if (BattleParam.Aries)
    {
      ExplainText.text = "おひつじ座の力を借りて、3Tの間、自分の防御力を3倍にする　その後、相手全体に自身の防御力×10のダメージ";
    }
    else if (BattleParam.Sagittarius)
    {
      ExplainText.text = "いて座の力を借りて、相手に攻撃力Xの貫通ダメージ その後、自分のHPをX回復 Xはこのとき自分が受けていたダメージ";
    }
  }
}
