using UnityEngine;
using System.Collections;

namespace CubeSpaceFree
{
    public class ZigZagManouver : MonoBehaviour
    {
        public float dodge;
        public float tilt;

        public Vector2 startWait;
        public Vector2 manouverTime;
        public Vector2 manouverWait;
        public float smoothing;
        private Rigidbody myRigidbody;
        private float targetManouver;
        public Boundary boundary;

        // Use this for initialization
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
            StartCoroutine(Evade());
        }

        IEnumerator Evade()
        {
            while (true)
            {
                if (transform.position.x>0)
                    targetManouver = boundary.xMin;
                else 
                    targetManouver = boundary.xMax;
                yield return new WaitForSeconds(Random.Range(manouverTime.x, manouverTime.y));
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float newManouver = Mathf.MoveTowards(myRigidbody.velocity.x, targetManouver, Time.deltaTime * smoothing);
            myRigidbody.velocity = new Vector3(newManouver, 0, myRigidbody.velocity.z);
            myRigidbody.position = new Vector3
                (
                    Mathf.Clamp(myRigidbody.position.x, boundary.xMin, boundary.xMax),
                    0,
                    Mathf.Clamp(myRigidbody.position.z, boundary.zMin-20, boundary.zMax+20) // added offset so that DestroyByBoundary will destroy the object and not keep clamping the position
                );

            myRigidbody.rotation = Quaternion.Euler(0, 0, myRigidbody.velocity.x * -tilt);
        }
    }
}
