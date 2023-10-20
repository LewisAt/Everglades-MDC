using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayGeneralInfo : MonoBehaviour
{
    public Text Frog;
    public Text Ali;
    public Text Fish;

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Frog.text = TrackAnimalCount.FrogCount.ToString();
        Ali.text = TrackAnimalCount.AligatorCount.ToString();
        Fish.text = TrackAnimalCount.fishCount.ToString();
    }
}
