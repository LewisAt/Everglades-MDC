using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCountText : MonoBehaviour
{
    public Text AligatorCountText;
    public Text PythonCountText;
    public Text FrogCountText;
    public Text FishCountText;
    public Text CatCountText;
    public Text RabbitCountText;

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
        AligatorCountText.text = AligatorCountNumber.ToString();
        PythonCountText.text = PythonCountNumber.ToString();
        FrogCountText.text = FrogCountNumber.ToString();
        FishCountText.text = FishCountNumber.ToString();
        CatCountText.text = CatCountNumber.ToString();
        RabbitCountText.text = RabbitCountNumber.ToString();







    }   
}       
