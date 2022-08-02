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
    public float time;
    public int timeInt;
    GameInfo info;

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
        time = 120f;
        info = GameObject.Find("LeaderBoardManager").GetComponent<GameInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0)
        {
            timeGUI.text = timeInt.ToString() + " s";
            time=time-Time.deltaTime;
            timeInt = (int)time;
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
}
