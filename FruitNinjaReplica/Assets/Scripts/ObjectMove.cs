using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;//Bu class'a Rigidbody2d çağırdık 
    //Objelerimizin ulaşacağı min ve max değerler
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    //Objelerin ne kadar süre yaşayacağı
    [SerializeField] private float lifeTime;

    private void Start()
    {
        rb.velocity = new Vector2(//Vector2 değerlerini velocity'e atadık
            Random.Range(minX, maxX),
            Random.Range(minY,maxY)
        );
        Destroy(gameObject, lifeTime);//Bizim vereceğimiz süre sonunda bu gameObject'i yok et 
    }
}
