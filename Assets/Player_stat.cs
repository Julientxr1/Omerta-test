using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_stat : MonoBehaviour
{
    [SerializeField] private float maxhealth = 100f;
    [SerializeField] private float currenthealth;
    [SerializeField] private Image Healthbarfill;
    
    void Awake()
    {
        currenthealth = maxhealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(15);
        }

        if (currenthealth<=0)
        {
            Destroy(gameObject);
        }

        
    }

    void TakeDamage(float dmg)
    {
        currenthealth -= dmg;
        updatefill();
        
    }

    void updatefill()
    {
        Healthbarfill.fillAmount = currenthealth / maxhealth;
    }
}
