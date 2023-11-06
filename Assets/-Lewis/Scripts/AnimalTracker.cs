using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTracker : MonoBehaviour
{
    public static List<GameObject> fishCount;
    public static List<GameObject> AligatorCount;
    public static List<GameObject> FrogCount;
    public static List<GameObject> PythonCount;
    public static void addAnimal(GameObject AnimalObject)
    {
        if (AnimalObject.tag == "Fish")
        {

            fishCount.Add(AnimalObject);
        }
        else if (AnimalObject.tag == "Aligator")
        {
            AligatorCount.Add(AnimalObject);

        }
        else if (AnimalObject.tag == "Frog")
        {
            FrogCount.Add(AnimalObject);

        }
        else if (AnimalObject.tag == "Python")
        {
            PythonCount.Add(AnimalObject);

        }
    }
    public static void RemoveAnimal(GameObject AnimalObject)
    {

        
    }
    
    public static void FindAnimal()
    {

    }
}
