using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static obslugaBlachy;

public class obslugaSpawarki : MonoBehaviour
{
    //public Material[] textures;
    //  public int currentText;
    //   private Object[] texturess;
    public GameObject drzwi;
    Animator animator;
    // Start is called before the first frame update
    // public TypBlachy wymaganeWejscie;
    GameObject blachaDolna;
    GameObject blachaGorna;

    void Start()
    {
     //   wymaganeWejscie = TypBlachy.wygietaDolna;
        animator = GetComponent<Animator>();
        gameObject.GetComponentInParent<Dane>().coObsluguje1 = TypBlachy.wygietaDolna;
        gameObject.GetComponentInParent<Dane>().coObsluguje2 = TypBlachy.wygietaDolna;
        gameObject.GetComponentInParent<Dane>().coObsluguje3 = TypBlachy.wygietaDolna;
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
                {//jeśli przekladacz wyszedł 
            /*        if (gameObject.GetComponentInParent<Dane>().pracuj == true)
                    {
                        GetComponent<Dane>().gotowy = !GetComponent<Dane>().gotowy;
                        gameObject.GetComponent<Dane>().stan = 0;
                    }*/
                    break;
                }
            case 2:
                {
                    if (gameObject.GetComponentInParent<Dane>().pracuj == true)
                    {
                        if (gameObject.GetComponentInParent<Dane>().coObsluguje1 == TypBlachy.wygietaGorna)
                        {
                            gameObject.GetComponentInParent<Dane>().gotowy = false;
                            gameObject.GetComponentInParent<Dane>().stan=0;

                        }
                        else
                        {
                            gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            animator.SetBool("pracuje", true);
                        }

                    
                       
                    }
                    //     gameObject.GetComponent<Dane>().manipulowanyObiekt.gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;

                    //     GetComponent<Dane>().gotowy = !GetComponent<Dane>().gotowy;
                    //      gameObject.GetComponent<Dane>().stan = 0;
                    break;
                }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "blacha")
        {
            gameObject.GetComponentInParent<Dane>().gotowy = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        //weszła blaacha z parentem nie jej
        if (other.tag == "blacha" && other.GetComponentInParent<obslugaBlachy>().domyslnyParent != other.transform.parent && gameObject.GetComponent<Dane>().stan == 0 && gameObject.GetComponent<Dane>().gotowy == false)//||other.tag=="blacha")
        {


            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.transform.parent.GetComponentInParent<Dane>().stan++;
            GetComponentInParent<Dane>().manipulowanyObiekt = other.gameObject;
            other.gameObject.transform.SetParent(null);


            //zmiana wymaganej kolejnej blachy
            if(gameObject.GetComponentInParent<Dane>().coObsluguje1==TypBlachy.wygietaGorna)
            {
                blachaGorna = other.gameObject;
                gameObject.GetComponentInParent<Dane>().coObsluguje1 = TypBlachy.wygietaDolna;
                gameObject.GetComponentInParent<Dane>().coObsluguje2 = TypBlachy.wygietaDolna;
                gameObject.GetComponentInParent<Dane>().coObsluguje3 = TypBlachy.wygietaDolna;
                gameObject.GetComponentInParent<Dane>().gotowy = false;

                
            }
            else
            {
                blachaDolna = other.gameObject;
                gameObject.GetComponentInParent<Dane>().coObsluguje1 = TypBlachy.wygietaGorna;
                gameObject.GetComponentInParent<Dane>().coObsluguje2 = TypBlachy.wygietaGorna;
                gameObject.GetComponentInParent<Dane>().coObsluguje3 = TypBlachy.wygietaGorna;
               // gameObject.GetComponentInParent<Dane>().gotowy = true;
            }
            gameObject.GetComponent<Dane>().stan = 2;


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
        blacha.gameObject.GetComponent<MeshFilter>().sharedMesh = blacha.gameObject.GetComponent<obslugaBlachy>().meshe[3].sharedMesh;
    }

    public void koniecAnimacji()
    {

        Vector3 polozenieDolnejBlachy = blachaDolna.transform.position;
        Quaternion rotacjaDolnejBlachy = blachaDolna.transform.rotation;
        Destroy(blachaGorna.gameObject);
        Destroy(blachaDolna.gameObject);
       GameObject noweDrzwi= Instantiate(drzwi, polozenieDolnejBlachy, rotacjaDolnejBlachy);
        gameObject.GetComponentInParent<Dane>().manipulowanyObiekt = noweDrzwi;
            noweDrzwi.GetComponent<Rigidbody>().isKinematic = true;
        noweDrzwi.transform.rotation.SetEulerAngles(0f,noweDrzwi.transform.rotation.y,0f);


        //kasowanie collidera i tworzenie nowego, bo poprzedni był cienki
        /*blachaDolna.gameObject.GetComponent<MeshFilter>().sharedMesh = blachaDolna.gameObject.GetComponent<obslugaBlachy>().meshe[5].sharedMesh;
        BoxCollider bc = gameObject.GetComponent<Dane>().manipulowanyObiekt.GetComponent<BoxCollider>();
        Destroy(bc);
        bc = gameObject.GetComponent<Dane>().manipulowanyObiekt.AddComponent<BoxCollider>() as BoxCollider;*/

        animator.SetBool("pracuje", false);
        
        gameObject.GetComponentInParent<Dane>().stan = 0;
        gameObject.GetComponentInParent<Dane>().gotowy = true;
    }


}
