using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class Task
{
    [XmlAttribute("ID")]
    public int ID;
    [XmlElement("Name")]
    public string TaskName;
    [XmlElement("Type")]
    public TaskType Type;
    [XmlElement("Description")]
    public string Description;
    [XmlElement("Whose Task")]
    public TeamMember TaskOwner;
    [XmlElement("Status")]
    public Status TaskStatus;
    [XmlElement("Priority")]
    public Priority TaskPriority;

    //custom
    [XmlElement("DialogueStage")]
    public DialogueStage DialogueStage;
    [XmlElement("ModelingStage")]
    public ModelingStage ModelingStage;
    [XmlElement("UIStage")]
    public UIStage UIStage;
    [XmlElement("MusicStage")]
    public MusicStage MusicStage;

    [XmlElement("DateCreated")]
    public string DateCreated;
    [XmlElement("DateCompleted")]
    public string DateCompleted;



    public Task()
    {
        TaskName = "";
        Description = "";
    }

    public Task(string name)
    {
        TaskName = name;
    }
}

//public class ModelingTask : Task
//{
//    [XmlElement("Stage")]
//    public ModelingStage TEST;
//}