using UnityEngine;
using System.Collections;

//シーン遷移時に戦闘で使うデータを保存しておくファイルの作成
[CreateAssetMenu(fileName = "BattleParameter", menuName = "CreateBattleParameter", order = 1 )]

public class BattleParam : ScriptableObject {

    // Playerのワールド空間の位置
    public Vector3 pos;
    // Playerの初期位置
    public Vector3 init_pos = new Vector3(0, 14.4f, 0);

    // Playerのワールド空間の角度
    public Quaternion rot;
    // Playerの初期配置
    public Quaternion inti_rot;
    //ステージ抽選用
    public int Stage;
    //プレイヤーの動きを制限
    public bool Stop;
    //シーン読み込みで生成されたダークハートを破壊
    public bool[] destroy;
    //会話イベントを破壊
    public bool[] vs;
    //戦闘終了後の会話イベント用
    public bool Trigger;
    //ゲーム開始
    public bool Starting;
    //朝と夜
    public bool night;
    //会話イベントの変化
    public bool StartUnStar;
    
    public bool AgainStar;

    public bool StartStar;

    public bool AgainUnStar;

    public bool HaveUnStar;

    public bool StartSun;

    public bool AgainSun;

    public bool Aries;
    public bool Leo;
    public bool Sagittarius;

    public int Enemys;
    
    private void OnEnable()
    {
        //ゲーム再生時に初期配置を代入
        pos = init_pos;
        rot = inti_rot;
    }
}
