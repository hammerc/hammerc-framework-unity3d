// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using UnityEditor;

/// <summary>
/// 
/// 简单的 AssetBundle 创建类.
/// 
/// 解决问题: 
/// 实现简单的资源打包.
/// 
/// 使用方法及步骤: 
/// 1.修改要打包到的目标平台枚举;
/// 2.选中要打包的文件在菜单栏点击对应的功能菜单.
/// 
/// </summary>
public class SimpleCreateAssetBundle
{
    /// <summary>
    /// 打包的目标平台.
    /// </summary>
    private const BuildTarget BUILD_TARGET = BuildTarget.StandaloneWindows64;

    /// <summary>
    /// 将选定的一个对象进行打包, 同时包含依赖项, 可通过 AssetBundle 的 main 属性获取.
    /// </summary>
    [MenuItem("Hammerc/AssetBundle/CreateSingleAssetBundle")]
    private static void CreateSingleAssetBundle()
    {
        if(Selection.activeObject != null)
        {
            //显示保存窗口
            string path = EditorUtility.SaveFilePanel("Create Single AssetBundle:", "", "New AssetBundle", "assetbundle");

            if(path.Length > 0)
            {
                //打包
                BuildPipeline.BuildAssetBundle(Selection.activeObject, null, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BUILD_TARGET);
            }
        }
    }

    /// <summary>
    /// 将选定的多个对象进行打包, 同时包含依赖项, 不指定 AssetBundle 的 main 属性获取.
    /// </summary>
    [MenuItem("Hammerc/AssetBundle/CreateMultipleAssetBundle")]
    private static void CreateMultipleAssetBundle()
    {
        if(Selection.objects.Length > 0)
        {
            //显示保存窗口
            string path = EditorUtility.SaveFilePanel("Create Multiple AssetBundle:", "", "New AssetBundle", "assetbundle");

            if(path.Length > 0)
            {
                //打包
                BuildPipeline.BuildAssetBundle(null, Selection.objects, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BUILD_TARGET);
            }
        }
    }
}
