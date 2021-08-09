using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class skryptTekstu : MonoBehaviour
{


    TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponentInParent<TextMeshPro>();
        //    GetComponentInParent<RectTransform>().position.x =0;
        //   textMeshPro. rectTransform.pivot.x = this.gameObject.transform.position.x;
       // textMeshPro.text = "tekst";
    }

    //    yield return null;
   

    // Update is called once per frame
    void Update()
    {
        /*   if (GetComponentInParent<Dane>().ColObjWe == null)
           {
               string g = "hhh;";
               g = g + "jj";
             g=  this.gameObject.transform.parent.ToString();
         g=      GetComponentInParent<TextMesh>().text = "brak wejscia w"+g ;


           }*/
        //    if (GetComponentInParent<Dane>().ColObjWe == null)
        //      {
        //  string g = "hhh;";
        //     g = g + "jj";
        // g = this.gameObject.transform.parent.ToString();
        //  g = 
        //  textMeshPro.text = "  < mark =#ffff00aa>brak wejscia w</mark> " + this.gameObject.transform.parent.ToString();
        //   string h="";



        Quaternion kamera = GameObject.FindWithTag("MainCamera").transform.rotation;
        textMeshPro.transform.rotation = kamera;
    }

    public void WyswietlTekst(string tekst)
    {

      
            textMeshPro.text = tekst;
     
        //textMeshPro.tes
        textMeshPro.color = Color.red;

        // textMeshPro.text = " < size = 30 > Some < color = yellow > RICH </ color > text </ size >" + this.gameObject.transform.parent.ToString();

        //   < mark =#ffff00aa>can be marked with</mark> 
        //   textMeshPro.tag.
        //   Quaternion kamera = Quaternion.LookRotation(GameObject.FindWithTag("MainCamera").transform.position - textMeshPro.rectTransform.position);
        //     textMeshPro.rectTransform.rotation = Quaternion.Slerp(textMeshPro.rectTransform.rotation, kamera, 0f);

        // textMeshPro.rectTransform.rotation =

        //   textMeshPro.rectTransform.localRotation =

      
        //    kamera.
        //   kamera.x = textMeshPro.transform.rotation.x;
       // GameObject.FindWithTag("MainCamera").transform.rotation;
                                                //    textMeshPro.transform.rotation.SetAxisAngle(,textMeshPro.transform.rotation.x - 90f);
                                                //    textMeshPro.transform.position.x = gameObject.transform.position.x + 1;
                                      //         yield return null;            
    }
}
