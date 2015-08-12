// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using HammercLib.IO;

namespace HammercLib.Struct
{
    /// <summary>
    /// 提供写入数据到字节流中的功能.
    /// </summary>
    public static class BytesWriter
    {
        /// <summary>
        /// 写入一个布尔值.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteBoolean(IDataOutput output, bool value)
        {
            output.WriteBoolean(value);
        }

        /// <summary>
        /// 写入一个带符号 8 位数字.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteByte(IDataOutput output, sbyte value)
        {
            output.WriteByte(value);
        }

        /// <summary>
        /// 写入一个无符号 8 位数字.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteUByte(IDataOutput output, byte value)
        {
            output.WriteUnsignedByte(value);
        }

        /// <summary>
        /// 写入一个带符号 16 位数字.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteShort(IDataOutput output, short value)
        {
            output.WriteShort(value);
        }

        /// <summary>
        /// 写入一个无符号 16 位数字.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteUShort(IDataOutput output, ushort value)
        {
            output.WriteUnsignedShort(value);
        }

        /// <summary>
        /// 写入一个带符号 32 位数字.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteInt(IDataOutput output, int value)
        {
            output.WriteInt(value);
        }

        /// <summary>
        /// 写入一个无符号 32 位数字.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteUInt(IDataOutput output, uint value)
        {
            output.WriteUnsignedInt(value);
        }

        /// <summary>
        /// 写入一个带符号 64 位数字.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteLong(IDataOutput output, long value)
        {
            output.WriteLong(value);
        }

        /// <summary>
        /// 写入一个无符号 64 位数字.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteULong(IDataOutput output, ulong value)
        {
            output.WriteUnsignedLong(value);
        }

        /// <summary>
        /// 写入一个 32 位浮点数.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteFloat(IDataOutput output, float value)
        {
            output.WriteFloat(value);
        }

        /// <summary>
        /// 写入一个 64 位浮点数.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteDouble(IDataOutput output, double value)
        {
            output.WriteDouble(value);
        }

        /// <summary>
        /// 写入一个字符串.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteString(IDataOutput output, string value)
        {
            output.WriteUTF(value);
        }

        /// <summary>
        /// 写入一个字节数组.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">要写入的数据.</param>
        public static void WriteBytes(IDataOutput output, byte[] value)
        {
            output.WriteUnsignedInt((uint)value.Length);
            output.WriteBytes(value);
        }

        /// <summary>
        /// 写入一个自定义数据.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        /// <param name="value">自定义数据.</param>
        public static void WriteStruct(IDataOutput output, AbstractStruct value)
        {
            value.WriteExternal(output);
        }
    }
}
