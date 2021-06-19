using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject columnPrefab; // reference
    public float minY;
    public float maxY;
    //
    // When timer is greater than maxTime we are going to spawn a new Column, and then set timer to 0
    float timer;
    public float maxTime; 
    
    void Start()
    {
        // spawn a column
        InstantiateColumns();
    }

    // Update is called once per frame
    void Update()
    {

        // spawn random columns every x amount of seconds
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            InstantiateColumns();
            timer = 0f;
        }

        
    }

    void InstantiateColumns()
    {
        float randomYPosition = Random.Range(minY, maxY);
        GameObject newColumn = Instantiate(columnPrefab); // we define the new column
        newColumn.transform.position = new Vector2(transform.position.x, randomYPosition);
    }
}
