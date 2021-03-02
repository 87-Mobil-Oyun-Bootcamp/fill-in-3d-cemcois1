using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => instance;

    private static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        LevelManager.Instance.LevelComplated += OnLevelComplated;
    }
    void OnLevelComplated()
    {
        print("LevelComplated");
        print("cansu <3 <3 ");

    }
}
