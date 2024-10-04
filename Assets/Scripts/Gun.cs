using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    public int maxBullets;
    public float fireRate, reloadTime;
    
    public GameObject bulletPrefab, effectModel;

    public Transform firePoint;
    
    public TextMeshProUGUI ammoText, pointText;
    
    public AudioSource bulletSound, reloadSound, emptySound;
    
    // Private variables
    private int _currentBullets, _points;
    private float _time;
    private bool _reloading;

    private void Start()
    {
        _currentBullets = maxBullets;
        _time = fireRate;
        _points = 0;
    }

    void Update()
    {
        _time += Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) FireBullet(); 

        if (Input.GetKey(KeyCode.R))
        {
            reloadSound.Play();
            StartCoroutine(Reload());
        }
        
        if (_time >= 0.1) effectModel.SetActive(false);
        
        CountBullets();
        CheckWin();
    }

    private void CheckWin()
    {
        pointText.text = "Points: " + _points.ToString();
        if (_points >= 7)
        {
            SceneManager.LoadScene("WinScreen");
        }
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

                if (hit.transform.CompareTag("Target"))
                {
                    Destroy(hit.transform.parent.parent.gameObject);
                    _points += 1;
                }
            }
        }
        else
        {
            emptySound.Play();
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
