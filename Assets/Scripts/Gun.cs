using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    public int maxBullets;
    public float fireRate, reloadTime;

    private float elapsedtime = 0f;

    public GameObject bulletPrefab, effectModel;

    public Transform firePoint;

    public TextMeshProUGUI ammoText, pointText, leaderboard;

    public static float[] boardvalues = new float[10];

    public Animator animator;

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
        getLeaderboard();
    }

    void Update()
    {
        _time += Time.deltaTime;
        elapsedtime += Time.deltaTime;

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
        CheckWin();
        
        
    }

    public void getLeaderboard()
    {
        for (int i = 0; i < 10; i++)
        {
            if (boardvalues[i] != 0)
            {
                leaderboard.text += i + 1 + ". " + boardvalues[i].ToString("0.00") + " seconds\n";
            }
            else break;
        }
    }

    private void CheckWin()
    {
        pointText.text = "Points: " + _points.ToString();
        if (_points >= 7)
        {
            for (int i = 9; i > 0; i--)
            {
                if (elapsedtime < boardvalues[i] && elapsedtime > boardvalues[i-1])
                {
                    boardvalues[i] = elapsedtime;
                    break;
                }
                else
                {
                    boardvalues[i-1] = boardvalues[i];
                }
            }
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("WinScreen");
        }
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

            yield return new WaitForSeconds(0.1f);
            animator.SetBool("shooting", false);
        }
        else if (_currentBullets == 0)
        {
            emptySound.Play();
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
