using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static Dane;

public class ObslugaPrzekladacza1 : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject we1;
    public GameObject wy1;

    public GameObject we2;
    public GameObject wy2;

    public GameObject we3;
    public GameObject wy3;

    
    public Animator animator;
   
    

    public int coObsluguje;

    

    private Quaternion target2;

    public Vector3 domyslnePionowo;
    public Vector3 zapamietanePoziomo;
    public Vector3 zapamietanePionowo;
    public Transform domyslnePaletka;



    Vector3 roznicaPaletkaPoziomo;
    Vector3 roznicaPletkaPionowo;
   
    Component item;
   public List<GameObject> listaObiektowWZasiegu;

   public Przejscie znalezionePrzejscie;
 




    public float katWe;
    public float katWy;



    public List<Przejscie> listaWejsc;


    public class Przejscie
    {
        public GameObject we;
        public GameObject wy;

        //   public int wewy;

        public Przejscie(GameObject we, GameObject wy)
        {
            this.we = we;
            this.wy = wy;
        }

    }
    
    private void Awake()
    {
        listaObiektowWZasiegu = new List<GameObject>();

        listaWejsc = new List<Przejscie>();
    }
    void Start()
    {
        Przejscie przejscie1 = new Przejscie(this.we1, wy1);
        Przejscie przejscie2 = new Przejscie(this.we2, wy2);
        Przejscie przejscie3 = new Przejscie(we3, wy3);
        listaWejsc.Add(przejscie1);
        listaWejsc.Add(przejscie2);
        listaWejsc.Add(przejscie3);



        domyslnePaletka = znajdzComponent("paletka").transform;
        zapamietanePoziomo = znajdzComponent("poziomo").transform.position;
        domyslnePionowo = znajdzComponent("pionowo").transform.position;
        animator = gameObject.GetComponent<Animator>();

        
       

    }

    // Update is called once per frame
    void Update()
    {

        switch (this.GetComponentInParent<Dane>().stan)
        {
            //idle
            case 0:
                {
                    //   Przejscie 
                    znalezionePrzejscie = sprawdzWarunki();

                    if (znalezionePrzejscie != null)
                    {
                        if (znalezionePrzejscie.we.GetComponentInParent<Dane>().zajety == false)
                        {
                            znalezionePrzejscie.we.GetComponentInParent<Dane>().zajety = true;
                            //  zwiekszKolejkePrzeplywu(znalezionePrzejscie);


                            item = znajdzComponent("obrot");
                            GameObject obiekt = znalezionePrzejscie.we.GetComponentInParent<Dane>().manipulowanyObiekt;

                            Vector3 a = item.transform.position;
                            Vector3 b = obiekt.transform.position;
                            Vector3 c = znalezionePrzejscie.wy.transform.position;

                            float AngleRad = Mathf.Atan2(c.x - item.transform.position.x, c.z - item.transform.position.z);
                            float AngleDeg = (180 / Mathf.PI) * AngleRad;

                            float AngleRad1 = Mathf.Atan2(obiekt.transform.position.x - item.transform.position.x, obiekt.transform.position.z - item.transform.position.z);
                            float AngleDeg1 = (180 / Mathf.PI) * AngleRad1;
                            katWy = AngleDeg;
                            katWe = AngleDeg1;



                            GetComponentInParent<Dane>().stan++;
                        }
                    }
                    //                         
                    break;
                }
            //obroc na we
            case 1:
                {
                    znalezionePrzejscie.we.SendMessage("Pracuj", false);


                    Obroc(znalezionePrzejscie.we.GetComponentInParent<Dane>().manipulowanyObiekt, katWe);

                    break;
                }
            //wysun
            case 2:
                {

                    Wysun(znalezionePrzejscie.we.GetComponentInParent<Dane>().manipulowanyObiekt);
                    break;
                }
            //obniż
            case 3:
                {
                    Obniz(znalezionePrzejscie.we.GetComponentInParent<Dane>().manipulowanyObiekt);


                    break;
                }
            //podnieś
            case 4:
                {
                    //tutaj przyklej obiekt
                    Podnies();
                    Debug.Log("yyyyyyyyyyyyy");
                    break;
                }

            //cofnij
            case 5:
                {

                    Cofnij(znalezionePrzejscie.we.GetComponentInParent<Dane>().manipulowanyObiekt);
                    break;
                }


            case 6:
                {
                    znalezionePrzejscie.we.SendMessage("Pracuj", true);
                    znalezionePrzejscie.we.GetComponentInParent<Dane>().zajety = false;
                    Obroc(znalezionePrzejscie.wy, katWy);

                    //  Obroc(GetComponentInParent<Dane>().root, obrotPow);
                    //    Obroc(kolejkaPrzejsc.Peek().we, 0);
                    break;
                }

            //obróć na wy
            case 7:
                {
                    znalezionePrzejscie.wy.SendMessage("Pracuj", false);

                    Component paletka = znajdzComponent("paletka");
                    Component obrot = znajdzComponent("obrot");

                    Quaternion tempItem = paletka.transform.rotation;
                    tempItem.x = -tempItem.x;
                    tempItem.y = -tempItem.y;
                    tempItem.z = -tempItem.z;
                    tempItem.w = -tempItem.w;

                    paletka.transform.GetChild(1).gameObject.transform.rotation = Quaternion.Lerp(paletka.transform.transform.GetChild(1).gameObject.transform.rotation,
                                         znalezionePrzejscie.wy.transform.rotation, 3f * Time.deltaTime);
                    Quaternion r = znalezionePrzejscie.wy.transform.rotation;
                    tempItem = r;
                    tempItem.Set(-r.x, -r.y, -r.z, -r.w);




                    if (paletka.transform.transform.GetChild(1).gameObject.transform.rotation == znalezionePrzejscie.wy.transform.rotation || (paletka.transform.transform.GetChild(1).gameObject.transform.rotation == tempItem))
                    {
                        zapamietanePoziomo = znajdzComponent("poziomo").transform.position;
                        roznicaPaletkaPoziomo = znajdzComponent("paletka").transform.position - zapamietanePoziomo;
                        GetComponentInParent<Dane>().stan++;
                        break;
                    }



                    break;
                }
            //wysun na wy
            case 8:
                {

                    Wysun(znalezionePrzejscie.wy);
                    break;
                }
            //obniż
            case 9:
                {
                    Obniz(znalezionePrzejscie.wy);
                    break;
                }
            //podnieś
            case 10:
                {
                    Podnies();
                    break;
                }
            //cofnij
            case 11:
                {
                    Cofnij(znalezionePrzejscie.wy);

                    break;
                }
            case 12:
                {
                    znalezionePrzejscie.wy.SendMessage("Pracuj", true);
                    GetComponentInParent<Dane>().stan = 0;
                    break;
                }

        }
    }
    
 
    public Przejscie sprawdzWarunki()
    {
        foreach (Przejscie item in listaWejsc)
        {
            bool temp1 = false, temp2 = false;
            if ((item.we.tag == "paletaOdbiorcza" && item.we.GetComponent<obslugaPaletyOdbierajacej>().iloscElementow > 0)
                ||
                (item.we.GetComponentInParent<Dane>().gotowy == true && item.we.GetComponentInParent<Dane>().stan == 0
                && item.wy.GetComponentInParent<Dane>().stan == 0 && item.wy.GetComponentInParent<Dane>().gotowy == false)

             &&( (item.wy.GetComponentInParent<Dane>().coObsluguje1 == obslugaBlachy.TypBlachy.wszystko ||
             item.we.GetComponentInParent<Dane>().manipulowanyObiekt.GetComponentInParent<obslugaBlachy>().typ == item.wy.GetComponentInParent<Dane>().coObsluguje1 ||
             item.we.GetComponentInParent<Dane>().manipulowanyObiekt.GetComponentInParent<obslugaBlachy>().typ == item.wy.GetComponentInParent<Dane>().coObsluguje2 ||
             item.we.GetComponentInParent<Dane>().manipulowanyObiekt.GetComponentInParent<obslugaBlachy>().typ == item.wy.GetComponentInParent<Dane>().coObsluguje3
                ))
                )
                foreach(GameObject item2 in listaObiektowWZasiegu)
                {
                    if (item2 == item.we) temp1 = true;
                    if (item2 == item.wy) temp2 = true;

                }
                if(temp1&&temp2)
            {
                return item;
            }
                
        }
        return null;
    }
    public Component znajdzComponent(string komponent)
    {
        foreach (Component item in GetComponentInParent<Dane>().root.GetComponentsInChildren<Component>())
        {
            if (item.name == komponent)
            {
                return item;
            }
        }
        return null;
    }

    public void Obroc(GameObject obiekt, float aa1)
    {
        Component item = znajdzComponent("obrot");
        target2 = Quaternion.Euler(0, aa1, 0);

           Quaternion tempItem = item.transform.rotation;
            tempItem.x = tempItem.x * -1;
            tempItem.y = tempItem.y * -1;
            tempItem.z = tempItem.z * -1;
            tempItem.w = tempItem.w * -1;
     

        item.transform.rotation = Quaternion.Lerp(item.transform.rotation, target2, 3f  *Time.fixedDeltaTime);

        if ((target2 == item.transform.rotation)|| (target2 == tempItem) )
            {
            zapamietanePoziomo = znajdzComponent("poziomo").transform.position;
            roznicaPaletkaPoziomo = znajdzComponent("paletka").transform.position - zapamietanePoziomo;
           
            GetComponentInParent<Dane>().stan++;
           
            }
       
    }

    public void Wysun(GameObject obiekt)
    {
        Component item = znajdzComponent("poziomo");
        Component paletka = znajdzComponent("paletka");
       

        Vector3 roznica = domyslnePaletka.transform.position - zapamietanePoziomo;
        roznica = paletka.transform.position - item.transform.position;
        Vector3 domyslnaPozItem;
        domyslnaPozItem = item.transform.position;

        Vector3 tempObiektBezy = obiekt.transform.position;
        roznica.y = item.transform.position.y;
        Vector3 bezY = roznica;


        Vector3 punktDocelowy = obiekt.transform.position - roznicaPaletkaPoziomo;
        punktDocelowy.y = item.transform.position.y;
        item.transform.position = Vector3.MoveTowards(item.transform.position,punktDocelowy, 3f * Time.fixedDeltaTime);
        if (item.transform.position == punktDocelowy)
        {
            zapamietanePionowo= znajdzComponent("pionowo").transform.position;
            roznicaPletkaPionowo = znajdzComponent("paletka").transform.position - znajdzComponent("pionowo").transform.position;
            GetComponentInParent<Dane>().stan++;
        }
    }

    
    public void Obniz(GameObject obiekt)
    {
        Component paletka = znajdzComponent("paletka");
        Component item = znajdzComponent("pionowo");
        Vector3 roznica = obiekt.transform.position - paletka.transform.position;


        Vector3 domyslnaPozItem;
        domyslnaPozItem = item.transform.position;

        Vector3 temp = item.transform.position + roznica;
        temp.x = domyslnaPozItem.x;
        temp.z = domyslnaPozItem.z;
        Vector3 bezXZ = temp;
        item.transform.position = Vector3.MoveTowards(item.transform.position, bezXZ, 1f * Time.fixedDeltaTime);

    }
    public void Podnies()
    {
          Component item = znajdzComponent("pionowo");
          Vector3 temp = item.transform.position;
          temp.y = domyslnePionowo.y;
          item.transform.position = Vector3.MoveTowards(item.transform.position, zapamietanePionowo, 1f * Time.fixedDeltaTime);

          if (item.transform.position== zapamietanePionowo)
          {
              GetComponentInParent<Dane>().stan++;
          }

    }
    public void Cofnij(GameObject obiekt)
    {
        Component item = znajdzComponent("poziomo");
        item.transform.position = Vector3.MoveTowards(item.transform.position, zapamietanePoziomo, 3f*Time.fixedDeltaTime);
        if (item.transform.position == zapamietanePoziomo)
        {
            roznicaPletkaPionowo = znajdzComponent("paletka").transform.position - znajdzComponent("pionowo").transform.position;
            GetComponentInParent<Dane>().stan++;
        }

    }
  
         


    

    public void OnTriggerEnter(Collider other)
    {
        //dodanie do zasięgu tylko maszynu (bez blach) i bez dzieci (dlatego sprawdzanie czy posiada skrypt Dane).
        if (!other.CompareTag("blacha") && other.TryGetComponent(out Dane script) == true)
        {


            listaObiektowWZasiegu.Add(other.gameObject);
            
        }


    }

}
