using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowchartvoidScript : MonoBehaviour
{

  public BattleParam BattleParam;

  public Fungus.Flowchart flowchart = null;

  public AudioSource PlusSound;
  public AudioSource ChangeSound;
  public ParticleSystem StarParticle;
  public ParticleSystem StarParticle2;
  public AudioSource StarSound;

  public Button AttackButton;
  public Button BarrierButton;
  public Button DelayButton;
  public Button UniverseButton;
  public Button ChangeButton;
  public GameObject LeoUI;
  public GameObject AriesUI;
  public GameObject SagittariusUI;

  public GameObject MainCamera;
  public GameObject BackCamera;
  public GameObject DarkHeartCamera;
  public GameObject BigDarkHeartCamera;
  public GameObject StarCamera;
  public GameObject StoneCamera;
  public GameObject DarkCamera;
  public GameObject NightCamera;
  public GameObject MorningCamera;

  public GameObject unstar;
  public GameObject star;
  public GameObject star2;
  public GameObject StarProtect;
  public GameObject StarFinal;
  public GameObject Panel;
  public GameObject[] Image;
  bool Info;
  bool Info2;
  bool Info3;
  public GameObject startsun;
  public GameObject sun;
  public GameObject moon;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  //動きを制限
  public void Stop()
  {
    BattleParam.Stop = true;
    if (BattleParam.Leo)
    {
      LeoUI.SetActive(false);
    }
    if (BattleParam.Aries)
    {
      AriesUI.SetActive(false);
    }
    if (BattleParam.Sagittarius)
    {
      SagittariusUI.SetActive(false);
    }
  }
  //制限解除
  public void UnStop()
  {
    BattleParam.Stop = false;
    if (BattleParam.Leo)
    {
      LeoUI.SetActive(true);
    }
    if (BattleParam.Aries)
    {
      AriesUI.SetActive(true);
    }
    if (BattleParam.Sagittarius)
    {
      SagittariusUI.SetActive(true);
    }
  }
  //ゲーム開始
  public void Starting()
  {
    PlusSound.Play();
    BattleParam.Starting = true;
    BattleParam.vs[0] = true;
  }
  //初めてのダークハート
  public void darkheart()
  {
    MainCamera.SetActive(false);
    BackCamera.SetActive(false);
    DarkHeartCamera.SetActive(true);
  }
  //終了
  public void darkheart2()
  {
    DarkHeartCamera.SetActive(false);
    MainCamera.SetActive(true);
    BattleParam.vs[1] = true;
  }
  //初めてのハート
  public void heart()
  {
    MainCamera.SetActive(false);
    BackCamera.SetActive(false);
    DarkHeartCamera.SetActive(true);
  }
  //終了
  public void heart2()
  {
    DarkHeartCamera.SetActive(false);
    MainCamera.SetActive(true);
    BattleParam.vs[2] = true;
  }
  //初めてのバトル
  public void battle()
  {
    AttackButton.interactable = false;
    BarrierButton.interactable = false;
  }
  //終了
  public void battle2()
  {
    AttackButton.interactable = true;
    BarrierButton.interactable = true;
  }
  //初めてのマルチバトル
  public void battle3()
  {
    AttackButton.interactable = false;
    BarrierButton.interactable = false;
    ChangeButton.interactable = false;
  }
  //終了
  public void battle4()
  {
    AttackButton.interactable = true;
    BarrierButton.interactable = true;
    ChangeButton.interactable = true;
  }
  //初めてのビックダークハート
  public void bigdarkheart()
  {
    MainCamera.SetActive(false);
    BackCamera.SetActive(false);
    BigDarkHeartCamera.SetActive(true);
  }
  //終了
  public void bigdarkheart2()
  {
    BigDarkHeartCamera.SetActive(false);
    MainCamera.SetActive(true);
    BattleParam.vs[3] = true;
  }
  //初めてのビックハート
  public void bigheart()
  {
    MainCamera.SetActive(false);
    BackCamera.SetActive(false);
    BigDarkHeartCamera.SetActive(true);
  }
  //終了
  public void bigheart2()
  {
    BigDarkHeartCamera.SetActive(false);
    MainCamera.SetActive(true);
    BattleParam.vs[4] = true;
  }
  //ディレイ　チュートリアル
  public void delay()
  {
    AttackButton.interactable = false;
    BarrierButton.interactable = false;
    DelayButton.interactable = false;
  }
  //終了
  public void delay2()
  {
    AttackButton.interactable = true;
    BarrierButton.interactable = true;
    DelayButton.interactable = true;
  }
  //カメラ切り替え
  public void StarStart()
  {
    MainCamera.SetActive(false);
    BackCamera.SetActive(false);
    StarCamera.SetActive(true);
    if (BattleParam.StartStar)
    {
      StarParticle2.Play();
    }
  }
  //終了
  public void StarFinish()
  {
    MainCamera.SetActive(true);
    StarCamera.SetActive(false);
    if (BattleParam.StartStar)
    {
      StarParticle2.Stop();
    }
  }
  //選択肢表示
  public void UnStarSelect()
  {
    unstar.SetActive(true);
  }
  //触る
  public void UnStarSelectYes()
  {
    unstar.SetActive(false);
    flowchart.SendFungusMessage("unstaryes");
    BattleParam.StartUnStar = true;
  }
  //やめとく
  public void UnStarSelectNo()
  {
    unstar.SetActive(false);

    if (BattleParam.AgainUnStar)
    {
      flowchart.SendFungusMessage("againunstarno");
    }
    else
    {
      BattleParam.AgainUnStar = true;
      flowchart.SendFungusMessage("startunstarno");
    }
  }
  //選択肢表示
  public void StarSelect()
  {
    star.SetActive(true);
  }
  //触る
  public void StarYes()
  {
    star.SetActive(false);
    flowchart.SendFungusMessage("staryes");
    BattleParam.StartStar = true;
    BattleParam.HaveUnStar = true;
  }
  //初回演出
  public void StarYes2()
  {
    StarParticle.Play();
    StarParticle2.Play();
    StarSound.Play();
  }
  //やめとく
  public void StarNo()
  {
    star.SetActive(false);

    if (BattleParam.AgainStar)
    {
      flowchart.SendFungusMessage("againstarno");
    }
    else if (!BattleParam.AgainStar)
    {
      BattleParam.AgainStar = true;
      flowchart.SendFungusMessage("startstarno");
    }
  }
  //選択肢表示
  public void StarSelect2()
  {
    star2.SetActive(true);
  }
  //加護一覧を表示
  public void StarYes3()
  {
    star2.SetActive(false);
    StarProtect.SetActive(true);
  }
  //やめとく
  public void StarNo2()
  {
    star2.SetActive(false);
    flowchart.SendFungusMessage("starno");
  }

  public void Leo()
  {
    Info = true;
    Info2 = false;
    Info3 = false;
    Panel.SetActive(true);
    StarProtect.SetActive(false);
    flowchart.SendFungusMessage("leo2");
    Image[0].SetActive(true);
  }

  public void Aries()
  {
    Info = false;
    Info2 = true;
    Info3 = false;
    Panel.SetActive(true);
    StarProtect.SetActive(false);
    flowchart.SendFungusMessage("aries2");
    Image[1].SetActive(true);
  }

  public void Sagittarius()
  {
    Info = false;
    Info2 = false;
    Info3 = true;
    Panel.SetActive(true);
    StarProtect.SetActive(false);
    flowchart.SendFungusMessage("sagittarius2");
    Image[2].SetActive(true);
  }

  public void StarFinalSelect()
  {
    StarFinal.SetActive(true);
    StarProtect.SetActive(false);
    Panel.SetActive(false);
  }

  public void StarTrue()
  {
    StarFinal.SetActive(false);
    StarParticle.Play();
    StarSound.Play();
    if (Info)
    {
      Info = false;
      BattleParam.Leo = true;
      BattleParam.Aries = false;
      BattleParam.Sagittarius = false;
      LeoUI.SetActive(true);
      AriesUI.SetActive(false);
      SagittariusUI.SetActive(false);
      flowchart.SendFungusMessage("leo");
      Image[0].SetActive(false);
    }
    if (Info2)
    {
      Info = false;
      BattleParam.Aries = true;
      BattleParam.Leo = false;
      BattleParam.Sagittarius = false;
      LeoUI.SetActive(false);
      AriesUI.SetActive(true);
      SagittariusUI.SetActive(false);
      flowchart.SendFungusMessage("aries");
      Image[1].SetActive(false);
    }
    if (Info3)
    {
      Info3 = false;
      BattleParam.Sagittarius = true;
      BattleParam.Leo = false;
      BattleParam.Aries = false;
      LeoUI.SetActive(false);
      AriesUI.SetActive(false);
      SagittariusUI.SetActive(true);
      flowchart.SendFungusMessage("sagittarius");
      Image[2].SetActive(false);
    }
  }

  public void StarFalse()
  {
    StarFinal.SetActive(false);
    StarProtect.SetActive(true);
    Image[0].SetActive(false);
    Image[1].SetActive(false);
    Image[2].SetActive(false);
  }
  //カメラ切り替え
  public void StoneStart()
  {
    MainCamera.SetActive(false);
    BackCamera.SetActive(false);
    StoneCamera.SetActive(true);
  }
  //終了
  public void StoneFinish()
  {
    MainCamera.SetActive(true);
    StoneCamera.SetActive(false);
  }
  //暗転
  public void Dark()
  {
    StoneCamera.SetActive(false);
    DarkCamera.SetActive(true);
  }
  //明転
  public void Shine()
  {
    DarkCamera.SetActive(false);
    StoneCamera.SetActive(true);
  }
  //選択肢表示
  public void SunSelect()
  {
    sun.SetActive(true);
  }
  //触る
  public void SunYes()
  {
    sun.SetActive(false);

    if (BattleParam.StartSun)
    {
      //通常
      DarkCamera.SetActive(true);
      StoneCamera.SetActive(false);
      ChangeSound.Play();
      StartCoroutine(Checking(() =>
      {
        StoneCamera.SetActive(true);
        DarkCamera.SetActive(false);
        flowchart.SendFungusMessage("sunyes");
      }));
    }
    else if (!BattleParam.StartSun)
    {
      //初回
      DarkCamera.SetActive(true);
      StoneCamera.SetActive(false);
      BattleParam.StartSun = true;
      ChangeSound.Play();
      flowchart.SendFungusMessage("startsunyes");
    }
    BattleParam.night = true;
  }

  public delegate void functionType();
  private IEnumerator Checking(functionType callback)
  {
    while (true)
    {
      yield return new WaitForFixedUpdate();
      if (!ChangeSound.isPlaying)
      {
        callback();
        break;
      }
    }
  }
  //初回演出
  public void SunYes2()
  {
    DarkCamera.SetActive(true);
    StoneCamera.SetActive(false);
    BattleParam.night = false;
    ChangeSound.Play();
    StartCoroutine(Checking(() =>
    {
      StoneCamera.SetActive(true);
      DarkCamera.SetActive(false);
      flowchart.SendFungusMessage("startsunyes2");
    }));
  }
  //やめとく
  public void SunNo()
  {
    sun.SetActive(false);
    if (BattleParam.StartSun)
    {
      //通常
      flowchart.SendFungusMessage("no");
    }
    else if (!BattleParam.StartSun)
    {
      if (BattleParam.AgainSun)
      {
        //未使用＆初回
        flowchart.SendFungusMessage("againsunno");
      }
      else if (!BattleParam.AgainSun)
      {
        //初回
        flowchart.SendFungusMessage("startsunno");
        BattleParam.AgainSun = true;
      }
    }
  }
  //選択肢表示
  public void MoonSelect()
  {
    moon.SetActive(true);
  }
  //触る
  public void MoonYes()
  {
    //通常
    moon.SetActive(false);
    DarkCamera.SetActive(true);
    StoneCamera.SetActive(false);
    BattleParam.night = false;
    ChangeSound.Play();
    StartCoroutine(Checking(() =>
    {
      StoneCamera.SetActive(true);
      DarkCamera.SetActive(false);
      flowchart.SendFungusMessage("moonyes");
    }));
  }
  //やめとく
  public void MoonNo()
  {
    //通常
    moon.SetActive(false);
    flowchart.SendFungusMessage("no");
  }
  //第二ボス発見
  public void WaterHeart()
  {
    if (BattleParam.night)
    {
      NightCamera.SetActive(true);
    }
    else if (!BattleParam.night)
    {
      MorningCamera.SetActive(true);
    }

    MainCamera.SetActive(false);
    BackCamera.SetActive(false);
  }
  //通常
  public void WaterFinish()
  {
    MainCamera.SetActive(true);
    BattleParam.vs[5] = true;

    if (BattleParam.night)
    {
      NightCamera.SetActive(false);
    }
    else if (!BattleParam.night)
    {
      MorningCamera.SetActive(false);
    }
  }
}
