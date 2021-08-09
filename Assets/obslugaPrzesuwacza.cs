using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obslugaPrzesuwacza : MonoBehaviour
{
    //  public int coObsluguje;

    public GameObject obiektColliderWe;
    public GameObject obiektColliderWy;
    private void Awake()
    {
        gameObject.GetComponentInParent<Dane>().coObsluguje1 = obslugaBlachy.TypBlachy.wszystko;
    }
    void Update()
    {
        switch (gameObject.GetComponentInParent<Dane>().stan)
        {
            case 0: //czeka
                {
                    if (gameObject.GetComponentInParent<Dane>().pracuj == false && gameObject.GetComponentInParent<Dane>().gotowy == false)
                    {
                        gameObject.GetComponentInParent<Dane>().stan = 5;
                    }
                    else if (gameObject.GetComponentInParent<Dane>().pracuj == false && gameObject.GetComponentInParent<Dane>().gotowy == true)
                    {
                        gameObject.GetComponentInParent<Dane>().stan = 7;
                    }
                    break;
                }
            case 1://weszla blacha wolna
                {
                    if (obiektColliderWy == null)//wy nie jest przesuwaczem
                    {
                        gameObject.GetComponentInParent<Dane>().stan = 4;//
                        break;
                    }
                    else
                    {
                        gameObject.GetComponentInParent<Dane>().stan++;//do 2
                        break;
                    }
                }
            case 2://sprawdz czy poprzednik  przesuwa
                {
                    if (obiektColliderWy.GetComponentInParent<Dane>().stan == 0 && GetComponentInParent<Dane>().gotowy == false)//nie przesuwa
                        gameObject.GetComponentInParent<Dane>().stan = 3;//do przesuwaj
                    break;
                }
            case 3:
                {
                    if (gameObject.GetComponentInParent<obslugaPrzesuwacza>().obiektColliderWy.GetComponentInParent<Dane>().stan == 0 &&
                        gameObject.GetComponentInParent<obslugaPrzesuwacza>().obiektColliderWy.GetComponentInParent<Dane>().gotowy == false)
                    {
                        gameObject.GetComponentInParent<Dane>().manipulowanyObiekt.transform.Translate(this.transform.forward * 1.1f * Time.deltaTime, Space.World);
                    }
                    break;
                }
            case 4://przesuwaj jeśli wy nie pracuje i nie jest gotowe
                {
                    gameObject.GetComponentInParent<Dane>().manipulowanyObiekt.transform.Translate(this.transform.forward * 1.1f * Time.deltaTime, Space.World);
                    if (Vector3.SqrMagnitude(gameObject.GetComponentInParent<Dane>().manipulowanyObiekt.transform.position - gameObject.transform.position) < 1f)
                    {
                        gameObject.GetComponentInParent<Dane>().gotowy = true;
                        gameObject.GetComponentInParent<Dane>().stan = 0;
                    }
                    break;
                }
            case 5:
                {
                    if (gameObject.GetComponentInParent<Dane>().pracuj == true)
                        gameObject.GetComponentInParent<Dane>().stan++;
                    break;
                }
            case 6:
                {
                    if (gameObject.GetComponentInParent<Dane>().pracuj == true && obiektColliderWy == null)
                    {
                        if (gameObject.GetComponentInParent<Dane>().manipulowanyObiekt == null)
                        {
                            gameObject.GetComponentInParent<Dane>().gotowy = false;
                        }
                        else
                        {
                            gameObject.GetComponentInParent<Dane>().gotowy = true;
                        }
                        gameObject.GetComponentInParent<Dane>().stan = 0;
                    }
                    else if (gameObject.GetComponentInParent<Dane>().pracuj == true && obiektColliderWy != null)
                    {
                        gameObject.GetComponentInParent<Dane>().gotowy = false;
                        gameObject.GetComponentInParent<Dane>().stan = 3;
                    }
                    break;
                }
            case 7:
                {
                    if (gameObject.GetComponentInParent<Dane>().pracuj == true)
                    {
                        gameObject.GetComponentInParent<Dane>().gotowy = false;
                        gameObject.GetComponentInParent<Dane>().stan = 0;
                    }
                    break;
                }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "blacha" && collision.gameObject.GetComponent<obslugaBlachy>().domyslnyParent != collision.gameObject.transform.parent)
        {
            gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = collision.gameObject.GetComponentInParent<Dane>().manipulowanyObiekt;
            collision.gameObject.transform.parent.GetComponentInParent<Dane>().manipulowanyObiekt = null;
            collision.gameObject.transform.parent.GetComponentInParent<Dane>().stan++;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.gameObject.GetComponentInParent<Dane>().transform.SetParent(collision.gameObject.GetComponent<obslugaBlachy>().domyslnyParent);

            gameObject.GetComponentInParent<Dane>().stan = 6;
        }
        // blacha wolna weszla
        else if (collision.gameObject.tag.Equals("blacha") && collision.gameObject.GetComponent<obslugaBlachy>().domyslnyParent == collision.gameObject.transform.parent)//nic nie ma na wejsciu
        {
            GameObject blacha = gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = collision.gameObject;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponentInParent<Dane>().stan = 1;
        }
        else
            if (collision.gameObject.tag == "przekladacz")
        {
            gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = collision.gameObject.GetComponentInParent<Dane>().manipulowanyObiekt;
            collision.gameObject.transform.SetParent(collision.gameObject.GetComponentInParent<obslugaBlachy>().domyslnyParent);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("blacha"))
        {
            gameObject.GetComponentInParent<Dane>().gotowy = false;
            gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = null;
            gameObject.GetComponentInParent<Dane>().stan = 0;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "blacha")
        {
            gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = collision.gameObject;
        }
    }

}
