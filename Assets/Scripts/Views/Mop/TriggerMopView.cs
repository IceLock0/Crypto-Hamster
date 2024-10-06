using System;
using Presenters.Mop;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using Views.Player;
using Zenject;

namespace Views.Mop
{
    public class TriggerMopView : MonoBehaviour
    {
        public event Action Entered, Exited;

        private TriggerMopPresenter _triggerMopPresenter;

        [Inject]
        public void Initialize(MopConfig mopConfig, ContaminationPresenter contaminationPresenter)
        {
            _triggerMopPresenter = new TriggerMopPresenter(this, mopConfig, contaminationPresenter);
            
            _triggerMopPresenter?.OnEnable();
        }
        
        private void OnDisable()
        {
            _triggerMopPresenter?.OnDisable();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerMoveView>())
            {
                Entered?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerMoveView>())
            {
                Exited?.Invoke();
            }
        }
    }
}