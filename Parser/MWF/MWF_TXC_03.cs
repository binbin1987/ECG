using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 字符编码
    /// </summary>
    internal class MWF_TXC_03:ITLV<string>
    {
        private string _characterCode = "ASCII ";
        public override byte TagType
        {
            get { return 0x03; }
        }

        public override string Content
        {
            get { return _characterCode; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            _characterCode = Encoding.Default.GetString(buffer, offset,base.DataLength);
            offset += base.DataLength;
            return ResolveResultCode.SUCCESS;
        }
    }
}
