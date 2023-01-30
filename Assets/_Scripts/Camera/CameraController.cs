using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DigitJump.CameraController
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float minValue;
        private bool _canCameraMove;

        [SerializeField] private CameraControlSettings cameraControlSettings;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Transform cameraTransform;


        private void Update()
        {
            CameraMovementFollow();
            //CameraRotationFollow();
        }

        private void CameraRotationFollow()
        {
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation,
                Quaternion.LookRotation(targetTransform.position - cameraTransform.position)
                , Time.deltaTime * cameraControlSettings.RotationLerpSpeed);
        }

        private void CameraMovementFollow()
        {
            if (!_canCameraMove) return;

            cameraTransform.position = Vector3.Lerp(cameraTransform.position,
                targetTransform.position + cameraControlSettings.PositionOffset,
                Time.deltaTime * cameraControlSettings.PositionLerp);
        }
        
    }
}