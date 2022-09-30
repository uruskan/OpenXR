using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class GiveValue : MonoBehaviour
{

    public XRNode leftHandNode;
    public XRNode rightHandNode;
    public Animator LeftHandAnimator;
    public Animator RightHandAnimator;

    //Left Hand
    [HideInInspector] public Vector2 leftAxis2D;

    // Start is called before the first frame update
    void Start()
    {


    }


    void UpdateHandAnimation()
    {
        InputDevice leftHandDevice = InputDevices.GetDeviceAtXRNode(leftHandNode);
        InputDevice rightHandDevice = InputDevices.GetDeviceAtXRNode(rightHandNode);

        //Left Hand Animator

        if (leftHandDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            LeftHandAnimator.SetFloat("Trigger", triggerValue);
        else
            LeftHandAnimator.SetFloat("Trigger", 0);

        if (leftHandDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            LeftHandAnimator.SetFloat("Grip", gripValue);
        else
            LeftHandAnimator.SetFloat("Grip", 0);

        //Right Hand Animator

        if (rightHandDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue2) && triggerValue2 > 0.1f)
            RightHandAnimator.SetFloat("Trigger", triggerValue2);
        else
            RightHandAnimator.SetFloat("Trigger", 0);

        if (rightHandDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue2) && gripValue2 > 0.1f)
            RightHandAnimator.SetFloat("Grip", gripValue2);
        else
            RightHandAnimator.SetFloat("Grip", 0);

    } 

    void Update()
    {
        InputDevice leftHandDevice = InputDevices.GetDeviceAtXRNode(leftHandNode);
        InputDevice rightHandDevice = InputDevices.GetDeviceAtXRNode(rightHandNode);
        
        UpdateHandAnimation();
        // Left Hand
        if (leftHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
            Debug.Log("Pressing primary button" + primaryButtonValue);

        if (leftHandDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            Debug.Log("Trigger pressed " + triggerValue);

        if (leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
            Debug.Log("Joystick pressed " + primary2DAxisValue);

        //Right Hand
        if (rightHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue2) && primaryButtonValue2)
            Debug.Log("Pressing primary button " + primaryButtonValue2);

        if (rightHandDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue2) && triggerValue2 > 0.1f)
            Debug.Log("Trigger pressed " + triggerValue2);

        if (rightHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue2) && primary2DAxisValue2 != Vector2.zero)
            Debug.Log("Joystick pressed " + primary2DAxisValue2);
    }
}
