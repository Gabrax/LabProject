using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GunShooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15;
    private float nextTimeToFire = 0f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;

    public Camera cam;
    public ParticleSystem MuzzleFlash;
    public AudioSource AK47ShootingSound;
    public AudioSource AK47ReloadSound;
    public GameObject HitEffect;
    public Animator animator;
    public TextMeshProUGUI magazineText;
    public GameObject AK47;
    public GameObject M16;


    void Start()
    {
        currentAmmo = maxAmmo;
        magazineText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            AK47ReloadSound.Play();
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            AK47ShootingSound.Play();
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        UpdateAmmoText();

        if (M16 == false)
        {
            magazineText.gameObject.SetActive(true);
        }
        if (AK47 == false)
        {
            magazineText.gameObject.SetActive(true);
        }

        




    }

    void Shoot()
    {
        MuzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TargetSystem target = hit.transform.GetComponent<TargetSystem>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impact = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1f);
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(1f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    private void UpdateAmmoText()
    {
        magazineText.text = $"{currentAmmo}/{maxAmmo}";
    }
    
}

