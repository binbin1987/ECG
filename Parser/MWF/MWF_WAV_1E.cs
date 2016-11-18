using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 波形数据
    /// </summary>
    internal class MWF_WAV_1E:ITLV<short[]>
    {
        public override byte TagType
        {
            get { return 0x1E; }
        }

        public override short[] Content
        {
            get { return _waveData; }
        }
        private short[] _waveData;
        private DataType _dataType;
        public MWF_WAV_1E(DataType dataType)
        {
            _dataType = dataType;
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            switch (_dataType)
            {
                case DataType.Int16:
                case DataType.Int16_Status:
                    {
                        _waveData = new short[base.DataLength / 2];
                        if (IsLittleEndian)
                        {
                            System.Buffer.BlockCopy(buffer, offset, _waveData, 0, base.DataLength);
                        }
                        else
                        {
                            int iOffset = offset;
                            short sData;
                            for (int i = 0; i < _waveData.Length; i++)
                            {
                                GetData16(buffer, 2, ref iOffset, out sData);
                                _waveData[i] = sData;
                            }
                        }
                    }
                    break;
                case DataType.Int32:
                    {
                        int[] waveData = new int[base.DataLength / 4];
                        if (IsLittleEndian)
                        {
                            System.Buffer.BlockCopy(buffer, offset, waveData, 0, base.DataLength);
                        }
                        else
                        {
                            int iOffset = offset;
                            int iData;
                            for (int i = 0; i < waveData.Length; i++)
                            {
                                GetData32(buffer, 4, ref iOffset, out iData);
                                waveData[i] = iData;
                            }
                        }
                        _waveData = new short[waveData.Length];
                        System.Buffer.BlockCopy(waveData, 0, _waveData, 0, _waveData.Length);
                    }
                    break;
                case DataType.Int64:
                    {
                        long[] waveData = new long[base.DataLength / 8];
                        if (IsLittleEndian)
                        {
                            System.Buffer.BlockCopy(buffer, offset, waveData, 0, base.DataLength);
                        }
                        else
                        {
                            int iOffset = offset;
                            long lData;
                            for (int i = 0; i < waveData.Length; i++)
                            {
                                GetData64(buffer, 8, ref iOffset, out lData);
                                waveData[i] = lData;
                            }
                        }
                        _waveData = new short[waveData.Length];
                        System.Buffer.BlockCopy(waveData, 0, _waveData, 0, _waveData.Length);
                    }
                    break;
                case DataType.Int8:
                case DataType.Int8_AHA:
                    {
                        byte[] waveData = new byte[base.DataLength];
                        System.Buffer.BlockCopy(buffer, offset, waveData, 0, base.DataLength);
                        _waveData = new short[waveData.Length];
                        System.Buffer.BlockCopy(waveData, 0, _waveData, 0, _waveData.Length);
                    }
                    break;
                case DataType.uInt8:
                    {
                        sbyte[] waveData = new sbyte[base.DataLength];
                        System.Buffer.BlockCopy(buffer, offset, waveData, 0, base.DataLength);
                        _waveData = new short[waveData.Length];
                        System.Buffer.BlockCopy(waveData, 0, _waveData, 0, _waveData.Length);
                    }
                    break;
                case DataType.uInt16:
                    {
                        UInt16[] waveData = new ushort[base.DataLength / 2];
                        if (IsLittleEndian)
                        {
                            System.Buffer.BlockCopy(buffer, offset, waveData, 0, base.DataLength);
                        }
                        else
                        {
                            int iOffset = offset;
                            UInt16 uData;
                            for (int i = 0; i < waveData.Length; i++)
                            {
                                GetData16(buffer, 2, ref iOffset, out uData);
                                waveData[i] = uData;
                            }
                        }
                        _waveData = new short[waveData.Length];
                        System.Buffer.BlockCopy(waveData, 0, _waveData, 0, _waveData.Length);
                    }
                    break;
                case DataType.uInt32:
                    {
                        UInt32[] waveData = new UInt32[base.DataLength / 4];
                        if (IsLittleEndian)
                        {
                            System.Buffer.BlockCopy(buffer, offset, waveData, 0, base.DataLength);
                        }
                        else
                        {
                            int iOffset = offset;
                            uint uData;
                            for (int i = 0; i < waveData.Length; i++)
                            {
                                GetData32(buffer, 4, ref iOffset, out uData);
                                waveData[i] = uData;
                            }
                        }
                        _waveData = new short[waveData.Length];
                        System.Buffer.BlockCopy(waveData, 0, _waveData, 0, _waveData.Length);
                    }
                    break;
            }
            offset += base.DataLength;
            return ResolveResultCode.SUCCESS;
        }

    }
}
