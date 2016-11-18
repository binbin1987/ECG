using System;
using System.Collections.Generic;
using System.IO;
using ECG.Parser.MWF;
using ECG.Definition;

namespace ECG.Parser
{
    /// <summary>
    /// MFER数据格式解析
    /// </summary>
    public class MFER
    {
        private List<MWF_NORMAL_FF> _MWF_NORMAL_FF = new List<MWF_NORMAL_FF>();
        private List<MWF_ZRO_00> _MWF_ZRO_00 = new List<MWF_ZRO_00>();
        private List<MWF_BLE_01> _MWF_BLE_01 = new List<MWF_BLE_01>();
        private List<MWF_VER_02> _MWF_VER_02 = new List<MWF_VER_02>();
        private List<MWF_TXC_03> _MWF_TXC_03 = new List<MWF_TXC_03>();
        private List<MWF_BLK_04> _MWF_BLK_04 = new List<MWF_BLK_04>();
        private List<MWF_CHN_05> _MWF_CHN_05 = new List<MWF_CHN_05>();
        private List<MWF_SEQ_06> _MWF_SEQ_06 = new List<MWF_SEQ_06>();
        private List<MWF_PNT_07> _MWF_PNT_07 = new List<MWF_PNT_07>();
        private List<MWF_WFM_08> _MWF_WFM_08 = new List<MWF_WFM_08>();
        private List<MWF_LDN_09> _MWF_LDN_09 = new List<MWF_LDN_09>();
        private List<MWF_DTP_0A> _MWF_DTP_0A = new List<MWF_DTP_0A>();
        private List<MWF_IVL_0B> _MWF_IVL_0B = new List<MWF_IVL_0B>();
        private List<MWF_SEN_0C> _MWF_SEN_0C = new List<MWF_SEN_0C>();
        private List<MWF_OFF_0D> _MWF_OFF_0D = new List<MWF_OFF_0D>();
        private List<MWF_CMP_0E> _MWF_CMP_0E = new List<MWF_CMP_0E>();
        private List<MWF_IPD_OF> _MWF_IPD_OF = new List<MWF_IPD_OF>();
        private List<MWF_FLT_11> _MWF_FLT_11 = new List<MWF_FLT_11>();
        private List<MWF_NUL_12> _MWF_NUL_12 = new List<MWF_NUL_12>();
        private List<MWF_INF_15> _MWF_INF_15 = new List<MWF_INF_15>();
        private List<MWF_NTE_16> _MWF_NTE_16 = new List<MWF_NTE_16>();
        private List<MWF_MAN_17> _MWF_MAN_17 = new List<MWF_MAN_17>();
        private List<MWF_WAV_1E> _MWF_WAV_1E = new List<MWF_WAV_1E>();
        private List<MWF_ATT_3F> _MWF_ATT_3F = new List<MWF_ATT_3F>();
        public bool ResolveSignals(string rawDataFileName, out Signals signals)
        {
            byte[] buffer = File.ReadAllBytes(rawDataFileName);
            int offset = 0;
            return ResolveSignals(buffer, offset, out signals);
        }
        public bool ResolveSignals(byte[] buffer, int offset, out Signals signals)
        {
            ClearItemList();
            BaseData.IsLittleEndian = false;
            ResolveResultCode result = ResolveResultCode.UNKNOWN_ERROR;
            while (offset < buffer.Length)
            {
                switch (buffer[offset])
                {
                    case 0x00:
                        MWF_ZRO_00 MWF_ZRO_00 = new MWF_ZRO_00();
                        result = MWF_ZRO_00.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_ZRO_00.Add(MWF_ZRO_00);
                        }
                        break;
                    case 0x01:
                        MWF_BLE_01 MWF_BLE_01 = new MWF_BLE_01();
                        result = MWF_BLE_01.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_BLE_01.Add(MWF_BLE_01);
                        }
                        break;
                    case 0x02:
                        MWF_VER_02 MWF_VER_02 = new MWF_VER_02();
                        result = MWF_VER_02.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_VER_02.Add(MWF_VER_02);
                        }
                        break;
                    case 0x03:
                        MWF_TXC_03 MWF_TXC_03 = new MWF_TXC_03();
                        result = MWF_TXC_03.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_TXC_03.Add(MWF_TXC_03);
                        }
                        break;
                    case 0x04:
                        MWF_BLK_04 MWF_BLK_04 = new MWF_BLK_04();
                        result = MWF_BLK_04.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_BLK_04.Add(MWF_BLK_04);
                        }
                        break;
                    case 0x05:
                        MWF_CHN_05 MWF_CHN_05 = new MWF_CHN_05();
                        result = MWF_CHN_05.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_CHN_05.Add(MWF_CHN_05);
                        }
                        break;
                    case 0x06:
                        MWF_SEQ_06 MWF_SEQ_06 = new MWF_SEQ_06();
                        result = MWF_SEQ_06.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_SEQ_06.Add(MWF_SEQ_06);
                        }
                        break;
                    case 0x07:
                        MWF_PNT_07 MWF_PNT_07 = new MWF_PNT_07();
                        result = MWF_PNT_07.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_PNT_07.Add(MWF_PNT_07);
                        }
                        break;
                    case 0x08:
                        MWF_WFM_08 MWF_WFM_08 = new MWF_WFM_08();
                        result = MWF_WFM_08.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_WFM_08.Add(MWF_WFM_08);
                        }
                        break;
                    case 0x09:
                        MWF_LDN_09 MWF_LDN_09 = new MWF_LDN_09();
                        result = MWF_LDN_09.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_LDN_09.Add(MWF_LDN_09);
                        }
                        break;
                    case 0x0A:
                        MWF_DTP_0A MWF_DTP_0A = new MWF_DTP_0A();
                        result = MWF_DTP_0A.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_DTP_0A.Add(MWF_DTP_0A);
                        }
                        break;
                    case 0x0B:
                        MWF_IVL_0B MWF_IVL_0B = new MWF_IVL_0B();
                        result = MWF_IVL_0B.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_IVL_0B.Add(MWF_IVL_0B);
                        }
                        break;
                    case 0x0C:
                        MWF_SEN_0C MWF_SEN_0C = new MWF_SEN_0C();
                        result = MWF_SEN_0C.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_SEN_0C.Add(MWF_SEN_0C);
                        }
                        break;
                    case 0x0D:
                        MWF_OFF_0D MWF_OFF_0D = new MWF_OFF_0D();
                        result = MWF_OFF_0D.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_OFF_0D.Add(MWF_OFF_0D);
                        }
                        break;
                    case 0x0E:
                        MWF_CMP_0E MWF_CMP_0E = new MWF_CMP_0E();
                        result = MWF_CMP_0E.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_CMP_0E.Add(MWF_CMP_0E);
                        }
                        break;
                    case 0x0F:
                        MWF_IPD_OF MWF_IPD_OF = new MWF_IPD_OF();
                        result = MWF_IPD_OF.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_IPD_OF.Add(MWF_IPD_OF);
                        }
                        break;
                    case 0x11:
                        MWF_FLT_11 MWF_FLT_11 = new MWF_FLT_11();
                        result = MWF_FLT_11.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_FLT_11.Add(MWF_FLT_11);
                        }
                        break;
                    case 0x12:
                        MWF_NUL_12 MWF_NUL_12 = new MWF_NUL_12();
                        result = MWF_NUL_12.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_NUL_12.Add(MWF_NUL_12);
                        }
                        break;
                    case 0x15:
                        MWF_INF_15 MWF_INF_15 = new MWF_INF_15();
                        result = MWF_INF_15.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_INF_15.Add(MWF_INF_15);
                        }
                        break;
                    case 0x16:
                        MWF_NTE_16 MWF_NTE_16 = new MWF_NTE_16();
                        result = MWF_NTE_16.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_NTE_16.Add(MWF_NTE_16);
                        }
                        break;
                    case 0x17:
                        MWF_MAN_17 MWF_MAN_17 = new MWF_MAN_17();
                        result = MWF_MAN_17.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_MAN_17.Add(MWF_MAN_17);
                        }
                        break;
                    case 0x1E:
                        MWF_WAV_1E MWF_WAV_1E = null;
                        if (_MWF_DTP_0A.Count > 0)
                        {
                            MWF_WAV_1E = new MWF_WAV_1E(_MWF_DTP_0A[_MWF_DTP_0A.Count - 1].Content);
                        }
                        else
                        {
                            MWF_WAV_1E = new MWF_WAV_1E(DataType.Int16);
                        }
                        result = MWF_WAV_1E.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_WAV_1E.Add(MWF_WAV_1E);
                        }
                        break;
                    case 0x3F:
                        MWF_ATT_3F att = new MWF_ATT_3F();
                        result = att.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_ATT_3F.Add(att);
                        }
                        break;
                    default:
                        MWF_NORMAL_FF MWF_NORMAL_FF = new MWF_NORMAL_FF();
                        result = MWF_NORMAL_FF.Resolve(buffer, ref offset);
                        if (result == ResolveResultCode.SUCCESS)
                        {
                            _MWF_NORMAL_FF.Add(MWF_NORMAL_FF);
                        }
                        break;
                }
            }
            if (result == ResolveResultCode.SUCCESS)
            {
                if (_MWF_WAV_1E.Count > 0
                    && _MWF_IVL_0B.Count > 0
                    && _MWF_SEN_0C.Count > 0
                    && _MWF_BLK_04.Count > 0
                    && _MWF_SEQ_06.Count > 0)
                {
                    byte iLeadNumber = (byte)_MWF_CHN_05[0].Content;
                    int iRhythmLength = (int)(_MWF_WAV_1E[0].Content.Length / _MWF_CHN_05[0].Content);
                    LeadType[] leadTypes = new LeadType[iLeadNumber];
                    for (int i = 0; i < iLeadNumber; i++)
                    {
                        leadTypes[i] = (LeadType)Enum.Parse(typeof(LeadType), MFERdef.GetLeadName(_MWF_ATT_3F[i].Content.Content));
                    }
                    signals = new Signals();
                    signals.InitializeSignals(_MWF_IVL_0B[0].SamplesPerSecond, (float)_MWF_SEN_0C[0].AVM, leadTypes);
                    for (int i = 0; i < iLeadNumber; i++)
                    {
                        signals[i].Data = new float[iRhythmLength];
                        for (int j = 0; j < iRhythmLength; j++)
                        {
                            signals[i].Data[j] = _MWF_WAV_1E[0].Content[i * _MWF_BLK_04[0].Content + j];
                        }
                    }
                    return true;
                }
            }
            signals = null;
            return false;
        }

        private void ClearItemList()
        {
            _MWF_NORMAL_FF.Clear();
            _MWF_ZRO_00.Clear();
            _MWF_BLE_01.Clear();
            _MWF_VER_02.Clear();
            _MWF_TXC_03.Clear();
            _MWF_BLK_04.Clear();
            _MWF_CHN_05.Clear();
            _MWF_SEQ_06.Clear();
            _MWF_PNT_07.Clear();
            _MWF_WFM_08.Clear();
            _MWF_LDN_09.Clear();
            _MWF_DTP_0A.Clear();
            _MWF_IVL_0B.Clear();
            _MWF_SEN_0C.Clear();
            _MWF_OFF_0D.Clear();
            _MWF_CMP_0E.Clear();
            _MWF_IPD_OF.Clear();
            _MWF_FLT_11.Clear();
            _MWF_NUL_12.Clear();
            _MWF_INF_15.Clear();
            _MWF_NTE_16.Clear();
            _MWF_MAN_17.Clear();
            _MWF_WAV_1E.Clear();
            _MWF_ATT_3F.Clear();
        }
    }
}
