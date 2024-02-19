using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    static public GameManager Instance;
    public bool bStageCleared = false;
    public PlayerCharater _player;
    public PlayerCharater Player => _player;

    public MapManager MapManager;
    public ItemManager ItemManager;
    public EnemySpawner EnemySpawner;
    public SoundManager SoundManager;

    public Canvas StageResultCanvas;
    public TMP_Text CurrentScoreText;
    public TMP_Text TimeText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        MapManager.Init(this);
        EnemySpawner.Init(this);
        SoundManager.Init(this);

        SoundManager.instance.PlayBGM("BGM1");
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void EnemyDies()
    {
        AddScore(10);
    }

    public void StageClear()
    {
        AddScore(500);

        float gameStartTime = GameInstance.instance.GameStartTime;
        int score = GameInstance.instance.Score;

        int elapsedTime = Mathf.FloorToInt(Time.time - gameStartTime);

        StageResultCanvas.gameObject.SetActive(true);
        CurrentScoreText.text = "CurrentScore : " + score;
        TimeText.text = "ElapsedTime : " + elapsedTime;
        bStageCleared = true;

        StartCoroutine(LoadNextStageAfterDelay(5f));
    }

    IEnumerator LoadNextStageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        switch (GameInstance.instance.CurrentStageLevel)
        {
            case 1:
                SceneManager.LoadScene("Stage2");
                GameInstance.instance.CurrentStageLevel = 2;
                break;

            case 2:
                SceneManager.LoadScene("Result");
                break;
        }
    }

    public void AddScore(int score)
    {
        GameInstance.instance.Score += score;
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in enemies)
            {
                Enemy enemy = obj?.GetComponent<Enemy>();
                enemy?.Dead();
            }
        }

       
        if (Input.GetKeyUp(KeyCode.F2))
        {
            GameManager.Instance.Player.CurrentWeaponLevel = 3;
            GameInstance.instance.CurrentPlayerWeaponLevel = GameManager.Instance.Player.CurrentWeaponLevel;
        }

        if (Input.GetKeyUp(KeyCode.F3))
        {
            GameManager.Instance.Player.InitSkillCoolDown();
        }

        if (Input.GetKeyUp(KeyCode.F4))
        {
            GameManager.Instance.Player.GetComponent<PlayerHPSystem>().InitHealth();
        }

        if (Input.GetKeyUp(KeyCode.F5))
        {
            GameManager.Instance.Player.GetComponent<PlayerFuelSystem>().InitFuel();
        }

        if (Input.GetKeyUp(KeyCode.F6))
        {
            StageClear();
        }
    }

    static public void InitInstance()
    {
        Debug.Log("!");
        GameInstance.instance.CurrentPlayerFuel = 100;
        GameInstance.instance.CurrentPlayerHP = 3;
        GameInstance.instance.CurrentPlayerWeaponLevel = 0;
        GameInstance.instance.CurrentStageLevel = 1;
        GameInstance.instance.GameStartTime = 0;
        GameInstance.instance.Score = 0;
        GameInstance.instance = null;
    }
}