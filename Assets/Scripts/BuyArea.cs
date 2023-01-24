using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyArea : MonoBehaviour
{
    public Image progressImage;  // 360 derecelik bir d�nme a��s� vererek alan� sat�n ald���m�z� g�steren basit bir Image
    public GameObject acceleratorGameObject, astronoutGameObject, buyGameObject,finishArea;  // alan�m�z aktif olaca�� zaman �nspector ekran�na s�r�klememiz gereken componentler'a ait de�i�kenler.
    public float cost, currentConcrete, progress;  // Basit matematik i�lemleri i�in gerekli de�i�kenler.

 public void Buy(int concreteAmount)
    {
        currentConcrete += concreteAmount;  
        progress = currentConcrete / cost;  // o anki betonumuzu , maliyete b�lerek image progress de�erinin 0 dan ba�layarak 1 de�erine kadar artmas�n� sa�l�yorum.
        progressImage.fillAmount = progress ;
        if (progress ==1)
        {
            //ilgili gameObjectlerin sahnede g�r�n�p g�r�nmeyece�ini belirtmek amac�yla yazd���m kod blo�u.
            buyGameObject.SetActive(false);
            acceleratorGameObject.SetActive(true);
            astronoutGameObject.SetActive(true);
            finishArea.SetActive(true);
            this.enabled = false;
        }
    }
}
