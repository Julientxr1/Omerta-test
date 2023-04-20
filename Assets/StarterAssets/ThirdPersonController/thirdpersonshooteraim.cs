using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using Unity.Mathematics;
using UnityEngine.InputSystem;

public class thirdpersonshooteraim : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera AimVirtualCamera;
    private StarterAssetsInputs StarterAssetsInputs;
    [SerializeField] private float Normalsensi;
    [SerializeField] private float aimsensi;
    private ThirdPersonController ThirdPersonController;
    [SerializeField] private LayerMask AimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform Debugtransform;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    private Animator Animator;

    private void Awake()
    {
        ThirdPersonController = GetComponent<ThirdPersonController>();
        StarterAssetsInputs = GetComponent<StarterAssetsInputs>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 mouseWroldPos = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f , AimColliderLayerMask))
        {
            Debugtransform.position = raycastHit.point;
            mouseWroldPos = raycastHit.point;
            hitTransform = raycastHit.transform;
        }
        if (StarterAssetsInputs.aim)
        {
            AimVirtualCamera.gameObject.SetActive(true);
            ThirdPersonController.setsentivity(aimsensi);
            ThirdPersonController.setRotateOnMove(false);
            Animator.SetLayerWeight(1,Mathf.Lerp(Animator.GetLayerWeight(1),1f,Time.deltaTime*10f));
            Vector3 worldAimtarger = mouseWroldPos;
            Vector3 aimdir = (worldAimtarger - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimdir, Time.deltaTime * 20f);
        }
        else
        {
            AimVirtualCamera.gameObject.SetActive(false);
            ThirdPersonController.setsentivity(Normalsensi );
            ThirdPersonController.setRotateOnMove(true);
            Animator.SetLayerWeight(1,Mathf.Lerp(Animator.GetLayerWeight(1),0f,Time.deltaTime*10f));
        }

        if (StarterAssetsInputs.shoot)
        {
            
            if (hitTransform!=null)
            {
                if (hitTransform.GetComponent<BulletTarget>()!=null)
                {
                    Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(vfxHitRed, transform.position, quaternion.identity);
                }
            }
            StarterAssetsInputs.shoot = false;
        }

        
    }
}
