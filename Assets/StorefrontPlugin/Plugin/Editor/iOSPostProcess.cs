#if UNITY_IOS
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;

public static class iOSPostProcess
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
    {
        if (target != BuildTarget.iOS) return;

        // 打开 Xcode 工程
        var projPath = PBXProject.GetPBXProjectPath(pathToBuiltProject);
        var proj = new PBXProject();
        proj.ReadFromFile(projPath);

        // 获取 target
        string mainTarget = proj.GetUnityMainTargetGuid();

        // 添加 StoreKit.framework
        proj.AddFrameworkToProject(mainTarget, "StoreKit.framework", false);

        // 保存
        proj.WriteToFile(projPath);
    }
}
#endif