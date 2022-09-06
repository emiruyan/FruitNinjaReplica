using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [HideInInspector]public int score;//int tipinde score oluşturduk
    [SerializeField] private Text scoreText;//Ekranda yazdıracağımız scoreText

    private void Update()
    {
        GameScore();
    }

    private void GameScore()
    {
        scoreText.text = score.ToString();//scoreText'in text'ini score'a ata ve bunu ToString'e çevir
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Aktif olan sahnemizi tekrardan yükle
    }
}
