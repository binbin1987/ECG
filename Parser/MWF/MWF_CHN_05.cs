using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 每帧通道数
    /// </summary>
    internal class MWF_CHN_05 : ITLV<uint>
    {
        private uint _numberOfChannels;
        public override byte TagType
        {
            get { return 0x05; }
        }

        public override uint Content
        {
            get { return _numberOfChannels; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            if (GetData32(buffer, base.DataLength, ref offset, out _numberOfChannels))
            {
                return ResolveResultCode.SUCCESS;
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }
}
