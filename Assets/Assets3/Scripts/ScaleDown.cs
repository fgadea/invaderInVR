using UnityEngine;
using System.Collections;


namespace CubeSpaceFree
{
    // Used by Player bullet class to shrink the bullet overtime
    public class ScaleDown : MonoBehaviour
    {
        public float multiplier = 0.98f;    // between 0.1 to 1.  smaller value meakes the object scaling down faster

        public void Update()
        {
            if (transform.localScale.x>0.2f)
            {
                transform.localScale *= multiplier;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
