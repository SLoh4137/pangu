using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class MoveCamera : MonoBehaviour
    {
        public Vector3 moveRate;

        // Update is called once per frame
        void Update()
        {
            transform.position += moveRate * Time.deltaTime;
        }
    }
}

