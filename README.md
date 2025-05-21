# StorefrontPlugin for Unity 🚀

**StorefrontPlugin** 是一个简单易用的 Unity 插件，让您在 iOS 平台上轻松获取用户当前登陆在 App Store 的 Apple ID 的国家/地区（即商店区号）。它基于 StoreKit 1.x 的 `SKStorefront` 接口，支持 iOS 16.0+，并提供了 Unity C# 层的友好封装，让您无需编写任何 Swift 代码即可在游戏内获取两位或三位国家/地区码。

---

## 📦 主要功能

* **获取三位国家码（ISO 3166-1 alpha-3）**：例如 `"USA"`, `"CHN"`, `"GBR"`。
* **纯 Objective-C 实现**：无需额外引入 Swift，兼容性佳。
* **自动化 Xcode 后处理**：导入插件后，Build 时自动将 `StoreKit.framework` 添加到 Xcode 工程，无需手动操作。
* **C# 层友好 API**：调用单个静态方法即可获取区域码，简洁直观。

---

## 🔧 安装与导入

1. **下载 `.unitypackage`**
   从 Releases 页面获取最新版本的 `StorefrontPlugin.unitypackage` 文件。
2. **导入到 Unity**
   在 Unity 编辑器中 **双击** 或通过 `Assets → Import Package → Custom Package…` 导入。
3. **检查项目结构**
   导入后应包含：

   ```text
   Assets/
     StorefrontPlugin/
       Plugins/iOS/StorefrontPlugin.mm
       Scripts/StorefrontUtil.cs
       Editor/iOSPostProcess.cs
       README.md
   ```

---

## 🚀 快速开始

在任意 C# 脚本中调用：

```csharp
using UnityEngine;

public class Demo : MonoBehaviour
{
    void Start()
    {
        // 获取三位国家码
        string alpha3 = StorefrontUtil.GetStorefrontCountryCode();
        Debug.Log($"App Store 三位码：{alpha3}");
    }
}
```

> **注意**：在 Unity 编辑器或非 iOS 平台运行时，方法会返回空字符串，并输出警告日志。

---

## ⚙️ 配置与兼容性

* **支持平台**：iOS 16.0 及以上（真机）。
* **降级方案**：iOS 16.0 以下或模拟器返回空串，您可在 C# 端自行兜底（如使用系统区域设置）。
* **自动添加**：无需手动在 Xcode 中添加 `StoreKit.framework`，插件会在 Post-Process 中完成。

---

## 📚 API 参考

| 方法名                                | 返回值示例   | 说明                                    |
| ---------------------------------- | ------- | ------------------------------------- |
| `GetStorefrontCountryCode()` | `"USA"` | 获取三位区号（ISO 3166-1 alpha-3）            |

---

## 🛠️ 原理与实现

1. **ObjC++ 接口**：`StorefrontPlugin.mm` 中调用 `SKPaymentQueue.defaultQueue.storefront.countryCode` 获取三位码。
3. **Xcode 后处理**：`iOSPostProcess.cs` 脚本自动将 `StoreKit.framework` 添加到 Xcode 工程。
4. **C# DllImport**：通过 `Marshal` 将 C 端字符串转换为 C# 字符串。


---

## 📄 许可证

本项目采用 [MIT License](LICENSE) 开源，详情请见 LICENSE 文件。
