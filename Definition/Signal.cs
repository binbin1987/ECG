using System;

namespace ECG.Definition
{
    public class Signal:ICloneable
    {
       public LeadType Type
        {
            get;
            set;
        }
        public float[] Data
        {
            get;
            set;
        }

        public Signal()
        {
            this.Type = LeadType.Unknown;
            this.Data = new float[0];
        }

        object ICloneable.Clone()
        {
            return new Signal() { Type = this.Type, Data = (float[])this.Data.Clone() };
        }

        public void Add(float[] data)
        {
            float[] newData = new float[Data.Length + data.Length];
            Array.Copy(Data, 0, newData, 0, Data.Length);
            Array.Copy(data, 0, newData, Data.Length, data.Length);
            Data = newData;
        }

        public void Remove(int count)
        {
            float[] newData = new float[Data.Length - count];
            Array.Copy(Data, count, newData, 0, newData.Length);
            Data = newData;
        }

        public void Empty()
        {
            this.Data = new float[0];
        }
    }
}
