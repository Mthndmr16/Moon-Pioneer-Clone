using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu scripti beton adedimizi g�ncel tutmak ama�l� yazd�m. 
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
        uIManager.concreteAmount = concreteCount;             // beton adedimi aray�zde g�rebilmek i�in bu iki sat�r� yaz�yorum
    }

    void BuyArea()
    {
        if (TriggerEvent.areaToBuy != null)   // e�er sat�n al�nacak alan null refference de�ilse ;
        {
            if (concreteCount >= 1)  // beton adedi 1 den b�y�k ve e�it oldu�u zaman
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
