using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class TaskListView
{
    public static TaskFilterType FilteredTaskType = TaskFilterType.ShowAll;

    private EmailHandler _emailHandler = new EmailHandler();
    private Vector2 _scrollPos;

    //list all of the stored tasks in the database
    public void TaskListField()
    {
        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));

        DisplayTasks();

        EditorGUILayout.EndScrollView();
    }

    public void DisplayTasks()
    {
        for (int i = 0; i < Database.Tasks.Count(); i++)    // will refer to the tasks in the filtered list.
            {
            if (FilteredTaskType != TaskFilterType.ShowAll)
            {
                //Debug.Log("Filter is: " + FilteredTaskType + ". This task type: " + Database.Tasks.Get(i).Type);
                if (FilteredTaskType == TaskFilterType.ConceptArt && Database.Tasks.Get(i).Type != TaskType.ConceptArt)
                {
                    continue;
                }
                else if (FilteredTaskType == TaskFilterType.Dialogue && Database.Tasks.Get(i).Type != TaskType.Dialogue)
                {
                    continue;
                }
                else if (FilteredTaskType == TaskFilterType.GameplayFunctionality && Database.Tasks.Get(i).Type != TaskType.GameplayFunctionality)
                {
                    continue;
                }
                else if (FilteredTaskType == TaskFilterType.Model && Database.Tasks.Get(i).Type != TaskType.Model)
                {
                    continue;
                }
                else if (FilteredTaskType == TaskFilterType.Music && Database.Tasks.Get(i).Type != TaskType.Music)
                {
                    continue;
                }
                else if (FilteredTaskType == TaskFilterType.Soundeffect && Database.Tasks.Get(i).Type != TaskType.Soundeffect)
                {
                    continue;
                }
                else if (FilteredTaskType == TaskFilterType.UI && Database.Tasks.Get(i).Type != TaskType.UI)
                {
                    continue;
                }
                else if (FilteredTaskType == TaskFilterType.Other && Database.Tasks.Get(i).Type != TaskType.Other)
                {
                    continue;
                }
            }


            GUILayout.BeginHorizontal();

            Database.Tasks.Get(i).ID = i;

            GUILayout.Label(Database.Tasks.Get(i).ID.ToString(), GUILayout.Width(30));

            GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Type: ", GUILayout.Width(100));
                Database.Tasks.Get(i).Type = (TaskType)EditorGUILayout.EnumPopup(Database.Tasks.Get(i).Type);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Task: ", GUILayout.Width(100));
                Database.Tasks.Get(i).TaskName = GUILayout.TextField(Database.Tasks.Get(i).TaskName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description: ", GUILayout.Width(100));
                Database.Tasks.Get(i).Description = GUILayout.TextArea(Database.Tasks.Get(i).Description, GUILayout.Height(100));
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Owner: ", GUILayout.Width(100));
                Database.Tasks.Get(i).TaskOwner = (TeamMember)EditorGUILayout.EnumPopup(Database.Tasks.Get(i).TaskOwner);
                GUILayout.EndHorizontal();

                if (Database.Tasks.Get(i).Type == TaskType.Dialogue)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Stage: ", GUILayout.Width(100));
                    Database.Tasks.Get(i).DialogueStage = (DialogueStage)EditorGUILayout.EnumPopup(Database.Tasks.Get(i).DialogueStage);
                    GUILayout.EndHorizontal();
                }
                else if (Database.Tasks.Get(i).Type == TaskType.Model)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Stage: ", GUILayout.Width(100));
                    Database.Tasks.Get(i).ModelingStage = (ModelingStage)EditorGUILayout.EnumPopup(Database.Tasks.Get(i).ModelingStage);
                    GUILayout.EndHorizontal();
                }
                else if (Database.Tasks.Get(i).Type == TaskType.UI)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Stage: ", GUILayout.Width(100));
                    Database.Tasks.Get(i).UIStage = (UIStage)EditorGUILayout.EnumPopup(Database.Tasks.Get(i).UIStage);
                    GUILayout.EndHorizontal();
                }
                else if (Database.Tasks.Get(i).Type == TaskType.Music)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Stage: ", GUILayout.Width(100));
                    Database.Tasks.Get(i).MusicStage = (MusicStage)EditorGUILayout.EnumPopup(Database.Tasks.Get(i).MusicStage);
                    GUILayout.EndHorizontal();
                }
                else
                {
                    Database.Tasks.Get(i).DialogueStage = DialogueStage.None;
                    Database.Tasks.Get(i).ModelingStage = ModelingStage.None;
                    Database.Tasks.Get(i).UIStage = UIStage.None;
                }

                GUILayout.BeginHorizontal();
                GUILayout.Label("Priority: ", GUILayout.Width(100));
                Database.Tasks.Get(i).TaskPriority = (Priority)EditorGUILayout.EnumPopup(Database.Tasks.Get(i).TaskPriority);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Status: ", GUILayout.Width(100));
                Database.Tasks.Get(i).TaskStatus = (Status)EditorGUILayout.EnumPopup(Database.Tasks.Get(i).TaskStatus);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label(" ", GUILayout.Width(200));
                if (GUILayout.Button("Email task to owner", GUILayout.Width(150)))
                {
                    string emailAddress = "";
                    if (Database.Tasks.Get(i).TaskOwner == TeamMember.Cesar)
                        emailAddress = "cesarvinken@hotmail.com";
                    //else if (Database.Tasks.Get(i).TaskOwner == TeamMember.Imre)
                    //    emailAddress = "imrevanson@gmail.com";
                    //else if (Database.Tasks.Get(i).TaskOwner == TeamMember.Renate)
                    //    emailAddress = "rcpsmit@hotmail.com";

                    _emailHandler.SendEmail(emailAddress, "new BBB task!", Database.Tasks.Get(i).Description);
                }
                GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            if (GUILayout.Button("x", GUILayout.Width(20)))
            {
                if (EditorUtility.DisplayDialog("Delete Task", "Are you sure you want to delete " + Database.Tasks.Get(i).TaskName + "?", "Delete", "Cancel"))
                {
                    Database.Tasks.Remove(i);
                }
            }

            GUILayout.EndHorizontal();
        }
    }
}
