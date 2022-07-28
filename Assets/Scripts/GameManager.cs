using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Blue;
    public int Green;
    public int Yellow;
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
