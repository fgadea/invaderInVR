using UnityEngine;
using System.Collections;

namespace CubeSpaceFree
{
    // Destroy object after lifetime has passed.
    public class DestroyByTime : MonoBehaviour
    {

        public float lifetime;
        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, lifetime);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}