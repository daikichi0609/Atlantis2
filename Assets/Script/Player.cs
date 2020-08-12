using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    //プレイヤーの情報
    public PlayerData PlayerData;
    //各パラメタ
    public int hp;
    public int at;
    public int df;
    int oldhp;
    //残りhpUI
    public Text hpText;

    public AudioSource DamageSound;

    public bool poison;
    
    // Use this for initialization
    void Start () {
        //パラメタ代入
        
    }
	
	// Update is called once per frame
	void Update () {
        //hp更新
        if (oldhp != hp)
        {
            hpText.text = "×" + hp.ToString();
            oldhp = hp;
        }
    }

    public void OnDamage(int _damage)
    {
        //EnemyのatだけPlayerのhpを減らす
        hp -= _damage;
        DamageSound.Play();
    }

    public void Barrier()
    {
        //バリア
        hp = hp - 2;
    }

    public void Delay()
    {
        //ディレイ
        hp--;
    }

    public void Universe()
    {
        //ユニバース
        hp = hp - 3;
    }

    public void Poison()
    {
        //毒
        poison = true;
    }
}
