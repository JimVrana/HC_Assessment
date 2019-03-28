using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using HealthCatalystTest.Models;
using HealthCatalystTest.Controllers;
using HealthCatalystTest.Contracts;

namespace PeopleAPItests
{
    public class PeopleControllerTest
    {

        PeopleController _controller;
        IPeopleService _service;



        public PeopleControllerTest()
        {
            _service = new PeopleServiceFake();
            _controller = new PeopleController(_service);



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
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Request all people
            var okResult = _controller.Get().Result as OkObjectResult;

            // Make sure it returns 4 people
            var people = Assert.IsType<List<Person>>(okResult.Value);
            Assert.Equal(4, people.Count);
        }


        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Use a guid from our fake data
            var testID = 3;

            // Try to find the person
            var okResult = _controller.Get(testID);

            // Make sure that the response is positive
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Use a guid from our fake data
            var testID = 3;

            // Try to find the person
            var okResult = _controller.Get(testID).Result as OkObjectResult;

            // Make sure the person is the one that we're looking for
            Assert.IsType<Person>(okResult.Value);
            Assert.Equal(testID, (okResult.Value as Person).Id);
        }


        [Fact]
        public void GetByString_SearchSringPassed_ReturnsOkResult()
        {
            // Use a guid from our fake data
            var testID = 3;

            // Try to find the person
            var okResult = _controller.Get(testID);

            // Make sure that the response is positive
            Assert.IsType<OkObjectResult>(okResult.Result);
        }



    }
}
