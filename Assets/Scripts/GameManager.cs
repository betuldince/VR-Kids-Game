using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Blue;
    public int Green;
    public int Yellow;
     
    public TextMeshProUGUI timeGUI;
    public TextMeshProUGUI countGUI;

    public TextMeshProUGUI blueGUI;
    public TextMeshProUGUI finalPoint;

    public GameObject countdownscreen;
    public GameObject finishedscreen;
    public float time;
    public int timeInt;
    GameInfo info;
    private bool isStarted=false;

      
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Blue = 0;
        Green = 0;
        Yellow = 0;
        time = 40f;
        info = GameObject.Find("LeaderBoardManager").GetComponent<GameInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        finalPoint.text = blueGUI.text;
        if (isStarted)
        {
            if (time >= 0)
            {
                timeGUI.text = timeInt.ToString() + " s";
                time = time - Time.deltaTime;
                timeInt = (int)time;
                if (time<=6)
                {
                    countdownscreen.SetActive(true);
                    countGUI.text = timeInt.ToString();
                    if (time<=0)
                    {
                        countdownscreen.SetActive(false);
                        // finalPointGUI.text= _pointManager.finalCounter.ToString();
                        
                        finishedscreen.SetActive(true);
                    }
                }
            }
        }

    }
    public void SetScore()
    {
        info.SetScoreInt();
    }
    public void GetScore()
    {
        info.GetScoreInt();
    }
    public void StartTime()
    {
        isStarted = true;   
    }
}
