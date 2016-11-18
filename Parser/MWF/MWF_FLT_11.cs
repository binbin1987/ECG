using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 滤波
    /// </summary>
    internal class MWF_FLT_11:ITLV<string>
    {
        private string _filterInfo=string.Empty;
        public override byte TagType
        {
            get { return 0x11; }
        }

        public override string Content
        {
            get { return _filterInfo; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            _filterInfo += Encoding.Default.GetString(buffer, offset, base.DataLength);
            offset += base.DataLength;
            return ResolveResultCode.SUCCESS;
        }
    }
}
