using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static obslugaBlachy;

public class ObslugaWycinarki : MonoBehaviour
{
    public Material[] textures;
    public int currentText;
    private Object[] texturess;
    Animator animator;
    // Start is called before the first frame update
    public TypBlachy wCoPrzeksztalcic;
    void Start()
    {
        animator = GetComponent<Animator>();
        if (wCoPrzeksztalcic == TypBlachy.wszystko) wCoPrzeksztalcic = TypBlachy.wycietaWaska;
    }

    // Update is called once per frame
    void Update()
    {














        switch(gameObject.GetComponent<Dane>().stan)
        {
            case 0:
                {

                    if (gameObject.GetComponentInParent<Dane>().pracuj == false && gameObject.GetComponentInParent<Dane>().gotowy == false)
                    {
                        gameObject.GetComponentInParent<Dane>().stan++;
                    }
                    if (GetComponent<Dane>().pracuj == false && gameObject.GetComponentInParent<Dane>().gotowy == true)
                    {
                       // gameObject.GetComponentInParent<Dane>().gotowy = false;
                    }
                        if (GetComponent<Dane>().pracuj == true && gameObject.GetComponentInParent<Dane>().gotowy == true)
                    {
                    //    stan = 6;
                   //     gameObject.GetComponentInParent<Dane>().gotowy = false;
                   //     GetComponentInParent<Dane>().manipulowanyObiekt = null;

                        //  gameObject.GetComponent<Dane>().gotowy = false;
                       // gameObject.GetComponent<Dane>().stan = 0;
                    }

                    /*     else if (gameObject.GetComponentInParent<Dane>().pracuj == false && gameObject.GetComponentInParent<Dane>().gotowy == true)
                         {
                             gameObject.GetComponentInParent<Dane>().stan = 7;
                         }*/

                    //triggerem wychodz z 1
                    break;
                }
            case 1:
                {
              //trigger blacha -> 2
              //trigger przekładacz ->7
                    break;
                }
                case  2:
                {

                    if (GetComponent<Dane>().pracuj==true)
                    {
                        gameObject.GetComponent<Dane>().stan++;
                    }

                    break;
                  
                }
            case 3:
                {
                    ///wlaczenie animacji
                    animator.SetBool("pracuje", true);
                 //   zmienTeksture(1);
                    //   gameObject.GetComponent<Dane>().stan = 2;
                    break;
                }
            case 4:
                {
                    break;
                }
            case 5:
                {
                    gameObject.GetComponent<Dane>().gotowy = true;
                    gameObject.GetComponent<Dane>().stan = 0;


                    /* gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
                   //gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponentInParent<obslugaBlachy>().typ = obslugaBlachy.TypBlachy.wycietaSzeroka;
                    GetComponent<Dane>().gotowy = true;
                    gameObject.GetComponent<Dane>().stan = 0;
                    break;*/
                    break;
                }
            case 6:
                {
                    if (GetComponent<Dane>().pracuj == true)
                    {
                        gameObject.GetComponentInParent<Dane>().gotowy = false;
                        GetComponentInParent<Dane>().manipulowanyObiekt = null;
                        
                      //  gameObject.GetComponent<Dane>().gotowy = false;
                        gameObject.GetComponent<Dane>().stan=0;
                    }
                    break;
                }

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "blacha")  
        {
            gameObject.GetComponentInParent<Dane>().gotowy = false;
            gameObject.GetComponentInParent<Dane>().pracuj = true;
            //    animator.SetBool("pracuje", false);
            //  gameObject.GetComponent<Dane>().stan = 6;
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        //puszczanie
        if (other.tag == "blacha" && other.transform.parent!=null && gameObject.GetComponent<Dane>().stan == 1) //&& gameObject.GetComponent<Dane>().gotowy == false)//||other.tag=="blacha")
        {
            other.gameObject.transform.parent.GetComponentInParent<Dane>().stan++;
         
            GetComponentInParent<Dane>().manipulowanyObiekt = other.gameObject;

other.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            // usuwanie parenta
            other.gameObject.transform.SetParent(other.GetComponentInParent<obslugaBlachy>().domyslnyParent);

            //niewidzialna  blacha
            other.GetComponentInParent<MeshRenderer>().enabled = false;
            //zmiana mesha
            if (wCoPrzeksztalcic == TypBlachy.wycietaSzeroka)

                gameObject.GetComponentInParent<Dane>().manipulowanyObiekt.gameObject.GetComponent<MeshFilter>().sharedMesh = other.gameObject.GetComponent<obslugaBlachy>().meshe[1].sharedMesh;
            else if (wCoPrzeksztalcic == TypBlachy.wycietaWaska)
                gameObject.GetComponentInParent<Dane>().manipulowanyObiekt.gameObject.GetComponent<MeshFilter>().sharedMesh = other.gameObject.GetComponent<obslugaBlachy>().meshe[2].sharedMesh;
            else; //tu dac tekstownik ze zly typ blachy na wyjscie

            //belka cofa sie


            //zmiana tekstury na blache
            zmienTeksture(1);
            gameObject.GetComponent<Dane>().stan  ++;//2

        }

        //przekladacz wrocil a na wycinarce stan 0 gotowy
        else if(other.tag == "przekladacz"  && gameObject.GetComponent<Dane>().stan == 1&& gameObject.GetComponent<Dane>().gotowy ==true)//||other.tag=="blacha"))
        {
            gameObject.GetComponent<Dane>().gotowy = false;
         //   zmienTeksture(0);
          

            gameObject.GetComponent<Dane>().stan = 6;
        }


        }
    public void zmienTeksture(int ktora)
    {
        GetComponent<SkinnedMeshRenderer>().material = textures[ktora];


    }
    public void koniecAnimacji()
    {
       
        animator.SetBool("pracuje", false);
        //   GetComponent<Dane>().stan = 6;
       gameObject.GetComponentInParent<Dane>().manipulowanyObiekt. gameObject.GetComponentInParent<obslugaBlachy>().typ = wCoPrzeksztalcic;
        gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponentInParent<MeshRenderer>().enabled = true;
        zmienTeksture(0);
        gameObject.GetComponent<Dane>().manipulowanyObiekt.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Dane>().stan = 5;

    }
}
