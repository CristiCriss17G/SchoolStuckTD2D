using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointOver : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    
    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = "Points: " + PlayerPrefs.GetInt("BossScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
