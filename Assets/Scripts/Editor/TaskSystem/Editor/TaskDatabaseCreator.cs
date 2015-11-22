using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class TaskDatabaseCreator : MonoBehaviour 
{
    [MenuItem("Tasks/Create Task Database")]
    public static void CreateTaskDatabase()
    {
        TaskDatabase newDatabase = ScriptableObject.CreateInstance<TaskDatabase>();
        AssetDatabase.CreateAsset(newDatabase, "Assets/TaskDatabase.asset");
        AssetDatabase.Refresh();
    }
}

public class TaskDatabaseEditor : EditorWindow
{
    private Task _selectedTask;
    private TaskListView _taskListView = new TaskListView();
    private TaskTypeListView _taskTypeListView = new TaskTypeListView();

    [MenuItem("Tasks/Open Task Database")]
    public static void OpenTaskDatabase()
    {
        TaskDatabaseEditor window = EditorWindow.GetWindow<TaskDatabaseEditor>();
        window.minSize = new Vector2(400, 300);
        window.titleContent.text = "Task Database";
        window.Show();
    }

    public void OnEnable()
    {
        _selectedTask = new Task();
    }

    public void OnGUI()
    {
        GUILayout.BeginHorizontal();
        _taskTypeListView.TaskTypeListField();

        _taskListView.TaskListField();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
        BottomBar();
        GUILayout.EndHorizontal();
    }

    public void BottomBar()
    {
        GUILayout.Label("Tasks: " + Database.Tasks.Count().ToString());
        if (GUILayout.Button("Add task"))
        {
            _selectedTask = new Task();
            _selectedTask.DateCreated = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString();

            Database.Tasks.MyTasks.Add(_selectedTask);
        }

        if (GUILayout.Button("Save database to drive"))
        {
            TaskSaver taskSaver = new TaskSaver();
            taskSaver.SaveAllTasks();
        }

        if (GUILayout.Button("Load database from drive"))
        {
            Database.Tasks.MyTasks.Clear();

            TaskLoader taskLoader = new TaskLoader();
            taskLoader.GetAllTasks();
        }
    }

    //private void DeleteButton()
    //{
        
    //    if (GUILayout.Button("Delete task", GUILayout.Width(100), GUILayout.Height(25)))
    //    {
    //        if (_selectedTask == null)
    //            return;

    //        Database.Tasks.Remove(_selectedTask);

    //        _selectedTask = new Task();
    //    }
    //}


}
