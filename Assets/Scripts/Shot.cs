using UnityEngine;

namespace SolidSample
{
    public class Shot : MonoBehaviour
    {
        [Tooltip("ショット速度"), SerializeField]
        float speed = 15f;
        [Tooltip("攻撃力"), SerializeField]
        int power = 1;
        [Tooltip("爆発プレハブ"), SerializeField]
        GameObject explosionPrefab = null;

        const float LifeTime = 3;

        private void Awake()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.right * speed;
            Destroy(gameObject, LifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Enemy en = other.GetComponent<Enemy>();
                en.hp -= power;
                if (en.hp <= 0)
                {
                    Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
                    Destroy(other.gameObject);
                }

                Destroy(gameObject);
            }
        }
    }
}