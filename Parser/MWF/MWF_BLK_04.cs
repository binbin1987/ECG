using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 每帧数据块长度
    /// </summary>
    internal class MWF_BLK_04:ITLV<uint>
    {
        private uint _dataBlockLength; 
        public override byte TagType
        {
            get { return 0x04; }
        }

        public override uint Content
        {
            get { return _dataBlockLength; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            if(GetData32(buffer,base.DataLength,ref offset,out _dataBlockLength))
            {
                return ResolveResultCode.SUCCESS;
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }
}
