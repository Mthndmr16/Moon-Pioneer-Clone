using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectOil : MonoBehaviour
{   
    // Üretilen petrol varillerini sýrtýmýzda depolamak için yazýlmasý gereken kodlar.

    public List<GameObject> oil_List = new List<GameObject>(); // birden fazla petrol varilini depolamak istediðim için bir liste oluþturuyorum.
    [SerializeField] private GameObject oilPrefab;
    public Transform oilCollectPoint;  // karakterimizin sýrtýnda depolamak için hierarchy ekranýnda boþ bir obje oluþturdum. o objeyi de karakterimizin sýrtýna hizaladým.


    int oil_Limit = 5;  // sýrtýmýzda depolayabildiðimiz maksimum petrol varili sayýsý.

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
        if (oil_List.Count <= oil_Limit) // eðer ilgili petrol varili sayýsý , taþýma kapasitemizin altýndaysa 
        {
            GameObject collectedOil = Instantiate(oilPrefab, oilCollectPoint);  // ýnstantiade edilecek petrol varilini burada referans alýyoruz.

            collectedOil.transform.position = new Vector3(oilCollectPoint.position.x, 0.5f + ((float)oil_List.Count / 2.5f), oilCollectPoint.position.z); // sýrtýmýzda aþaðýdan baþlayýp yukarý doðru stacklenmesi için gerekli kod satýrý. karakterimizin arkasýna güzel bir þekilde hizalanmasý için eksenlerdeki float deðerleriyle oynama yaptým.
            oil_List.Add(collectedOil);

            collectedOil.transform.localScale = new Vector3(.04f, .04f, .04f); // üretilen petrol varilini sýrtýmýza alýrken küçültüyorum.
            collectedOil.transform.Rotate(new Vector3(0, 0, 90));  // dikey olarak deðil de yatak olarak üst üste binmesini istiyorum

            UIManager uIManager = FindObjectOfType<UIManager>();
            uIManager.oilAmount = oil_List.Count;

            if (TriggerEvent.oilDrillingMachine != null)
            {
                TriggerEvent.oilDrillingMachine.RemoveLastComponent();
            }
        }
    }

    public void GiveOil()  // elimizdeki petrol varillerini ilgili beton üreticisine aktarmak için bu kod bloðunu hazýrladým
    {
        if (oil_List.Count > 0)
        {
            TriggerEvent.ConcreteProducer.GetOil(); // Halihazýrda TriggerEvent scriptinde refernas alýnmmýþ olan beton üreticisinin scriptine eriþip oradan "GetOil()" adlý fonskiyonu çaðýrýyoruz      
            RemoveLast();
        }
    }  
    public void RemoveLast()  // karakterimizin üstünde biriktirmiþ olduðu varilleri sondan baþlayarak ilgili yere aktarmasý için gerekli olan kod bloðu
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
