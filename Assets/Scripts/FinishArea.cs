using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// oyuncumuzun 6 adet beton blok verip açmasý gereken alan için hazýrlanmýþ bir sýnýf.
public class FinishArea : MonoBehaviour
{
    public Image progressImage;
    public GameObject finishGameObject , finishPanel;
    public float cost,currentConcrete, progress;

    public void FinishTheGame(int concreteAmount)
    {
        currentConcrete += concreteAmount;
        progress = currentConcrete / cost;
        progressImage.fillAmount = progress;
        if (progress >= 1)  // eðer image %100 dolarsa yani 6 beton da ilgili alana verilirse;
        {
            finishGameObject.gameObject.SetActive(false);  // alan sahneden silinecek
            finishPanel.gameObject.SetActive(true);        // Hazýrlamýþ olduðum finish Panel sahnede görünecek
            this.enabled = false;  // bu kod deaktif olacak.
        }
    }
}
