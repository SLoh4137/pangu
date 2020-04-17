using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class CharacterControl : MonoBehaviour
    {
        public CharacterController controller;
        public float MoveSpeed;
        public int Health;
        public float MoveHorizontal;
        public bool Jump;
        public bool Crouch;
        public bool IsGrounded;
        public GameObject GroundDetectionSpherePrefab;
        public float GroundDetectionGranularity;

        private List<GameObject> _groundDetectionSpheres;

        public List<GameObject> GroundDetectionSpheres
        {
            get { return _groundDetectionSpheres; }
        }

        public Vector3 Movement { get; set; } // so it can't be set in the Unity editor

        void Awake()
        {
            float bottom = controller.bounds.center.y - controller.bounds.extents.y;
            float left = controller.bounds.center.x - controller.bounds.extents.x;
            float right = controller.bounds.center.x + controller.bounds.extents.x;
            _groundDetectionSpheres = new List<GameObject>();

            if (_groundDetectionSpheres != null)
            {
                // A prefab given, so let's create ground detection!
                GameObject bottomLeft = CreateEdgeSphere(new Vector3(left, bottom, 0));
                GameObject bottomRight = CreateEdgeSphere(new Vector3(right, bottom, 0));

                _groundDetectionSpheres.Add(bottomLeft);
                _groundDetectionSpheres.Add(bottomRight);

                float distanceBetween = (bottomLeft.transform.position - bottomRight.transform.position).magnitude / GroundDetectionGranularity;
                for (int i = 1; i < GroundDetectionGranularity; i++) 
                {
                    Vector3 pos = bottomLeft.transform.position + Vector3.right * distanceBetween * i;

                    GameObject sphere = CreateEdgeSphere(pos);
                    _groundDetectionSpheres.Add(sphere);
                }
            }

        }

        private GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject sphere = Instantiate(GroundDetectionSpherePrefab, pos, Quaternion.identity, transform);
            return sphere;
        }

    }
}

