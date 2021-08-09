using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static obslugaBlachy;

public class obslugaWygniatarki : MonoBehaviour
{
    public Material[] textures;
    public int currentText;
    private Object[] texturess;
    Animator animator;
    public TypBlachy wCoPrzeksztalcic;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(wCoPrzeksztalcic==TypBlachy.wszystko) wCoPrzeksztalcic = TypBlachy.wygietaDolna;
       // gameObject.GetComponentInParent<Dane>().coObsluguje=
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameObject.GetComponent<Dane>().stan)
        {
            case 0:
                {
                    //triggerem wychodz z 1
                    break;
                }
            case 1:
                {

                    if (((gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponent<obslugaBlachy>().typ== TypBlachy.wycietaWaska|| gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponent<obslugaBlachy>().typ == TypBlachy.wygietaDolna) && (gameObject.GetComponent<obslugaWygniatarki>().wCoPrzeksztalcic==TypBlachy.wygietaGorna))||
                        ((gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponent<obslugaBlachy>().typ == TypBlachy.wycietaSzeroka|| gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponent<obslugaBlachy>().typ == TypBlachy.wygietaGorna) && gameObject.GetComponent<obslugaWygniatarki>().wCoPrzeksztalcic == TypBlachy.wygietaDolna)  
                        )
                    {
                        gameObject.GetComponent<Dane>().stan = 3;
                    }
                    if (gameObject.GetComponentInParent<Dane>().pracuj == true)
                    {
                        gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        animator.SetBool("pracuje", true); }
                    break;
                }
            case 2:
                {
                    GetComponent<Dane>().gotowy = !GetComponent<Dane>().gotowy;
                    gameObject.GetComponent<Dane>().stan = 0;
                    //     gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;

                    //     GetComponent<Dane>().gotowy = !GetComponent<Dane>().gotowy;
                    //      gameObject.GetComponent<Dane>().stan = 0;
                    break;
                }
            case 3:  //wyswietlanie bledu
                {
                    string wejscie=null;
                    TypBlachy wCoPrzeksztalcic = gameObject.GetComponent<obslugaWygniatarki>().wCoPrzeksztalcic;
                    if (wCoPrzeksztalcic == TypBlachy.wygietaGorna)
                    {
                        wejscie = TypBlachy.wycietaSzeroka.ToString();
                    }
                     else if  (wCoPrzeksztalcic == TypBlachy.wygietaDolna)
                    {
                        wejscie = TypBlachy.wycietaWaska.ToString();
                    }
                    

                    gameObject.GetComponentInChildren<skryptTekstu>().WyswietlTekst("Ta wygniatarka wymaga na wejsciu: "
                          + gameObject.GetComponentInParent<obslugaWygniatarki>().wCoPrzeksztalcic.ToString() + "\n a otrzymała: "
                        + wejscie);
                    break;
                }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "blacha")
        {
            gameObject.GetComponentInParent<Dane>().gotowy = false;
            other.gameObject.GetComponentInParent<obslugaBlachy>().typ = wCoPrzeksztalcic;
          

        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "blacha" && other.GetComponentInParent<obslugaBlachy>().domyslnyParent != other.transform.parent && gameObject.GetComponent<Dane>().stan == 0&&gameObject.GetComponent<Dane>().gotowy==false)//||other.tag=="blacha")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.transform.parent.GetComponentInParent<Dane>().stan++;
            GetComponentInParent<Dane>().manipulowanyObiekt = other.gameObject;
          //  other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.SetParent(other.GetComponentInParent<obslugaBlachy>().domyslnyParent);

            //niewidzialna  blacha
            //    other.GetComponentInParent<MeshRenderer>().enabled = false;
            //zmiana mesha
            //       gameObject.GetComponentInParent<Dane>().manipulowanyObiekt.gameObject.GetComponent<MeshFilter>().sharedMesh = other.gameObject.GetComponent<obslugaBlachy>().meshe[1].sharedMesh;


            //belka cofa sie


            //zmiana tekstury na blache
            //         gameObject.GetComponent<SkinnedMeshRenderer>().material = textures[1];

            ///wlaczenie animacji
            ///
        //    gameObject.GetComponentInChildren<skryptTekstu>().WyswietlTekst("Ta wygniatarka wymaga na wejsciu: ");
      //      if (gameObject.GetComponentInParent<obslugaWygniatarki>().wCoPrzeksztalcic!= other.gameObject.GetComponentInParent<obslugaBlachy>().typ)
        //    {
     //           gameObject.GetComponentInChildren<skryptTekstu>().WyswietlTekst("Ta wygniatarka wymaga na wejsciu: ");
              /*      + gameObject.GetComponentInParent<obslugaWygniatarki>().wCoPrzeksztalcic.ToString()+"\n a otrzymała: " 
                    + other.gameObject.GetComponentInParent<obslugaBlachy>().typ.ToString());*/
       //     }
      //    else
        //    {
                gameObject.GetComponent<Dane>().stan = 1;
       //     }
          
        }

        //przekladacz wrocil a na wycinarce stan 0 gotowy
        else if (other.tag == "przekladacz" && gameObject.GetComponent<Dane>().stan == 0 && gameObject.GetComponent<Dane>().gotowy)//||other.tag=="blacha"))
        {
            gameObject.GetComponent<Dane>().gotowy = false;
     //       gameObject.GetComponent<SkinnedMeshRenderer>().material = textures[0];
    //        gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponentInParent<MeshRenderer>().enabled = true;


        }

        

    }


    public void podmienMesh()
    {
        //gameObject.GetComponent<Dane>().manipulowanyObiekt.
        GameObject blacha = gameObject.GetComponent<Dane>().manipulowanyObiekt;
      //  blacha.gameObject.GetComponent<MeshFilter>().sharedMesh = blacha.gameObject.GetComponent<obslugaBlachy>().meshe[3].sharedMesh;

        if (wCoPrzeksztalcic == TypBlachy.wygietaDolna)

            blacha.gameObject.GetComponent<MeshFilter>().sharedMesh = blacha.gameObject.GetComponent<obslugaBlachy>().meshe[3].sharedMesh;
        else if (wCoPrzeksztalcic == TypBlachy.wygietaGorna)
            blacha.gameObject.GetComponent<MeshFilter>().sharedMesh = blacha.gameObject.GetComponent<obslugaBlachy>().meshe[4].sharedMesh;
        else; //tu dac tekstownik ze zly typ blachy na wyjscie

    }

    public void koniecAnimacji()
    {
        gameObject.GetComponentInParent<Dane>().stan = 2;
        gameObject.GetComponent<Dane>().manipulowanyObiekt.GetComponent<Rigidbody>().isKinematic = true;

        //kasowanie collidera i tworzenie nowego, bo poprzedni był cienki
        BoxCollider bc = gameObject.GetComponent<Dane>().manipulowanyObiekt.GetComponent<BoxCollider>();
        Destroy(bc);
        bc=gameObject.GetComponent<Dane>().manipulowanyObiekt.AddComponent<BoxCollider>() as BoxCollider;
        animator.SetBool("pracuje", false);
    }


}
