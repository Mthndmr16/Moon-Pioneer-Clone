using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyArea : MonoBehaviour
{
    public Image progressImage;  // 360 derecelik bir dönme açýsý vererek alaný satýn aldýðýmýzý gösteren basit bir Image
    public GameObject acceleratorGameObject, astronoutGameObject, buyGameObject,finishArea;  // alanýmýz aktif olacaðý zaman ýnspector ekranýna sürüklememiz gereken componentler'a ait deðiþkenler.
    public float cost, currentConcrete, progress;  // Basit matematik iþlemleri için gerekli deðiþkenler.

 public void Buy(int concreteAmount)
    {
        currentConcrete += concreteAmount;  
        progress = currentConcrete / cost;  // o anki betonumuzu , maliyete bölerek image progress deðerinin 0 dan baþlayarak 1 deðerine kadar artmasýný saðlýyorum.
        progressImage.fillAmount = progress ;
        if (progress ==1)
        {
            //ilgili gameObjectlerin sahnede görünüp görünmeyeceðini belirtmek amacýyla yazdýðým kod bloðu.
            buyGameObject.SetActive(false);
            acceleratorGameObject.SetActive(true);
            astronoutGameObject.SetActive(true);
            finishArea.SetActive(true);
            this.enabled = false;
        }
    }
}
