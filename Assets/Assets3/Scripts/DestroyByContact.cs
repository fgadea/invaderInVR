using UnityEngine;
using System.Collections;

namespace CubeSpaceFree
{
    public class DestroyByContact : MonoBehaviour
    {
        public GameObject explosion;
        public GameObject playerExplosion;
        public int scoreValue;
        private static GameController gameController;
        private bool isVisible = false;

        // Use this for initialization
        void Start()
        {
            if (!gameController)
                gameController = GameObject.FindObjectOfType<GameController>();
        }

        void OnBecameInvisible()
        {
            isVisible = false;
        }

        void OnBecameVisible()
        {
            isVisible = true;
        }

        void OnTriggerEnter(Collider other)
        {
            // Note: you can optimize these by using Tags
            // ignore bullet to bullet collision
            if (this.GetComponent<Bullet>() && other.GetComponent<Bullet>())
                return;

            // ignore collision with Enemy or Boundary
            if (other.name=="Boundary")
                return;
            if (other.GetComponent<Enemy>() && this.GetComponent<EnemyBullet>())
                return;
            if (other.GetComponent<EnemyBullet>() && this.GetComponent<Enemy>())
                return;

            if (explosion)
                Instantiate(explosion, transform.position, transform.rotation);

            if (other.CompareTag("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
