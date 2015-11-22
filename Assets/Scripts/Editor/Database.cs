using System.Collections;
using UnityEngine;

public class Database
{
    private static TaskDatabase _taskDatabase;

    public static TaskDatabase Tasks
    {
        get 
        {
            if(_taskDatabase == null)
            {
                Debug.Log("trying to load the task database");
                _taskDatabase = Resources.Load<TaskDatabase>("Databases/TaskDatabase");
            }

            return _taskDatabase; 
        }
        set { _taskDatabase = value; }
    }
}