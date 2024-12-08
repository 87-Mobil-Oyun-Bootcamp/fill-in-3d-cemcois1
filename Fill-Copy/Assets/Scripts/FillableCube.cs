using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillableCube : MonoBehaviour
{
    public Color SavingColor;
    public System.Action<FillableCube> OnCreated { get; set; }
    public System.Action OnPainted { get; set; }

    private void OnEnable()
    {
        OnCreated += LevelManager.Instance.OnFillableCubeCreated;

        OnCreated?.Invoke(this);
    }
    private void OnDisable()
    {
        OnCreated -= LevelManager.Instance.OnFillableCubeCreated;
    }
    public void Fill()
    {
        this.gameObject.GetComponent<Renderer>().material.color = SavingColor;
        print("Rengi degisti");
        //to do process bar ++
        OnPainted += LevelManager.Instance.OnBlockPainted;
        OnPainted?.Invoke();
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
