using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    
    
    public float timeBetweenSpawns;
    public GameObject prefab;
    
    private float timeToNextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeToNextSpawn = timeBetweenSpawns;
    }
    
    void Spawn(){
        for(int i = 0; i < 30; i++){
            Instantiate(prefab,new Vector2(-10+0.7f*i, 20),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 60 times per second
        // 60 frames per second
        // 1/60 of a second to calculate 
        // slow machine, lower fps
        
        //get to know how much it takes to pass to next frame
        // Debug.Log(Time.deltaTime);
        timeToNextSpawn -= Time.deltaTime;
        if(timeToNextSpawn <=0.0f){
            
            Spawn();
            timeToNextSpawn = timeBetweenSpawns;
        }
    }
}
