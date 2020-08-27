using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattlePanelScript : MonoBehaviour
{
  public GameObject Uni;
  public BattleParam BattleParam;
  private EnemyCommandButtonScript EnemyCommandButtonScript;
  public GameObject BattlePanel;
  public GameObject EnemyInfoPanel;
  public bool Info;
  public Image Enemyimage;
  private Sprite sprite;
  public Text Enemytitle;
  public Text Enemyexplanation;
  public Button[] EnemyCommandButton;
  private int Enemys;
  public GameObject Right;
  public GameObject Left;
  public int page;
  public Text CT;
  public Text EnemyCommandexplanation;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      if (Info)
      {
        Info = false;
        BattlePanel.SetActive(true);
        EnemyInfoPanel.SetActive(false);
        EnemyCommandexplanation.text = "";
        CT.text = "CT：-";
      }
    }
  }

  public void PushBattleButton()
  {
    //シーン移動の前に位置情報を記憶
    BattleParam.pos = Uni.transform.position;
    BattleParam.rot = Uni.transform.rotation;
    BattleParam.Stop = false;

    //バトルへ
    if (BattleParam.Stage == 0)
    {
      SceneManager.LoadScene("Battle");
    }
    if (BattleParam.Stage == 1)
    {
      SceneManager.LoadScene("Battle 1");
    }
    if (BattleParam.Stage == 2)
    {
      SceneManager.LoadScene("Battle 2");
    }
    if (BattleParam.Stage == 3)
    {
      SceneManager.LoadScene("Battle 3");
    }
    if (BattleParam.Stage == 4)
    {
      SceneManager.LoadScene("Battle 4");
    }
    if (BattleParam.Stage == 5)
    {
      SceneManager.LoadScene("Battle 5");
    }
    if (BattleParam.Stage == 6)
    {
      SceneManager.LoadScene("Battle 6");
    }
    if (BattleParam.Stage == 7)
    {
      SceneManager.LoadScene("Battle 7");
    }
    if (BattleParam.Stage == 8)
    {
      SceneManager.LoadScene("Battle 8");
    }
    if (BattleParam.Stage == 9)
    {
      SceneManager.LoadScene("Battle 9");
    }
  }

  public void PushEnemyInfoButton()
  {
    BattlePanel.SetActive(false);
    EnemyInfoPanel.SetActive(true);
    Info = true;
    page = 0;

    if (BattleParam.Stage == 0)
    {
      Enemys = 1;
      sprite = Resources.Load<Sprite>("goblin");
      Enemyimage = Enemyimage.GetComponent<Image>();
      Enemyimage.sprite = sprite;
      Enemytitle.text = "ゴブリン";
      Enemyexplanation.text = "赤いぼうしがチャームポイント\n攻撃力が少し高め";
      EnemyCommandButton[0].GetComponentInChildren<Text>().text = "ラフスラッシュ";
      EnemyCommandButton[1].GetComponentInChildren<Text>().text = "ダブルスラッシュ";
      EnemyCommandButton[2].GetComponentInChildren<Text>().text = "レイジ";
      EnemyCommandButton[3].GetComponentInChildren<Text>().text = "プロテクション";
    }
    if (BattleParam.Stage == 1)
    {
      Enemys = 1;
      sprite = Resources.Load<Sprite>("kinoko");
      Enemyimage = Enemyimage.GetComponent<Image>();
      Enemyimage.sprite = sprite;
      Enemytitle.text = "マッシュ";
      Enemyexplanation.text = "食べたら美味しいかもしれないきのこ\n体力が少し高め";
      EnemyCommandButton[0].GetComponentInChildren<Text>().text = "パワーウィップ";
      EnemyCommandButton[1].GetComponentInChildren<Text>().text = "ベノムショット";
      EnemyCommandButton[2].GetComponentInChildren<Text>().text = "ウィザーマジック";
      EnemyCommandButton[3].GetComponentInChildren<Text>().text = "テイクルート";
    }
    if (BattleParam.Stage == 2)
    {
      Enemys = 1;
      sprite = Resources.Load<Sprite>("slime");
      Enemyimage = Enemyimage.GetComponent<Image>();
      Enemyimage.sprite = sprite;
      Enemytitle.text = "スライム";
      Enemyexplanation.text = "お馴染みのスライム\n防御力が少し高め";
      EnemyCommandButton[0].GetComponentInChildren<Text>().text = "スライムショット";
      EnemyCommandButton[1].GetComponentInChildren<Text>().text = "ベノムショット";
      EnemyCommandButton[2].GetComponentInChildren<Text>().text = "バリア";
      EnemyCommandButton[3].GetComponentInChildren<Text>().text = "ヒール";
    }
    if (BattleParam.Stage == 3)
    {
      Enemys = 1;
      sprite = Resources.Load<Sprite>("seed");
      Enemyimage = Enemyimage.GetComponent<Image>();
      Enemyimage.sprite = sprite;
      Enemytitle.text = "シード";
      Enemyexplanation.text = "凶暴な花\n非常に攻撃的";
      EnemyCommandButton[0].GetComponentInChildren<Text>().text = "パワーウィップ";
      EnemyCommandButton[1].GetComponentInChildren<Text>().text = "バイト";
      EnemyCommandButton[2].GetComponentInChildren<Text>().text = "レイジ";
      EnemyCommandButton[3].GetComponentInChildren<Text>().text = "テイクルート";
    }
    if (BattleParam.Stage == 4)
    {
      Enemys = 2;
      sprite = Resources.Load<Sprite>("goblin");
      Enemyimage = Enemyimage.GetComponent<Image>();
      Enemyimage.sprite = sprite;
      Enemytitle.text = "ゴブリン";
      Enemyexplanation.text = "リベンジを果たしに再びやってきた\n攻撃力が少し高め";
      EnemyCommandButton[0].GetComponentInChildren<Text>().text = "ラフスラッシュ";
      EnemyCommandButton[1].GetComponentInChildren<Text>().text = "ダブルスラッシュ";
      EnemyCommandButton[2].GetComponentInChildren<Text>().text = "レイジ";
      EnemyCommandButton[3].GetComponentInChildren<Text>().text = "プロテクション";
    }
    if (BattleParam.Stage == 5)
    {

    }
    if (BattleParam.Stage == 6)
    {

    }
    if (BattleParam.Stage == 7)
    {

    }
    if (BattleParam.Stage == 8)
    {

    }
    if (BattleParam.Stage == 9)
    {

    }
    Arrow();
  }

  public void ToPage1()
  {
    switch (BattleParam.Stage)
    {
      case 4:
        sprite = Resources.Load<Sprite>("slime");
        Enemyimage = Enemyimage.GetComponent<Image>();
        Enemyimage.sprite = sprite;
        Enemytitle.text = "スライム";
        Enemyexplanation.text = "リベンジを果たしに再びやってきた\n防御力が少し高め";
        EnemyCommandButton[0].GetComponentInChildren<Text>().text = "スライムショット";
        EnemyCommandButton[1].GetComponentInChildren<Text>().text = "ベノムショット";
        EnemyCommandButton[2].GetComponentInChildren<Text>().text = "バリア";
        EnemyCommandButton[3].GetComponentInChildren<Text>().text = "ヒール";
        break;
    }
    Arrow();
  }

  public void ToPage2()
  {
    switch (BattleParam.Stage)
    {

    }
    Arrow();
  }

  public void PushRight()
  {
    if (page == 0)
    {
      page = 1;
      ToPage1();
      return;
    }
    if (page == 1)
    {
      page = 2;
      ToPage2();
      return;
    }
  }

  public void PushLeft()
  {
    if (page == 1)
    {
      page = 0;
      PushEnemyInfoButton();
      return;
    }
    else if (page == 2)
    {
      page = 1;
      ToPage1();
      return;
    }
  }

  public void Arrow()
  {
    if (Enemys == 2)
    {
      switch (page)
      {
        case 0:
          Right.SetActive(true);
          Left.SetActive(false);
          break;
        case 1:
          Right.SetActive(false);
          Left.SetActive(true);
          break;
      }
    }
    else if (Enemys == 3)
    {
      switch (page)
      {
        case 0:
          Right.SetActive(true);
          Left.SetActive(false);
          break;
        case 1:
          Right.SetActive(true);
          Left.SetActive(true);
          break;
        case 2:
          Right.SetActive(false);
          Left.SetActive(true);
          break;
      }
    }
  }

  public void PushReverseButton()
  {
    //戻る
    //移動制限を解除
    BattlePanel.SetActive(false);
    BattleParam.Stop = false;
  }


}
