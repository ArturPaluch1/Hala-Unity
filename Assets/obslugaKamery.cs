using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class obslugaKamery : MonoBehaviour
{
    private float szybkosc = 1f;
    private Vector3 kierunek;
    private Vector3 ruch;
    float czuloscMyszy = 2f;
    void Start()
    {
    }
    void Update()
    {
        Klwiatura();
        Mysz();
    }
    public void Klwiatura()
    {
        Vector3 kierunek = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            kierunek += transform.InverseTransformVector(transform.forward);
        if (Input.GetKey(KeyCode.S))
            kierunek += transform.InverseTransformVector(-transform.forward);
        if (Input.GetKey(KeyCode.A))
            kierunek += transform.InverseTransformVector(-transform.right);
        if (Input.GetKey(KeyCode.D))
            kierunek += transform.InverseTransformVector(transform.right);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }
        kierunek = transform.rotation * kierunek;
        transform.position += kierunek * szybkosc;
    }
    public void Mysz()
    {
        float myszPoziomo = Input.GetAxis("Mouse X") * czuloscMyszy;

        float myszPionowo = -Input.GetAxis("Mouse Y") * czuloscMyszy;
        transform.Rotate(myszPionowo, myszPoziomo, 0);
    }
}