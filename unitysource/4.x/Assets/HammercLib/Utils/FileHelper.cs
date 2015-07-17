// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using System;
using System.IO;
using System.Text;

namespace HammercLib.Utils
{
    /// <summary>
    /// 文件工具类.
    /// </summary>
    public sealed class FileHelper
    {
        /// <summary>
        /// 系统路径分隔符.
        /// </summary>
        public static readonly char SEPARATOR = Path.DirectorySeparatorChar;

        /// <summary>
        /// 系统换行符.
        /// </summary>
        public static readonly string LINE_SEPARATOR = Environment.NewLine;

        /// <summary>
        /// 保存数据到指定文件.
        /// </summary>
        /// <param name="path">文件完整路径名.</param>
        /// <param name="bytes">要保存的数据.</param>
        /// <returns>是否保存成功.</returns>
        public static bool SaveAsBytes(string path, byte[] bytes)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = File.Open(path, FileMode.OpenOrCreate);
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Flush();
                fileStream.Close();
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                if(fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
            return true;
        }

        /// <summary>
        /// 保存数据到指定文件.
        /// </summary>
        /// <param name="path">文件完整路径名.</param>
        /// <param name="content">要保存的数据.</param>
        /// <returns>是否保存成功.</returns>
        public static bool SaveAsString(string path, string content)
        {
            return SaveAsString(path, content, Encoding.UTF8);
        }

        /// <summary>
        /// 保存数据到指定文件.
        /// </summary>
        /// <param name="path">文件完整路径名.</param>
        /// <param name="content">要保存的数据.</param>
        /// <param name="encoding">编码格式.</param>
        /// <returns>是否保存成功.</returns>
        public static bool SaveAsString(string path, string content, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(content);
            return SaveAsBytes(path, bytes);
        }

        /// <summary>
        /// 打开文件的简便方法.
        /// </summary>
        /// <param name="path">文件完整路径名.</param>
        /// <returns>文件内容.</returns>
        public static byte[] ReadAsBytes(string path)
        {
            byte[] bytes = null;
            using(FileStream fileStream = File.Open(path, FileMode.Open))
            {
                bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, (int)fileStream.Length);
                fileStream.Close();
            }
            return bytes;
        }

        /// <summary>
        /// 打开文件的简便方法.
        /// </summary>
        /// <param name="path">文件完整路径名.</param>
        /// <returns>文件内容.</returns>
        public static string ReadAsString(string path)
        {
            return ReadAsString(path, Encoding.UTF8);
        }

