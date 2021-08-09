using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obslugaStertyBlach : MonoBehaviour
{
    public int iloscBlach;
    void Awake()
    {
        gameObject.GetComponent<Dane>().manipulowanyObiekt = gameObject.transform.GetChild(1).gameObject;
    }
    void Start()
    {
        iloscBlach = gameObject.transform.childCount - 1;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "przekladacz")
        {
            iloscBlach--;
            if (iloscBlach == 0)
            { gameObject.GetComponent<Dane>().gotowy = false; }
           
            
        }
    }
}