using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField]
        private float force = 10f;

        private Rigidbody2D myBody;

        private void Awake()
        {
            myBody = GetComponent<Rigidbody2D>();
        }

        public void Shoot(Vector2 dir)
        {
            myBody.AddForce(dir * force, ForceMode2D.Impulse);
            Invoke("DestroyBullet", 1f);
        }

        void DestroyBullet()
        {
            Destroy(gameObject); 
        }

    }
}