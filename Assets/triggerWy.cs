using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerWy : MonoBehaviour
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

      
      //  if (other.tag == "Respawn")//&&other.gameObject!=this.gameObject)
      if(other.tag=="przesuwacz")
        {
          //  gameObject.GetComponentInParent<obslugaPrzesuwacza>().obiektColliderWe = other.gameObject;
            gameObject.GetComponentInParent<obslugaPrzesuwacza>().obiektColliderWy = other.gameObject;
        }
           
      //  if (other.gameObject.tag == "przesuwacz") other.GetComponent<Dane>().ColObjWe = GetComponentInParent<Dane>().root;  ;
        /*  if (other.gameObject.tag.Equals("przekladacz"))
          {
              obslugaPrzesuwacza sc1 = gameObject.GetComponentInParent<obslugaPrzesuwacza>();
              sc1.wy = 2;
              gameObject.GetComponentInParent<obslugaPrzesuwacza>().ColObjWy = other.gameObject;
          }
          else if (other.gameObject.tag.Equals("przesuwacz"))
          {
              obslugaPrzesuwacza sc1 = gameObject.GetComponentInParent<obslugaPrzesuwacza>();
              sc1.wy = 1;
              gameObject.GetComponentInParent<obslugaPrzesuwacza>().ColObjWy = other.gameObject;
          }*/

        //   sc = gameObject.GetComponent<SkryptPrzesuwacz>();
        //     sc.we = 1;
        //  sc.someFunction();




        // SkryptPrzesuwacz sc2 = gameObject.GetComponentInChild<SkryptPrzesuwacz>();
        //  sc2.we = 3;
    }
}
