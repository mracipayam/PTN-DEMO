using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public bool CanBoyMove;
    public bool CanOpponentMove;

    public bool CanPaint;

    public bool isFinish;

    public GameObject StartingPanel;
    public GameObject InGamePanel;
    public GameObject EndGamePanel;

    public Animator BoyAnim;
    public Animator OpponentAnim;
    public List<Animator> opponentsAnim;

    private void Awake() {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }

        Screen.SetResolution(1080, 1920, true);
    }

    private void Start() {
        
        StartingPanel.SetActive(true);
    }

    public void StartGameButton(){
        StartingPanel.SetActive(false);
        InGamePanel.SetActive(true);
        CanBoyMove = true;
        BoyAnim.SetBool("run",true);

        SetTrueOpponentAnimation();

        CanOpponentMove = true;
        
    }

    
    void Update()
    {
        if(isFinish){
            InGamePanel.SetActive(false);
            //Open the endgame panel
            //EndGamePanel.SetActive(true);
            CanPaint = true;
            CanBoyMove = false;
            CanOpponentMove = false;
            BoyAnim.SetBool("run",false);
            SetFalseOpponentAnimation();
            
        }
    }

    public void OpenEndGameScene(){
        EndGamePanel.SetActive(true);
        CanPaint = false;
    }


    public void RestartScene(){
        SceneManager.LoadScene("PanteonDemo");
    }

    public void SetTrueOpponentAnimation(){
        foreach(Animator a in opponentsAnim){
            a.SetBool("run",true);
        }
    }
    public void SetFalseOpponentAnimation(){
        foreach(Animator a in opponentsAnim){
            a.SetBool("run",false);
        }
    }

    
}
