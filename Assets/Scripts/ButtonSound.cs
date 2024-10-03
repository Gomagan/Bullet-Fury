using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource sound;

    public void HoverSound()
    {
        sound.Play();
    }
}
