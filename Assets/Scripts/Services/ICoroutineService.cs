using System.Collections;
using UnityEngine;

namespace Services
{

    public interface ICoroutineService
    {
        public Coroutine StartRoutine(IEnumerator enumerator);
        public void StopRoutine(Coroutine coroutine);
    }

}