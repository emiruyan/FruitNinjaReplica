using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
   [SerializeField] private GameObject cutPrefab;//prefab nesnemiz

   [SerializeField] private float cutLifeTime;//bu prefab'in yaşayacağı süre

   private bool dragging;//kesik

   private Vector2 swipeStart;//kaydırma başlangıcı

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))//Mouse sol click tıklanıyor ise;
      {
         dragging = true;//dragging'i true'a çekiyoruz
         swipeStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Mouse pozisyonunu swipeStart'a atadık.
      }
      else if (Input.GetMouseButtonUp(0) && dragging)//Mouse sol click yukarı doğru ve dragging true ise;
      {
         dragging = false;//mouse'u bıraktığımız zaman kesik oluşmayacak bunu false'a çektik
         CutSpawner();
      }
   }

   private void CutSpawner()
   {
      Vector2 swipeEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);//swipeEnde bir mousePozisyonu atadık.
      GameObject cutInstance = Instantiate(cutPrefab, swipeStart, Quaternion.identity);
      //cutPrefab'i Instantiete ile çoğaltıp cutInstance'a atıyoruz.
      
      //LineRenderer Componentinin SetPosition'ına indexlerini verdik.
      cutInstance.GetComponent<LineRenderer>().SetPosition(0, swipeStart);
      cutInstance.GetComponent<LineRenderer>().SetPosition(1,swipeEnd);

      //Bu collider'ın uzunluğunu belirliyoruz;
      Vector2[] colliderPoints = new Vector2[2];
      colliderPoints[0] = Vector2.zero;
      colliderPoints[1] = swipeEnd - swipeStart;

      //EdgeCollider içindeki points'e 40.satır'da oluşturduğumuz değerler ile birlikte colliderPoints'i atadık
      cutInstance.GetComponent<EdgeCollider2D>().points = colliderPoints; 
      
      Destroy(cutInstance, cutLifeTime);//Bizim vereceğimiz süre ile bu nesneyi yok et
   }
}
