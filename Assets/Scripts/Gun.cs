using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int maxBullets;
    public float fireRate, reloadTime;
    
    public GameObject bulletPrefab, effectModel;

    public Transform firePoint;
    
    public TextMeshProUGUI ammoText;
    
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
        RaycastHit hit;

        if (Physics.Raycast(firePoint.transform.position, transform.TransformDirection(Vector3.forward), out hit, 9999))
        {
            Debug.DrawRay(firePoint.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

            if (hit.transform.CompareTag("Target"))
            {
                Destroy(hit.transform.parent.parent.gameObject);
            }
        }
        
        _time += Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) FireBullet(); 

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
            ammoText.text = "Reloading...";
        }
        else
        {
            string curBul = _currentBullets.ToString();
            string maxBul = maxBullets.ToString();
        
            ammoText.text = "Ammo: " + curBul + "/" + maxBul;
        }
    }

    private void FireBullet()
    {
        if (_time >= fireRate && !_reloading && _currentBullets > 0)
        {
            bulletSound.Play();
            _time = 0f; _currentBullets--;
            effectModel.SetActive(true);

            RaycastHit hit;

            if (Physics.Raycast(firePoint.transform.position, transform.TransformDirection(Vector3.forward), out hit, 9999))
            {
                Debug.DrawRay(firePoint.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            }
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
