using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    private Text timeText;
    private float startTime = 0.0f, 
                  time = 0.0f, 
                  timeStopper = 0;
    private bool flag = false;

    void Start(){
        timeText = this.GetComponent<Text>();
        timeStopper = Random.Range(8f,13f);
    }
    public void timeReset(){
        startTime = 0.0f; 
        time = 0.0f;
        flag = false;
    }
    public void timerTextReset(){
        timeText.text = "00";
    }
    //ただの時間計測
    public float getTime(){
        startTime += Time.deltaTime;
        return startTime;
    }
    //計測後に一定値超えたら合図送る
    public bool getStart(){
        time += Time.deltaTime;
        if(time >= timeStopper){
            flag = true;
        }
        return flag;
    }
    //時間計測結果をコンマ99でストップ
    public void setTime(float timer){
        if(0.99<=timer){
            timer = 0.99f;
        }
        timeText.text = ((timer % 1)*100).ToString("f0");
    }
}