using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public AudioSource lose;

    private void Start()
    {
        lose.Play();
    }
}
