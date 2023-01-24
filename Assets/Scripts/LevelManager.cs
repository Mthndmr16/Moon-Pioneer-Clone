using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // sahne y�kleme i�lemleri iin bu k�t�phaneyi ekledim.

public class LevelManager : MonoBehaviour
{
    // Hierarchy'de bulunan UI => FinishTheGame => RestartButton'a ait "OnClick()" eventine eri�im sa�lay�p butona t�klay�nca ne yap�laca��n� g�steren fonksiyonu yaz�yorum.
    // Bu metodun public olmas�na dikkat ediyorum yoksa event'�n i�inde g�z�kmez.  
    public void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;  //  yeni bir de�i�ken olu�turup �uanki aktif olan sahneyi referans al�yorum.
        SceneManager.LoadScene(currentScene);  // Scene manager k�t�phanesinden �uanki aktif olan sahneyi bana getirmesini istiyorum.
    }
}
