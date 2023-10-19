using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPlacer : MonoBehaviour
{
    public GameObject[] TrashObjects;
    public Transform trashlayer;
    [Range(0f, 1f)]
    public float pollution;
    int iterations;
    int numberActive;
    // Start is called before the first frame update
    private void Update()
    {
        iterations = (int)(TrashObjects.Length * pollution);
        revealGarbage();
    }
    void revealGarbage()
    {
        if (!TrashObjects[0].activeSelf && pollution == 0f) return;
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

    //this is out of date can needs to be rewriten to work.
    void GeneraterandomGarbage()
    {
        for (int i = 0; i < iterations; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-500, 500), .2f, Random.Range(-500, 500));
            GameObject boop = Instantiate(TrashObjects[Random.Range(0, 4)], randomPosition, Quaternion.identity, trashlayer);
            boop.transform.localScale = Vector3.one * Random.Range(0.1f, 0.6f);
        }
    }

}
