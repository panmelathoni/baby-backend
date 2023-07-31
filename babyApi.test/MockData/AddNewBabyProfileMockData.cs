using babyApi.domain;

namespace babyApi.test.MockData
{
    public class AddNewBabyProfileMockData
    {
        public static List<BabyProfile> Add()
        {
            return new List<BabyProfile>
            {

                new BabyProfile {
                    Id = 1,
                    Name = "Maria",
                    Birth = "23-09-2022",
                },

                 new BabyProfile {
                    Id = 2,
                    Name = "Marcus",
                    Birth = "09-10-1987"
                },


            };
        }
    }
}

