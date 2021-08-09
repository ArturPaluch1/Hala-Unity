using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obslugaPaletyOdbierajacej : MonoBehaviour
{
    public int iloscElementow;
    void Awake()
    {
        gameObject.GetComponent<Dane>().manipulowanyObiekt = this.gameObject;
    }
    void Start()
    {
        iloscElementow = 0;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "blacha" && 
            other.gameObject.GetComponent<obslugaBlachy>().domyslnyParent 
            != other.gameObject.transform.parent)
        {
            iloscElementow++;
            if (iloscElementow == 5)
            {
                gameObject.GetComponent<Dane>().gotowy = true;
                other.gameObject.transform.parent.GetComponentInParent<Dane>().manipulowanyObiekt = null;
                other.gameObject.transform.parent.GetComponentInParent<Dane>().stan++;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                other.gameObject.GetComponentInParent<Dane>().transform.SetParent(gameObject.transform);
            }
        }
    }
}