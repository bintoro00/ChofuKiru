using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour{
    [SerializeField]private Animator playerAnim = default;
    [SerializeField]private Animator enemyAnim = default;
    [SerializeField]private GameObject effect = default;
    [SerializeField]private GameObject start_set = default;

    void Start(){
        Invoke("moveSet",1.0f);
        effect.SetActive(false);
        playerAnim.SetBool("player_set", true);
        enemyAnim.SetBool("enemy_set",true);
    }

    public void setPlayerWin(){
        playerAnim.SetBool("player_win", true);
        enemyAnim.SetBool("enemy_lose",true);
    }

    public void otetsuki(){
        playerAnim.SetBool("otetsuki", true);
    }

    public void setEnemyWin(){
        playerAnim.SetBool("otetsuki", false);
        playerAnim.SetBool("player_lose", true);
        enemyAnim.SetBool("enemy_win",true);
    }

    public void animReset(){
        playerAnim.SetBool("player_lose", false);
        enemyAnim.SetBool("enemy_win",false);
        playerAnim.SetBool("player_win", false);
        enemyAnim.SetBool("enemy_lose",false);
        playerAnim.SetBool("otetsuki", false);

        playerAnim.SetBool("player_set", true);
        enemyAnim.SetBool("enemy_set",true);
    }

    public void setEffect(bool flag){
        effect.SetActive(flag);
    }
    public void moveSet(){
        start_set.SetActive(true);
        Invoke("removeSet",3.5f);
    }
    void removeSet(){
        start_set.SetActive(false);
    }
}