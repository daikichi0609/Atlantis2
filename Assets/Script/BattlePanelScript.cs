using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattlePanelScript : MonoBehaviour {
	
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
    private int Waves;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			if(Info){
			Info = false;
			BattlePanel.SetActive(true);
			EnemyInfoPanel.SetActive(false);
			}
		}	
	}

	public void PushBattleButton()
        {
            //シーン移動の前に位置情報を記憶
            BattleParam.pos = this.transform.position;
            BattleParam.rot = this.transform.rotation;

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

	public void PushEnemyInfoButton(){

		BattlePanel.SetActive(false);
		EnemyInfoPanel.SetActive(true);
		Info = true;

		if (BattleParam.Stage == 0)
            {
                sprite = Resources.Load<Sprite>("goblin");
			    Enemyimage = Enemyimage.GetComponent<Image>();
			    Enemyimage.sprite = sprite;
			    Enemytitle.text = "ゴブリン";
				Enemyexplanation.text = "赤いぼうしがチャームポイント。攻撃力が少し高い。";
				EnemyCommandButton[0].GetComponentInChildren<Text>().text = "ラフスラッシュ";
				EnemyCommandButton[1].GetComponentInChildren<Text>().text = "レイジ";
				EnemyCommandButton[2].GetComponentInChildren<Text>().text = "ーーーーー";
				EnemyCommandButton[3].GetComponentInChildren<Text>().text = "ーーーーー";
                
            }
            if (BattleParam.Stage == 1)
            {
                sprite = Resources.Load<Sprite>("kinoko");
			    Enemyimage = Enemyimage.GetComponent<Image>();
			    Enemyimage.sprite = sprite;
			    Enemytitle.text = "マッシュ";
				Enemyexplanation.text = "食べたら美味しいかもしれないきのこ。体力が少し高い。";
				EnemyCommandButton[0].GetComponentInChildren<Text>().text = "ホウシ";
				EnemyCommandButton[1].GetComponentInChildren<Text>().text = "テイクルート";
				EnemyCommandButton[2].GetComponentInChildren<Text>().text = "ーーーーー";
				EnemyCommandButton[3].GetComponentInChildren<Text>().text = "ーーーーー";
            }
            if (BattleParam.Stage == 2)
            {       
                sprite = Resources.Load<Sprite>("slime");
			    Enemyimage = Enemyimage.GetComponent<Image>();
			    Enemyimage.sprite = sprite;
			    Enemytitle.text = "スライム";
				Enemyexplanation.text = "お馴染みのスライム。防御力が少し高い。";
				EnemyCommandButton[0].GetComponentInChildren<Text>().text = "スライムショット";
				EnemyCommandButton[1].GetComponentInChildren<Text>().text = "バリア";
				EnemyCommandButton[2].GetComponentInChildren<Text>().text = "ーーーーー";
				EnemyCommandButton[3].GetComponentInChildren<Text>().text = "ーーーーー";
            }
            if (BattleParam.Stage == 3)
            {
                sprite = Resources.Load<Sprite>("seed");
			    Enemyimage = Enemyimage.GetComponent<Image>();
			    Enemyimage.sprite = sprite;
			    Enemytitle.text = "シード";
				Enemyexplanation.text = "凶暴な花。非常に攻撃的。";
				EnemyCommandButton[0].GetComponentInChildren<Text>().text = "バイト";
				EnemyCommandButton[1].GetComponentInChildren<Text>().text = "パワーウィップ";
				EnemyCommandButton[2].GetComponentInChildren<Text>().text = "テイクルート";
				EnemyCommandButton[3].GetComponentInChildren<Text>().text = "ーーーーー";
            }
            if (BattleParam.Stage == 4)
            {
                sprite = Resources.Load<Sprite>("goblin");
			    Enemyimage = Enemyimage.GetComponent<Image>();
			    Enemyimage.sprite = sprite;
			    Enemytitle.text = "ゴブリン";
				Enemyexplanation.text = "赤いぼうしがチャームポイント。攻撃力が少し高い。";
				EnemyCommandButton[0].GetComponentInChildren<Text>().text = "ラフスラッシュ";
				EnemyCommandButton[1].GetComponentInChildren<Text>().text = "レイジ";
				EnemyCommandButton[2].GetComponentInChildren<Text>().text = "ランダムスラッシュ";
				EnemyCommandButton[3].GetComponentInChildren<Text>().text = "ーーーーー";
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
	}
	public void PushReverseButton()
        {
            //戻る
            //移動制限を解除
            BattlePanel.SetActive(false);
            BattleParam.Stop = false;
        }

	
}
