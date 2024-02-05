using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpaceOutSidecontroller : MonoBehaviour
{
    public XRLever lever;
    public XRKnob knob;

    public float forwardSpeed;
    public float sideSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardVelocity = forwardSpeed * (lever.value ? 1 : 0);
        // Mathf.Lerp(-1, 1, knob.value) knob.value : 0 ~ 1 이지만 -1 ~ 1로 값 주도록 바꿈
        float sideVelocity = sideSpeed * (lever.value ? 1: 0) * Mathf.Lerp(-1, 1, knob.value);

        Vector3 velocity = new Vector3(sideVelocity, 0, forwardVelocity);
        transform.position += velocity * Time.deltaTime;
    }
}
