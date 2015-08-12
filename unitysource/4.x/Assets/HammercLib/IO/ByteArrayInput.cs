// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using System.Text;

namespace HammercLib.IO
{
    /// <summary>
    /// 数据输入类.
    /// </summary>
    public class ByteArrayInput : IDataInput
    {
        /// <summary>
        /// 字节缓冲对象.
        /// </summary>
        protected ByteBuffer _byteBuffer;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="bytes">字节数组.</param>
        /// <param name="endian">字节序.</param>
        public ByteArrayInput(byte[] bytes, Endian endian = Endian.LittleEndian)
        {
            _byteBuffer = new ByteBuffer(bytes, endian);
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="byteBuffer">字节缓冲对象.</param>
        public ByteArrayInput(ByteBuffer byteBuffer)
        {
            _byteBuffer = byteBuffer;
        }

        public Endian endian
        {
            set { _byteBuffer.endian = value; }
            get { return _byteBuffer.endian; }
        }

        public int position
        {
            set { _byteBuffer.readIndex = value; }
            get { return _byteBuffer.readIndex; }
        }

        public int bytesAvailable
        {
            get { return _byteBuffer.capacity - _byteBuffer.readIndex; }
        }

        /// <summary>
        /// 获取字节缓冲对象.
        /// </summary>
        public ByteBuffer byteBuffer
        {
            get { return _byteBuffer; }
        }

        public bool ReadBoolean()
        {
            return _byteBuffer.ReadByte() != 0;
        }

        public sbyte ReadByte()
        {
            return _byteBuffer.ReadByte();
        }

        public byte ReadUnsignedByte()
        {
            return _byteBuffer.ReadUnsignedByte();
        }

        public short ReadShort()
        {
            return _byteBuffer.ReadShort();
        }

        public ushort ReadUnsignedShort()
        {
            return _byteBuffer.ReadUnsignedShort();
        }

        public int ReadInt()
        {
            return _byteBuffer.ReadInt();
        }

        public uint ReadUnsignedInt()
        {
            return _byteBuffer.ReadUnsignedInt();
        }

        public long ReadLong()
        {
            return _byteBuffer.ReadLong();
        }

        public ulong ReadUnsignedLong()
        {
            return _byteBuffer.ReadUnsignedLong();
        }

        public float ReadFloat()
        {
            return _byteBuffer.ReadFloat();
        }

        public double ReadDouble()
        {
            return _byteBuffer.ReadDouble();
        }

        public string ReadUTF()
        {
            ushort length = this.ReadUnsignedShort();
            return this.ReadUTFBytes(length);
        }

        public string ReadUTFBytes(int length)
        {
            byte[] bytes = new byte[length];
            _byteBuffer.ReadBytes(bytes, 0, length);
            return Encoding.UTF8.GetString(bytes);
        }

        public string ReadMultiBytes(int length, string charSet)
        {
            byte[] bytes = new byte[length];
            _byteBuffer.ReadBytes(bytes, 0, length);
            return Encoding.GetEncoding(charSet).GetString(bytes);
        }

        public void ReadBytes(byte[] bytes)
        {
            _byteBuffer.ReadBytes(bytes);
        }

        public void ReadBytes(byte[] bytes, int offset, int length)
        {
            _byteBuffer.ReadBytes(bytes, offset, length);
        }
    }
}
