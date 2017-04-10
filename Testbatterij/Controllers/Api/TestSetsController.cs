using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Testbatterij.Dtos;
using Testbatterij.Models;

namespace Testbatterij.Controllers.Api
{
    public class TestSetsController : ApiController
    {
        private ApplicationDbContext _context;

        public TestSetsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetTestSets(string query = null)
        {
            var testSetQuery = _context.TestSets.Select(ts => new
            {
                TestSet = ts,
                TestScenarios = ts.TestSetTestScenarios.OrderBy(tc => tc.Order).Select(tc => tc.TestScenario)
            });

            if (!string.IsNullOrWhiteSpace(query))
                testSetQuery = testSetQuery.Where(c => c.TestSet.Name.Contains(query));

            var result = testSetQuery.ToList().Select(c => new TestSetDto
            {
                Name = c.TestSet.Name,
                Id = c.TestSet.Id,
                TestScenarios = c.TestScenarios.Select(Mapper.Map<TestScenario, TestScenarioDto>).ToList()
            });

            return Ok(result);
        }

        public IHttpActionResult GetTestSet(int id)
        {
            var testSet = _context.TestSets.Select(ts => new
            {
                TestSet = ts,
                TestScenarios = ts.TestSetTestScenarios.OrderBy(tc => tc.Order).Select(tc => tc.TestScenario)
            }).SingleOrDefault(t => t.TestSet.Id == id);


            if (testSet == null)
                return NotFound();

            var result = new TestSetDto
            {
                Name = testSet.TestSet.Name,
                Id = testSet.TestSet.Id,
                TestScenarios = testSet.TestScenarios.Select(Mapper.Map<TestScenario, TestScenarioDto>).ToList()
            };

            return Ok(result);
        }

        
        [HttpPost]
        public IHttpActionResult CreateTestSet(NewTestSetDto newTestSetDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var testScenarios = new List<TestSetTestScenarios>();

            for (int i = 0; i < newTestSetDto.TestScenarioIds.Count; i++)
            {
                var id = newTestSetDto.TestScenarioIds[i];
                var testScenario = _context.TestScenarios.SingleOrDefault(ts => ts.Id == id);

                if (testScenario != null)
                {
                    testScenarios.Add(new TestSetTestScenarios
                    {
                        TestScenarioId = testScenario.Id,
                        Order = i
                    });
                }
            }

            if (newTestSetDto.TestScenarioIds.Count != testScenarios.Count)
                return BadRequest("One or more TestScenarioIds are invalid.");

            var testSet = new TestSet
            {
                Name = newTestSetDto.Name,
            };

            _context.TestSets.Add(testSet);

            foreach (var testScenario in testScenarios)
            {
                testScenario.TestSetId = testSet.Id;

                _context.TestSetTestScenarios.Add(testScenario);
            }
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + testSet.Id), Mapper.Map<TestSet, TestSetDto>(testSet));
        }

        
        [HttpPut]
        public IHttpActionResult UpdateTestSet(int id, NewTestSetDto newTestSetDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var testSetInDb = _context.TestSets.SingleOrDefault(c => c.Id == id);

            if (testSetInDb == null)
                return NotFound();

            var currentTestScenariosInDb = _context.TestSetTestScenarios.Where(ts => ts.TestSetId == id);
            _context.TestSetTestScenarios.RemoveRange(currentTestScenariosInDb);

            var testScenarios = new List<TestSetTestScenarios>();

            for (int i = 0; i < newTestSetDto.TestScenarioIds.Count; i++)
            {
                var testScenarioId = newTestSetDto.TestScenarioIds[i];
                var testScenario = _context.TestScenarios.SingleOrDefault(ts => ts.Id == testScenarioId);

                if (testScenario != null)
                {
                    testScenarios.Add(new TestSetTestScenarios
                    {
                        TestScenarioId = testScenario.Id,
                        Order = i
                    });
                }
            }

            if (newTestSetDto.TestScenarioIds.Count != testScenarios.Count)
                return BadRequest("One or more TestScenarioIds are invalid.");

            testSetInDb.Name = newTestSetDto.Name;

            foreach (var testScenario in testScenarios)
            {
                testScenario.TestSetId = testSetInDb.Id;

                _context.TestSetTestScenarios.Add(testScenario);
            }

            _context.SaveChanges();

            return Ok(Mapper.Map<TestSet, TestSetDto>(testSetInDb));
        }
        
        [HttpDelete]
        public IHttpActionResult DeleteTestSet(int id)
        {
            var testScenarios = _context.TestSetTestScenarios.Where(ts => ts.TestSetId == id);

            var testSetInDb = _context.TestSets.SingleOrDefault(c => c.Id == id);

            if (testSetInDb == null)
                return NotFound();

            _context.TestSetTestScenarios.RemoveRange(testScenarios);
            _context.TestSets.Remove(testSetInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
