using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public Factory factory;
    public GameObject smallBullet;
    public GameObject largeBullet;
    // Start is called before the first frame update
    void Awake()
    {

    }

    public GameObject CreateBullet(string type)
    {
        if (type == "small")
        {
            return smallBullet;
        }

        if (type == "large")
        {
            return largeBullet;
        }

        return smallBullet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
