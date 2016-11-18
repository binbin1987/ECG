using System;
using System.Collections.Generic;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// MFER中的定义
    /// </summary>
    internal class MFERdef
    {
        public static int[] dTypeCode = new int[] { 0, 1, 2, 3, 4, 5, 6 };
        public static string[] dTypeName = new string[] { "Signed 16 bits integer", "Unsigned 16 bits integer", "Signed 32 bits integer", "Unsigned 8 bits integer", "16 bits status", "Signed 8 bits integer", "Unsigned 32 bits integer", "32 bitst single-precision floating(IEEE754)", "64 bits double-precision floating(IEEE754)", "8 bits AHA differential" };
        public static int[] ECGleadCode = new int[] { 
            1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 15, 0x3d, 0x3e, 
            0x3f, 0x40, 0x42, 0x43, 0x44, 0x45
         };
        public static string[] ECGleadName = new string[] { 
            "I", "II", "V1", "V2", "V3", "V4", "V5", "V6", "V7", "V3R", "V4R", "V5R", "V6R", "V7R", "III", "aVR", 
            "aVL", "aVF", "V8", "V9", "V8R", "V9R"
         };
        public static int[] WaveformCode = new int[] { 1, 2, 40, 20, 30 };
        public static string[] WaveformName = new string[] { "Standard 12 lead ECG", "Long term ECG", "EEG", "Monitor", "PCG" };
        
        public static string GetLeadName(int leadCode)
        {
            for (int i = 0; i < ECGleadCode.Length; i++)
            {
                if (ECGleadCode[i] == leadCode)
                {
                    return ECGleadName[i];
                }
            }
            return "II";
        }
        public const int MAX_EVENT_CNT = 0x30d40;
        public const int MAX_WAVE_CHANNEL = 0x80;
        public const int MWF_AGE = 0x83;
        public const int MWF_AHA_DIF = 1;
        public const int MWF_ATT = 0x3f;
        public const int MWF_BLE = 1;
        public const int MWF_BLK = 4;
        public const int MWF_CHN = 5;
        public const int MWF_CMP = 14;
        public const int MWF_DTP = 10;
        public const int MWF_ECG12_1 = 1;
        public const int MWF_ECG12_2 = 2;
        public const int MWF_ECG12_3 = 0x3d;
        public const int MWF_ECG12_aVF = 0x40;
        public const int MWF_ECG12_aVL = 0x3f;
        public const int MWF_ECG12_aVR = 0x3e;
        public const int MWF_ECG12_V1 = 3;
        public const int MWF_ECG12_V2 = 4;
        public const int MWF_ECG12_V3 = 5;
        public const int MWF_ECG12_V3R = 11;
        public const int MWF_ECG12_V4 = 6;
        public const int MWF_ECG12_V4R = 12;
        public const int MWF_ECG12_V5 = 7;
        public const int MWF_ECG12_V5R = 13;
        public const int MWF_ECG12_V6 = 8;
        public const int MWF_ECG12_V6R = 14;
        public const int MWF_ECG12_V7 = 9;
        public const int MWF_ECG12_V7R = 15;
        public const int MWF_ECG12_V8 = 0x42;
        public const int MWF_ECG12_V8R = 0x44;
        public const int MWF_ECG12_V9 = 0x43;
        public const int MWF_ECG12_V9R = 0x45;
        public const int MWF_EEG = 40;
        public const int MWF_END = 0x80;
        public const int MWF_EVT = 0x41;
        public const int MWF_EVT_L1 = 0x13;
        public const int MWF_FLT = 0x11;
        public const int MWF_FQ_1m = 2;
        public const int MWF_FQ_1s = 3;
        public const int MWF_FQ_1u = 1;
        public const int MWF_FQ_HZ = 0;
        public const int MWF_INF = 0x15;
        public const int MWF_IPD = 15;
        public const int MWF_IVL = 11;
        public const int MWF_LDN = 9;
        public const int MWF_LONG_TERM = 2;
        public const int MWF_MAN = 0x17;
        public const int MWF_MAP = 0x88;
        public const int MWF_MONT = 20;
        public const int MWF_MSS = 0x86;
        public const int MWF_MSS_L1 = 0x1d;
        public const int MWF_NTE = 0x16;
        public const int MWF_NUL = 0x12;
        public const int MWF_OFF = 13;
        public const int MWF_PCG = 30;
        public const int MWF_PCG_H = 0x203;
        public const int MWF_PCG_L = 0x201;
        public const int MWF_PCG_M = 0x202;
        public const int MWF_PCG_O = 0x200;
        public const int MWF_PID = 130;
        public const int MWF_PID_L1 = 0x1b;
        public const int MWF_PNM = 0x81;
        public const int MWF_PNM_L1 = 0x1a;
        public const int MWF_PNT = 7;
        public const int MWF_PRE = 0x40;
        public const int MWF_RPT = 0x68;
        public const int MWF_SEN = 12;
        public const int MWF_SEQ = 6;
        public const int MWF_SET = 0x67;
        public const int MWF_SEX = 0x84;
        public const int MWF_SIG = 0x69;
        public const int MWF_SKW = 0x43;
        public const int MWF_SKW_L1 = 0x10;
        public const int MWF_SN_mV = 2;
        public const int MWF_SN_nV = 0;
        public const int MWF_SN_uV = 1;
        public const int MWF_SN_V = 3;
        public const int MWF_STD12 = 1;
        public const int MWF_TIM = 0x85;
        public const int MWF_TIM_L1 = 0x1c;
        public const int MWF_TXC = 3;
        public const int MWF_UID = 0x87;
        public const int MWF_VAL = 0x42;
        public const int MWF_VAL_L1 = 20;
        public const int MWF_VER = 2;
        public const int MWF_WAV = 30;
        public const int MWF_WFM = 8;
        public const int MWF_ZRO = 0;
    }
}
