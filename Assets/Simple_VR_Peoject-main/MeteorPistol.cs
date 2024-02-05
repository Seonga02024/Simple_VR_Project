using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;
    public LayerMask layerMask;
    public Transform shootSource;
    public float distance = 10;

    private bool rayActive = false;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        // 사용자가 트리거를 눌렸을 때
        grabInteractable.activated.AddListener(x => StartShoot());
        // 사용자가 트리거를 눌렸다가 놓았을 때
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }

    public void StartShoot(){
        particles.Play();
        rayActive = true;
    }

    public void StopShoot(){
        // 공중에 있는 파티클 입자 모두 제거
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActive = false;
    }

    void Update(){
        if(rayActive) RaycastCheak();
    }

    void RaycastCheak(){
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, layerMask);

        if(hasHit){
            // Breakable 의 Break 함수 호출
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
