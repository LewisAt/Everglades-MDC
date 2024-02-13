using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCountText : MonoBehaviour
{
    public Slider AligatorCountText;
    public Slider PythonCountText;
    public Slider FrogCountText;
    public Slider FishCountText;
    public Slider CatCountText;
    public Slider RabbitCountText;

    private int AligatorCountNumber;
    private int PythonCountNumber;
    private int FrogCountNumber;
    private int FishCountNumber;
    private int CatCountNumber;
    private int RabbitCountNumber;

    private void Update()
    {
        updateAnimalCountText();
    }
    private void FixedUpdate()
    {
        AligatorCountNumber = GameObject.FindGameObjectsWithTag("Aligator").Length;
        PythonCountNumber = GameObject.FindGameObjectsWithTag("Python").Length;
        FrogCountNumber = GameObject.FindGameObjectsWithTag("Frog").Length;
        FishCountNumber = GameObject.FindGameObjectsWithTag("Fish").Length;
        CatCountNumber = GameObject.FindGameObjectsWithTag("Cat").Length;
        RabbitCountNumber = GameObject.FindGameObjectsWithTag("Rabbit").Length;
    }
    void getNumberOfAnimals()
    {

    }
    void updateAnimalCountText()
    {
        AligatorCountText.value = AligatorCountNumber;
        PythonCountText.value = PythonCountNumber;
        FrogCountText.value = FrogCountNumber;
        FishCountText.value = FishCountNumber;
        CatCountText.value = CatCountNumber;
        RabbitCountText.value = RabbitCountNumber;
    }   
}       
