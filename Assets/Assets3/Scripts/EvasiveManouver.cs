using UnityEngine;
using System.Collections;

namespace CubeSpaceFree
{
    // Move object left or right depending on their position.
    // If the object is on the left side of the screen, move it right and vice verse.
    // Use manouverTime and manouverWait to control how often and how fast the object makes a manouver.
    public class EvasiveManouver : MonoBehaviour
    {
        public Vector2 startWait;       // how long to wait before we start manouvering
        public Vector2 manouverTime;    // how fast the manouver is
        public Vector2 manouverWait;    // how long to wait before manouvering
        public float smoothing;         // control the smoothness of the manouver
        private Rigidbody myRigidbody;  // reference to rigidbody
        private float targetManouver;   // target position
        public Boundary boundary;       // limit the object so it doesn't go out of boundary
        public float dodge;             // dodge factor
        public float tilt;              // tilt factor

        // Use this for initialization
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
            StartCoroutine(Evade());
        }

        IEnumerator Evade()
        {
            yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
            while (true)
            {
                targetManouver = Random.Range(1, dodge*-Mathf.Sign(transform.position.x));
                yield return new WaitForSeconds(Random.Range(manouverTime.x, manouverTime.y));
                targetManouver = 0;
                yield return new WaitForSeconds(Random.Range(manouverWait.x, manouverWait.y));
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
                    Mathf.Clamp(myRigidbody.position.z, boundary.zMin-20, boundary.zMax+20)   // added offset so that DestroyByBoundary will destroy the object and not keep clamping the position
                );

            myRigidbody.rotation = Quaternion.Euler(0, 0, myRigidbody.velocity.x * -tilt);
        }
    }
}
