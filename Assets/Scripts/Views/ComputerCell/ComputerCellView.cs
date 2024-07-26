using System;
using Presenters.CameraCell;
using UnityEngine;
using Views.Entity;

namespace Views.ComputerCell
{
    public class ComputerCellView : MonoBehaviour
    {
        private ComputerCellPresenter _presenter;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EntityView entity))
            {
                
            }
        }
    }
}