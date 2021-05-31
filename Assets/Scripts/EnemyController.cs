using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float enemySpeed = 0.6f;
    private bool flag = false;
    private SpriteRenderer sprite = default;
    public TimeCounter timeCounter = default;

    public void setColor(int lev){
        switch(lev){
            case 1:
                enemySpeed = 0.6f;
                sprite = this.GetComponent<SpriteRenderer>();
                sprite.color = new Color(255,255,255,255);
                break;
            case 2:
                enemySpeed = 0.5f;
                sprite = this.GetComponent<SpriteRenderer>();
                sprite.color = new Color(255,0,0,255);
            break;
            case 3:
                enemySpeed = 0.3f;
                sprite = this.GetComponent<SpriteRenderer>();
                sprite.color = new Color(0,0,0,255);
            break;
            
        }
    }
    public bool getEnemyWin(){
        if(timeCounter.getTime() >= enemySpeed){
            flag = true;
        }
        return flag;
    }
}
