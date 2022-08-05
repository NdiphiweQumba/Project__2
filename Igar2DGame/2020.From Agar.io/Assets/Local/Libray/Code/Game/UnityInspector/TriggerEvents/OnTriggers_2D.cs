using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PersonalProjectsNdiphiwe
{
    [RequireComponent(typeof(Collider2D))]
    public class OnTriggers_2D : MonoBehaviour
    {
        #region Public Fields
        public float DelayTime;
        #endregion

        #region Private Fields
        [SerializeField] private string Tag_Collider2D;
        [SerializeField] private Collider2D Colldier2D;
        [SerializeField] private bool useDelays;
        #endregion

        #region Public UnityEvents Fields
        public UnityEvent OnTriggerEnter;
        public UnityEvent OnTriggerExit;
        public UnityEvent OnTriggerStay;
        #endregion

        #region MonoBehavior
        private void Awake()
        {
            Colldier2D = this.gameObject.GetComponent<Collider2D>();
        }

        private void OnEnable()
        {
            if (!Colldier2D.isTrigger)
                Debug.LogFormat("<color=orange>Collider does not behave as a trigger you might need to set iit in the inspector!" +
                                "</color>");
        }
        private void Start()
        {
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Tag_Collider2D != string.Empty || Tag_Collider2D == "N")
            {
                if (collision.tag == Tag_Collider2D)
                {
                    if (useDelays)
                        StartCoroutine(DelayWait(DelayTime));

                    Invoke("EnterTrigger", 1);
                    OnTriggerEnter.AddListener(OnTriggerEnterMethod);
                }
            }
            else
            {
                Debug.LogError($"{this.gameObject.name}  Tag Field is Empty ");
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (Tag_Collider2D != string.Empty || Tag_Collider2D == "N")
            {
                if (collision.tag == Tag_Collider2D)
                {
                    if (useDelays)
                        StartCoroutine(DelayWait(DelayTime));

                    Invoke("ExitTrigger", 1);
                    OnTriggerEnter.AddListener(OnTriggerExitMethod);
                }
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (Tag_Collider2D != string.Empty || Tag_Collider2D == "N")
            {
                if (collision.tag == Tag_Collider2D)
                {
                    if (useDelays)
                        StartCoroutine(DelayWait(DelayTime));

                    Invoke("StayTrigger", 1);
                    OnTriggerEnter.AddListener(OnTriggerStayMethod);
                }
            }
        }
        #endregion
        
        #region Private Methods
        private void OnTriggerEnterMethod()
        {
            OnTriggerEnter.Invoke();
        }
        private void OnTriggerExitMethod()
        {
            OnTriggerExit.Invoke();
        }
        private void OnTriggerStayMethod()
        {
            OnTriggerStay.Invoke();
        }
        #endregion



        public void EnterTrigger()
        {
            Debug.Log("<color=green>Entered</color>");
        }
        public void ExitTrigger()
        {
            Debug.Log("<color=red>Exited</color>");
        }
        public void StayTrigger()
        {
            Debug.Log("<color=cyan>Stay...</color>");

        }

        #region System.Collections
        private IEnumerator DelayWait(float _delay_seconds)
        {
            if (useDelays)
            {
                yield return new WaitForSeconds(_delay_seconds);
            }
        } 
        #endregion
    }
}