        /// <summary>
        /// 打开文件的简便方法.
        /// </summary>
        /// <param name="path">文件完整路径名.</param>
        /// <param name="encoding">编码格式.</param>
        /// <returns>文件内容.</returns>
        public static string ReadAsString(string path, Encoding encoding)
        {
            byte[] bytes = ReadAsBytes(path);
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 移动文件或目录.
        /// </summary>
        /// <param name="source">文件源路径.</param>
        /// <param name="dest">文件要移动到的目标路径.</param>
        /// <param name="overwrite">是否覆盖同名文件.</param>
        /// <returns>是否移动成功.</returns>
        public static bool MoveTo(string source, string dest, bool overwrite = true)
        {
            if(!overwrite && Exists(dest))
            {
                return false;
            }
            File.Move(source, dest);
            return true;
        }

        /// <summary>
        /// 复制文件或目录.
        /// </summary>
        /// <param name="source">文件源路径.</param>
        /// <param name="dest">文件要移动到的目标路径.</param>
        /// <param name="overwrite">是否覆盖同名文件.</param>
        /// <returns>是否复制成功.</returns>
        public static bool CopyTo(string source, string dest, bool overwrite = true)
        {
            if(!overwrite && Exists(dest))
            {
                return false;
            }
            File.Copy(source, dest);
            return true;
        }

        /// <summary>
        /// 删除文件或目录.
        /// </summary>
        /// <param name="path">要删除的文件源路径.</param>
        /// <returns>是否删除成功.</returns>
        public static bool DeletePath(string path)
        {
            if(!Exists(path))
            {
                return false;
            }
            if(IsDirectory(path))
            {
                Directory.Delete(path, true);
            }
            else
            {
                File.Delete(path);
            }
            return true;
        }

        /// <summary>
        /// 获取文件的文件夹路径.
        /// </summary>
        /// <param name="path">指定文件.</param>
        /// <returns>文件夹路径.</returns>
        public static string GetDirectory(string path)
        {
            int separatePos = Math.Max(path.LastIndexOf('/'), path.LastIndexOf('\\'));
            return separatePos == -1 ? path : path.Substring(0, separatePos);
        }

        /// <summary>
        /// 获取路径的文件名或文件夹名.
        /// </summary>
        /// <param name="path">指定文件.</param>
        /// <returns>对应的文件名或文件夹名.</returns>
        public static string GetFileName(string path)
        {
            int separatePos = Math.Max(path.LastIndexOf('/'), path.LastIndexOf('\\'));
            return separatePos == -1 ? path : path.Substring(separatePos + 1, path.Length);
        }

        /// <summary>
        /// 获取文件扩展名.
        /// </summary>
        /// <param name="fileName">文件名.</param>
        /// <returns>文件扩展名.</returns>
        public static string GetFileExtension(string fileName)
        {
            int separatePos = fileName.LastIndexOf('.');
            return separatePos == -1 ? fileName : fileName.Substring(separatePos + 1);
        }

        /// <summary>
        /// 获取去掉扩展名的路径.
        /// </summary>
        /// <param name="path">指定文件.</param>
        /// <returns>去掉扩展名的路径.</returns>
        public static string GetNoneExtension(string path)
        {
            int separatePos = path.LastIndexOf('.');
            return separatePos == -1 ? path : path.Substring(0, separatePos);
        }

        /// <summary>
        /// 获取指定目录下的所有文件列表.
        /// </summary>
        /// <param name="path">指定目录.</param>
        /// <param name="recursive">是否包含子目录.</param>
        /// <returns>指定目录下的所有文件列表.</returns>
        public static FileInfo[] GetFileList(string path, bool recursive = false)
        {
            return GetFileList(path, "*.*", recursive);
        }

        /// <summary>
        /// 获取指定目录下的所有文件列表.
        /// </summary>
        /// <param name="path">指定目录.</param>
        /// <param name="searchPattern">文件名过滤表达式.</param>
        /// <param name="recursive">是否包含子目录.</param>
        /// <returns>指定目录下的所有文件列表.</returns>
        public static FileInfo[] GetFileList(string path, string searchPattern, bool recursive = false)
        {
            if(!IsDirectory(path))
            {
                throw new FileNotFoundException();
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles(searchPattern, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// 指定路径的文件或文件夹是否存在.
        /// </summary>
        /// <param name="path">指定路径的文件或文件夹.</param>
        /// <returns>指定的文件或文件夹是否存在.</returns>
        public static bool Exists(string path)
        {
            return File.Exists(path) || Directory.Exists(path);
        }

        /// <summary>
        /// 判断指定路径是否为文件夹.
        /// </summary>
        /// <param name="path">指定路径的文件或文件夹.</param>
        /// <returns>指定路径是否为文件夹.</returns>
        public static bool IsDirectory(string path)
        {
            if(!Exists(path))
            {
                throw new FileNotFoundException();
            }
            FileInfo fileInfo = new FileInfo(path);
            return (fileInfo.Attributes & FileAttributes.Directory) != 0;
        }

        /// <summary>
        /// 创建指定的文件夹.
        /// </summary>
        /// <param name="path">文件夹路径.</param>
        public static void CreateDirectoty(string path)
        {
            if(!Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// 格式化路径为当前系统可使用的路径, 去掉末尾的路径分隔符.
        /// </summary>
        /// <param name="path">带格式化的路径.</param>
        /// <returns>格式化的路径.</returns>
        public static string FormatPath(string path)
        {
            string separator = SEPARATOR.ToString();
            if(separator == "\\")
            {
                separator = "\\\\";
            }
            path = path.Replace("\\\\", separator);
            path = path.Replace("/", separator);
            int index = path.LastIndexOf(SEPARATOR);
            if (index == path.Length - 1)
            {
                path = path.Substring(0, path.Length - 1);
            }
            return path;
        }

        /// <summary>
        /// 统一换行符为系统默认的换行符.
        /// </summary>
        /// <param name="source">带处理文本.</param>
        /// <returns>处理后的文本.</returns>
        public static string UnifyEnter(string source)
        {
            source = source.Replace("\\r\\n", "\r");
            source = source.Replace("\\n", "\r");
            source = source.Replace("\\r", LINE_SEPARATOR);
            return source;
        }
    }
}
