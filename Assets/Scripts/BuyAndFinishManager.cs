using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu scripti beton adedimizi güncel tutmak amaçlý yazdým. 
public class BuyAndFinishManager : MonoBehaviour
{
    public int concreteCount = 0;  

    private void OnEnable()  
    {
        TriggerEvent.OnConcreteCollected += IncreaseConcrete; 
        TriggerEvent.OnBuyingAccelerator += BuyArea;
        TriggerEvent.onFinish += FinishArea;

    }

    private void OnDisable()
    {
        TriggerEvent.OnConcreteCollected -= IncreaseConcrete;
        TriggerEvent.OnBuyingAccelerator -= BuyArea;
        TriggerEvent.onFinish -= FinishArea;


    }

    void IncreaseConcrete()
    {
        concreteCount += 1;
        UIManager uIManager = FindObjectOfType<UIManager>();  
        uIManager.concreteAmount = concreteCount;             // beton adedimi arayüzde görebilmek için bu iki satýrý yazýyorum
    }

    void BuyArea()
    {
        if (TriggerEvent.areaToBuy != null)   // eðer satýn alýnacak alan null refference deðilse ;
        {
            if (concreteCount >= 1)  // beton adedi 1 den büyük ve eþit olduðu zaman
            {
                TriggerEvent.areaToBuy.Buy(1);  
                concreteCount -= 1;
                UIManager uIManager = FindObjectOfType<UIManager>();
                uIManager.concreteAmount = concreteCount;
            }
        }
    }

    void FinishArea()
    {
        if (TriggerEvent.areaToFinish != null)
        {
            if (concreteCount >= 1)
            {
                TriggerEvent.areaToFinish.FinishTheGame(1);
                concreteCount -= 1;
                UIManager uIManager = FindObjectOfType<UIManager>();
                uIManager.concreteAmount = concreteCount;

            }
        }
    }
}
