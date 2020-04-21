using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolidSample
{
    public class Shot : MonoBehaviour
    {
        [Tooltip("ショット速度"), SerializeField]
        float speed = 15f;

        Rigidbody rb = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.right * speed;
        }
    }
}