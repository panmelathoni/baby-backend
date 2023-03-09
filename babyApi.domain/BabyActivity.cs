namespace babyApi.domain
{
    public class BabyActivity
    {

        public int Id { get; set; }


        public DateTime InitialTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; } = string.Empty;

        public int ActivityId { get; set; }

        public virtual Activity Activities { get; set; }

        public int BabyProfileId { get; set; }

        public virtual BabyProfile Babies { get; set; }


    }
}
