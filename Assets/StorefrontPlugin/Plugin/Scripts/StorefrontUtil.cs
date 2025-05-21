using System;
using System.Runtime.InteropServices;
using UnityEngine;

public static class StorefrontUtil
{
    #if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern IntPtr _GetStorefrontCountryCode();
    #endif

    /// <summary>
    /// 获取当前 AppStore 登录账号的国家代码
    /// </summary>
    /// <param name="testCode">非真机环境返回的测试码</param>
    /// <returns>三字母的国家／地区代码（比如 "USA"、"CAN"、"CHN" 等）</returns>
    public static string GetStorefrontCountryCode(string testCode)
    {
        #if UNITY_IOS && !UNITY_EDITOR
        IntPtr ptr = _GetStorefrontCountryCode();
        if (ptr == IntPtr.Zero) return "";
        string code = Marshal.PtrToStringUTF8(ptr) ?? "";
        Marshal.FreeHGlobal(ptr);
        return code;
        #else
        Debug.LogWarning("Storefront API 仅在 iOS 真机可用");
        return testCode;
        #endif
    }
}