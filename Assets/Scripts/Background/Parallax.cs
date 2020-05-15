using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace pangu
{
    public class Parallax : MonoBehaviour
    {
        private float lengthX, startPosX;
        private float lengthY, startPosY;
        public GameObject Cam;
        public float ParallaxEffect;
        // Start is called before the first frame update
        void Start()
        {
            startPosX = transform.position.x;
            lengthX = GetComponent<SpriteRenderer>().bounds.size.x;

            startPosY = transform.position.y;
            lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
        }

        // Update is called once per frame
        void Update()
        {
            float repeatX = (Cam.transform.position.x * (1 - ParallaxEffect));
            float distX = (Cam.transform.position.x * ParallaxEffect);

            float repeatY = (Cam.transform.position.y * (1 - ParallaxEffect));
            float distY = (Cam.transform.position.y * ParallaxEffect);
            
            transform.position = new Vector3(startPosX + distX, startPosY + distY, transform.position.z);

            if(repeatX > startPosX + lengthX) {
                startPosX += lengthX;
            } 
            else if(repeatX < startPosX - lengthX)
            {
                startPosX -= lengthX;
            }

            if(repeatY > startPosY + lengthY) {
                startPosY += lengthY;
            } 
            else if(repeatY < startPosY - lengthY)
            {
                startPosY -= lengthY;
            }
        }
    }
}

