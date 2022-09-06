using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerController : MonoBehaviour
{
   [SerializeField] private GameObject prefab;//Spawnlacak prefablerimiz
   //Spawner'ımızın yön aralığı ile spawnlayacağı değerler;
   [SerializeField] private float minX;
   [SerializeField] private float maxX;

   public Sprite[] sprites;

   [SerializeField] private float startTime;
   private float time;

   private void Update()
   {
      if (time <= 0) //time 0'a küçük eşit ise;
      {
         SpawnObject();
         time = startTime;//vereceğimiz startTime'ı time'a atıyoruz
      }
      else
      {
         time -= Time.deltaTime;//Verdiğimi time azaltıyoruz ve koşulun başına dönüyoruz
      }
   }

   private void SpawnObject()
   {
      GameObject newPrefab = Instantiate(prefab);//Çoğalacak nesnemiz prefab. Bunu newPrefab'a atadık.
      newPrefab.transform.position = new Vector2(//newPrefab transform'una random olarak x değerleri atadık. 
         Random.Range(minX,maxX),
         transform.position.y
         );

      //Birden fazla fruit objemiz var ve bunları Random olarak üreteceğiz;
      Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];//0 ve Dizi uzunluğu kadar sprite'ı randomSprite'a atadık.
      newPrefab.GetComponent<SpriteRenderer>().sprite = randomSprite;//randomSprite'ı newPrefab'a atadık bu şekilde farklı objeler üreteceğiz. 
   }
}
