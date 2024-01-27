using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objGen : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb; 
    public GameObject obj;
    public GameObject coconut;
    public GameObject[] prefabs;

    public float spawnXPosition = 0f; // X轴初始生成位置
    public Vector3 minPosition;
    public Vector3 maxPosition;

    public float spawnInterval = 2f; // 生成间隔时间
    private float nextSpawnTime;

    void Start()
    {   
        nextSpawnTime = Time.time + spawnInterval;

        // obj = prefabs[Random.Range(0, prefabs.Length)];
        // coconut = Instantiate(obj, spawnPosition, Quaternion.identity);
        // Debug.Log(spawnPosition);
        // rb = coconut.GetComponent<Rigidbody>();
        // if (rb == null){
        //     rb = coconut.AddComponent<Rigidbody>();
        // }
        

    }

    void Update()
    {
        if (Time.time > nextSpawnTime){
            GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            Vector3 spawnPosition = new Vector3(
                Random.Range(-10.0f, 10.0f),
                6f, 0f);
            GameObject spawnedObject = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
            rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb == null){
                rb = spawnedObject.AddComponent<Rigidbody>();
            }
            if (rb!= null){
                Debug.Log(rb.position.y);
                Debug.Log(rb.useGravity);
                if(rb.position.y < -5f){
                    Destroy(rb, 2.0f);
                    Destroy(spawnedObject, 2.0f);
                } else {
                    rb.useGravity = true;
                    rb.mass = 2.0f;
                }
            }
            nextSpawnTime = Time.time + spawnInterval;

        }

        
        

    }
}


