using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int maxBullets;
    public float fireRate, reloadTime;
    
    public GameObject bulletPrefab, bulletsParent, effectModel;
    
    public TextMeshProUGUI ammoText;

    public Animator animator;
    
    public AudioSource bulletSound, reloadSound;
    
    // Private variables
    private int _currentBullets;
    private float _time;
    private bool _reloading;

    private void Start()
    {
        _currentBullets = maxBullets;
        _time = fireRate;
    }

    void Update()
    {
        _time += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(FireBullet()); 
        }

        if (Input.GetKey(KeyCode.R))
        {  
            reloadSound.Play();
            StartCoroutine(Reload());
        }
        
        if (_time >= 0.1) effectModel.SetActive(false);
        
        CountBullets();
    }

    private void CountBullets()
    {
        if (_reloading)
        {
            ammoText.text = "0/0";
        }
        else
        {
            string curBul = _currentBullets.ToString();
            string maxBul = maxBullets.ToString();
        
            ammoText.text = curBul + "/" + maxBul;
        }
        
    }

    private IEnumerator FireBullet()
    {
        if (_time >= fireRate && !_reloading && _currentBullets > 0)
        {
            animator.SetBool("shooting", true);
            _time = 0f; _currentBullets--;
            effectModel.SetActive(true);
            bulletSound.Play();
            
            GameObject bullet = Instantiate(bulletPrefab, bulletsParent.transform.position, bulletsParent.transform.rotation);

            yield return new WaitForSeconds(0.1f);
            animator.SetBool("shooting", false);
        }
    }

    private IEnumerator Reload()
    {
        _reloading = true;
        animator.SetBool("reloading", true);
        yield return new WaitForSeconds(reloadTime);
        
        _currentBullets = maxBullets;
        _reloading = false;
        animator.SetBool("reloading", false);

    }
}
