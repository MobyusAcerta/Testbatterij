using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Testbatterij.Dtos;
using Testbatterij.Models;

namespace Testbatterij.Controllers.Api
{
    public class TestScenariosController : ApiController
    {
        private ApplicationDbContext _context;

        public TestScenariosController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetTestScenarios(string query = null)
        {
            var testScenariosQuery = _context.TestScenarios.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
                testScenariosQuery = testScenariosQuery.Where(c => c.Name.Contains(query));

            var testScenarios = testScenariosQuery.ToList().Select(Mapper.Map<TestScenario, TestScenarioDto>);

            return Ok(testScenarios);
        }

        public IHttpActionResult GetTestScenario(int id)
        {
            var testScenario = _context.TestScenarios.SingleOrDefault(t => t.Id == id);

            if(testScenario == null)
                return NotFound();

            return Ok(Mapper.Map<TestScenario, TestScenarioDto>(testScenario));
        }

        [HttpPost]
        public IHttpActionResult CreateTestScenario(TestScenarioDto testScenarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var testScenario = Mapper.Map<TestScenarioDto, TestScenario>(testScenarioDto);

            _context.TestScenarios.Add(testScenario);
            _context.SaveChanges();

            testScenarioDto.Id = testScenario.Id;

            return Created(new Uri(Request.RequestUri + "/" + testScenario.Id), testScenarioDto);
        }

        [HttpPut]
        public void UpdateTestScenario(int id, TestScenarioDto testScenarioDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var testScenarioInDb = _context.TestScenarios.SingleOrDefault(c => c.Id == id);

            if (testScenarioInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(testScenarioDto, testScenarioInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public IHttpActionResult DeleteTestScenario(int id)
        {
            var testScenarioInDb = _context.TestScenarios.SingleOrDefault(c => c.Id == id);

            if (testScenarioInDb == null)
                return NotFound();

            if (testScenarioInDb.TestSetTestScenarios.Count > 0)
                return BadRequest();

            _context.TestScenarios.Remove(testScenarioInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
