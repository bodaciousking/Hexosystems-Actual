using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hextile : MonoBehaviour
{
    public Vector2 tileLocation;

    public bool isCity;
    public GameObject myCity;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (isCity)
        {
            myCity.SetActive(true);
        }
    }

}
