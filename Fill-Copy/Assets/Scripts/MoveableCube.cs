using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableCube : MonoBehaviour
{
    public Action<MoveableCube> OnCreated { get; private set; }

    // Start is called before the first frame update
    public Vector3 Startposition = Vector3.zero;
    private void OnEnable()
    {
        OnCreated += LevelManager.Instance.OnMoveableCubeCreated;
        OnCreated?.Invoke(this);

        Startposition = transform.position;
    }
    private void OnDisable()
    {
        OnCreated -= LevelManager.Instance.OnMoveableCubeCreated;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            other.GetComponent<FillableCube>().Fill();
            gameObject.SetActive(false);
        }

    }


}
