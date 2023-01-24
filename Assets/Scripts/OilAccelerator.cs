using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu script, 5 altýnla almamýz gereken alan açýldýðýnda aktif oluyor çünkü Hierarchy ekranýnda normalde deaktif olan 'Accelerator' adlý GameObject'e ait bir script.
// Scriptin amacý petrol sondaj makinesinin üretim hýzýný artýrmak.
public class OilAccelerator : MonoBehaviour
{
    // referans alma iþlemleri
    BuyArea buyArea;
    OilDrillingMachine oilDrillingMachine;


    bool isFaster = false;

    private void Start()
    {
        //Referans alma iþlemleri.
        oilDrillingMachine = FindObjectOfType<OilDrillingMachine>();
        buyArea = FindObjectOfType<BuyArea>();


    }
    private void Update()
    {
        if (buyArea.astronoutGameObject.activeInHierarchy)
        {
            if (!isFaster)
            {                
                oilDrillingMachine.time -= 1.8f; // Hýzlandýrýcýnýn, sondaj makinesinin üretim hýzýný artýrmasý için yazýlan kod satýrý. (3 saniyede bir iken script aktif olduktan sonra 1.2 saniyede bir üretim yapýyor)
                isFaster = true;
            }
        }
        Debug.Log("Petrol çýkma süresi : " + oilDrillingMachine.time + " saniye"); // Petrol üretim hýzýnýn, script etkin olmadan önce ve sonra deðiþtiðini göstermek amaçlý console ekranýnda göstermek amaçlý yazýlan kod satýrý.
    }
}
