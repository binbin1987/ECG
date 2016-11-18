using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    public class BaseData
    {
        public static bool IsLittleEndian = false;
        public static bool GetData64(byte[] buffer, int dataLength, ref int offset, out UInt64 value)
        {
            Int64 iValue;
            if (GetData64(buffer, dataLength, ref  offset, out iValue))
            {
                value = (UInt64)iValue;
                return true;
            }
            value = 0;
            return false;
        }

        public static bool GetData64(byte[] buffer, int dataLength, ref int offset, out Int64 value)
        {
            value = 0;
            if (dataLength > 8)
            {
                return false;
            }
            int iDataLength = 8;
            if (iDataLength > dataLength)
            {
                iDataLength = dataLength;
            }
            if (IsLittleEndian)
            {
                for (int i = 0; i < iDataLength; i++)
                {
                    int iValue = buffer[offset + i];
                    for (int j = 0; j < i; j++)
                    {
                        iValue *= 0x100;
                    }
                    value += iValue;
                }
            }
            else
            {
                for (int k = 0; k < iDataLength; k++)
                {
                    value = (value * 0x100) + buffer[offset + k];
                }
            }
            offset += dataLength;
            return true;
        }

        public static bool GetData32(byte[] buffer, int dataLength, ref int offset, out UInt32 value)
        {
            Int32 iValue;
            if (GetData32(buffer, dataLength, ref  offset, out iValue))
            {
                value = (UInt32)iValue;
                return true;
            }
            value = 0;
            return false;
        }

        public static bool GetData32(byte[] buffer, int dataLength, ref int offset, out Int32 value)
        {
            value = 0;
            if (dataLength > 4)
            {
                return false;
            }
            int iDataLength = 4;
            if (iDataLength > dataLength)
            {
                iDataLength = dataLength;
            }
            if (IsLittleEndian)
            {
                for (int i = 0; i < iDataLength; i++)
                {
                    int iValue = buffer[offset + i];
                    for (int j = 0; j < i; j++)
                    {
                        iValue *= 0x100;
                    }
                    value += iValue;
                }
            }
            else
            {
                for (int k = 0; k < iDataLength; k++)
                {
                    value = (value * 0x100) + buffer[offset + k];
                }
            }
            offset += dataLength;
            return true;
        }

        public static bool GetData16(byte[] buffer, int dataLength, ref int offset, out UInt16 value)
        {
            Int16 iValue;
            if (GetData16(buffer, dataLength, ref  offset, out iValue))
            {
                value = (UInt16)iValue;
                return true;
            }
            value = 0;
            return false;
        }

        public static bool GetData16(byte[] buffer, int dataLength, ref int offset, out Int16 value)
        {
            value = 0;
            if (dataLength > 2)
            {
                return false;
            }
            int iDataLength = 2;
            if (iDataLength > dataLength)
            {
                iDataLength = dataLength;
            }
            int tmpValue = 0;
            if (IsLittleEndian)
            {
                for (int i = 0; i < iDataLength; i++)
                {
                    int iValue = buffer[offset + i];
                    for (int j = 0; j < i; j++)
                    {
                        iValue *= 0x100;
                    }
                    tmpValue += iValue;
                }
            }
            else
            {
                for (int k = 0; k < iDataLength; k++)
                {
                    tmpValue = (tmpValue * 0x100) + buffer[offset + k];
                }
            }
            value = (short)tmpValue;
            offset += dataLength;
            return true;
        }
    }
}
