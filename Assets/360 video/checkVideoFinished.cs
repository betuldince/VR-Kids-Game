using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class checkVideoFinished : MonoBehaviour
{
 

    public double time;
    public double currentTime;
    public GameObject sphere;
    public GameObject scene;
    public GameObject rig;
    // Use this for initialization

    public VideoPlayer vid;
    public VideoClip rewardclip;

    void Start()
    {
        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }
    private void Awake()
    {
        LeaderboardManager leaderboardManager = new LeaderboardManager();
        leaderboardManager.DeleteScores();
    }


    // Update is called once per frame
    void Update()
    {
        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime >= (int)time)
        {
            Debug.Log("//do Stuff");
            sphere.SetActive(false);
            rig.SetActive(false);
            scene.SetActive(true);
        }
    }

    public void rewardVideo()
    {
        sphere.SetActive(true);
        rig.SetActive(true);
        scene.SetActive(false);
        vid.clip = rewardclip;
    }
}
