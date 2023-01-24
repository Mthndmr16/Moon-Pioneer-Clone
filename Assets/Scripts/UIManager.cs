using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image oilImage;
    public Image ConcreteImage;

    public Text oilAmountText;
    public Text concreteAmountText;

    public int oilAmount = 0;
    public int concreteAmount = 0;

    private void Update()
    {
        oilAmountText.text = ""+oilAmount;
        concreteAmountText.text = "" + concreteAmount;
    }


}
