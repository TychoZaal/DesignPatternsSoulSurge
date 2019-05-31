using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleInactive : MonoBehaviour
{
    public bool needsToReset = false;

    // Update is called once per frame
    void Update()
    {
        if (needsToReset)
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);
        needsToReset = false;
        gameObject.SetActive(false);
    }
}
