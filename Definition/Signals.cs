namespace ECG.Definition
{
    public class Signals
    {
        public float SamplePerSeconds
        {
            get;
            set;
        }

        public float Resolution
        {
            get;
            set;
        }

        public Signal[] Leads
        {
            get;
            set;
        }

        public Signal this[int index]
        {
            get
            {
                return Leads[index];
            }
        }


        public Signal this[LeadType leadType]
        {
            get
            {
                if (Leads != null)
                {
                    foreach (Signal signal in Leads)
                    {
                        if (signal.Type == leadType)
                        {
                            return signal;
                        }
                    }
                }
                return null;
            }
        }

        public Signals()
        {

        }

        public void InitializeSignals(float samplePerSeconds, float resolution, LeadType[] leadType)
        {
            this.Resolution = resolution;
            this.SamplePerSeconds = samplePerSeconds;
            this.Leads = new Signal[leadType.Length];
            for (int i = 0; i < leadType.Length; i++)
            {
                this.Leads[i] = new Signal();
                this.Leads[i].Type = leadType[i];
            }
        }

        public void InitializeSignals(Signals signals)
        {
            this.Resolution = signals.Resolution;
            this.SamplePerSeconds = signals.SamplePerSeconds;
            this.Leads = new Signal[signals.Leads.Length];
            for (int i = 0; i < signals.Leads.Length; i++)
            {
                this.Leads[i] = new Signal();
                this.Leads[i].Type = signals.Leads[i].Type;
            }
        }

        public void CoverSignals(Signals signals)
        {
            this.Resolution = signals.Resolution;
            this.SamplePerSeconds = signals.SamplePerSeconds;
            this.Leads = signals.Leads;
        }

        public int GetActualLength()
        {
            if (Leads == null)
            {
                return 0;
            }
            int iActualLength = int.MaxValue;
            foreach (Signal signal in Leads)
            {
                if (iActualLength > signal.Data.Length)
                {
                    iActualLength = signal.Data.Length;
                }
            }
            return iActualLength;
        }

        public float GetActualLengthSeconds()
        {
            return GetActualLength() / SamplePerSeconds;
        }

        public int GetLeadNumber()
        {
            return this.Leads.Length;
        }
    }
}
