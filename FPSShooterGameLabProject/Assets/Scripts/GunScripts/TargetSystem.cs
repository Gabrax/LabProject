using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSystem : MonoBehaviour
{
    public Image frontHealthBar;
    public Image Frame;
    private float health;
    private float lerpTimer;
    public float chipseed = 2f;
    public float maxHealth = 100f;
    public AudioSource dying;

    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        UpdateHealthUI();
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f )
        {
            Die();
            dying.Play();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    public void UpdateHealthUI()
    {

        float fillF = frontHealthBar.fillAmount;
        float fillB = Frame.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            Frame.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipseed;
            percentComplete = percentComplete * percentComplete;
            Frame.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            Frame.color = Color.green;
            Frame.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipseed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, Frame.fillAmount, percentComplete);
        }
    }
}
