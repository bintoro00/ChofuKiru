 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 
 public class FazeManager : MonoBehaviour
 {
     private int result = 0;
     private int faze = 1;
     private bool is_game = true; //ゲーム開始のフラグ
     private bool is_start = false; //合図のフラグ
     private EnemyController enemyController = default;
     private PlayerController playerController = default;

     [SerializeField]private GameObject enemy = default;
     [SerializeField]private GameObject player = default;

     [SerializeField]private GameObject resultPanel = default;
     [SerializeField]private Text resultNum = default;
     [SerializeField]private Text num = default;
     [SerializeField]private GameObject check = default;
     public AudioManager audioManager = default;
     public AnimationManager animationManager = default;
     public UIManager uiManager = default;

     public TimeCounter timeCounter = default;
 
     void Start()
     {
         setFormat(); //初期化
         enemyController = enemy.GetComponent<EnemyController>();
         playerController = player.GetComponent<PlayerController>();
     }
     void FixedUpdate()
     {
        switch(faze)
        {
            case 1: setFaze1(); break;
            case 2: setFaze2(); break;
            case 3: setFaze3(); break;
            case 4: setResult(); break;
        }
     }
    //結果画面
     public void setResult()
     {
        animationManager.setEffect(false);
        resultPanel.SetActive(true);
        resultNum.text = result.ToString();
     }
     //倒した数カウント
     public void setResultNum(bool res)
     {
         if(res)
         {
            result += 1;
         }
     }
     //プレイヤー勝利時のイベント
     public void playerWinEvent()
     {
        animationManager.setPlayerWin();
        setResultNum(true);
        timeCounter.timeReset();
        Action();
        setFormat();
        Invoke("selectFaze",4.0f);
     }

     //エネミー勝利時のイベント
     public void enemyWinEvent()
     {
         animationManager.setEnemyWin();
         Action();
         check.SetActive(false);
         playerController.setPlayerWin(false);
         Invoke("setResult",4.0f);
     }

     public void selectFaze()
     {
         faze += 1;
         is_game = true;
         animationManager.setEffect(false);
         audioManager.setStopMusic();
         timeCounter.timerTextReset();
         animationManager.animReset();
         animationManager.moveSet();
     }

     public void setFaze1()
     {
         setGame();
     }
     public void setFaze2()
     {
         setGame();
     }
     public void setFaze3()
     {
         setGame();
     }

     void setGame()
     {
         enemyController.setColor(faze);
         if(faze==1)num.text = "一";
         if(faze==2)num.text = "二";
         if(faze==3)num.text = "三";

         if(is_game) //ゲーム開始
         {
            if(is_start) //合図が鳴った後の処理
            {
                //押すまでの時間計測と 押した時間取得
                timeCounter.setTime(timeCounter.getTime());
                //敵の勝利判定
                if(enemyController.getEnemyWin())
                {
                    enemyWinEvent();
                }
            }
            else //鳴るまでの処理
            {
                //合図を鳴らす
                if(timeCounter.getStart())
                {
                    audioManager.setStopMusic();
                    audioManager.setCheckSE();
                    check.SetActive(true);
                    is_start = true;
                }
                //鳴るまで鳴らす曲
                else
                {
                    audioManager.setSignal();
                    audioManager.setStartMusic();
                }
            } 
        }
     }
     //初期化
     void setFormat()
     {
         resultPanel.SetActive(false);
         check.SetActive(false);
         is_start = false;
     }

     void Action()
     {
         is_game = false;
         animationManager.setEffect(true);
         audioManager.setStopMusic();
         audioManager.setSord();
     }

     //ゲッター・セッター
     public bool getIsGame()
     {
         return is_game;
     }
     public bool getIsStart()
     {
         return is_start;
     }
     public void setIsGame(bool game)
     {
         is_game = game;
     }
     public void setIsStart(bool start)
     {
         is_start = start;
     }
 }