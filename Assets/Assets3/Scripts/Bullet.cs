using UnityEngine;
using System.Collections;


namespace CubeSpaceFree
{
    // A stub class that we use to check if an object is a Bullet (we could have used a Tag instead).
    public class Bullet : MonoBehaviour
    {
        public void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
