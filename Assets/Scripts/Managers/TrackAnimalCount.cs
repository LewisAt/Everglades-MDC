using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAnimalCount : MonoBehaviour
{
    public static int fishCount = 0;
    public static int AligatorCount = 0;
    public static int FrogCount = 0;
    public static int PythonCount = 0;
    public static int CatCount = 0;
    public static int RabbitCount = 0;
    public static void RemoveFromCount(string animalTagName)
    {
        if(animalTagName == "Fish")
        {
            fishCount --;
        }
        else if (animalTagName == "Aligator")
        {
            AligatorCount--;
        }
        else if (animalTagName == "Frog")
        {
            FrogCount--;
        }
        else if (animalTagName == "Python")
        {
            PythonCount--;
        }
        else if (animalTagName == "Cat")
        {
            CatCount--;
        }
        else if (animalTagName == "Rabbit")
        {
            RabbitCount--;
        }
    }
    public static void addtoPopulationCount(string animalTagName)
    {
        if (animalTagName == "Fish")
        {
            fishCount ++;
        }
        else if (animalTagName == "Aligator")
        {
            AligatorCount++;
        }
        else if (animalTagName == "Frog")
        {
            FrogCount++;
        }
        else if (animalTagName == "Python")
        {
            PythonCount++;
        }
        else if (animalTagName == "Cat")
        {
            CatCount++;
        }
        else if (animalTagName == "Rabbit")
        {
            RabbitCount++;
        }
       
    }
    public static int ReturnCount(string animalTagName)
    {
        if (animalTagName == "Fish")
        {
            return fishCount;
        }
        else if (animalTagName == "Aligator")
        {
            return AligatorCount;

        }
        else if (animalTagName == "Frog")
        {
            return FrogCount;

        }
        else if (animalTagName == "Python")
        {
            return PythonCount;

        }
        else if (animalTagName == "Cat")
        {
            return CatCount;
        }
        else if (animalTagName == "Rabbit")
        {
            return RabbitCount;
        }
        return 0;
    }


}
