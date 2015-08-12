// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

namespace HammercLib.IO
{
    /// <summary>
    /// 数据输出类型.
    /// </summary>
    public interface IDataOutput
    {
        /// <summary>
        /// 设置或获取字节序.
        /// </summary>
        Endian endian { set; get; }

        /// <summary>
        /// 写入布尔值.
        /// </summary>
        /// <param name="value">布尔值.</param>
        void WriteBoolean(bool value);

        /// <summary>
        /// 写入带符号字节.
        /// </summary>
        /// <param name="value">带符号字节.</param>
        void WriteByte(sbyte value);

        /// <summary>
        /// 写入无符号字节.
        /// </summary>
        /// <param name="value">无符号字节.</param>
        void WriteUnsignedByte(byte value);

        /// <summary>
        /// 写入带符号短整型.
        /// </summary>
        /// <param name="value">带符号短整型.</param>
        void WriteShort(short value);

        /// <summary>
        /// 写入无符号短整型.
        /// </summary>
        /// <param name="value">无符号短整型.</param>
        void WriteUnsignedShort(ushort value);

        /// <summary>
        /// 写入带符号整型.
        /// </summary>
        /// <param name="value">带符号整型.</param>
        void WriteInt(int value);

        /// <summary>
        /// 写入无符号整型.
        /// </summary>
        /// <param name="value">无符号整型.</param>
        void WriteUnsignedInt(uint value);

        /// <summary>
        /// 写入带符号长整型.
        /// </summary>
        /// <param name="value">带符号长整型.</param>
        void WriteLong(long value);

        /// <summary>
        /// 写入无符号长整型.
        /// </summary>
        /// <param name="value">无符号长整型.</param>
        void WriteUnsignedLong(ulong value);

        /// <summary>
        /// 写入单精度浮点数.
        /// </summary>
        /// <param name="value">单精度浮点数.</param>
        void WriteFloat(float value);

        /// <summary>
        /// 写入双精度浮点数.
        /// </summary>
        /// <param name="value">双精度浮点数.</param>
        void WriteDouble(double value);

        /// <summary>
        /// 写入 UTF-8 字符串.
        /// </summary>
        /// <param name="value">字符串.</param>
        void WriteUTF(string value);

        /// <summary>
        /// 写入不带长度标识 UTF-8 字符串.
        /// </summary>
        /// <param name="value">字符串.</param>
        void WriteUTFBytes(string value);

        /// <summary>
        /// 写入指定编码的字符串.
        /// </summary>
        /// <param name="value">字符串.</param>
        /// <param name="charSet">指定的编码字符集.</param>
        void WriteMultiBytes(string value, string charSet);

        /// <summary>
        /// 写入指定的字节数组.
        /// </summary>
        /// <param name="bytes">字节数组.</param>
        void WriteBytes(byte[] bytes);

        /// <summary>
        /// 写入指定的字节数组.
        /// </summary>
        /// <param name="bytes">字节数组.</param>
        /// <param name="offset">偏移量.</param>
        /// <param name="length">指定的长度.</param>
        void WriteBytes(byte[] bytes, int offset, int length);
    }
}
