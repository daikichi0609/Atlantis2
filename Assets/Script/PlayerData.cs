using System.Collections;

using System.Collections.Generic;

using UnityEngine;



[CreateAssetMenu(menuName = "MyScriptable/Create PlayerData")]

public class PlayerData : ScriptableObject
{
    //public string playerName;
    public int Lv;
    public int BasicAt;
    public int BasicDf;
    public int BasicHP;
    public int SP; //ステータス割り振りポイント
    public int CP;　//技取得ポイント
    public float AtMagni;
    public float DfMagni;
    public float HPMagni;
    public int AT;
    public int DF;
    public int HP;
    //触れたダークハートを破壊してピンクのハートを生成
    public bool breakmode;

}
