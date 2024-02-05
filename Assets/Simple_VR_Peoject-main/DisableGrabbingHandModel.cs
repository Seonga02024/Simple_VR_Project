using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        // 객체를 잡을 때 이벤트 호출
        grabInteractable.selectEntered.AddListener(HideGrabbinghand);
        // 객체를 잡은 것을 놓을 때 호출
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    public void HideGrabbinghand(SelectEnterEventArgs args){
        if(args.interactorObject.transform.tag == "Left Hand"){
            leftHandModel.SetActive(false);
        }else if(args.interactorObject.transform.tag == "Right Hand"){
            rightHandModel.SetActive(false);
        }
    }

    public void ShowGrabbingHand(SelectExitEventArgs args){
        if(args.interactorObject.transform.tag == "Left Hand"){
            leftHandModel.SetActive(true);
        }else if(args.interactorObject.transform.tag == "Right Hand"){
            rightHandModel.SetActive(true);
        }
    }
}
