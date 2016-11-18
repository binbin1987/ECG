using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 备注
    /// </summary>
    internal class MWF_NTE_16:ITLV<string>
    {
        private string _comment;
        public override byte TagType
        {
            get { return 0x16; }
        }

        public override string Content
        {
            get { return _comment; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            _comment += Encoding.Default.GetString(buffer,offset,base.DataLength);
            offset += base.DataLength;
            return ResolveResultCode.SUCCESS;
        }
    }
}
