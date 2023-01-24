using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteProducer : MonoBehaviour
{
    public List<GameObject> oil_List = new List<GameObject>();  // petrol varillerinin tutulaca�� liste
    public List<GameObject> concrete_List = new List<GameObject>(); // beton bloklar�n�n tutulaca�� liste

    public Transform oilGivingPoint;  // petrol varillerinin olu�aca�� nokta
    public Transform concreteDropPoint; // beton bloklar�n olu�aca�� nokta

    public GameObject oilPrefab;  
    public GameObject concretePrefab;

    int stackCount = 6;  // g�r�nt� olarak k�t� g�z�kmemesi i�in tek s�tunda 4'er adet beton blok �retilmesini istiyorum. o y�zden b�yle bir de�i�ken kulland�m.
    public float time = 1.2f; // beton �reticisinin petrol� al�p beton yapma s�resi ile alakal� de�i�ken.

    private void Start()
    {
        StartCoroutine(GenerateConcrete());  // IEnumerator'u ba�lat�yorum.
    }

    IEnumerator GenerateConcrete()    // Beton �reticinin belli saniye aral�klarla �al��mas�n� istedi�im i�in yeni bir IEnumerator olu�turdum.
    {
        while (true) 
        {
            float concreteCount = concrete_List.Count;  
            int columnCount = (int)concreteCount / stackCount;
            if (oil_List.Count > 0 )  // E�er beton �reticinin �st�nde petrol varsa alttaki kod blo�unu yapmas�n� s�yledim
            {
                GameObject createdConcrete = Instantiate(concretePrefab); // ilgili prefab'� burada referans ald�m
                //alttaki sat�rda da belirlemi� oldu�um concreteDrop point noktas�ndan ba�layarak , z ekseninde 4 tane �retip x eksenine ge��iyor. yani bir s�tunda sadece 4 adet beton �retiliyor.
                createdConcrete.transform.position = new Vector3(9f+(float)columnCount/.5f, concreteDropPoint.position.y, -20f+(concreteCount%stackCount) /.7f);  
                concrete_List.Add(createdConcrete);
                RemoveLast();
            }
            yield return new WaitForSeconds(time);  //5 saniye aral�klarla �retiliyor.
        }         
    }
 
    public void GetOil()  // Beton �reticinin �st taraf�na koydu�um drop point'e ilgili petrol varilleri koyuluyor.
    {
        if (oil_List.Count < 7)
        {       
                GameObject temp = Instantiate(oilPrefab);
                temp.transform.position = new Vector3(1f + (float)oil_List.Count / 1.5f, oilGivingPoint.position.y, oilGivingPoint.position.z);
                oil_List.Add(temp);                  
        }          
    }

    public void RemoveLast()  // Son giren ilk ��kar mant���n� kullanarak en sondaki varil Hierarchy ekran�ndan siliniyor.
    {
        if (oil_List.Count > 0)
        {
            Destroy(oil_List[oil_List.Count - 1]);
            oil_List.RemoveAt(oil_List.Count - 1);
        }
    }
   


}
