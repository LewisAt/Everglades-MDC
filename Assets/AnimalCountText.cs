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

    private void Update()
    {
        updateAnimalCountText();

    }
    void updateAnimalCountText()
    {
        AligatorCountText.text = TrackAnimalCount.AligatorCount.ToString();
        PythonCountText.text = TrackAnimalCount.PythonCount.ToString();
        FrogCountText.text = TrackAnimalCount.FrogCount.ToString();
        FishCountText.text = TrackAnimalCount.fishCount.ToString();
    }
}
