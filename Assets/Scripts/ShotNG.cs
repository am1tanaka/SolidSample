using UnityEngine;

namespace SolidSample
{
    public class ShotNG : MonoBehaviour
    {
        [Tooltip("ショット速度"), SerializeField]
        float speed = 15f;
        [Tooltip("攻撃力"), SerializeField]
        int power = 1;

        const float LifeTime = 3;

        private void Awake()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = transform.right * speed;
            Destroy(gameObject, LifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Enemy en = other.GetComponent<Enemy>();
                en.Damage(power);
                Destroy(gameObject);
            }
            else if (other.CompareTag("EnemyB"))
            {
                EnemyB en = other.GetComponent<EnemyB>();
                en.Damage(power);
                Destroy(gameObject);
            }
        }
    }
}