using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace PersonalProjectsNdiphiwe
{
    [CustomEditor(typeof(HeartBarEditor))]
    public class ScoreCount : MonoBehaviour
    {

        public static ScoreCount _instance;
        public static ScoreCount Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("Instance of Score Count is NULL");
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        [ReadOnlyTexture] [ReadOnlyAttribute] public Text ScoreText;

        [ReadOnlyTexture]int score = 0;

        public int AddScore()
        {
            score++;
            ScoreText.text = score.ToString();
            return score;
        }
    }
}
