using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using Oculus.Platform.Models;
public class LeaderBoardManager : MonoBehaviour
{
    // Start is called before the first frame update
    List<LeaderboardEntry> lbe;
    public int amount;
    void Start()
    {
        
    }
    private void Awake()
    {
        try
        {
            Core.AsyncInitialize();
            Entitlements.IsUserEntitledToApplication().OnComplete(EntitlementCallBack);
        }
        catch (UnityException e)
        {
            Debug.LogError("Failed to intiliaze exception");
            Debug.LogException(e);
            UnityEngine.Application.Quit();
        }
    }
    void EntitlementCallBack(Message msg)
    {
        if (msg.IsError)
        {
            Debug.LogError("You are not entitled to use this app");
            UnityEngine.Application.Quit();
        }
        else
        {
            Debug.Log("You are entitled to use this app");

        }
    }
    public void SubmitScore(string leaderboardname, int score)
        {
        if(score < 0)
        {
            Debug.Log("Error, score cant be negative");
            return;
        }
        Leaderboards.WriteEntry(leaderboardname, score);
        Debug.Log("Data saved to leaderboard");
        }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetLeaderboardData(string leaderboardname)
    {
        lbe = new List<LeaderboardEntry>(); //clear the old ones
        Leaderboards.GetEntries(leaderboardname, amount, LeaderboardFilterType.None, LeaderboardStartAt.Top).OnComplete(LeaderBoardGetCallBack);
    }
    void LeaderBoardGetCallBack(Message<LeaderboardEntryList> msg)
    {
        if (!msg.IsError)
        {
            var entries = msg.Data;
            foreach(var entry in entries)
            {
                lbe.Add(entry);
                
            }
            Debug.Log("Leaderbords fetched successfully");
            UpdateUI();
        }
        else
        {
            Debug.Log("Error getting the leaderbords");
        }
    }

    void UpdateUI()
    {
        
    }
}
