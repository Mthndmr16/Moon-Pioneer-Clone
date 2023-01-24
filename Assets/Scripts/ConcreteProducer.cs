using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteProducer : MonoBehaviour
{
    public List<GameObject> oil_List = new List<GameObject>();  // petrol varillerinin tutulacaðý liste
    public List<GameObject> concrete_List = new List<GameObject>(); // beton bloklarýnýn tutulacaðý liste

    public Transform oilGivingPoint;  // petrol varillerinin oluþacaðý nokta
    public Transform concreteDropPoint; // beton bloklarýn oluþacaðý nokta

    public GameObject oilPrefab;  
    public GameObject concretePrefab;

    int stackCount = 6;  // görüntü olarak kötü gözükmemesi için tek sütunda 4'er adet beton blok üretilmesini istiyorum. o yüzden böyle bir deðiþken kullandým.
    public float time = 1.2f; // beton üreticisinin petrolü alýp beton yapma süresi ile alakalý deðiþken.

    private void Start()
    {
        StartCoroutine(GenerateConcrete());  // IEnumerator'u baþlatýyorum.
    }

    IEnumerator GenerateConcrete()    // Beton üreticinin belli saniye aralýklarla çalýþmasýný istediðim için yeni bir IEnumerator oluþturdum.
    {
        while (true) 
        {
            float concreteCount = concrete_List.Count;  
            int columnCount = (int)concreteCount / stackCount;
            if (oil_List.Count > 0 )  // Eðer beton üreticinin üstünde petrol varsa alttaki kod bloðunu yapmasýný söyledim
            {
                GameObject createdConcrete = Instantiate(concretePrefab); // ilgili prefab'ý burada referans aldým
                //alttaki satýrda da belirlemiþ olduðum concreteDrop point noktasýndan baþlayarak , z ekseninde 4 tane üretip x eksenine geççiyor. yani bir sütunda sadece 4 adet beton üretiliyor.
                createdConcrete.transform.position = new Vector3(9f+(float)columnCount/.5f, concreteDropPoint.position.y, -20f+(concreteCount%stackCount) /.7f);  
                concrete_List.Add(createdConcrete);
                RemoveLast();
            }
            yield return new WaitForSeconds(time);  //5 saniye aralýklarla üretiliyor.
        }         
    }
 
    public void GetOil()  // Beton üreticinin üst tarafýna koyduðum drop point'e ilgili petrol varilleri koyuluyor.
    {
        if (oil_List.Count < 7)
        {       
                GameObject temp = Instantiate(oilPrefab);
                temp.transform.position = new Vector3(1f + (float)oil_List.Count / 1.5f, oilGivingPoint.position.y, oilGivingPoint.position.z);
                oil_List.Add(temp);                  
        }          
    }

    public void RemoveLast()  // Son giren ilk çýkar mantýðýný kullanarak en sondaki varil Hierarchy ekranýndan siliniyor.
    {
        if (oil_List.Count > 0)
        {
            Destroy(oil_List[oil_List.Count - 1]);
            oil_List.RemoveAt(oil_List.Count - 1);
        }
    }
   


}
