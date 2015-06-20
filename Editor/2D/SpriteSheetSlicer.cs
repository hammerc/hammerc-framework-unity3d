// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 
/// 2D 图集切割类, 使用 U3D 内置的切割功能将合成好的大图切割为小图.
/// 
/// 解决问题: 
/// 从网上下载或破解得到的已经导出的图集, 可以用这个脚本将其重新分割.
/// 
/// 使用方法及步骤: 
/// 1.先把要切割的图集导入 Unity3D 中;
/// 2.选择图片, 在属性面板里将纹理类型更改为 Advanced , 将 Read/Write Enabled 属性打勾, 将 Sprite Mode 改成 Multiple, 去掉 Mipmap 生成;
/// 3.点击 Apply 按钮进行应用;
/// 4.点击 Sprite Editor 按钮打开编辑界面对图集进行分割和对小图命名, 完成后点击 Apply 按钮应用分割;
/// 5.选中图集, 在菜单栏点击 Hammerc/2D/SpriteSheetSplit 即可在图集同一目录下生成同名的文件夹, 文件夹中会按命名导出所有的小图.
/// 
/// </summary>
public class SpriteSheetSlicer
{
    /// <summary>
    /// 将选定的带有分割信息的图片切割为同目录下的多个小图.
    /// </summary>
    [MenuItem("Hammerc/2D/SpriteSheetSplit")]
    private static void SpriteSheetSplit()
    {
        EditorUtility.DisplayProgressBar("Make Sprite Slices", "Please wait...", 1);

        //获取选择的对象
        Texture2D selectionTexture2D = Selection.activeObject as Texture2D;
        if(selectionTexture2D == null)
        {
            return;
        }
        //获取文件夹路径
        string rootPath = Path.GetDirectoryName(AssetDatabase.GetAssetPath(selectionTexture2D));
        //获取图片路径名称
        string path = rootPath + "/" + selectionTexture2D.name + ".png";
        //获取纹理导入对象
        TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
        if(textureImporter == null)
        {
            return;
        }
        //创建文件夹
        AssetDatabase.CreateFolder(rootPath, selectionTexture2D.name);
        //遍历小图集
        foreach(SpriteMetaData metaData in textureImporter.spritesheet)
        {
            //创建新的纹理对象
            Texture2D texture2D = new Texture2D((int)metaData.rect.width, (int)metaData.rect.height);
            //拷贝像素
            texture2D.SetPixels(selectionTexture2D.GetPixels((int)metaData.rect.x, (int)metaData.rect.y, (int)metaData.rect.width, (int)metaData.rect.height));
            //编码为 png 文件格式
            var pngData = texture2D.EncodeToPNG();
            //输出图片
            File.WriteAllBytes(rootPath + "/" + selectionTexture2D.name + "/" + metaData.name + ".png", pngData);
        }

        EditorUtility.ClearProgressBar();
    }
}
