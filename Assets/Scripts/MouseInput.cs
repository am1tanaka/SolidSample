using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SolidSample {
    /// <summary>
    /// マウス座標からプレイヤーの移動方向を決定して
    /// 移動処理を呼び出します。
    /// </summary>
    public class MouseInput : MonoBehaviour
    {
        [Tooltip("プレイヤー"), SerializeField]
        Player player = null;

        Camera gameCamera = null;

        private void Awake()
        {
            gameCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                player.Shot();
            }

            Vector3 mpos = Input.mousePosition;
            mpos.z = player.transform.position.z - gameCamera.transform.position.z;
            player.targetPosition = gameCamera.ScreenToWorldPoint(mpos);
        }

    }
}