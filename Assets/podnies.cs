using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podnies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        /*
         //  if(GetComponentInParent<ObslugaPrzekladacza>().przenoszonyObiekt.GetComponentInChildren<Collider>().)
         // Tutaj kod wykonywany po wejściu w obszar
         if (other.gameObject.tag.Equals("blacha") && other.GetComponentInParent<obslugaBlachy>().podnies == true)//&&podnosi==false)// && gameObject.GetComponentInParent<ObslugaPrzekladacza>().wyjscie.Equals(false))
         {
             // podnosi = true;
             other.gameObject.transform.SetParent(this.gameObject.GetComponentInParent<Transform>().transform);
             other.gameObject.GetComponent<Rigidbody>().useGravity = false;
             //   other.gameObject.GetComponent<BoxCollider>().enabled = false;


             //  this.GetComponentInParent<ObslugaPrzekladacza>().stan = 1;

             this.gameObject.GetComponentInParent<Animator>().SetFloat("Speed", -1);
             this.gameObject.GetComponentInParent<Animator>().speed = 1;
             this.GetComponentInParent<ObslugaPrzekladacza>().przenoszonyObiekt = other.gameObject;
             Physics.IgnoreCollision(this.GetComponentInParent<ObslugaPrzekladacza>().glownyCollider, other, true);
         }
         else if (other.gameObject.tag.Equals("blacha") && other.GetComponentInParent<obslugaBlachy>().podnies == false)
         {
             this.gameObject.GetComponentInParent<Animator>().SetFloat("Speed", -1);
             this.gameObject.GetComponentInParent<Animator>().speed = 1;
             this.GetComponentInParent<ObslugaPrzekladacza>().przenoszonyObiekt = null;

             Physics.IgnoreCollision(this.GetComponentInParent<ObslugaPrzekladacza>().glownyCollider, other, false);




         }
         */

        //przyklejanie
        // || (other.gameObject.tag.Equals("paletaZBlachami")) || (other.gameObject.tag.Equals("paletaOdbiorcza"))
        if ((other.gameObject.tag.Equals("blacha")) && GetComponentInParent<Dane>().stan == 3)//&&other.gameObject!=gameObject.GetComponentInParent<Dane>().manipulowanyObiekt)
        {
            if (other.gameObject.GetComponent<Dane>().GetComponentInParent<MeshRenderer>().enabled == false)
            {
                other.gameObject.gameObject.GetComponentInParent<MeshRenderer>().enabled = true;
            }
            //     gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = other.gameObject;

            //  Physics.IgnoreCollision(this.GetComponentInParent<ObslugaPrzekladacza1>().glownyCollider, other, true);
            other.gameObject.transform.SetParent(this.gameObject.GetComponentInParent<Transform>().transform);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

               gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = other.gameObject;
            gameObject.GetComponentInParent<Dane>().stan++;
            //   other.gameObject.GetComponent<BoxCollider>().enabled = false;
            //  other.attachedRigidbody.isKinematic = true;

        }
        //puszczanie
        else if (other.gameObject.tag.Equals("blacha") && (GetComponentInParent<Dane>().stan == 9 || GetComponentInParent<Dane>().stan == 10) )//&& other.gameObject!= gameObject.GetComponentInParent<Dane>().manipulowanyObiekt) //to chyba nie potrzebne
        {
            //          gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = null;
            //this.GetComponentInParent<ObslugaPrzekladacza1>().przenoszonyObiekt = null;
            //   Physics.IgnoreCollision(this.GetComponentInParent<ObslugaPrzekladacza1>().glownyCollider, other, false);
            gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = null;
           other.gameObject.transform.SetParent(other.GetComponentInParent<obslugaBlachy>().domyslnyParent);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponentInParent<Dane>().stan++;
        }
    else if (other.tag == "paletaOdbiorcza" )//&& gameObject.GetComponentInParent<Dane>().manipulowanyObiekt != null)
        {
            gameObject.GetComponentInParent<Dane>().manipulowanyObiekt.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponentInParent<Dane>().manipulowanyObiekt.transform.SetParent(other.gameObject.transform);
            gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = null;
           
            gameObject.GetComponentInParent<Dane>().stan++;
            //         gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = null;
            //           gameObject.GetComponentInParent<Dane>().stan++;
            //      other.gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = gameObject.GetComponentInParent<Dane>().manipulowanyObiekt;
        }
       
        // gameObject.GetComponentInParent<Dane>().stan++;
        else { }

        Vector3 n = new Vector3();


        /*    else if (other.gameObject.tag.Equals("blacha") && podnosi == true)// && gameObject.GetComponentInParent<ObslugaPrzekladacza>().wyjscie.Equals(false))
            {
                this.gameObject.GetComponentInParent<Animator>().SetFloat("Speed", -1);
                this.gameObject.GetComponentInParent<Animator>().speed = 1;
                this.GetComponentInParent<ObslugaPrzekladacza>().przenoszonyObiekt = other.gameObject;

                    podnosi = false;
                    other.gameObject.transform.SetParent(this.gameObject.GetComponentInParent<Transform>().transform);
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    //   other.gameObject.GetComponent<BoxCollider>().enabled = false;


                    this.GetComponentInParent<ObslugaPrzekladacza>().stan = 1;

                    this.gameObject.GetComponentInParent<Animator>().SetFloat("Speed", -1);
                    this.gameObject.GetComponentInParent<Animator>().speed = 1;
                    this.GetComponentInParent<ObslugaPrzekladacza>().przenoszonyObiekt = other.gameObject;
            }
            */





    }

}
