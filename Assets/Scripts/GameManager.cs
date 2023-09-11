using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject PausePanel; 
    
    [SerializeField]
    private GameObject gameOverPanel;
    private int coin = 0;

    [HideInInspector]
    public bool isGameOver = false;
    void Awake(){
        if (instance==null){
            instance = this;
        }
    }
    public void IncreaseCoin(){
        coin += 1;
        text.SetText(coin.ToString());
        
  //코인 n개마다 무기 업그레이드
        // if(coin % 30 ==0){
        //     Player player = FindObjectOfType<Player>();
        //     if (player != null){
        //         player.Upgrade();
        //     }
        // }
        
    }
    //게임오버 
    public void SetGameOver(){
        isGameOver = true;

        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if(enemySpawner != null){
            enemySpawner.StopEnemyRoutine();
        }
        
        Invoke("showGameOverPanel",1f);
    }
    //게임 오버 화면 보이기
    void showGameOverPanel(){
        gameOverPanel.SetActive(true); // 게임오버패널 보이게하기
        GetComponent<AudioSource>().Play();
    }

    //일시 정지 화면 보이기
    public void showPausePanel(){
        Time.timeScale = 0;//시간을 멈춤
        PausePanel.SetActive(true); 
        GetComponent<AudioSource>().Play();
    }
    //일시 정지 화면 숨기기
    public void hidenPanel(){
        Time.timeScale = 1;//시간이 다시 흐름
        PausePanel.SetActive(false); 
        GetComponent<AudioSource>().Play();
    }
    //게임 처음부터 시작
    public void PlayAgain(){
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayScene");
    }
    public void Play(){
        
        SceneManager.LoadScene("PlayScene");
    }
    //메인메뉴로..
    public void toMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    //게임 나가기
    public void GameExit(){
	Application.Quit();
    }
}
