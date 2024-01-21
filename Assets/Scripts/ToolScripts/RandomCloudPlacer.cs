using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCloudPlacer : MonoBehaviour
{
    public int randomNumberOfClouds;
    public int RandomDistanceFromZero;
    public GameObject[] Clouds;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < randomNumberOfClouds; i++)
        {
            Vector3 RandomPositon = new Vector3(Random.Range(-RandomDistanceFromZero, RandomDistanceFromZero), Random.Range(700, 1200), Random.Range(-RandomDistanceFromZero, RandomDistanceFromZero));
            GameObject clone = Instantiate(Clouds[Random.Range(0,4)], RandomPositon,Quaternion.identity);
            clone.transform.localScale = Vector3.one * Random.Range(40, 70);
        }
        
    }

}
