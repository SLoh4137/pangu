using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace pangu
{
    public class FaceTowardsMouse : MonoBehaviour
    {
        private Camera camera;

        void Awake()
        {
            camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            // Vector3 mousePos = new Vector3(Mouse.current.position.x, Mouse.current.position.y, 0);
            // mousePos = camera.ScreenToWorldPoint(Mouse.current.position);
            // Vector3 perpendicular = Vector3.Cross(transform.position - mousePos, Vector3.forward);
            // transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
        }
    }
}

