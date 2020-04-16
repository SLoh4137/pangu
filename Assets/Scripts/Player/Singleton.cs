using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Usage insiration and code from: Roundbeargames Choi https://youtu.be/8LpdxIsZlTs
*/

namespace pangu
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                    obj.name = typeof(T).ToString();
                }

                return _instance;
            }
        }
    }
}

