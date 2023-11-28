using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public struct HandCommand 
{
    public float thumbTouchedCommand;
    public float indexTouchedCommand;
    public float gripCommand;
    public float triggerCommand;
    public int poseCommand;
    public float pinchCommand;
}


public class HardwareHand : MonoBehaviour
{
    public RigPart side;
    // public HandCommand handCommand;
    //
    public bool isGrabbing;
    // public Grabber grabber;
    //
    // public InputActionProperty thumbAction;
    // public InputActionProperty gripAction;
    // public InputActionProperty triggerAction;
    // public InputActionProperty indexAction;
    // public int handPose = 0;
    // public InputActionProperty grabAction;
    // public float grabThreshold = 0.5f;
    // public bool updateGrabWithAction = true;
    //
    // public IHandRepresentation localHandRepresentation;

    private void Awake()
    {
        // thumbAction.EnableWithDefaultXRBindings(side: side, new List<string> { "thumbstickTouched", "primaryTouched", "secondaryTouched" });
        // gripAction.EnableWithDefaultXRBindings(side: side, new List<string> { "grip" });
        // triggerAction.EnableWithDefaultXRBindings(side: side, new List<string> { "trigger" });
        // indexAction.EnableWithDefaultXRBindings(side: side, new List<string> { "triggerTouched" });
        // gripAction.EnableWithDefaultXRBindings(side: side, new List<string> { "grip" });
        // // We separate the hand grip action and the grab interaction action, as we may want to use different action for some hardware
        // grabAction.EnableWithDefaultXRBindings(side: side, new List<string> { "grip" });
        //
        // grabber = GetComponentInChildren<Grabber>();
        // localHandRepresentation = GetComponentInChildren<IHandRepresentation>();
    }
    
    // protected virtual void Update()
    // {
    //     // update hand pose
    //     handCommand.thumbTouchedCommand = thumbAction.action.ReadValue<float>();
    //     handCommand.indexTouchedCommand = indexAction.action.ReadValue<float>();
    //     handCommand.gripCommand = gripAction.action.ReadValue<float>();
    //     handCommand.triggerCommand = triggerAction.action.ReadValue<float>();
    //     handCommand.poseCommand = handPose;
    //     handCommand.pinchCommand = 0;
    //
    //     // update hand interaction
    //     if(updateGrabWithAction) isGrabbing = grabAction.action.ReadValue<float>() > grabThreshold;
    //     if (localHandRepresentation != null) localHandRepresentation.SetHandCommand(handCommand);
    // }
}
