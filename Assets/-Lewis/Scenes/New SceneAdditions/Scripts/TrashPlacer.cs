using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPlacer : MonoBehaviour
{
    public GameObject[] TrashObjects;
    public Transform trashlayer;
    public int pollution;
    [Range(0f, 1f)]
    private float Incrementpollution;
    int iterations;
    int numberActive;
    // Start is called before the first frame update
    private void Start()
    {
    }
    private void Update()
    {
        iterations = (int)(TrashObjects.Length * pollution);
        
        revealGarbage();
    }
    void revealGarbage()
    {
        if (!TrashObjects[0].activeSelf && pollution == 0) return;
        if(iterations == numberActive)
        {
            return;
        }
        if(iterations < numberActive)
        {
            for (int i = numberActive; i >= iterations; i--)
            {
                Debug.Log("I am being called");

                TrashObjects[i].gameObject.SetActive(false);
                numberActive = i;
            }
        }
        for(int i = 0; i < iterations; i ++)
        {
            TrashObjects[i].gameObject.SetActive(true);
            numberActive = i;
        }
    }
    public void increasePolution()
    {
        pollution += 5;
        pollution = Mathf.Clamp(pollution, 1, 20);
        Incrementpollution += 0.1f;
        Incrementpollution = Mathf.Clamp(pollution, 0, 1);


    }
    public void DecreasePolution()
    {
        
        pollution -= 5;
        pollution = Mathf.Clamp(pollution, 1, 20);
        Incrementpollution -= 0.1f;
        Incrementpollution = Mathf.Clamp(pollution, 0, 1);


    }

    //this is out of date can needs to be rewriten to work.
    void GeneraterandomGarbage()
    {
        for (int i = 0; i < iterations; i++)
        {
            Debug.Log("????");
            Vector3 randomPosition = new Vector3(Random.Range(-1500, 1500), 0, Random.Range(-1500, 1500));
            GameObject boop = Instantiate(TrashObjects[Random.Range(0, 3)], randomPosition, Quaternion.identity, trashlayer);
            boop.transform.localScale = Vector3.one * Random.Range(0.1f, 0.6f);
        }
    }

}
