using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SnapshotCreator : EditorWindow
{
    public RenderTexture TargetTexture; 
    public Camera SnapshotCamera;
    public string SnapshotName;

    private SerializedObject SerializedSnapshotCreator;

    [MenuItem("Tools/SnapshotCreator")]
    public static void ShowWindow()
    {
        GetWindow<SnapshotCreator>("Take Snapshot");   
    }

    private void OnEnable()
    {
        SerializedSnapshotCreator = new SerializedObject(this);
    }
    private void OnGUI()
    {
        EditorGUILayout.PropertyField(SerializedSnapshotCreator.FindProperty("TargetTexture"));
        EditorGUILayout.PropertyField(SerializedSnapshotCreator.FindProperty("SnapshotCamera"));
        EditorGUILayout.PropertyField(SerializedSnapshotCreator.FindProperty("SnapshotName"));
        SerializedSnapshotCreator.ApplyModifiedProperties();

        if(GUILayout.Button("Take Snapshot"))
        {
            Camera SceneCamera = SceneView.lastActiveSceneView.camera;
            SnapshotCamera.transform.SetPositionAndRotation(SceneCamera.transform.position,SceneCamera.transform.rotation);

            SceneCamera.Render();

            Texture2D TextureToSave = ToTexture2D(TargetTexture);
            byte[] ImageData = TextureToSave.EncodeToPNG();

            File.WriteAllBytes($"{Application.dataPath}/Configs/Snapshot/{SnapshotName}.png", ImageData);
            AssetDatabase.Refresh();
        }
    }

    private Texture2D ToTexture2D(RenderTexture Target)
    {
        Texture2D Result = new Texture2D(Target.width, Target.height);
        RenderTexture.active = Target;

        Result.ReadPixels(new Rect(0, 0, Target.width, Target.height), 0, 0);
        Result.Apply();

        RenderTexture.active = null;

        return Result;
    }
}
