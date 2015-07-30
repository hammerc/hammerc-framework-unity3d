// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using System;

namespace HammercLib.IO
{
    /// <summary>
    /// 字节缓冲类.
    /// </summary>
    public class ByteBuffer
    {
        private byte[] _bytes;
        private int _capacity;
        private Endian _endian;

        private int _readIndex = 0;
        private int _writeIndex = 0;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="capacity">字节容量.</param>
        /// <param name="endian">字节序.</param>
        public ByteBuffer(int capacity, Endian endian = Endian.LittleEndian)
        {
            _bytes = new byte[capacity];
            _capacity = capacity;
            _endian = endian;
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="bytes">字节数组.</param>
        /// <param name="endian">字节序.</param>
        public ByteBuffer(byte[] bytes, Endian endian = Endian.LittleEndian)
        {
            _bytes = bytes;
            _capacity = _bytes.Length;
            _endian = endian;
        }

        /// <summary>
        /// 获取当前的容量.
        /// </summary>
        public int capacity
        {
            get { return _capacity; }
        }

        /// <summary>
        /// 获取字节序.
        /// </summary>
        public Endian endian
        {
            get { return _endian; }
        }

        private byte[] Flip(byte[] bytes)
        {
            if((BitConverter.IsLittleEndian && _endian == Endian.BigEndian) || (!BitConverter.IsLittleEndian && _endian == Endian.LittleEndian))
            {
                Array.Reverse(bytes);
            }
            return bytes;
        }

        private byte[] ReadByFlip(int len)
        {
            byte[] bytes = new byte[len];
            Array.Copy(_bytes, _readIndex, bytes, 0, len);
            Flip(bytes);
            _readIndex += len;
            return bytes;
        }

        private int FixSizeAndReset(int curLen, int newLen)
        {
            if(newLen > curLen)
            {
                int size = FixLength(curLen) * 2;
                if(newLen > size)
                {
                    size = FixLength(newLen) * 2;
                }
                byte[] newBytes = new byte[size];
                Array.Copy(_bytes, 0, newBytes, 0, curLen);
                _bytes = newBytes;
                _capacity = newBytes.Length;
            }
            return newLen;
        }

        private int FixLength(int length)
        {
            int result = 2;
            int n = 2;
            while(result < length)
            {
                result = 2 << n;
                n++;
            }
            return result;
        }

        /// <summary>
        /// 读取一个字节.
        /// </summary>
        /// <returns>字节.</returns>
        public byte ReadByte()
        {
            byte result = _bytes[_readIndex];
            _readIndex++;
            return result;
        }

        /// <summary>
        /// 读取一个短整型.
        /// </summary>
        /// <returns>短整型.</returns>
        public short ReadShort()
        {
            return BitConverter.ToInt16(ReadByFlip(2), 0);
        }

        /// <summary>
        /// 读取一个无符号短整型.
        /// </summary>
        /// <returns>无符号短整型.</returns>
        public ushort ReadUnsignedShort()
        {
            return BitConverter.ToUInt16(ReadByFlip(2), 0);
        }

        /// <summary>
        /// 读取一个 32 位整型.
        /// </summary>
        /// <returns>32 位整型.</returns>
        public int ReadInt()
        {
            return BitConverter.ToInt32(ReadByFlip(4), 0);
        }

        /// <summary>
        /// 读取一个无符号 32 位整型.
        /// </summary>
        /// <returns>无符号 32 位整型.</returns>
        public uint ReadUnsignedInt()
        {
            return BitConverter.ToUInt32(ReadByFlip(4), 0);
        }

        /// <summary>
        /// 读取一个 64 位整型.
        /// </summary>
        /// <returns>64 位整型.</returns>
        public long ReadLong()
        {
            return BitConverter.ToInt64(ReadByFlip(8), 0);
        }

        /// <summary>
        /// 读取一个无符号 64 位整型.
        /// </summary>
        /// <returns>无符号 64 位整型.</returns>
        public ulong ReadUnsignedLong()
        {
            return BitConverter.ToUInt64(ReadByFlip(8), 0);
        }

        /// <summary>
        /// 读取一个 32 位浮点数.
        /// </summary>
        /// <returns>32 位浮点数.</returns>
        public float ReadFloat()
        {
            return BitConverter.ToSingle(ReadByFlip(4), 0);
        }

        /// <summary>
        /// 读取一个 64 位浮点数.
        /// </summary>
        /// <returns>64 位浮点数.</returns>
        public double ReadDouble()
        {
            return BitConverter.ToDouble(ReadByFlip(8), 0);
        }

        /// <summary>
        /// 读取指定的多个字节填满目标字节数组.
        /// </summary>
        /// <param name="bytes">读取数据的目标字节数组.</param>
        public void ReadBytes(byte[] bytes)
        {
            this.ReadBytes(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// 读取指定的多个字节.
        /// </summary>
        /// <param name="bytes">读取数据的目标字节数组.</param>
        /// <param name="offset">目标字节数组的起始偏移量.</param>
        /// <param name="length">读取的字节长度.</param>
        public void ReadBytes(byte[] bytes, int offset, int length)
        {
            int size = offset + length;
            for(int i = offset; i < size; i++)
            {
                bytes[i] = this.ReadByte();
            }
        }

        /// <summary>
        /// 写入一个字节.
        /// </summary>
        /// <param name="value">字节.</param>
        public void WriteByte(byte value)
        {
            int afterLen = _writeIndex + 1;
            int len = _bytes.Length;
            FixSizeAndReset(len, afterLen);
            _bytes[_writeIndex] = value;
            _writeIndex = afterLen;
        }

        /// <summary>
        /// 写入一个短整型.
        /// </summary>
        /// <param name="value">短整型.</param>
        public void WriteShort(short value)
        {
            this.WriteBytes(Flip(BitConverter.GetBytes(value)));
        }

        /// <summary>
        /// 写入一个无符号短整型.
        /// </summary>
        /// <param name="value">短整型.</param>
        public void WriteUnsignedShort(ushort value)
        {
            this.WriteBytes(Flip(BitConverter.GetBytes(value)));
        }

        /// <summary>
        /// 写入一个 32 位整型.
        /// </summary>
        /// <param name="value">32 位整型.</param>
        public void WriteInt(int value)
        {
            this.WriteBytes(Flip(BitConverter.GetBytes(value)));
        }

        /// <summary>
        /// 写入一个无符号 32 位整型.
        /// </summary>
        /// <param name="value">无符号 32 位整型.</param>
        public void WriteUnsignedInt(uint value)
        {
            this.WriteBytes(Flip(BitConverter.GetBytes(value)));
        }

        /// <summary>
        /// 写入一个 64 位整型.
        /// </summary>
        /// <param name="value">64 位整型.</param>
        public void WriteLong(long value)
        {
            this.WriteBytes(Flip(BitConverter.GetBytes(value)));
        }

        /// <summary>
        /// 写入一个无符号 64 位整型.
        /// </summary>
        /// <param name="value">无符号 64 位整型.</param>
        public void WriteUnsignedLong(ulong value)
        {
            this.WriteBytes(Flip(BitConverter.GetBytes(value)));
        }

        /// <summary>
        /// 写入一个 32 位浮点数.
        /// </summary>
        /// <param name="value">32 位浮点数.</param>
        public void WriteFloat(float value)
        {
            this.WriteBytes(Flip(BitConverter.GetBytes(value)));
        }

        /// <summary>
        /// 写入一个 64 位浮点数.
        /// </summary>
        /// <param name="value">64 位浮点数.</param>
        public void WriteDouble(double value)
        {
            this.WriteBytes(Flip(BitConverter.GetBytes(value)));
        }

        /// <summary>
        /// 写入字节缓冲对象.
        /// </summary>
        /// <param name="buffer">字节缓冲对象.</param>
        public void WriteBytes(ByteBuffer buffer)
        {
            if(buffer == null)
            {
                return;
            }
            this.WriteBytes(buffer.ToArray());
        }

        /// <summary>
        /// 写入字节数组.
        /// </summary>
        /// <param name="bytes">字节数组.</param>
        public void WriteBytes(byte[] bytes)
        {
            this.WriteBytes(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// 写入字节数组.
        /// </summary>
        /// <param name="bytes">要写入字节的目标字节数组.</param>
        /// <param name="offset">目标字节数组的起始偏移量.</param>
        /// <param name="length">写入的长度.</param>
        public void WriteBytes(byte[] bytes, int offset, int length)
        {
            lock(this)
            {
                int temp = length - offset;
                if(temp <= 0)
                {
                    return;
                }
                int total = temp + _writeIndex;
                int len = _bytes.Length;
                FixSizeAndReset(len, total);
                for(int i = _writeIndex, j = offset; i < total; i++, j++)
                {
                    _bytes[i] = bytes[j];
                }
                _writeIndex = total;
            }
        }

        /// <summary>
        /// 获取字节缓冲对象对应的字节数组.
        /// </summary>
        /// <returns>字节数组.</returns>
        public byte[] ToArray()
        {
            byte[] bytes = new byte[_writeIndex];
            Array.Copy(_bytes, 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// 清空当前字节缓冲, 可进行重复利用.
        /// </summary>
        public void Clear()
        {
            _readIndex = 0;
            _writeIndex = 0;
        }
    }
}
