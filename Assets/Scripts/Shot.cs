using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace SolidSample
{
    public class Shot : MonoBehaviour
    {
        [Tooltip("ショット速度"), SerializeField]
        float speed = 15f;
        [Tooltip("爆発プレハブ"), SerializeField]
        GameObject explosionPrefab = null;


        Rigidbody rb = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.right * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}