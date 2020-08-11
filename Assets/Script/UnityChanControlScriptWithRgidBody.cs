//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
//
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace UnityChan
{
// 必要なコンポーネントの列記
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Rigidbody))]

	public class UnityChanControlScriptWithRgidBody : MonoBehaviour
	{
        //データ取得
        public BattleParam BattleParam;
        public PlayerData PlayerData;
        public Fungus.Flowchart flowchart = null;
        //ピンクのハート
        public GameObject BigHeart;
        public GameObject BigHeart1;
        //遅延用
        float second;
        public GameObject Status;
        //上手く音を流すためにゲームオブジェクトとして扱う
        public GameObject RunningSound;
        public GameObject WalkingSound;
        public GameObject RunningSound2;
        public GameObject WalkingSound2;
        public GameObject RunningSound3;
        public GameObject WalkingSound3;
        //hp最大値増加時のSE
        public AudioSource PlusSound;

        public GameObject[] ui;

        float h;
        float v;
        //バトル遷移確認パネル
        public GameObject BattlePanel;
        public AudioSource ApiSound;
        public GameObject Camera;
        public GameObject ApiCamera;
        public AnimationClip[] faceAnime;
        //hpMaxの値によって破壊される壁
        public GameObject AudioSource;

        public float animSpeed = 1.5f;				// アニメーション再生速度設定
		public float lookSmoother = 3.0f;			// a smoothing setting for camera motion
		public bool useCurves = true;				// Mecanimでカーブ調整を使うか設定する
		// このスイッチが入っていないとカーブは使われない
		public float useCurvesHeight = 0.5f;		// カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）

		// 以下キャラクターコントローラ用パラメタ
		// 前進速度
		public float forwardSpeed = 2.0f;
		// 後退速度
		public float backwardSpeed = 3.0f;
		// 旋回速度
		public float rotateSpeed = 2.0f;
		// ジャンプ威力
		//public float jumpPower = 3.0f; 
		// キャラクターコントローラ（カプセルコライダ）の参照
		private CapsuleCollider col;
		private Rigidbody rb;
		// キャラクターコントローラ（カプセルコライダ）の移動量
		private Vector3 velocity;
		// CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
		private float orgColHight;
		private Vector3 orgVectColCenter;
		private Animator anim;							// キャラにアタッチされるアニメーターへの参照
		private AnimatorStateInfo currentBaseState;			// base layerで使われる、アニメーターの現在の状態の参照

		private GameObject cameraObject;	// メインカメラへの参照
		
		// アニメーター各ステートへの参照
		static int idleState = Animator.StringToHash ("Base Layer.Idle");
		static int locoState = Animator.StringToHash ("Base Layer.Locomotion");
		//static int jumpState = Animator.StringToHash ("Base Layer.Jump");
		static int restState = Animator.StringToHash ("Base Layer.Rest");

		// 初期化
		void Start ()
		{
            // Animatorコンポーネントを取得する
            anim = GetComponent<Animator> ();
			// CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
			col = GetComponent<CapsuleCollider> ();
			rb = GetComponent<Rigidbody> ();
			//メインカメラを取得する
			cameraObject = GameObject.FindWithTag ("MainCamera");
			// CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
			orgColHight = col.height;
			orgVectColCenter = col.center;
        }
	
	
		// 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
		void FixedUpdate ()
		{
            //確認画面でないなら
            if (!BattleParam.Stop)
            {
                h = Input.GetAxis("Horizontal");              // 入力デバイスの水平軸をhで定義
                v = Input.GetAxis("Vertical");                // 入力デバイスの垂直軸をvで定義

                anim.SetFloat("Speed", v);                          // Animator側で設定している"Speed"パラメタにvを渡す
                anim.SetFloat("Direction", h);                      // Animator側で設定している"Direction"パラメタにhを渡す
                anim.speed = animSpeed;                             // Animatorのモーション再生速度に animSpeedを設定する
                currentBaseState = anim.GetCurrentAnimatorStateInfo(0); // 参照用のステート変数にBase Layer (0)の現在のステートを設定する
                rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする

                // 以下、キャラクターの移動処理
                velocity = new Vector3(0, 0, v);        // 上下のキー入力からZ軸方向の移動量を取得

                // キャラクターのローカル空間での方向に変換
                velocity = transform.TransformDirection(velocity);
                //以下のvの閾値は、Mecanim側のトランジションと一緒に調整する

                if (v > 0.1)
                {
                    velocity *= forwardSpeed;// 移動速度を掛ける
                }
                else if (v < -0.1)
                {
                    velocity *= backwardSpeed;  // 移動速度を掛ける
                }
                else
                {
                    RunningSound.SetActive(false);
                    WalkingSound.SetActive(false);
                    RunningSound2.SetActive(false);
                    WalkingSound2.SetActive(false);
                    RunningSound3.SetActive(false);
                    WalkingSound3.SetActive(false);
                }
      
                // 上下のキー入力でキャラクターを移動させる
                transform.localPosition += velocity * Time.fixedDeltaTime;

                // 左右のキー入力でキャラクタをY軸で旋回させる
                transform.Rotate(0, h * rotateSpeed, 0);
            }

            //確認画面表示中は移動できない
            if (BattleParam.Stop)
            {
                anim.SetFloat("Speed", 0);
                anim.SetFloat("Direction", 0);
                RunningSound.SetActive(false);
                WalkingSound.SetActive(false);
                RunningSound2.SetActive(false);
                WalkingSound2.SetActive(false);
                RunningSound3.SetActive(false);
                WalkingSound3.SetActive(false);
            }
           
			// 以下、Animatorの各ステート中での処理
			// Locomotion中
			// 現在のベースレイヤーがlocoStateの時
			if (currentBaseState.nameHash == locoState) {
                //カーブでコライダ調整をしている時は、念のためにリセットする
				if (useCurves) {
					resetCollider ();
				}
			}
		

		// IDLE中の処理
		// 現在のベースレイヤーがidleStateの時
		else if (currentBaseState.nameHash == idleState) {
				//カーブでコライダ調整をしている時は、念のためにリセットする
				if (useCurves) {
					resetCollider ();
				}
				// スペースキーを入力したらRest状態になる
				if (Input.GetButtonDown ("Jump")) {
                    if (!BattleParam.Stop)
                    {
                        //メニュー表示
                    }
                }

			}
		// REST中の処理
		// 現在のベースレイヤーがrestStateの時
		else if (currentBaseState.nameHash == restState) {
				//cameraObject.SendMessage("setCameraPositionFrontView");		// カメラを正面に切り替える
				// ステートが遷移中でない場合、Rest bool値をリセットする（ループしないようにする）
				if (!anim.IsInTransition (0)) {
					anim.SetBool ("Rest", false);
				}
			}

            //カメラ切り替え
            if (Input.GetKeyDown(KeyCode.C))
            {
                ApiCamera.SetActive(!ApiCamera.activeSelf);
                Camera.SetActive(!Camera.activeSelf);
            }

            anim.SetLayerWeight(1, 1f);

            if (BattleParam.Starting)
            {
                AudioSource.SetActive(true);
                ui[0].SetActive(true);
            }
            else
            {
                ui[0].SetActive(false);
            }
        }

        public void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "enemy")
            {
                if (!PlayerData.breakmode)
                {
                    //確認画面を表示
                    //移動を制限
                    BattleParam.Stage = col.gameObject.GetComponent<DarkHeartScript>().Stage;
                    BattlePanel.SetActive(true);
                    BattleParam.Stop = true;
                }
                if (PlayerData.breakmode)
                {
                    //ダークハートを破壊して代わりのハートを生成
                    GameObject gameObject = col.gameObject;
                    Destroy(gameObject);
                    PlayerData.breakmode = false;
                    if(BattleParam.Stage <= 3)
                    {
                        Instantiate(BigHeart, gameObject.transform.position + new Vector3(0f, 0f, 0f),
                        gameObject.transform.rotation);
                    }else if(BattleParam.Stage == 4)
                    {
                        Instantiate(BigHeart1, gameObject.transform.position + new Vector3(0f, 0f, 0f),
                        gameObject.transform.rotation);
                    }else if(BattleParam.Stage <= 13)
                    {
                        Instantiate(BigHeart, gameObject.transform.position + new Vector3(0f, 0f, 0f),
                        gameObject.transform.rotation);
                    }
                }
            }
            if(col.gameObject.tag == "wall")
            {
                flowchart.SendFungusMessage("wall");
            }
            if(col.gameObject.tag == "unstar")
            {
                if (BattleParam.StartUnStar)
                {
                    flowchart.SendFungusMessage("unstar");
                }
                else if (BattleParam.HaveUnStar)
                {
                    flowchart.SendFungusMessage("haveunstar");
                }
                else 
                {
                    if (BattleParam.AgainUnStar)
                    {
                        flowchart.SendFungusMessage("againunstar");
                    }
                    else
                    {
                        flowchart.SendFungusMessage("startunstar");
                    }
                }
                
            }
            if (col.gameObject.tag == "star")
            {
                if (BattleParam.StartStar)
                {
                    flowchart.SendFungusMessage("star");
                }
                else
                {
                    if (BattleParam.AgainStar)
                    {
                        flowchart.SendFungusMessage("againstar");
                    }
                    else
                    {
                        flowchart.SendFungusMessage("startstar");
                    }
                }
            }
            if (!BattleParam.Stop)
            {
                if (col.gameObject.tag == "Sun")
                {
                    if (BattleParam.StartSun)
                    {
                        flowchart.SendFungusMessage("sun");
                    }
                    else
                    {
                        if (BattleParam.AgainSun)
                        {
                            flowchart.SendFungusMessage("againsun");
                        }
                        else
                        {
                            flowchart.SendFungusMessage("startsun");
                        }
                    }

                }
                if (col.gameObject.tag == "Moon")
                {
                    flowchart.SendFungusMessage("moon");
                }
            }
        }
            
        public void OnCollisionStay(Collision col)
        {
            if (v > 0.1)
            {
                if (col.gameObject.tag == "1")
                {
                    RunningSound.SetActive(true);
                    WalkingSound.SetActive(false);
                    RunningSound2.SetActive(false);
                    WalkingSound2.SetActive(false);
                    RunningSound3.SetActive(false);
                    WalkingSound3.SetActive(false);
                }
                else if(col.gameObject.tag == "2")
                {
                    RunningSound2.SetActive(true);
                    WalkingSound2.SetActive(false);
                    RunningSound.SetActive(false);
                    WalkingSound.SetActive(false);
                    RunningSound3.SetActive(false);
                    WalkingSound3.SetActive(false);
                }
                else if(col.gameObject.tag == "3")
                {
                    RunningSound3.SetActive(true);
                    WalkingSound3.SetActive(false);
                    RunningSound.SetActive(false);
                    WalkingSound.SetActive(false);
                    RunningSound2.SetActive(false);
                    WalkingSound2.SetActive(false);
                }
            }

            else if (v < -0.1)
            {
                if (col.gameObject.tag == "1")
                {
                    WalkingSound.SetActive(true);
                    RunningSound.SetActive(false);
                    WalkingSound2.SetActive(false);
                    RunningSound2.SetActive(false);
                    WalkingSound3.SetActive(false);
                    RunningSound3.SetActive(false);
                }
                else if(col.gameObject.tag == "2")
                {
                    WalkingSound2.SetActive(true);
                    RunningSound2.SetActive(false);
                    WalkingSound.SetActive(false);
                    RunningSound.SetActive(false);
                    WalkingSound3.SetActive(false);
                    RunningSound3.SetActive(false);
                }
                else if(col.gameObject.tag == "3")
                {
                    WalkingSound3.SetActive(true);
                    RunningSound3.SetActive(false);
                    WalkingSound.SetActive(false);
                    RunningSound.SetActive(false);
                    WalkingSound2.SetActive(false);
                    RunningSound2.SetActive(false);
                }
            }
        }
            //col.gameObject.GetComponent<DarkHeartScript>();

        /*
        void OnGUI ()
		{
			GUI.Box (new Rect (Screen.width - 260, 30, 250, 150), "操作方法");
			GUI.Label (new Rect (Screen.width - 245, 60, 250, 30), "上/下 入力 : 前へ走る/後ろへ歩く");
			GUI.Label (new Rect (Screen.width - 245, 80, 250, 30), "左/右 入力 : 左へ旋回/右へ旋回");
			GUI.Label (new Rect (Screen.width - 245, 100, 250, 30), "スペースキー : ポージング");
            GUI.Label(new Rect(Screen.width - 245, 120, 250, 30), "Cキー : カメラ切り替え");
        }
        */

        // キャラクターのコライダーサイズのリセット関数
        void resetCollider ()
		{
			// コンポーネントのHeight、Centerの初期値を戻す
			col.height = orgColHight;
			col.center = orgVectColCenter;
		}
	}
}