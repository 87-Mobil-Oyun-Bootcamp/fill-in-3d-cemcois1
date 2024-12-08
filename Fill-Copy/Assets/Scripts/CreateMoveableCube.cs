using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMoveableCube : MonoBehaviour
{
    public GameObject moveableCube;

    public static CreateMoveableCube Instance => instance;

    private static CreateMoveableCube instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Create(255);
        LevelManager.Instance.LevelCompleted += Create;
    }


    public void Create(int pixelCount)
    {
        print("createMoveablecube");
        int temp = 0;
        for (int x = 0; x < 16; x++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (pixelCount < temp + 10)
                {
                    break;
                }
                Instantiate(moveableCube, transform.position + new Vector3(x * 3, 0, j * 3), Quaternion.identity, transform);
                temp++;

            }

        }
    }
    public void Create()
    {


        for (int x = 0; x < 32; x++)
        {
            for (int j = 0; j < 12; j++)
            {

                Instantiate(moveableCube, transform.position + new Vector3(x * 3, 0, j * 3), Quaternion.identity, transform);
            }

        }
    }
}
