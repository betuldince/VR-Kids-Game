using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TMPro;
using System;
public class LeaderboardManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isSetting;
    private bool isGetting;
    private bool isDeleting;
    private bool setButton=false;
    private bool finalSetButton = false;
    
    private bool deleteButton = false;
    private bool getButton = false;
    public bool isReady;
    public TextMeshProUGUI[] topscores;
    private int score;
    private int scoreInitial=0;
    private void Start()
    {

        SetButton();

    }
    private void Awake()
    {

        StartCoroutine(DeleteScores());

    }
    void Update()
    {

        if (setButton && !isSetting)
        {
            isSetting = true;
 
            StartCoroutine(SetScore("Mavi Takim", "" + scoreInitial));
            //StartCoroutine(SetScore("Sari Takim", "" + scoreInitial));
            //StartCoroutine(SetScore("Yesil Takim", "" + scoreInitial));
            setButton = false;
        }
        if (finalSetButton && !isSetting)
        {
            isSetting = true;
            score = PointManager.counter;
            StartCoroutine(SetScore("Mavi Takim", "" + score));
 
            finalSetButton = false;
        }



        if (deleteButton && !isDeleting)
        {
            isDeleting = true;
            StartCoroutine(DeleteScores());
            deleteButton = false;
        }

      /*  
        if (getButton && !isGetting)
        {
            isGetting = true;
            StartCoroutine(GetScore());
            getButton = false;
        }
      */

        if (getButton )
        {
            
            StartCoroutine(GetScore());
            
        }

    }

    public void SetButton()
    {
        setButton = true;
    }
    public void FinalSetButton()
    {
        finalSetButton = true;
    }
    public void DeleteButton()
    {
        //Startta sýfýrla, username e göre en son generate et 
        deleteButton = true;
    }
    public void GetButton()
    {
        getButton = true;
    }
    private IEnumerator SetScore(string username, string score)
    {
        string url = $"http://dreamlo.com/lb/lm1gyszIlk6D7SfWnQwdjw3EP7lFbF_UmjQnfezRP91A/add/{username}/{score}";
        using(UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            Debug.Log("sent score");
            isSetting = false;
        }
    }
    public IEnumerator DeleteScores()
    {
        string url = $"http://dreamlo.com/lb/lm1gyszIlk6D7SfWnQwdjw3EP7lFbF_UmjQnfezRP91A/clear";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            Debug.Log("delete score");
            isDeleting = false;
        }

    }
    private IEnumerator GetScore( )
    {
        string url = "http://dreamlo.com/lb/62ff64cf8f40bba6d065a53c/json/3";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            string responseData = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);
            DreamloResponse response = JsonConvert.DeserializeObject<DreamloResponse>(responseData);

            UpdateBoard(response);
            Debug.Log("recieved score");
            isGetting = false;
        }
    }

    void UpdateBoard(DreamloResponse response)
    {
        foreach(var score in topscores)
        {
            score.text = "";
        }
        for (int i = 0; i <= response.dreamlo.leaderboard.entry.Count - 1; i++)
        {
            var user = response.dreamlo.leaderboard.entry[i].name;
            var score = response.dreamlo.leaderboard.entry[i].score;
            topscores[i].text = $"{i + 1}: { user} : { score}";
        }
    }


}
