using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class TaskSaver
{
    public static TaskSaver Instance;
    public const string path = "Xml/tasks"; //in resources folder

    void Start()
    {
        Instance = this;
    }

    public void SaveAllTasks()
    {
        Tasks tasks = new Tasks();

        foreach (Task task in Database.Tasks.MyTasks)
        {
            tasks.tasks.Add(task);
        }

        TaskContainer.SaveTask("/Resources/Xml/tasks.xml", tasks);

    } 

}
