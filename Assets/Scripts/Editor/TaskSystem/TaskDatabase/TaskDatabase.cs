using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;

public class TaskDatabase : ScriptableObject
{
    public List<Task> MyTasks;

    public Task FindTask(int id)
    {
        for (int i = 0; i < MyTasks.Count; i++)
        {
            if(MyTasks[i].ID == id)
            {
                return MyTasks[i];
            }
        }
        return null;
    }

    public void AddTask(Task task)
    {
        MyTasks.Add(task);
        EditorUtility.SetDirty(this);
    }

    public void InsertTask(int index, Task task)
    {
        MyTasks.Insert(index, task);
        EditorUtility.SetDirty(this);
    }

    public void Remove(Task task)
    {
        MyTasks.Remove(task);
        EditorUtility.SetDirty(this);
    }

    public void Remove(int index)
    {
        MyTasks.RemoveAt(index);
        EditorUtility.SetDirty(this);
    }

    public int Count()
    {
        return MyTasks.Count;
    }

    public Task Get(int index)
    {
        return MyTasks.ElementAt(index);
    }

    public void Replace(int index, Task task)
    {
        MyTasks[index] = task;
        EditorUtility.SetDirty(this);
    }
}



public class UITask : Task
{
    public UITaskPhase Phase;
}

public enum UITaskPhase
{
    NotStarted, InProgress, Completed
}
