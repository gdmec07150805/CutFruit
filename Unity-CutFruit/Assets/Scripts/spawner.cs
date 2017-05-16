using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    [Header("水果")]
    public GameObject[] fruits;
    [Header("炸弹")]
    public GameObject boom;
    private Rigidbody rb;
    // Use this for initialization

    private float spawnTime = 2;
    private bool isPlaying = true;
    private float targetTime = 0;
    private int tempZ = 0;
    // Update is called once per frame
    void Update () {
        if (!isPlaying)
        {
            return;
        }
       
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            float num = Random.Range(1,3);
            for (int i=0;i<num;i++)
            {
                OnSpawn(true);

            }
            float num2 = Random.Range(10,100);
            if (num2>70)
            {
                OnSpawn(false);
            }
           spawnTime = 2;
           
        }
	}
    private void OnSpawn(bool isFruit)
    {
        float x = Random.Range(-8.2f,8.2f);
        float y = -5f;
        float z = tempZ;
        tempZ -= 2;
        if (tempZ<=-10)
        {
            tempZ = 0;
        }

        int index = Random.Range(0,fruits.Length);
        GameObject GO;
        if (isFruit)
        {
            GO = Instantiate(fruits[index], new Vector3(x, y, z),Quaternion.identity);
        }else
        {
            GO = Instantiate(boom, new Vector3(x, y, 0), Quaternion.identity);
        }
        
        Vector3 vel = new Vector3(-x * Random.Range(0.2f,0.8f),-Physics.gravity.y * Random.Range(1,1.4f),0);
        rb = GO.GetComponent<Rigidbody>();
        rb.velocity = vel;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
