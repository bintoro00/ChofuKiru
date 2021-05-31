using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

*/

public class AudioManager : MonoBehaviour
{
    public AudioClip sound1,sound2,sound3,sound4,sound5,sound6,sound7;
    private AudioSource audioSource;
    private bool signal = true;

    void Start(){
        audioSource = this.GetComponent<AudioSource>();
    }
    //風の音
    public void setStartMusic(){
        if(!audioSource.isPlaying)
        audioSource.PlayOneShot(sound1);
    }
    //ターン！
    public void setCheckSE(){
        audioSource.PlayOneShot(sound2);
    }
    //デュクシッ
    public void setSord(){
        if(!signal){
            if(!audioSource.isPlaying)
            audioSource.PlayOneShot(sound4);
            signal = true;
        }
    }
    //ブオオ～～～ン
    public void setSignal(){
        if(signal){
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(sound3);
                signal = false;
            }
        }
    }
    //全ストップ
    public void setStopMusic(){
        audioSource.Stop();
    }
    //選択音
    public void setSelect(){
        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(sound5);   
    }
    public void setSelect2(){
            audioSource.PlayOneShot(sound7);
    }
    //決定音
    public void setEnter(){
        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(sound6);   
    }
}
