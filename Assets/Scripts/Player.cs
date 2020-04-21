using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolidSample
{
    public class Player : MonoBehaviour
    {
        [Tooltip("移動速度"), SerializeField]
        float speed = 10f;
        [Tooltip("ショットプレハブ"), SerializeField]
        Shot shotPrefab = null;

        /// <summary>
        /// 移動目的座標を設定します。
        /// </summary>
        public Vector3 targetPosition;

        Rigidbody rb = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            targetPosition = transform.position;
        }

        private void FixedUpdate()
        {
            Vector3 dir = targetPosition - transform.position;
            dir.z = 0f;
            float speedStep = speed * Time.fixedDeltaTime;
            float step = Mathf.Min(dir.magnitude, speedStep);
            if (!Mathf.Approximately(step, 0f))
            {
                step /= Time.fixedDeltaTime;
            }
            rb.velocity = dir.normalized * step;
        }

        /// <summary>
        /// ショット時に呼び出します。
        /// </summary>
        public void Shot()
        {
            Instantiate(shotPrefab, transform.position, Quaternion.identity);
        }
    }
}