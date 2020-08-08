using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMasterScript : MonoBehaviour {

    public BattleParam BattleParam;

    public GameObject Unitychan;

    public GameObject[] DarkHeart;

    public GameObject[] Message;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        //Unitychanを移動させる
        Unitychan.transform.position = BattleParam.pos;
        Unitychan.transform.rotation = BattleParam.rot;
    }
	
	// Update is called once per frame
	void Update () {
        if (BattleParam.destroy[0])
        {
            Destroy(DarkHeart[0], 0.1f);
        }
        if (BattleParam.destroy[1])
        {
            Destroy(DarkHeart[1], 0.1f);
        }
        if (BattleParam.destroy[2])
        {
            Destroy(DarkHeart[2], 0.1f);
        }
        if (BattleParam.destroy[3])
        {
            Destroy(DarkHeart[3], 0.1f);
        }
        if (BattleParam.destroy[4])
        {
            Destroy(DarkHeart[4], 0.1f);
        }
        if (BattleParam.destroy[5])
        {
            Destroy(DarkHeart[5], 0.1f);
        }
        if (BattleParam.destroy[6])
        {
            Destroy(DarkHeart[6], 0.1f);
        }
        if (BattleParam.destroy[7])
        {
            Destroy(DarkHeart[7], 0.1f);
        }
        if (BattleParam.destroy[8])
        {
            Destroy(DarkHeart[8], 0.1f);
        }
        if (BattleParam.destroy[9])
        {
            Destroy(DarkHeart[9], 0.1f);
        }

        if (BattleParam.vs[0])
        {
            Destroy(Message[0]);
        }
        if (BattleParam.vs[1])
        {
            Destroy(Message[1]);
        }
        if (BattleParam.vs[2])
        {
            Destroy(Message[2]);
        }
        if (BattleParam.vs[3])
        {
            Destroy(Message[3]);
        }
        if (BattleParam.vs[4])
        {
            Destroy(Message[4]);
        }
        if (BattleParam.vs[5])
        {
            Destroy(Message[5]);
        }
    }

    

}
