using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillableCube : MonoBehaviour
{
    public Color SavingColor;

    public void Fill()
    {
        this.gameObject.GetComponent<Renderer>().material.color = SavingColor;
        print("Rengi degisti");
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
