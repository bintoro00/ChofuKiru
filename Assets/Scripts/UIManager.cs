using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject onePlay = default;
    [SerializeField] private GameObject twoPlay = default;
    [SerializeField] private Text textOne = default;
    [SerializeField] private Text textTwo = default;
    
    private GameObject selectedObj;
    public AudioManager audioManager;

    void Start()
    {
        try{
            EventSystem.current.SetSelectedGameObject(onePlay);
        }catch(NullReferenceException){

        }
    }

    void Update()
    {
        try{
            selectedObj = EventSystem.current.currentSelectedGameObject;
            float dy = Input.GetAxis ("Vertical");
            float dx = Input.GetAxis ("Horizontal");

            if(selectedObj == onePlay){
                textOne.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            }else{
                textOne.color = new Color(0.3f, 0.3f, 0.3f, 1f);
            }
            if(selectedObj == twoPlay){
                textTwo.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            }else{
                textTwo.color = new Color(0.3f, 0.3f, 0.3f, 1f);
            }
            
            if(dy>0 || dy<0 || dx>0 || dx<0){
                audioManager.setSelect();
            }

        }catch(NullReferenceException){}

    }
    public void OnClickButton1(){
        Invoke("moveScene",0.5f);
        audioManager.setEnter();
    }
    public void OnClickButton2(){
        
    }

    public void OnClickButtonTitle(){
        SceneManager.LoadScene("Title");
    }
    public void moveScene(){
        SceneManager.LoadScene("Game");
    }
}
