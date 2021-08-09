using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obslugaBlachy : MonoBehaviour
{
    public Transform domyslnyParent;
    public TypBlachy typ;
    public List<MeshFilter> meshe;
    public enum TypBlachy
    {
        wszystko,
        blacha,
        wycietaWaska,
        wycietaSzeroka,
        wygietaDolna,
        wygietaGorna,
        drzwi
    }

    void Start()
    {
        domyslnyParent = this.transform.parent;
        typ = TypBlachy.blacha;
    }
}
