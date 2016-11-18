using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 字节顺序
    /// </summary>
    internal class MWF_BLE_01 : ITLV<bool>
    {
        private bool _isLittleEndian = false;
        public override byte TagType
        {
            get { return 0x01; }
        }

        public override bool Content
        {
            get { return _isLittleEndian; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            switch (buffer[offset])
            { 
                case 0x00:
                    _isLittleEndian = false;
                    break;
                case 0x01:
                    _isLittleEndian = true;
                    break;
                default:
                    return ResolveResultCode.CONTENT_ERROR;
            }
            IsLittleEndian = _isLittleEndian;
            offset++;
            return ResolveResultCode.SUCCESS;
        }
    }
}
