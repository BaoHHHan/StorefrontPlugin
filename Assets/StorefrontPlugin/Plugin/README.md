# StorefrontPlugin for Unity

**简介**  
在 iOS 16+ 上，通过 ObjC 的 SKStorefront 接口获取当前 App Store 区域代码，并在 Unity C# 中暴露。

**安装**
1. 导入本插件（.unitypackage）。
2. 在 Xcode 中无需额外手动添加 StoreKit.framework——插件会 Post‐Process 自动添加。

**使用**
1. 在代码里调用：
   ```csharp
   var code = StorefrontUtil.GetStorefrontCountryCode();
2. 返回值：
   - `string`：当前 App Store 区域代码，遵循 ISO 3166-1 Alpha-3 标准
   - 例如：如果当前 App Store 区域是中国大陆，则返回 "CHN"；如果是美国，则返回 "USA"。