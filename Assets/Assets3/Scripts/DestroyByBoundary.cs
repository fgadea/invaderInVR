using UnityEngine;
using System.Collections;

// Heavily based on Unity Space Shooter tutorial
namespace CubeSpaceFree
{
    public class DestroyByBoundary : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);

        }
    }
}