using System.Collections;
using UnityEngine;
using Utils;

namespace Services
{

    public class CoroutineService : MonoBehaviour, ICoroutineService
    {
        public Coroutine StartRoutine(IEnumerator enumerator)
        {
            InvariantChecker.CheckObjectInvariant(enumerator);
            return StartCoroutine(enumerator);
        }

        public void StopRoutine(Coroutine coroutine)
        {
            InvariantChecker.CheckObjectInvariant(coroutine);
            StopCoroutine(coroutine);
        }
    }

}