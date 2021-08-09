using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static obslugaBlachy;

public class Dane : MonoBehaviour
{
    public bool gotowy;
    public bool pracuj;
    public GameObject manipulowanyObiekt;
    public GameObject root;
    public int stan;

    public TypBlachy coObsluguje1;
    public TypBlachy coObsluguje2;
    public TypBlachy coObsluguje3;
    public bool zajety;

    private void Awake()
    {
        pracuj = true;
        root = this.gameObject;
    }
    public void Pracuj(bool pracuj)
    {
        this.pracuj = pracuj;
    }
}
