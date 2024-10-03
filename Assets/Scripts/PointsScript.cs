using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsScript : MonoBehaviour
{
    public int points;
    public TextMeshProUGUI pointsText;


    public GameObject[] targets;
    
    private bool _pointsSet1, _pointsSet2, _pointsSet3, _pointsSet4, _pointsSet5;
    void Update()
    {
        pointsText.text = "Points: " + points.ToString();

        if (points >= 5)
        {
            SceneManager.LoadScene("WinScreen");
            Cursor.lockState = CursorLockMode.None;
        }
        
        if (targets[0].IsDestroyed())
        {
            if (_pointsSet1 == false)
            {
                _pointsSet1 = true;
                points += 1;
            }
        }

        if (targets[1].IsDestroyed())
        {
            if (_pointsSet2 == false)
            {
                _pointsSet2 = true;
                points+= 1;
            }
        }
        
        if (targets[2].IsDestroyed())
        {
            if (_pointsSet3 == false)
            {
                _pointsSet3 = true;
                points+= 1;
            }
        }
        
        if (targets[3].IsDestroyed())
        {
            if (_pointsSet4 == false)
            {
                _pointsSet4 = true;
                points+= 1;
            }
        }
        
        if (targets[4].IsDestroyed())
        {
            if (_pointsSet5 == false)
            {
                _pointsSet5 = true;
                points+= 1;
            }
        }
    }
}
