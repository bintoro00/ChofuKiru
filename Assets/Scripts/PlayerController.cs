using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    private bool is_win = true;
    [SerializeField]private GameObject ote = default;
    public AnimationManager animationManager = default;
    public AudioManager audioManager = default;
    public FazeManager fazeManager = default;

    void Start()
    {
        ote.SetActive(false);
    }

    void FixedUpdate()
    {
        //合図が鳴った後の処理
        if(fazeManager.getIsStart())
        {
            //プレイヤーの勝利
            if(Input.anyKey && !Input.GetMouseButton(0)
             && !Input.GetMouseButton(1) && !Input.GetMouseButton(2) && is_win)
            {
                fazeManager.playerWinEvent();
            }
        }
        if(!fazeManager.getIsStart() && fazeManager.getIsGame())
        {
            if(Input.anyKey && !Input.GetMouseButton(0)
             && !Input.GetMouseButton(1) && !Input.GetMouseButton(2) && is_win)
            {
                Debug.Log("おてつき");
                is_win = false;
                audioManager.setSelect2();
                animationManager.otetsuki();
                ote.SetActive(true);
            }
        }
    }
    public bool playerWin()
    {
        return is_win;
    }
    public void setPlayerWin(bool p)
    {
        is_win = p;
    }
}
