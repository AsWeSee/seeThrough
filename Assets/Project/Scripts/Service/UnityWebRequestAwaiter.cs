﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

//public class UnityWebRequestAwaiter : INotifyCompletion
//{
//    private UnityWebRequestAsyncOperation asyncOp;
//    private Action continuation;

//    public UnityWebRequestAwaiter(UnityWebRequestAsyncOperation asyncOp)
//    {
//        this.asyncOp = asyncOp;
//        asyncOp.completed += OnRequestCompleted;
//    }

//    public bool IsCompleted { get { return asyncOp.isDone; } }

//    public void GetResult() { }

//    public void OnCompleted(Action continuation)
//    {
//        this.continuation = continuation;
//    }

//    private void OnRequestCompleted(AsyncOperation obj)
//    {
//        continuation();
//    }
//}

public static class ExtensionMethods
{
    //public static UnityWebRequestAwaiter GetAwaiter(this UnityWebRequestAsyncOperation asyncOp)
    //{
    //    return new UnityWebRequestAwaiter(asyncOp);
    //}





    public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
    {
        var tcs = new TaskCompletionSource<object>();
        asyncOp.completed += obj => { tcs.SetResult(null); };
        return ((Task)tcs.Task).GetAwaiter();
    }
    /* Example:
    var getRequest = UnityWebRequest.Get("http://www.google.com");
    await getRequest.SendWebRequest();
    var result = getRequest.downloadHandler.text;
    */
}

