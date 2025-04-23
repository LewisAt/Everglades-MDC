//Ian Marshburn
//Script handles the collection menu and collectable storage
//Pressing buttons will cycle through the collection, showing different figurines and infographics
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CollectablesPair
{
    public GameObject collectionFigurine;
    public GameObject collectionInfographic;

    //constructor
    public CollectablesPair(GameObject figure, GameObject info)
    {
        collectionFigurine = figure;
        collectionInfographic = info;
    }

    public void ActivateCollectable()
    {
        collectionFigurine.SetActive(true);
        collectionInfographic.SetActive(true);
    }
    public void DeactivateCollectable()
    {
        collectionFigurine.SetActive(false);
        collectionInfographic.SetActive(false);
    }
}

public class CollectionManager : MonoBehaviour
{
    //used for positioning the collection objects
    public GameObject figureSpawn, panelSpawn;

    //the collection to be maintained at runtime
    public List<CollectablesPair> collection = new List<CollectablesPair>();
    public CollectablesPair defaultValue;

    public int currentCollectionIndex = 0;

    //check something whenever the collection is opened
    private void OnEnable()
    {
        if (collection.Count <= 0)
        {
            defaultValue.ActivateCollectable();
        }
        else
        {
            defaultValue.DeactivateCollectable();
            collection[currentCollectionIndex].ActivateCollectable();
        }

    }

    //only call this on the first interaction with each object
    public void AddToCollection(GameObject figure, GameObject infoPanel)
    {
        //make a new collection pair with instances in the scene
        CollectablesPair newPair = new CollectablesPair(Instantiate(figure, figureSpawn.transform), Instantiate(infoPanel, panelSpawn.transform));

        //disable new pair
        newPair.DeactivateCollectable();

        collection.Add(newPair);
    }

    //should we instantiate or enable?
    public void CycleCollectionList(bool moveListForward)
    {
        if (collection.Count <= 0)
        {
            return;
        }
        else
        {
            if (moveListForward)
            {
                //deactivate the prior collectable
                collection[currentCollectionIndex].DeactivateCollectable();
                //move index forward
                currentCollectionIndex++;
                if (currentCollectionIndex > collection.Count - 1)
                {//cycle back to beginning of list if at end
                    currentCollectionIndex = 0;
                }
                //activate new current item
                collection[currentCollectionIndex].ActivateCollectable();
            }
            else
            {
                //deactivate the prior collectable
                collection[currentCollectionIndex].DeactivateCollectable();
                //move index back
                currentCollectionIndex--;
                if (currentCollectionIndex < 0)
                {//cycle back to end of list if at beginning
                    currentCollectionIndex = collection.Count - 1;
                }
                //activate new current item
                collection[currentCollectionIndex].ActivateCollectable();
            }
        }

    }
}
