using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Assignment_6_WebApi.Controllers;
using Assignment_6_WebApi.Models;
using System.Web.Http.Results;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace BLLTest
{
    public class TestUserStoryController
    {

        [SetUp]
        public void Setup()
        {
        } 
        [Test]
        public void PostUserStory_ShouldReturnSameUserStory()
        {
            var controller = new UserStoryController(new TestUserStoryContext());

           var item = GetDemoUserStory();

            var result =
                controller.AddNewUserStory(item);
            var r = result as OkObjectResult; //CreatedAtRouteNegotiatedContentResult<UserStory>;

            Assert.IsNotNull(r);
           
            //Assert.AreEqual(r.RouteName, "api/UserStory/AddUserStory");
            //Assert.AreEqual(r.RouteValues["id"], "api/UserStory/AddUserStory");
            //var r1 = result as OkObjectResult;//r.UserStoryId
            var res = (string)r.Value.GetType().GetProperty("UserStoryName").GetValue(r.Value);
            Assert.AreEqual(res, item.UserStoryName);
        }

        [Test]
        public void PutUserStory_ShouldReturnStatusCode()
        {
            var context = new TestUserStoryContext();
            var controller = new UserStoryController(context);
            context.UserStories.Add(GetDemoUserStory());
            var item = GetDemoUserStory();

            var result = controller.UpdateUserStory(item.UserStoryId, item) as Microsoft.AspNetCore.Mvc.StatusCodeResult;  //StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.OkResult>(result); // as OkObjectResult);
            //Assert.IsInstanceOf<StatusCodeResult>(result);
            Assert.AreEqual(((int)HttpStatusCode.OK), result.StatusCode);
        }

        [Test]
        public void PutUserStory_ShouldFail_WhenDifferentID()
        {
            var controller = new UserStoryController(new TestUserStoryContext());

            var badresult = controller.UpdateUserStory(999, GetDemoUserStory());
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.NotFoundResult>(badresult);
        }

        [Test]
        public void GetUserStory_ShouldReturnUserStoryWithSameID()
        {
            var context = new TestUserStoryContext();
            context.UserStories.Add(GetDemoUserStory());

            var controller = new UserStoryController(context);
            // UserStory u = new UserStory();
            var result = controller.GetById(4) as OkObjectResult; //; // as OkObjectResult(u); //
            var count = (int)result.Value.GetType().GetProperty("UserStoryId").GetValue(result.Value);
            //var res = result as 
            //serStory u = res.Value as UserStory;
            Assert.IsNotNull(count);
           
            //Assert.AreEqual(4, result.Content.UserStoryId);
        }

        [Test]
        public void GetUserStory_ShouldReturnAllUserStory()
        {
            var context = new TestUserStoryContext();
            context.UserStories.Add(new UserStory { UserStoryId = 1, UserStoryName = "Name1", StoryOwner = "Owner1", StoryPoints = 3, StoryDescription = "StoryDescription1" });
            context.UserStories.Add(new UserStory { UserStoryId = 2, UserStoryName = "Name2", StoryOwner = "Owner2", StoryPoints = 5, StoryDescription = "StoryDescription2" });
            context.UserStories.Add(new UserStory { UserStoryId = 3, UserStoryName = "Name3", StoryOwner = "Owner3", StoryPoints = 9, StoryDescription = "StoryDescription3" });


            var controller = new UserStoryController(context);
            var result = controller.GetUserStory();// as TestUserDbSet;
            //var okResult = controller.GetUserStory() as OkObjectResult;
             Assert.IsNotNull(result);
             Assert.IsInstanceOf<OkObjectResult>(result as OkObjectResult);
            //Assert.AreEqual(3, result.Local.Count);
            //var items = Assert.IsInstanceOf<List<UserStory>>(okResult.Value);
            //Assert.Equal(3, items.Count);
        }

       /** [Test]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var context = new TestUserStoryContext();
            UserStory item = GetDemoUserStory();
            context.UserStories.Add(item);

            var controller = new UserStoryController(context);
            // TestUserDbSet result = controller.GetUserStory() as TestUserDbSet;
            var result = controller.GetUserStory() as OkObjectResult;
            // var res = result.Value as UserStory;
            //Assert.IsNotNull(result);
            var m = result.Value as ClientListResponse;
            //Assert.AreEqual(1,result.Formatters.Count);
            var count = (int)result.Value.GetType().Get   GetProperty("count").GetValue(result.Value);
            //Assert.AreEqual(1, res.);
            //Assert.AreEqual(1, result.Local.Count);
            // Act
            /**var result = controller.GetUserStory() as OkObjectResult;
            // Assert
            Assert.IsInstanceOf<List<UserStory>>(result.Value);
            Assert.AreEqual(1, result.Count
        } **/



        [Test]
        public void DeleteUserStory_ShouldReturnOK()
        {
            var context = new TestUserStoryContext();
            UserStory item = GetDemoUserStory();
            context.UserStories.Add(item);

            var controller = new UserStoryController(context);
            var result = controller.DeleteUserStory(4);// as OkNegotiatedContentResult<UserStory>;

            Assert.IsNotNull(result);
            //Assert.AreEqual(item.UserStoryId, result.Content.UserStoryId);
        }

        public static UserStory GetDemoUserStory()
        {
            return new UserStory() { UserStoryId = 4, UserStoryName = "Name4", StoryOwner = "Owner4", StoryPoints = 7, StoryDescription = "StoryDescription4" };

        }
    }
}
