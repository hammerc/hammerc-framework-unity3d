// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using HammercLib.IO;
using System;

namespace HammercLib.Struct
{
    /// <summary>
    /// 提供从字节流中读取数据的功能.
    /// </summary>
    public static class BytesReader
    {
        /// <summary>
        /// 读取一个布尔值.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static bool ReadBoolean(IDataInput input)
        {
            return input.ReadBoolean();
        }

        /// <summary>
        /// 读取一个带符号 8 位数字.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static sbyte ReadByte(IDataInput input)
        {
            return input.ReadByte();
        }

        /// <summary>
        /// 读取一个无符号 8 位数字.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static byte ReadUByte(IDataInput input)
        {
            return input.ReadUnsignedByte();
        }

        /// <summary>
        /// 读取一个带符号 16 位数字.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static short ReadShort(IDataInput input)
        {
            return input.ReadShort();
        }

        /// <summary>
        /// 读取一个无符号 16 位数字.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static ushort ReadUShort(IDataInput input)
        {
            return input.ReadUnsignedShort();
        }

        /// <summary>
        /// 读取一个带符号 32 位数字.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static int ReadInt(IDataInput input)
        {
            return input.ReadInt();
        }

        /// <summary>
        /// 读取一个无符号 32 位数字.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static uint ReadUInt(IDataInput input)
        {
            return input.ReadUnsignedInt();
        }

        /// <summary>
        /// 读取一个带符号 64 位数字.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static long ReadLong(IDataInput input)
        {
            return input.ReadLong();
        }

        /// <summary>
        /// 读取一个无符号 64 位数字.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static ulong ReadULong(IDataInput input)
        {
            return input.ReadUnsignedLong();
        }

        /// <summary>
        /// 读取一个 32 位浮点数.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static float ReadFloat(IDataInput input)
        {
            return input.ReadFloat();
        }

        /// <summary>
        /// 读取一个 64 位浮点数.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static double ReadDouble(IDataInput input)
        {
            return input.ReadDouble();
        }

        /// <summary>
        /// 读取一个字符串.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static string ReadString(IDataInput input)
        {
            return input.ReadUTF();
        }

        /// <summary>
        /// 读取一个字节数组.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <returns>对应的数据.</returns>
        public static byte[] ReadBytes(IDataInput input)
        {
            int len = (int)input.ReadUnsignedInt();
            byte[] bytes = new byte[len];
            input.ReadBytes(bytes, 0, len);
            return bytes;
        }

        /// <summary>
        /// 读取一个自定义数据.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        /// <param name="structClass">自定义数据类.</param>
        /// <returns>自定义数据.</returns>
        public static AbstractStruct ReadStruct(IDataInput input, Type structClass)
        {
            AbstractStruct target = (AbstractStruct)structClass.GetConstructor(Type.EmptyTypes).Invoke(null);
            target.ReadExternal(input);
            return target;
        }
    }
}
