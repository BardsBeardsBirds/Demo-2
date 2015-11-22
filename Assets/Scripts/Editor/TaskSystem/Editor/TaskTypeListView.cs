using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public class TaskTypeListView
{
    private Vector2 _scrollPos;
    public static List<Task> FilteredTasks = new List<Task>();


    public void TaskTypeListField()
    {

        GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));

        DisplayTaskTypes();

        EditorGUILayout.EndScrollView();
        GUILayout.EndHorizontal();

    }

    public void DisplayTaskTypes()
    {
        GUILayout.BeginVertical();

        if (GUILayout.Button("All tasks", GUILayout.Width(200)))
        {
            TaskListView.FilteredTaskType = TaskFilterType.ShowAll;
        }
        if (GUILayout.Button("Concept art", GUILayout.Width(200)))
        {
            TaskListView.FilteredTaskType = TaskFilterType.ConceptArt;
        }
        if (GUILayout.Button("Models", GUILayout.Width(200)))
        {
            TaskListView.FilteredTaskType = TaskFilterType.Model;
        }
        if (GUILayout.Button("Dialogue", GUILayout.Width(200)))
        {
            TaskListView.FilteredTaskType = TaskFilterType.Dialogue;
        }
        if (GUILayout.Button("UI", GUILayout.Width(200)))
        {
            TaskListView.FilteredTaskType = TaskFilterType.UI;
        }
        if (GUILayout.Button("Gameplay", GUILayout.Width(200)))
        {
            TaskListView.FilteredTaskType = TaskFilterType.GameplayFunctionality;
        }
        if (GUILayout.Button("Music", GUILayout.Width(200)))
        {
            TaskListView.FilteredTaskType = TaskFilterType.Music;
        }
        if (GUILayout.Button("Soundeffect", GUILayout.Width(200)))
        {
            TaskListView.FilteredTaskType = TaskFilterType.Soundeffect;
        }        
        if (GUILayout.Button("Other", GUILayout.Width(200)))
        {
            TaskListView.FilteredTaskType = TaskFilterType.Other;
        }



        GUILayout.EndVertical();
    }
}
