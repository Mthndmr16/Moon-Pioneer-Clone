using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// alana girme , alanda durma ve bulundu�umuz alandan ��kma i�lemlerini yapmam�z gerek.
// Bu y�zden tek scriptte OnTriggerExit ve OnTriggerStay metotlar�n� event yard�m�yla bir arada kullanabilece�im tek bir script olu�turdum 

public class TriggerEvent : MonoBehaviour
{
    // Buras� petrol sontaj makinesi ile alakal� trigger k�sm�n� i�eriyor.
    public delegate void OnCollectArea();   
    public static event OnCollectArea OnOilCollect;
    public static OilDrillingMachine oilDrillingMachine;

    // Buras� beton �retici ile alakal� trigger k�sm�n� i�eriyor
    public delegate void OnConcreteGeneratorArea();
    public static event OnConcreteGeneratorArea OnOilGive;
    public static ConcreteProducer ConcreteProducer;

    //Buras� �retilen betonu para yerine kullan�p yeni bir alan a�mmam�z i�in gerekli.
    public delegate void OnConcreteArea();
    public static event OnConcreteArea OnConcreteCollected;


    //Buras� unlock yapaca��m�z alan ile alakal� trigger k�sm�n� i�eriyor
    public delegate void OnBuyArea();
    public static event OnBuyArea OnBuyingAccelerator;
    public static BuyArea areaToBuy;

    //Buras� da oyunu bitirmemiz i�in i�inde bulunmam�z gereken alan ile alakal� trigger k�sm�n� i�eriyor
    public delegate void OnFinishArea();
    public static FinishArea areaToFinish;
    public static OnFinishArea onFinish;

   

    bool isCollecting;  // Bu iki bool de�i�kenini true - false aras� de�i�tirerek IEnumeratorun �al���p �al��mamas�n� kontrol ediyorum.
    bool isGiving;



    void Start()
    {

        StartCoroutine(CollectEnum());

    }


    IEnumerator CollectEnum()  // toplama h�z�m�z i�in IEnumerator kullan�yorum.
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
            yield return new WaitForSeconds(.8f);  // Bloklar� toplama s�remiz.
        }
    }

    private void OnTriggerEnter(Collider other)  // Beton blo�un �zerine geldi�imiz anda a�a��daki kod blo�u aktif oluyor.
    {
        if (other.gameObject.CompareTag("Concrete"))
        {
            OnConcreteCollected();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)  // ilgili Colliderlar'�n i�lerinde kald���m�z s�re boyunca a�a��daki kod bloklar� aktif oluyor.
    {
        if (other.gameObject.CompareTag("BuyArea"))  // 5 adet beton blok verip sat�n alaca��m�z alan ile alakal� kod blo�u
        {
            OnBuyingAccelerator(); 
            areaToBuy = other.gameObject.GetComponent<BuyArea>();
        }

        if (other.gameObject.CompareTag("FinishArea")) // 6 adet beton blok verip oyunu bitirece�imiz alan ile alakal� kod blo�u
        {
            onFinish();
            areaToFinish = other.gameObject.GetComponent<FinishArea>();
        }


        if (other.gameObject.CompareTag("CollectArea"))   // E�er oyuncumuz "CollectArea" Tag'�n� verdi�imiz alanda kald��� s�re boyunca petrol varillerini toplamaya ba�l�yor
        {                                                 // CollectArea tag'� hierarchy'de OilDrill adl� componente verdi�im tag.
                isCollecting = true;
                oilDrillingMachine = other.gameObject.GetComponent<OilDrillingMachine>();
        }
        if (other.gameObject.CompareTag("WorkArea"))      // E�er oyuncumuz "WorkArea" Tag'�n� verdi�imiz alanda kald��� s�re boyunca beton bloklar� toplamaya ba�l�yor
        {
            isGiving = true;
            ConcreteProducer = other.gameObject.GetComponent<ConcreteProducer>();

        }
    }
   

    private void OnTriggerExit(Collider other)   // e�er belirlenen alanlardan ��k�l�rsa toplama , da��tma sat�n alma ve oyunu bitirme i�lemleri
    {
        if (other.gameObject.CompareTag("CollectArea"))  // e�er belirlenen alandan c�karsak toplama i�lemi yap�lm�yor
        {
            isCollecting = false;
            oilDrillingMachine = null;
        }
        if (other.gameObject.CompareTag("WorkArea"))    // e�er belirlenen alandan c�karsak verme i�lemi yap�lm�yor
        {
            isGiving = false;
            oilDrillingMachine = null;
        }
        if (other.gameObject.CompareTag("BuyArea"))  // e�er belirlenen alandan c�karsak sat�n alma i�lemi yap�lm�yor
        {            
            areaToBuy = null;
        }
        if (other.gameObject.CompareTag("FinishArea")) // e�er belirlenen alandan c�karsak oyunu bitirme i�lemi yap�lm�yor
        {
            areaToFinish = null;
        }
    }

}
