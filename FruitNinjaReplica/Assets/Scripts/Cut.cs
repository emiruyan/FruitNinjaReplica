using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cut : MonoBehaviour
{
    private Manager manager;//Manager classımıza ulaştık.

    private void Start()
    {
        manager = GameObject.FindObjectOfType<Manager>();  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fruit")//Diğer tetiklenen gameObject tagı "Fruit" ise;
        {
            Destroy(other.gameObject);//Diğer nesneyi yok et.
            manager.score++;//manager içerisindeki score'u bir bir arttır.
        }
        else if (other.gameObject.tag == "Bomb" )////Diğer tetiklenen gameObject tagı "Bomb" ise;
        { 
            manager.RestartGame();//Manager classı içerisindeki RestartGame methodunu çalıştır.
        }
    }
}
