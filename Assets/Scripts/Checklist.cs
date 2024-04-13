using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    public static bool cat;
    public static bool Croc;
    public static bool bass;
    public static bool toad;
    public static bool Rabbit;
    public static bool python;
    public static bool mangroove;
    public static bool litter;
    public static bool oil;
    public static void ReadItem(string Name)
    {
        Debug.Log("Item Checked: " + Name);

        if (Name == "Cat")
        {
            cat = true;
            Debug.Log("Checked: Cat");
        }
        if (Name == "Aligator")
        {
            Croc = true;
            Debug.Log("Checked: Aligator");
        }
        if (Name == "Fish")
        {
            bass = true;
            Debug.Log("Checked: Fish");
        }
        if (Name == "Frog")
        {
            toad = true;
            Debug.Log("Checked: Frog");
        }
        if (Name == "Python")
        {
            python = true;
            Debug.Log("Checked: Python");
        }
        if (Name == "Rabbit")
        {
            Rabbit = true;
            Debug.Log("Checked: Rabbit");
        }
        if (Name == "mangroove")
        {
            mangroove = true;
            Debug.Log("Checked: mangroove");
        }
        if (Name == "trash")
        {
            litter = true;
            Debug.Log("Checked: trash");
        }
        if (Name == "Oil")
        {
            oil = true;
            Debug.Log("Checked: oil " + oil);
        }


    }
}
