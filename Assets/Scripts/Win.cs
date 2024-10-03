using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public AudioSource win;

    private void Start()
    {
        win.Play();
    }
}
