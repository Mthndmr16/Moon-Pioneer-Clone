using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectOil : MonoBehaviour
{   
    // �retilen petrol varillerini s�rt�m�zda depolamak i�in yaz�lmas� gereken kodlar.

    public List<GameObject> oil_List = new List<GameObject>(); // birden fazla petrol varilini depolamak istedi�im i�in bir liste olu�turuyorum.
    [SerializeField] private GameObject oilPrefab;
    public Transform oilCollectPoint;  // karakterimizin s�rt�nda depolamak i�in hierarchy ekran�nda bo� bir obje olu�turdum. o objeyi de karakterimizin s�rt�na hizalad�m.


    int oil_Limit = 5;  // s�rt�m�zda depolayabildi�imiz maksimum petrol varili say�s�.

    private void OnEnable()  
    {
            TriggerEvent.OnOilCollect += GetOil;
            TriggerEvent.OnOilGive += GiveOil;
    }

    private void OnDisable()
    {
        TriggerEvent.OnOilCollect -= GetOil;
        TriggerEvent.OnOilGive -= GiveOil;
    }

    public void GetOil()
    {
        if (oil_List.Count <= oil_Limit) // e�er ilgili petrol varili say�s� , ta��ma kapasitemizin alt�ndaysa 
        {
            GameObject collectedOil = Instantiate(oilPrefab, oilCollectPoint);  // �nstantiade edilecek petrol varilini burada referans al�yoruz.

            collectedOil.transform.position = new Vector3(oilCollectPoint.position.x, 0.5f + ((float)oil_List.Count / 2.5f), oilCollectPoint.position.z); // s�rt�m�zda a�a��dan ba�lay�p yukar� do�ru stacklenmesi i�in gerekli kod sat�r�. karakterimizin arkas�na g�zel bir �ekilde hizalanmas� i�in eksenlerdeki float de�erleriyle oynama yapt�m.
            oil_List.Add(collectedOil);

            collectedOil.transform.localScale = new Vector3(.04f, .04f, .04f); // �retilen petrol varilini s�rt�m�za al�rken k���lt�yorum.
            collectedOil.transform.Rotate(new Vector3(0, 0, 90));  // dikey olarak de�il de yatak olarak �st �ste binmesini istiyorum

            UIManager uIManager = FindObjectOfType<UIManager>();
            uIManager.oilAmount = oil_List.Count;

            if (TriggerEvent.oilDrillingMachine != null)
            {
                TriggerEvent.oilDrillingMachine.RemoveLastComponent();
            }
        }
    }

    public void GiveOil()  // elimizdeki petrol varillerini ilgili beton �reticisine aktarmak i�in bu kod blo�unu haz�rlad�m
    {
        if (oil_List.Count > 0)
        {
            TriggerEvent.ConcreteProducer.GetOil(); // Halihaz�rda TriggerEvent scriptinde refernas al�nmm�� olan beton �reticisinin scriptine eri�ip oradan "GetOil()" adl� fonskiyonu �a��r�yoruz      
            RemoveLast();
        }
    }  
    public void RemoveLast()  // karakterimizin �st�nde biriktirmi� oldu�u varilleri sondan ba�layarak ilgili yere aktarmas� i�in gerekli olan kod blo�u
    {
        if (oil_List.Count > 0)
        {
            Destroy(oil_List[oil_List.Count - 1]);
            oil_List.RemoveAt(oil_List.Count - 1);
            UIManager uIManager = FindObjectOfType<UIManager>();
            uIManager.oilAmount = oil_List.Count;
        }
    }
}
