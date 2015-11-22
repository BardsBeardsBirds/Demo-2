using UnityEngine;
using System.Collections;

public class TaskLoader
{
    public const string path = "Xml/tasks"; //in resources folder
    private TaskDatabase _database;

    void Start()
    {
        Debug.Log(Database.Tasks);
        _database = Database.Tasks;
    }

    public void GetAllTasks()
    {
        TaskContainer tc = TaskContainer.Load(path);
        _database = Database.Tasks;

        foreach (Task task in tc.tasks)
        {
            _database.AddTask(task);
        }
    }
}
