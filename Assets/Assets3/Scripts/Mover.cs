using UnityEngine;
using System.Collections;

namespace CubeSpaceFree
{
    public class Mover : MonoBehaviour
    {

        public float speed;

        // Use this for initialization
        void Start()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}