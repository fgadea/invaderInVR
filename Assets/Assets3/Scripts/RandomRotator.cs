using UnityEngine;
using System.Collections;

namespace CubeSpaceFree
{
    // Rotates an object
    public class RandomRotator : MonoBehaviour
    {
        public float tumble;

        // Use this for initialization
        void Start()
        {
            GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        }
    }
}
