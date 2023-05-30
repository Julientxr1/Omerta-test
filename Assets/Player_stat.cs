using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_stat : MonoBehaviour
{
    [SerializeField] public  float maxhealth = 100f;
    [SerializeField] public  float currenthealth;
    [SerializeField] public  Image Healthbarfill;
    
    void Awake()
    {
        currenthealth = maxhealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            TakeDamage(15);
        }

        if (currenthealth<=0)
        {
            Destroy(gameObject);
        }

        
    }

    public  void TakeDamage(float dmg)
    {
        currenthealth -= dmg;
        updatefill();
        
    }

    public void updatefill()
    {
        Healthbarfill.fillAmount = currenthealth / maxhealth;
    }
}
