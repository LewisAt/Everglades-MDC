using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    static bool cat = false;
    static bool Croc = false;
    static bool bass = false;
    static bool toad = false;
    static bool python = false;
    static bool mangroove = false;
    static bool litter = false;
    static bool oil = false;
    public static void ReadItem(string Name)
    {
        Debug.Log("Item Checked: " + Name);

        if (Name == "cat")
        {
            cat = true;
        }
        if (Name == "Croc")
        {
            Croc = true;
        }
        if (Name == "Fish")
        {
            bass = true;
        }
        if (Name == "toad")
        {
            toad = true;
        }
        if (Name == "python")
        {
            python = true;
        }
        if (Name == "mangroove")
        {
            mangroove = true;
        }
        if (Name == "trash")
        {
            litter = true;
        }
        if (Name == "oil")
        {
            oil = true;
        }
        if(cat && Croc && bass && toad && python && mangroove && litter && oil)
        {
            Debug.Log("You have completed the checklist");
        }

    }
}
