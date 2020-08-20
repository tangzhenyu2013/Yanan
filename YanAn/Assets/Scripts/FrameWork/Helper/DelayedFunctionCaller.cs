using System.Collections;
using UnityEngine;
using System;

public class DelayedFunctionCaller
{
    public delegate void Action<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    public delegate void Action<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
    public delegate void Action<T1, T2, T3, T4, T5, T6, T7>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);

    public static void DelayedCall(MonoBehaviour caller, float delaySeconds, Action delayedFunction)
    {
        _DelayedCall(caller, delaySeconds, delayedFunction);
    }
    public static void DelayedCall<T>(MonoBehaviour caller, float delaySeconds, Action<T> delayedFunction, T arg)
    {
        _DelayedCall(caller, delaySeconds, delayedFunction, arg);
    }
    public static void DelayedCall<T1, T2>(MonoBehaviour caller, float delaySeconds, Action<T1, T2> delayedFunction, T1 arg1, T2 arg2)
    {
        _DelayedCall(caller, delaySeconds, delayedFunction, arg1, arg2);
    }
    public static void DelayedCall<T1, T2, T3>(MonoBehaviour caller, float delaySeconds, Action<T1, T2, T3> delayedFunction, T1 arg1, T2 arg2, T3 arg3)
    {
        _DelayedCall(caller, delaySeconds, delayedFunction, arg1, arg2, arg3);
    }
    public static void DelayedCall<T1, T2, T3, T4>(MonoBehaviour caller, float delaySeconds, Action<T1, T2, T3, T4> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        _DelayedCall(caller, delaySeconds, delayedFunction, arg1, arg2, arg3, arg4);
    }
    public static void DelayedCall<T1, T2, T3, T4, T5>(MonoBehaviour caller, float delaySeconds, Action<T1, T2, T3, T4, T5> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        _DelayedCall(caller, delaySeconds, delayedFunction, arg1, arg2, arg3, arg4, arg5);
    }

    public static void DelayedCall<T1, T2, T3, T4, T5, T6>(MonoBehaviour caller, float delaySeconds, Action<T1, T2, T3, T4, T5, T6> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        _DelayedCall(caller, delaySeconds, delayedFunction, arg1, arg2, arg3, arg4, arg5, arg6);
    }
    public static void DelayedCall<T1, T2, T3, T4, T5, T6, T7>(MonoBehaviour caller, float delaySeconds, Action<T1, T2, T3, T4, T5, T6, T7> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        _DelayedCall(caller, delaySeconds, delayedFunction, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }

    static void _DelayedCall(MonoBehaviour caller, float delaySeconds, Action delayedFunction)
    {
        if (caller == null || delayedFunction == null)
            return;

        caller.StartCoroutine(DelayedCallCoroutine(delaySeconds, delayedFunction));
    }

    static void _DelayedCall<T>(MonoBehaviour caller, float delaySeconds, Action<T> delayedFunction, T arg)
    {
        if (caller == null || delayedFunction == null)
            return;

        caller.StartCoroutine(DelayedCallCoroutine(delaySeconds, delayedFunction, arg));
    }

    static void _DelayedCall<T1, T2>(MonoBehaviour caller, float delaySeconds, Action<T1, T2> delayedFunction, T1 arg1, T2 arg2)
    {
        if (caller == null || delayedFunction == null)
            return;

        caller.StartCoroutine(DelayedCallCoroutine(delaySeconds, delayedFunction, arg1, arg2));
    }

    static void _DelayedCall<T1, T2, T3>(MonoBehaviour caller, float delaySeconds, Action<T1, T2, T3> delayedFunction, T1 arg1, T2 arg2, T3 arg3)
    {
        if (caller == null || delayedFunction == null)
            return;

        caller.StartCoroutine(DelayedCallCoroutine(delaySeconds, delayedFunction, arg1, arg2, arg3));
    }

    static void _DelayedCall<T1, T2, T3, T4>(MonoBehaviour caller, float delaySeconds, Action<T1, T2, T3, T4> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        if (caller == null || delayedFunction == null)
            return;

        caller.StartCoroutine(DelayedCallCoroutine(delaySeconds, delayedFunction, arg1, arg2, arg3, arg4));
    }

    static void _DelayedCall<T1, T2, T3, T4, T5>(MonoBehaviour caller, float delaySeconds, Action<T1, T2, T3, T4, T5> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        if (caller == null || delayedFunction == null)
            return;

        caller.StartCoroutine(DelayedCallCoroutine(delaySeconds, delayedFunction, arg1, arg2, arg3, arg4, arg5));
    }

    static void _DelayedCall<T1, T2, T3, T4, T5, T6>(MonoBehaviour caller, float delaySeconds, Action<T1, T2, T3, T4, T5, T6> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        if (caller == null || delayedFunction == null)
            return;

        caller.StartCoroutine(DelayedCallCoroutine(delaySeconds, delayedFunction, arg1, arg2, arg3, arg4, arg5, arg6));
    }

    static void _DelayedCall<T1, T2, T3, T4, T5, T6, T7>(MonoBehaviour caller, float delaySeconds, Action<T1, T2, T3, T4, T5, T6, T7> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        if (caller == null || delayedFunction == null)
            return;

        caller.StartCoroutine(DelayedCallCoroutine(delaySeconds, delayedFunction, arg1, arg2, arg3, arg4, arg5, arg6, arg7));
    }

    static IEnumerator DelayedCallCoroutine(float delaySeconds, Action delayedFunction)
    {
        if (delaySeconds <= 0f)
            yield return new WaitForEndOfFrame();
        else
            yield return new WaitForSeconds(delaySeconds);
        delayedFunction();
    }

    static IEnumerator DelayedCallCoroutine<T>(float delaySeconds, Action<T> delayedFunction, T arg)
    {
        if (delaySeconds <= 0f)
            yield return new WaitForEndOfFrame();
        else
            yield return new WaitForSeconds(delaySeconds);
        delayedFunction(arg);
    }

    static IEnumerator DelayedCallCoroutine<T1, T2>(float delaySeconds, Action<T1, T2> delayedFunction, T1 arg1, T2 arg2)
    {
        if (delaySeconds <= 0f)
            yield return new WaitForEndOfFrame();
        else
            yield return new WaitForSeconds(delaySeconds);
        delayedFunction(arg1, arg2);
    }

    static IEnumerator DelayedCallCoroutine<T1, T2, T3>(float delaySeconds, Action<T1, T2, T3> delayedFunction, T1 arg1, T2 arg2, T3 arg3)
    {
        if (delaySeconds <= 0f)
            yield return new WaitForEndOfFrame();
        else
            yield return new WaitForSeconds(delaySeconds);
        delayedFunction(arg1, arg2, arg3);
    }

    static IEnumerator DelayedCallCoroutine<T1, T2, T3, T4>(float delaySeconds, Action<T1, T2, T3, T4> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        if (delaySeconds <= 0f)
            yield return new WaitForEndOfFrame();
        else
            yield return new WaitForSeconds(delaySeconds);
        delayedFunction(arg1, arg2, arg3, arg4);
    }

    static IEnumerator DelayedCallCoroutine<T1, T2, T3, T4, T5>(float delaySeconds, Action<T1, T2, T3, T4, T5> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        if (delaySeconds <= 0f)
            yield return new WaitForEndOfFrame();
        else
            yield return new WaitForSeconds(delaySeconds);
        delayedFunction(arg1, arg2, arg3, arg4, arg5);
    }

    static IEnumerator DelayedCallCoroutine<T1, T2, T3, T4, T5, T6>(float delaySeconds, Action<T1, T2, T3, T4, T5, T6> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        if (delaySeconds <= 0f)
            yield return new WaitForEndOfFrame();
        else
            yield return new WaitForSeconds(delaySeconds);
        delayedFunction(arg1, arg2, arg3, arg4, arg5, arg6);
    }

    static IEnumerator DelayedCallCoroutine<T1, T2, T3, T4, T5, T6, T7>(float delaySeconds, Action<T1, T2, T3, T4, T5, T6, T7> delayedFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        if (delaySeconds <= 0f)
            yield return new WaitForEndOfFrame();
        else
            yield return new WaitForSeconds(delaySeconds);
        delayedFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }

}
