using babyApi.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyApi.test.MockData
{
    public class GetAllUsersMockData
    {
        public static List<User> GetAll()
        {
            return new List<User>
            {

                new User {
                    Id = 1,
                    Name = "Maria",
                    Email = "maria@gmail.com"
                },

                 new User {
                    Id = 2,
                    Name = "Joao",
                    Email = "joao@gmail.com"
                },


            };
        }
    }
}
