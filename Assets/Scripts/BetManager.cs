using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class BetManager
{
    public static int betValue = 1;

    public static int totalMoney = 1000;

    public static int totalBet = 0;

    public static bool thePlayerLost = true;

    public static List<numberButton> betData = new List<numberButton>();

    public static void CheckNumberOnList(int number) 
    {
        foreach(numberButton betNumber in betData)
        {
            if(betNumber.buttonNumber == number)
            {
                PayWinningBet();
                Debug.Log("Congratulations, you won");
                thePlayerLost = false;                
            }            
        }

        if(thePlayerLost)
        {
            Debug.Log("You lose, sorry");            
        }
        thePlayerLost = true;

    }

    private static void PayWinningBet()
    {
        totalMoney += totalBet * 4;
    }

    public static bool IsMoneyEnough()
    {
        if (totalMoney >= betValue)
        {
            return true;
        }

        return false;
    }
}

public static class TaskExtensionsForCoroutines
{

    private static TaskAwaiter taskAwaiter;

    public static void AwaitInCoroutine(this Task task, Action onResult, Action<Exception> onError = null, Action onCompleted = null)
    {

        if(taskAwaiter == null)
        {
            taskAwaiter = CreateTaskAwaiter();
        }
        taskAwaiter.AwaitTask(task, onResult, onError, onCompleted);

    }

    public static void AwaitInCoroutine<T>(this Task<T> task, Action<T> onResult, Action<Exception> onError = null, Action onCompleted = null)
    {
        if (taskAwaiter == null)
        {
            taskAwaiter = CreateTaskAwaiter();
        }
        taskAwaiter.AwaitTask(task, onResult, onError, onCompleted);

    }

    private static TaskAwaiter CreateTaskAwaiter()
    {
        return new GameObject("TaskAwaiter").AddComponent<TaskAwaiter>();
    }

}

public class TaskAwaiter : MonoBehaviour
{

    public void AwaitTask(Task task, Action onResult, Action<Exception> onError, Action onCompleted)
    {
        StartCoroutine(AwaitTaskCoroutine(task, onResult, onError, onCompleted));
    }

    public void AwaitTask<T>(Task<T> task, Action<T> onResult, Action<Exception> onError, Action onCompleted)
    {
        StartCoroutine(AwaitTaskCoroutine(task, onResult, onError, onCompleted));
    }

    private IEnumerator AwaitTaskCoroutine(Task task, Action onResult, Action<Exception> onError, Action onCompleted)
    {
        
        while(task.IsCompleted == false)
        {
            yield return null;
        }

        if(task.IsFaulted)
        {
            onError?.Invoke(task.Exception);
        }
        else
        {
            onResult?.Invoke();
        }

        onCompleted?.Invoke();
    }

    private IEnumerator AwaitTaskCoroutine<T>(Task<T> task, Action<T> onResult, Action<Exception> onError, Action onCompleted)
    {

        while (task.IsCompleted == false)
        {
            yield return null;
        }

        if (task.IsFaulted)
        {
            onError?.Invoke(task.Exception);
        }
        else
        {
            onResult?.Invoke(task.Result);
        }

        onCompleted?.Invoke();

        

    }

}
