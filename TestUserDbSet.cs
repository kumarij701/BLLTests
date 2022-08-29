using Assignment_6_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTest
{
     class TestUserDbSet : TestDbSet<UserStory>
    {
        public override UserStory Find(params object[] keyValues)
        {
            return this.SingleOrDefault(UserStory => UserStory.UserStoryId == (int)keyValues.Single());
        }
    }
}
