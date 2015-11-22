using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;

[XmlRoot("TaskCollection")]
public class Tasks
{
    [XmlArray("Tasks")]
    [XmlArrayItem("Task")]

    public List<Task> tasks;

    public Tasks() 
    { 
        tasks = new List<Task>(); 
    }
}

[XmlRoot("TaskCollection")]
public class TaskContainer
{
    [XmlArray("Tasks")]
    [XmlArrayItem("Task")]

    public List<Task> tasks;    //for load function

    public static TaskContainer Load(string path)
    {
        Debug.Log(path);
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(TaskContainer));

        StringReader reader = new StringReader(_xml.text);

        TaskContainer tasks = serializer.Deserialize(reader) as TaskContainer;

        reader.Close();

        return tasks;
    }

    public static void SaveTask(string path, Tasks task)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Tasks));
        FileStream fs = new FileStream(Application.dataPath + path, FileMode.Create);
        using(TextWriter t = new StreamWriter(fs, new UTF8Encoding()))
        {
            serializer.Serialize(t, task);
        }
    }
}
