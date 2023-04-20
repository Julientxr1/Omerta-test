using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_stat : MonoBehaviour
{
    [SerializeField] private float maxhealth = 100f;
    [SerializeField] private float currenthealth;
    [SerializeField] private Image Healthbarfill;
    public Animator Animator;
    void Awake()
    {
        currenthealth = maxhealth;
        Animator = GetComponent<Animator>();
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
            Animator.SetBool("IsDead",true);
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
