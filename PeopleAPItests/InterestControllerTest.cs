using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using HealthCatalystTest.Models;
using HealthCatalystTest.Controllers;
using HealthCatalystTest.Contracts;
using System.Linq;

namespace PeopleAPItests
{
    public class InterestControllerTest
    {

        InterestController _controller;
        IPeopleService _service;

        public InterestControllerTest()
        {
            _service = new PeopleServiceFake();
            _controller = new InterestController(_service);
        }


        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Test the Get Method
            var okResult = _controller.Get();

            //Make sure it returns a positive result
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllInterestsForPersonID()
        {
            int PersonID = 1;

            // Request all interests
            var okResult = _controller.Get(PersonID).Result as OkObjectResult;

            // Make sure it returns 3 interests
            var interests = Assert.IsType<List<Interest>>(okResult.Value);
            Assert.Equal(3, interests.Count);
        }

    }
}
