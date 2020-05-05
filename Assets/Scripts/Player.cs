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
        GameObject shotPrefab = null;

        /// <summary>
        /// 移動目的座標を設定します。
        /// </summary>
        public Vector3 targetPosition;

        Rigidbody rb = null;
        Camera gameCamera = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            targetPosition = transform.position;
            gameCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (Input.GetButton("Fire2"))
                {
                    Shot(Vector3.SignedAngle(
                        Vector3.right, 
                        rb.velocity.normalized,
                        Vector3.forward));
                }
                else
                {
                    Shot(0);
                }
            }

            UpdateMove();
        }

        /// <summary>
        /// ショット時に呼び出します。
        /// </summary>
        public void Shot(float rotz)
        {
            Instantiate(shotPrefab, transform.position, 
                Quaternion.AngleAxis(rotz, Vector3.forward));
        }

        void UpdateMove()
        {
            Vector3 mpos = Input.mousePosition;
            mpos.z = transform.position.z
                - gameCamera.transform.position.z;
            targetPosition = gameCamera.ScreenToWorldPoint(mpos);
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
    }
}