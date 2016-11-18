using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 厂家信息 
    /// </summary>
    internal class MWF_MAN_17:ITLV<string>
    {
        private string _manufacturer;
        public override byte TagType
        {
            get { return 0x17; }
        }

        public override string Content
        {
            get { return _manufacturer; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            _manufacturer += Encoding.Default.GetString(buffer, offset, base.DataLength);
            offset += base.DataLength;
            return ResolveResultCode.SUCCESS;
        }
    }
}
