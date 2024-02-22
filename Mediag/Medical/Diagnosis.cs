using System;

namespace Mediag.Medical
{
    class Diagnosis
    {
        private static long lastId = 0;

        public long Id { get; protected set; } = ++lastId;

        public IllnessTypes Illness { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public bool Result { get; set; }


        public Diagnosis(IllnessTypes illness, bool result)
        {
            Illness = illness;
            Result = result;
        }

        public Diagnosis(IllnessTypes illness, bool result, DateTime date)
        {
            Illness = illness;
            Result = result;
            Date = date;
        }


        public override string ToString()
        {
            return $"Diagnosis for {Illness}: {Result} on {Date}";
        }
    }
}
