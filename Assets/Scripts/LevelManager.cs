using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // sahne yükleme iþlemleri iin bu kütüphaneyi ekledim.

public class LevelManager : MonoBehaviour
{
    // Hierarchy'de bulunan UI => FinishTheGame => RestartButton'a ait "OnClick()" eventine eriþim saðlayýp butona týklayýnca ne yapýlacaðýný gösteren fonksiyonu yazýyorum.
    // Bu metodun public olmasýna dikkat ediyorum yoksa event'ýn içinde gözükmez.  
    public void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;  //  yeni bir deðiþken oluþturup þuanki aktif olan sahneyi referans alýyorum.
        SceneManager.LoadScene(currentScene);  // Scene manager kütüphanesinden þuanki aktif olan sahneyi bana getirmesini istiyorum.
    }
}
