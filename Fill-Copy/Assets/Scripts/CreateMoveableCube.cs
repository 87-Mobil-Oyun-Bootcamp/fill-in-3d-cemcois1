using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMoveableCube : MonoBehaviour
{
    public GameObject moveableCube;
    void Start()
    {
        for (int x = 0; x < 16; x++)
        {
            for (int j = 0; j < 16; j++)
            {
                Instantiate(moveableCube, transform.position + new Vector3(x * 3, 0, j*3), Quaternion.identity, transform);

            }

        }
    }

}
