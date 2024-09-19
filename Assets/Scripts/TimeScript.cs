using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    private float _time = 120f;
    
    public TextMeshProUGUI timeText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        
        timeText.text = "Time: " + _time.ToString("0");

        if (_time <= 0)
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
