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
        
        if (Input.GetMouseButtonDown(0)) FireBullet();
        if (Input.GetKey(KeyCode.R)) StartCoroutine(Reload());
        
        if (_time >= 0.1) effectModel.SetActive(false);
        
        CountBullets();
    }

    private void CountBullets()
    {
        if (_reloading)
        {
            ammoText.text = "Reloading...";
        }
        else
        {
            string curBul = _currentBullets.ToString();
            string maxBul = maxBullets.ToString();
        
            ammoText.text = curBul + "/" + maxBul;
        }
        
    }

    private void FireBullet()
    {
        if (_time >= fireRate && !_reloading && _currentBullets > 0)
        {
            _time = 0f; _currentBullets--;
            effectModel.SetActive(true);
            GameObject bullet = Instantiate(bulletPrefab, bulletsParent.transform.position, bulletsParent.transform.rotation);
        }

        
    }

    private IEnumerator Reload()
    {
        _reloading = true;
        yield return new WaitForSeconds(reloadTime);
        
        _currentBullets = maxBullets;
        _reloading = false;
    }
}
