using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerWe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
      //  if (other.tag == "Respawn")// && other.gameObject != this.gameObject)
      if(other.tag=="przesuwacz")
        {
         //   gameObject.GetComponentInParent<Dane>().ColObjWe = other.gameObject;
            gameObject.GetComponentInParent<obslugaPrzesuwacza>().obiektColliderWe = other.gameObject;
        }
           


        /*  if (other.tag == "przesuwacz")
          {
              //    PrzesuwaczDane sc1 = 
              gameObject.GetComponentInParent<obslugaPrzesuwacza>().we = 1;
              //   sc1.we = 1;






          }
          else if (other.tag == "przekladacz")
          {
              //    PrzesuwaczDane sc1 = 
              gameObject.GetComponentInParent<obslugaPrzesuwacza>().we = 2;
              //   sc1.we = 1;

          }
          //   sc = gameObject.GetComponent<SkryptPrzesuwacz>();
          //     sc.we = 1;
          //  sc.someFunction();

      */


        // SkryptPrzesuwacz sc2 = gameObject.GetComponentInChild<SkryptPrzesuwacz>();
        //  sc2.we = 3;
    }
}
