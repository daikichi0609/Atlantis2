using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCommandButtonScript : MonoBehaviour
{
  public string Name;
  public Text CT;
  public Text EnemyCommandexplanation;
  public Button button;
  public Color[] colors;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Name = this.GetComponentInChildren<Text>().text;
    switch (Name)
    {
      case "ラフスラッシュ":
      case "ダブルスラッシュ":
      case "パワーウィップ":
      case "スライムショット":
      case "バイト":
        button.GetComponent<Image>().color = colors[0];
        break;
      case "レイジ":
      case "プロテクション":
        button.GetComponent<Image>().color = colors[1];
        break;
      case "ヒール":
      case "テイクルート":
        button.GetComponent<Image>().color = colors[2];
        break;
      case "ベノムショット":
      case "ウィザーマジック":
        button.GetComponent<Image>().color = colors[3];
        break;
    }
  }

  public void PushEnemyCommandButton()
  {
    if (Name == "ラフスラッシュ")
    {
      EnemyCommandexplanation.text = "相手に攻撃力×2のダメージ\n低確率で代わりに攻撃力×4のダメージ";
      CT.text = "CT：3";
    }
    else if (Name == "ダブルスラッシュ")
    {
      EnemyCommandexplanation.text = "相手に攻撃力×1.5のダメージ\nこれを2回行う";
      CT.text = "CT：10";
    }
    else if (Name == "レイジ")
    {
      EnemyCommandexplanation.text = "4Tの間、自分の攻撃力を2倍にする";
      CT.text = "CT：10";
    }
    else if (Name == "プロテクション")
    {
      EnemyCommandexplanation.text = "4Tの間、自分の防御力を2倍にする";
      CT.text = "CT：10";
    }
    else if (Name == "パワーウィップ")
    {
      EnemyCommandexplanation.text = "相手に攻撃力×2のダメージ\nさらに低確率で3Tの間、相手の防御力を20%ダウンさせる";
      CT.text = "CT：3";
    }
    else if (Name == "ベノムショット")
    {
      EnemyCommandexplanation.text = "相手に攻撃力×1のダメージ\nさらに4Tの間、ターン終了時に最大体力の5%のダメージを受ける毒をあたえる";
      CT.text = "CT：6";
    }
    else if (Name == "ウィザーマジック")
    {
      EnemyCommandexplanation.text = "4Tの間、相手の攻撃力を50%ダウン";
      CT.text = "CT：6";
    }
    else if (Name == "テイクルート")
    {
      EnemyCommandexplanation.text = "4Tの間、ターン終了時に自分の体力を1割回復";
      CT.text = "CT：10";
    }
    else if (Name == "スライムショット")
    {
      EnemyCommandexplanation.text = "相手に攻撃力×2のダメージ\nさらに低確率で3Tの間、相手の攻撃力を20%ダウン";
      CT.text = "CT：3";
    }
    else if (Name == "バリア")
    {
      EnemyCommandexplanation.text = "6Tの間、被ダメージを5割カット";
      CT.text = "CT：10";
    }
    else if (Name == "ヒール")
    {
      EnemyCommandexplanation.text = "自分のHPを4割回復";
      CT.text = "CT：10";
    }
    else if (Name == "バイト")
    {
      EnemyCommandexplanation.text = "相手に攻撃力×2のダメージ\nさらに低確率で3Tの間、自分の攻撃力を20%アップ";
      CT.text = "CT：3";
    }
    else if (Name == "")
    {
      EnemyCommandexplanation.text = "相手に攻撃力×2のダメージ\n低確率でさらに敵の攻撃力を30%ダウン";
      CT.text = "CT：3";
    }
    else if (Name == "")
    {
      EnemyCommandexplanation.text = "6Tの間、被ダメージを5割カット";
      CT.text = "CT：10";
    }
    else
    {
      EnemyCommandexplanation.text = "";
      CT.text = "";
    }

  }
}
