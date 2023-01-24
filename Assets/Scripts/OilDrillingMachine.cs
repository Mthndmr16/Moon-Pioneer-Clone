using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu script , ilgili oyun objesinin belirlenen s�re boyunca petrol �retip belirtilen yere beton blok spawnlayacak.

public class OilDrillingMachine : MonoBehaviour
{
    public List<GameObject> oil_List = new List<GameObject>();  // �retilecek petrol varillerinin say�s�n� tutmak i�in bir list de�i�keni olu�turuyorum.
    public GameObject oilPrefab;
    public Transform exitPoint;  // �retilen petrol�n nerede stacklenmeye ba�layaca��n� belirlemek ama�l� olu�turulmus de�i�ken.
    bool isWorking;
    int stackCount = 10; // her bir x ekseninde ka� tane �retilece�ini belirlemek ama�l� yaz�lan kod sat�r�.
                       
    public float time = 3f;   // unlock alan� a��ld��� anda referans al�p petrol �retim h�z�n� de�i�tirebilmek i�in bir 'time' de�i�keni olu�turuyorum.


    void Start()
    {
        StartCoroutine(ProduceOil());  // IEnumeretor' u �a��r�yoru.
    }

    
    public void RemoveLastComponent()  // En son �retilen ilk al�n�r mant���n� kullanarak �retilen en son petrol varilini s�rt�m�za al�yoruz.
    {
        if (oil_List.Count > 0)
        {
            Destroy(oil_List[oil_List.Count - 1]); 
            oil_List.RemoveAt(oil_List.Count - 1);
        }
    }

     public IEnumerator ProduceOil()  // �retim h�z�n� kontrol etmek amac�yla ilkel bir saya� olu�turuyorum.
        {
       
        while (true)
        {
            float oilCount = oil_List.Count;  // daha temiz bir i�lem yapabilmek i�in listemizi float bir de�ere at�yorum.
            int columnCount = (int)oilCount / stackCount; // tek s�tunda ka� adet petrol varilinin olu�mas� i�in petrol varili say�s�n� belirledi�im stackCount say�s�na b�l�yorum
            if (isWorking) //
            {
                GameObject createdOil = Instantiate(oilPrefab);  // olu�acak petrol varili i�in referans atamas� yap�yorum
                // A�a��daki kod blo�unda; olu�turulan petrol varillerinin sondaj makinesinin neresinde olaca��n� belirlemek i�in yazd���m kod. ExitPoint noktas�ndan ba�layarak z eksenine do�ru artarak ilerliyor.
                createdOil.transform.position = new Vector3(exitPoint.position.x + ((float)columnCount/1.5f), exitPoint.position.y, 1f + (oilCount%stackCount) / 1.5f);
                oil_List.Add(createdOil);
                if (oil_List.Count >= 30 )
                {
                    isWorking = false;  // e�er �retilen petrol varili say�s� 15'e ula�t�ysa �retimi durdur.
                }
              
            }       
            else if (oil_List.Count <30)  
            {
                isWorking = true;  // ayn� �ekilde e�er �retilen petrol varili say�s� 15'ten k���kse �retime devam et.
            }
            
            yield return new WaitForSeconds(time);  // petrol varili �retim h�z�.
        }        
    }
}
