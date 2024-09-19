using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    
    public GameObject[] target;
    public int targetType;

    private float _time;
    private bool _timeUp;
    
    void Start()
    {
        _time = 0;
    }
    void Update()
    {
        _time += Time.deltaTime;

        if (targetType == 1)
        {
            if (_time <= 1f)
            {
                spriteRenderer.sprite = sprites[0];
                target[0].SetActive(true);
                target[1].SetActive(false);
                target[2].SetActive(false);
            }
            else if (_time <= 2f)
            {
                spriteRenderer.sprite = sprites[1];
                target[0].SetActive(false);
                target[1].SetActive(true);
                target[2].SetActive(false);
            }
            else if (_time <= 3f)
            {
                spriteRenderer.sprite = sprites[2];
                target[0].SetActive(false);
                target[1].SetActive(false);
                target[2].SetActive(true);
            }
            else if (_time <= 4f)
            {
                spriteRenderer.sprite = sprites[1];
                target[0].SetActive(false);
                target[1].SetActive(true);
                target[2].SetActive(false);
            }
            else if (_time <= 5f)
            {
                spriteRenderer.sprite = sprites[0];
                target[0].SetActive(true);
                target[1].SetActive(false);
                target[2].SetActive(false);
                _time = 0f;
            }
        }
        else
        {
            if (_time <= 1f)
            {
                spriteRenderer.sprite = sprites[0];
                target[0].SetActive(true);
                target[1].SetActive(false);
            }
            else if (_time <= 2f)
            {
                spriteRenderer.sprite = sprites[1];
                target[0].SetActive(false);
                target[1].SetActive(true);
            }
            else if (_time <= 3f)
            {
                spriteRenderer.sprite = sprites[0];
                target[0].SetActive(true);
                target[1].SetActive(false);
                _time = 0f;
            }
        }
        
    }
}
