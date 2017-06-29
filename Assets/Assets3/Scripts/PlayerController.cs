using UnityEngine;
using System.Collections;

// Heavily based on Unity Space Shooter tutorial
namespace CubeSpaceFree
{

    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }

    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float tilt;              // tilt factor
        public Boundary boundary;       // movememnt boundary

        public GameObject shot;         // bullet prefab
        public Transform shotSpawn;     // the turret (bullet spawn location)
        public Rigidbody myRigidbody;   // reference to rigitbody
        public float fireRate = 0.5f;   
        private float nextFire = 0.0f;

        public float smoothing = 5;     // this value is used for smoothing ovement
        private Vector3 smoothDirection;// used to smooth out mouse and touch control

        // Use this for initialization
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            // keyboard
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // if keyboard direction key is pressed
            if (moveHorizontal != 0 || moveVertical != 0)
            {
                myRigidbody.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;

            }
            else
            {

                Vector3 pos = Input.mousePosition;

                pos.z = Camera.main.transform.position.y + 1;
                pos = Camera.main.ScreenToWorldPoint(pos);
                Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);//.zero;

                Vector2 currentPosition = new Vector3(pos.x, pos.z);
                Vector3 directionRaw = pos - origin;
                Debug.Log("directionRaw.magnitude=" + directionRaw.magnitude);

                Vector3 direction = directionRaw.normalized;

                smoothDirection = Vector3.MoveTowards(smoothDirection, direction, smoothing);

                direction = smoothDirection;
                Vector3 movement = new Vector3(direction.x, 0, direction.z);
                myRigidbody.velocity = movement * speed;
                /*Debug.Log("currentPosition=" + currentPosition + "  Input.mousePosition=" + Input.mousePosition +
                    " pos =" + pos + " direction=" + direction + " smoothDirection=" + smoothDirection +
                    " movement=" + movement);*/

                //transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime* speed*2);
                //myRigidbody.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;                    

            }

            transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
            );


            myRigidbody.rotation = Quaternion.Euler(0, 0, myRigidbody.velocity.x * -tilt);
        }

        void Update()
        {
            // Should we fire a bullet?
            if ((Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.Space)) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
