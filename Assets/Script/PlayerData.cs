using System.Collections;

using System.Collections.Generic;

using UnityEngine;



[CreateAssetMenu(menuName = "MyScriptable/Create PlayerData")]

public class PlayerData : ScriptableObject
{
  public int Lv;
  public int BasicAt;
  public int BasicDf;
  public int BasicHP;
  public int SP; //ステータス割り振りポイント
  public float AtMagni;
  public float DfMagni;
  public float HPMagni;
  public int AT;
  public int DF;
  public int HP;
  public int[] CommandNum;
  public string[] skillname;
  public Color[] buttonColors;
  //触れたダークハートを破壊してピンクのハートを生成
  public bool breakmode;

}
