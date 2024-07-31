using System;
using UnityEngine;
using UnityEngine.AI;
using NavMeshSurface = Unity.AI.Navigation.NavMeshSurface;

namespace Views.Staff
{
    public class StaffView : MonoBehaviour
    {
        [SerializeField] private Unity.AI.Navigation.NavMeshSurface _surface;
        [SerializeField] private NavMeshAgent _agent;
        private UnityEngine.Camera _camera;

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
                    _agent.SetDestination(hit.point);
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                _surface.BuildNavMesh();
            }
        }
    }
}