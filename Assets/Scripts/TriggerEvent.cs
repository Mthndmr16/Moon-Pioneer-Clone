using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// alana girme , alanda durma ve bulunduðumuz alandan çýkma iþlemlerini yapmamýz gerek.
// Bu yüzden tek scriptte OnTriggerExit ve OnTriggerStay metotlarýný event yardýmýyla bir arada kullanabileceðim tek bir script oluþturdum 

public class TriggerEvent : MonoBehaviour
{
    // Burasý petrol sontaj makinesi ile alakalý trigger kýsmýný içeriyor.
    public delegate void OnCollectArea();   
    public static event OnCollectArea OnOilCollect;
    public static OilDrillingMachine oilDrillingMachine;

    // Burasý beton üretici ile alakalý trigger kýsmýný içeriyor
    public delegate void OnConcreteGeneratorArea();
    public static event OnConcreteGeneratorArea OnOilGive;
    public static ConcreteProducer ConcreteProducer;

    //Burasý üretilen betonu para yerine kullanýp yeni bir alan açmmamýz için gerekli.
    public delegate void OnConcreteArea();
    public static event OnConcreteArea OnConcreteCollected;


    //Burasý unlock yapacaðýmýz alan ile alakalý trigger kýsmýný içeriyor
    public delegate void OnBuyArea();
    public static event OnBuyArea OnBuyingAccelerator;
    public static BuyArea areaToBuy;

    //Burasý da oyunu bitirmemiz için içinde bulunmamýz gereken alan ile alakalý trigger kýsmýný içeriyor
    public delegate void OnFinishArea();
    public static FinishArea areaToFinish;
    public static OnFinishArea onFinish;

   

    bool isCollecting;  // Bu iki bool deðiþkenini true - false arasý deðiþtirerek IEnumeratorun çalýþýp çalýþmamasýný kontrol ediyorum.
    bool isGiving;



    void Start()
    {

        StartCoroutine(CollectEnum());

    }


    IEnumerator CollectEnum()  // toplama hýzýmýz için IEnumerator kullanýyorum.
    {
        while (true)
        {
            if (isCollecting == true)
            {
                OnOilCollect();

            }
            if (isGiving == true)
            {
                OnOilGive();
            }
            yield return new WaitForSeconds(.8f);  // Bloklarý toplama süremiz.
        }
    }

    private void OnTriggerEnter(Collider other)  // Beton bloðun üzerine geldiðimiz anda aþaðýdaki kod bloðu aktif oluyor.
    {
        if (other.gameObject.CompareTag("Concrete"))
        {
            OnConcreteCollected();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)  // ilgili Colliderlar'ýn içlerinde kaldýðýmýz süre boyunca aþaðýdaki kod bloklarý aktif oluyor.
    {
        if (other.gameObject.CompareTag("BuyArea"))  // 5 adet beton blok verip satýn alacaðýmýz alan ile alakalý kod bloðu
        {
            OnBuyingAccelerator(); 
            areaToBuy = other.gameObject.GetComponent<BuyArea>();
        }

        if (other.gameObject.CompareTag("FinishArea")) // 6 adet beton blok verip oyunu bitireceðimiz alan ile alakalý kod bloðu
        {
            onFinish();
            areaToFinish = other.gameObject.GetComponent<FinishArea>();
        }


        if (other.gameObject.CompareTag("CollectArea"))   // Eðer oyuncumuz "CollectArea" Tag'ýný verdiðimiz alanda kaldýðý süre boyunca petrol varillerini toplamaya baþlýyor
        {                                                 // CollectArea tag'ý hierarchy'de OilDrill adlý componente verdiðim tag.
                isCollecting = true;
                oilDrillingMachine = other.gameObject.GetComponent<OilDrillingMachine>();
        }
        if (other.gameObject.CompareTag("WorkArea"))      // Eðer oyuncumuz "WorkArea" Tag'ýný verdiðimiz alanda kaldýðý süre boyunca beton bloklarý toplamaya baþlýyor
        {
            isGiving = true;
            ConcreteProducer = other.gameObject.GetComponent<ConcreteProducer>();

        }
    }
   

    private void OnTriggerExit(Collider other)   // eðer belirlenen alanlardan çýkýlýrsa toplama , daðýtma satýn alma ve oyunu bitirme iþlemleri
    {
        if (other.gameObject.CompareTag("CollectArea"))  // eðer belirlenen alandan cýkarsak toplama iþlemi yapýlmýyor
        {
            isCollecting = false;
            oilDrillingMachine = null;
        }
        if (other.gameObject.CompareTag("WorkArea"))    // eðer belirlenen alandan cýkarsak verme iþlemi yapýlmýyor
        {
            isGiving = false;
            oilDrillingMachine = null;
        }
        if (other.gameObject.CompareTag("BuyArea"))  // eðer belirlenen alandan cýkarsak satýn alma iþlemi yapýlmýyor
        {            
            areaToBuy = null;
        }
        if (other.gameObject.CompareTag("FinishArea")) // eðer belirlenen alandan cýkarsak oyunu bitirme iþlemi yapýlmýyor
        {
            areaToFinish = null;
        }
    }

}
