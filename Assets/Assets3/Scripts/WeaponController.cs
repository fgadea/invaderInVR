using UnityEngine;
using System.Collections;

namespace CubeSpaceFree
{
    public class WeaponController : MonoBehaviour
    {
        public GameObject shot;
        public Transform shotSpawn;
        public float fireRate;
        public float delay;

        private AudioSource audioSource;

        // This is called when the bullet instance is created
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            InvokeRepeating("Fire", delay, fireRate);
        }

        void Fire()
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
        }

    }
}