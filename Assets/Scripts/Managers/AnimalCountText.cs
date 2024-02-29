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

    private int[] animalCounts;
    private int checker = 0;

    private void Update()
    {
        animalCounts[0] = AligatorCountNumber;
        animalCounts[1] = PythonCountNumber;
        animalCounts[2] = FrogCountNumber;
        animalCounts[3] = FishCountNumber;
        animalCounts[4] = CatCountNumber;
        animalCounts[5] = RabbitCountNumber;

        updateAnimalCountText();

        for (int i = 0; i < animalCounts.Length; i++)
        {
            
        }
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
