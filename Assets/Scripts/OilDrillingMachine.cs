using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu script , ilgili oyun objesinin belirlenen süre boyunca petrol üretip belirtilen yere beton blok spawnlayacak.

public class OilDrillingMachine : MonoBehaviour
{
    public List<GameObject> oil_List = new List<GameObject>();  // üretilecek petrol varillerinin sayýsýný tutmak için bir list deðiþkeni oluþturuyorum.
    public GameObject oilPrefab;
    public Transform exitPoint;  // üretilen petrolün nerede stacklenmeye baþlayacaðýný belirlemek amaçlý oluþturulmus deðiþken.
    bool isWorking;
    int stackCount = 10; // her bir x ekseninde kaç tane üretileceðini belirlemek amaçlý yazýlan kod satýrý.
                       
    public float time = 3f;   // unlock alaný açýldýðý anda referans alýp petrol üretim hýzýný deðiþtirebilmek için bir 'time' deðiþkeni oluþturuyorum.


    void Start()
    {
        StartCoroutine(ProduceOil());  // IEnumeretor' u çaðýrýyoru.
    }

    
    public void RemoveLastComponent()  // En son üretilen ilk alýnýr mantýðýný kullanarak üretilen en son petrol varilini sýrtýmýza alýyoruz.
    {
        if (oil_List.Count > 0)
        {
            Destroy(oil_List[oil_List.Count - 1]); 
            oil_List.RemoveAt(oil_List.Count - 1);
        }
    }

     public IEnumerator ProduceOil()  // üretim hýzýný kontrol etmek amacýyla ilkel bir sayaç oluþturuyorum.
        {
       
        while (true)
        {
            float oilCount = oil_List.Count;  // daha temiz bir iþlem yapabilmek için listemizi float bir deðere atýyorum.
            int columnCount = (int)oilCount / stackCount; // tek sütunda kaç adet petrol varilinin oluþmasý için petrol varili sayýsýný belirlediðim stackCount sayýsýna bölüyorum
            if (isWorking) //
            {
                GameObject createdOil = Instantiate(oilPrefab);  // oluþacak petrol varili için referans atamasý yapýyorum
                // Aþaðýdaki kod bloðunda; oluþturulan petrol varillerinin sondaj makinesinin neresinde olacaðýný belirlemek için yazdýðým kod. ExitPoint noktasýndan baþlayarak z eksenine doðru artarak ilerliyor.
                createdOil.transform.position = new Vector3(exitPoint.position.x + ((float)columnCount/1.5f), exitPoint.position.y, 1f + (oilCount%stackCount) / 1.5f);
                oil_List.Add(createdOil);
                if (oil_List.Count >= 30 )
                {
                    isWorking = false;  // eðer üretilen petrol varili sayýsý 15'e ulaþtýysa üretimi durdur.
                }
              
            }       
            else if (oil_List.Count <30)  
            {
                isWorking = true;  // ayný þekilde eðer üretilen petrol varili sayýsý 15'ten küçükse üretime devam et.
            }
            
            yield return new WaitForSeconds(time);  // petrol varili üretim hýzý.
        }        
    }
}
