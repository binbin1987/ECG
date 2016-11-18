using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 通道属性
    /// </summary>
    internal class MWF_ATT_3F : ITLV<MWF_LDN_09>
    {
        private MWF_LDN_09 _ldn = new MWF_LDN_09();
        public override byte TagType
        {
            get { return 0x3F; }
        }

        public override MWF_LDN_09 Content
        {
            get { return _ldn; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            return _ldn.Resolve(buffer,ref offset);
        }
    }
}
