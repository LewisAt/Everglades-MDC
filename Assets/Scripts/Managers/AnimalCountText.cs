using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCountText : MonoBehaviour
{
    private int AligatorCountNumber;
    private int PythonCountNumber;
    private int FrogCountNumber;
    private int FishCountNumber;
    private int CatCountNumber;
    private int RabbitCountNumber;

    private void Update()
    {

        if(AligatorCountText != null)
        {
            updateAnimalCountText();

        }

    }
    private void FixedUpdate()
    {
        AligatorCountNumber = TrackAnimalCount.ReturnCount("Aligator");
        PythonCountNumber = TrackAnimalCount.ReturnCount("Python");
        FrogCountNumber = TrackAnimalCount.ReturnCount("Frog");
        FishCountNumber = TrackAnimalCount.ReturnCount("Fish");
        CatCountNumber = TrackAnimalCount.ReturnCount("Cat");
        RabbitCountNumber = TrackAnimalCount.ReturnCount("Rabbit");
    }
    void updateAnimalCountText()
    {
        
    }   
}       
