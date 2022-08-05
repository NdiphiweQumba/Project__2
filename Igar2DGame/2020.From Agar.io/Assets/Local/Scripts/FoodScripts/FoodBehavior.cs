using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PersonalProjectsNdiphiwe
{
    public class FoodBehavior : MonoBehaviour
    {
        #region Public Fields
        public bool isEating;

        #endregion
        #region Private Fields
        private bool hasStarted;
        private float delay_time = 3f;
        #endregion

        private void Start() => StartCoroutine(OnStarting(delay_time));

        #region MonoBehaviour CallBacks 
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Player")
            {
                isEating = true;
                Invoke("SpawnNewFoodPrefab", 3);
                this.gameObject.SetActive(false);

                if (hasStarted)
                {
                    ScoreCount.Instance.AddScore();
                    isPlayerEating();
                }
            }
            
        }
        private void Update() => isPlayerEating();
        #endregion

        #region Public Methods
        public void SpawnNewFoodPrefab()
        {
            // Randomise x && y positions based on screen width and height //
            float randomX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x,
                             Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            float randomY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y,
                            Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

            GameObject food = ObjectPooler.Instance.RequestFood();
            food.transform.position = new Vector2(randomX, randomY);
        }
        /// <summary>
        /// Runs when the Player Eats ///
        /// </summary>
        /// <returns></returns>
        public bool isPlayerEating()
        {
            if (isEating)
                isEating = false;

            return isEating;
        }

        #endregion

        #region Private Methods
        #region Interface Systems.Collections.IEnumerator
        IEnumerator OnStarting(float delay_time)
        {
            yield return new WaitForSeconds(delay_time);
            hasStarted = true;
        }
        #endregion

        #endregion

    }
}
