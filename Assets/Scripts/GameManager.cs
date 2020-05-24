#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

namespace SolidSample
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance { get; private set; }

		[Tooltip("スコアテキスト"), SerializeField]
		Text scoreText = null;

		/// <summary>
		/// 最高得点
		/// </summary>
		const int MaxScore = 999999;

		/// <summary>
		/// 点数
		/// </summary>
		public static int Score { get; private set; }

		void Awake()
		{
			Instance = this;
		}

		void Start()
		{
			GameInit();
		}

#if DEBUG_KEY
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SampleScene");
			}
		}
#endif

		/// <summary>
		/// ゲームの新規開始時の初期化をします。
		/// </summary>
		void GameInit()
		{
			Score = 0;
			DrawScore();
		}

		/// <summary>
		/// 指定の得点を加算。
		/// </summary>
		/// <param name="point">得点</param>
		public void AddScore(int point)
		{
			Score += point;
			if (Score > MaxScore)
			{
				Score = MaxScore;
			}
			DrawScore();
		}

		/// <summary>
		/// スコア描画(仮)
		/// </summary>
		void DrawScore()
		{
			scoreText.text = "SCORE "+Score;
		}
	}
}