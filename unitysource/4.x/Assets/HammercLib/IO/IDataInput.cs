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
    /// 数据输入类型.
    /// </summary>
    public interface IDataInput
    {
        /// <summary>
        /// 获取字节序.
        /// </summary>
        Endian endian { get; }

        /// <summary>
        /// 获取剩余可用的字节.
        /// </summary>
        int bytesAvailable { get; }

        /// <summary>
        /// 读取布尔值.
        /// </summary>
        /// <returns>布尔值.</returns>
        bool ReadBoolean();

        /// <summary>
        /// 读取带符号字节.
        /// </summary>
        /// <returns>带符号字节.</returns>
        sbyte ReadByte();

        /// <summary>
        /// 读取无符号字节.
        /// </summary>
        /// <returns>无符号字节.</returns>
        byte ReadUnsignedByte();

        /// <summary>
        /// 读取带符号短整型.
        /// </summary>
        /// <returns>带符号短整型.</returns>
        short ReadShort();

        /// <summary>
        /// 读取无符号短整型.
        /// </summary>
        /// <returns>无符号短整型.</returns>
        ushort ReadUnsignedShort();

        /// <summary>
        /// 读取带符号整型.
        /// </summary>
        /// <returns>带符号整型.</returns>
        int ReadInt();

        /// <summary>
        /// 读取无符号整型.
        /// </summary>
        /// <returns>无符号整型.</returns>
        uint ReadUnsignedInt();

        /// <summary>
        /// 读取带符号长整型.
        /// </summary>
        /// <returns>带符号长整型.</returns>
        long ReadLong();

        /// <summary>
        /// 读取无符号长整型.
        /// </summary>
        /// <returns>无符号长整型.</returns>
        ulong ReadUnsignedLong();

        /// <summary>
        /// 读取单精度浮点数.
        /// </summary>
        /// <returns>单精度浮点数.</returns>
        float ReadFloat();

        /// <summary>
        /// 读取双精度浮点数.
        /// </summary>
        /// <returns>双精度浮点数.</returns>
        double ReadDouble();

        /// <summary>
        /// 读取 UTF-8 字符串.
        /// </summary>
        /// <returns>UTF-8 字符串.</returns>
        string ReadUTF();

        /// <summary>
        /// 读取指定长度的 UTF-8 字符串.
        /// </summary>
        /// <param name="length">要读取的长度.</param>
        /// <returns>字符串.</returns>
        string ReadUTFBytes(int length);

        /// <summary>
        /// 读取指定长度的指定编码的字符串.
        /// </summary>
        /// <param name="length">要读取的长度.</param>
        /// <param name="charSet">指定的编码字符集.</param>
        /// <returns>字符串.</returns>
        string ReadMultiBytes(int length, string charSet);

        /// <summary>
        /// 读取剩余的所有字节.
        /// </summary>
        /// <param name="bytes">要放入的字节数组.</param>
        void ReadBytes(byte[] bytes);

        /// <summary>
        /// 读取指定长度的字节.
        /// </summary>
        /// <param name="bytes">要放入的字节数组.</param>
        /// <param name="offset">偏移量.</param>
        /// <param name="length">指定的长度.</param>
        void ReadBytes(byte[] bytes, int offset, int length);
    }
}
