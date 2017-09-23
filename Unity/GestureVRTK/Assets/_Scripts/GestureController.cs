﻿using System;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GestureController : MonoBehaviour {

    public string selectedPose;
    public List<GesturePose> Poses;

    public GesturePose targetPose = null;

    private Transform thumb1;
    private Transform thumb2;
    private Transform thumb3;
    private Transform index1;
    private Transform index2;
    private Transform index3;
    private Transform middle1;
    private Transform middle2;
    private Transform middle3;
    private Transform ring1;
    private Transform ring2;
    private Transform ring3;
    private Transform pinky1;
    private Transform pinky2;
    private Transform pinky3;

    private bool changePose = false;

    public bool triggerPressed = false;
    public bool gripPressed = false;
    public bool touchIndex = false;
    public bool touchThumb = false;

    public float smoothness = 20.0f;

    // Use this for initialization
    void Start () {

        targetPose = Poses.Find(r => r.Name.Equals("Open"));
        selectedPose = targetPose.Name;
        
        foreach(var transform in gameObject.GetComponentsInChildren<Transform>())
        {
            switch(transform.name)
            {
                case "Thumb_1":
                    thumb1 = transform;
                    break;

                case "Thumb_2":
                    thumb2 = transform;
                    break;

                case "Thumb_3":
                    thumb3 = transform;
                    break;

                case "Index_1":
                    index1 = transform;
                    break;

                case "Index_2":
                    index2 = transform;
                    break;

                case "Index_3":
                    index3 = transform;
                    break;

                case "Middle_1":
                    middle1 = transform;
                    break;

                case "Middle_2":
                    middle2 = transform;
                    break;

                case "Middle_3":
                    middle3 = transform;
                    break;

                case "Ring_1":
                    ring1 = transform;
                    break;

                case "Ring_2":
                    ring2 = transform;
                    break;

                case "Ring_3":
                    ring3 = transform;
                    break;

                case "Pinky_1":
                    pinky1 = transform;
                    break;

                case "Pinky_2":
                    pinky2 = transform;
                    break;

                case "Pinky_3":
                    pinky3 = transform;
                    break;

            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        ApplyPose();        
    }

    public void SelectPose(string poseName)
    {
        var pose = Poses.Find(r => r.Name.Equals(poseName));
        if (pose != null)
        {
            targetPose = pose;
        }
        selectedPose = targetPose.Name;
        changePose = true;
    }

    public void ApplyPose()
    {
        //if (!changePose)
        //{
        //    return;
        //}

        if (thumb1 == null)
        {
            return;
        }
        
        thumb1.localEulerAngles = LerpTransform(thumb1, targetPose.RotateThumb.x, null, targetPose.SlideThumb);
        thumb2.localEulerAngles = LerpTransform(thumb2, targetPose.RotateThumb.y, null, null);
        thumb3.localEulerAngles = LerpTransform(thumb2, targetPose.RotateThumb.z, null, null);

        index1.localEulerAngles = LerpTransform(index1, targetPose.RotateIndex.x, targetPose.SlideIndex, null);
        index2.localEulerAngles = LerpTransform(index2, targetPose.RotateIndex.y, null, null);
        index3.localEulerAngles = LerpTransform(index3, targetPose.RotateIndex.z, null, null);

        middle1.localEulerAngles = LerpTransform(middle1, targetPose.RotateMiddle.x, targetPose.SlideMiddle, null);
        middle2.localEulerAngles = LerpTransform(middle2, targetPose.RotateMiddle.y, null, null);
        middle3.localEulerAngles = LerpTransform(middle3, targetPose.RotateMiddle.z, null, null);

        ring1.localEulerAngles = LerpTransform(ring1, targetPose.RotateRing.x, targetPose.SlideRing, null);
        ring2.localEulerAngles = LerpTransform(ring2, targetPose.RotateRing.y, null, null);
        ring3.localEulerAngles = LerpTransform(ring3, targetPose.RotateRing.z, null, null);

        pinky1.localEulerAngles = LerpTransform(pinky1, targetPose.RotatePinky.x, targetPose.SlidePinky, null);
        pinky2.localEulerAngles = LerpTransform(pinky2, targetPose.RotatePinky.y, null, null);
        pinky3.localEulerAngles = LerpTransform(pinky3, targetPose.RotatePinky.z, null, null);


        //thumb1.localEulerAngles = new Vector3(targetPose.SlideThumb, -95.39f, targetPose.RotateThumb.x);
        //thumb2.localEulerAngles = new Vector3(2.496f, -1.409f, targetPose.RotateThumb.y);
        //thumb3.localEulerAngles = new Vector3(-8.5080f, -5.3480f, targetPose.RotateThumb.z);

        //index1.localEulerAngles = new Vector3(1.329f, 0f, targetPose.RotateIndex.x);
        //index2.localEulerAngles = new Vector3(0.033f, 3.075f, targetPose.RotateIndex.y);
        //index3.localEulerAngles = new Vector3(0.026f, 4.108f, targetPose.RotateIndex.z);

        //middle1.localEulerAngles = new Vector3(-4.0270f, 5.696f, targetPose.RotateMiddle.x);
        //middle2.localEulerAngles = new Vector3(0.112f, 0.494f, targetPose.RotateMiddle.y);
        //middle3.localEulerAngles = new Vector3(0.005f, 0.317f, targetPose.RotateMiddle.z);

        //ring1.localEulerAngles = new Vector3(-0.46f, 3.836f, targetPose.RotateRing.x);
        //ring2.localEulerAngles = new Vector3(-0.035f, -1.099f, targetPose.RotateRing.y);
        //ring3.localEulerAngles = new Vector3(0.088f, 7.936f, targetPose.RotateRing.z);

        //pinky1.localEulerAngles = new Vector3(10f, -6.411f, targetPose.RotatePinky.x);
        //pinky2.localEulerAngles = new Vector3(-1.631f, 4.197f, targetPose.RotatePinky.y);
        //pinky3.localEulerAngles = new Vector3(0.209f, -2.287f, targetPose.RotatePinky.z);

        changePose = false;
    }

    private Vector3 LerpTransform(Transform transform, float zAxis, float? yAxis, float? xAxis)
    {
        var currentRotation = transform.localEulerAngles;
        if (xAxis != null)
        {
            currentRotation.x = Mathf.LerpAngle(currentRotation.x, (float)xAxis, Time.deltaTime * smoothness);
        }
        if (yAxis != null)
        {
            currentRotation.y = Mathf.LerpAngle(currentRotation.y, (float)yAxis, Time.deltaTime * smoothness);
        }
        currentRotation.z = Mathf.LerpAngle(currentRotation.z, zAxis, Time.deltaTime * smoothness);
        return currentRotation;
    }
}
