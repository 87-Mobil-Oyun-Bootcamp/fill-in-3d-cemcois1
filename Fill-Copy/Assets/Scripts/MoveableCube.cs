using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableCube : MonoBehaviour
{
    public Action<MoveableCube> OnCreated { get; private set; }

    // Start is called before the first frame update
    private void OnEnable()
    {
        OnCreated += LevelManager.Instance.OnMoveableCubeCreated;

        OnCreated?.Invoke(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            other.GetComponent<FillableCube>().Fill();
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
        }

    }
    private void OnDisable()
    {

    }
}
