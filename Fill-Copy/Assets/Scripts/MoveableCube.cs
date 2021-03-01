using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            other.GetComponent<FillableCube>().Fill();
            // to do move t
            Destroy(gameObject);
        }

    }
}
