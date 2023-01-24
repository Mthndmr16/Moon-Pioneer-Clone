using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu script, 5 alt�nla almam�z gereken alan a��ld���nda aktif oluyor ��nk� Hierarchy ekran�nda normalde deaktif olan 'Accelerator' adl� GameObject'e ait bir script.
// Scriptin amac� petrol sondaj makinesinin �retim h�z�n� art�rmak.
public class OilAccelerator : MonoBehaviour
{
    // referans alma i�lemleri
    BuyArea buyArea;
    OilDrillingMachine oilDrillingMachine;


    bool isFaster = false;

    private void Start()
    {
        //Referans alma i�lemleri.
        oilDrillingMachine = FindObjectOfType<OilDrillingMachine>();
        buyArea = FindObjectOfType<BuyArea>();


    }
    private void Update()
    {
        if (buyArea.astronoutGameObject.activeInHierarchy)
        {
            if (!isFaster)
            {                
                oilDrillingMachine.time -= 1.8f; // H�zland�r�c�n�n, sondaj makinesinin �retim h�z�n� art�rmas� i�in yaz�lan kod sat�r�. (3 saniyede bir iken script aktif olduktan sonra 1.2 saniyede bir �retim yap�yor)
                isFaster = true;
            }
        }
        Debug.Log("Petrol ��kma s�resi : " + oilDrillingMachine.time + " saniye"); // Petrol �retim h�z�n�n, script etkin olmadan �nce ve sonra de�i�ti�ini g�stermek ama�l� console ekran�nda g�stermek ama�l� yaz�lan kod sat�r�.
    }
}
