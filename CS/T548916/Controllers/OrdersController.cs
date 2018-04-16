using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dxSample.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Web.Http.ModelBinding;

namespace dxSample.Controllers
{
    public class DataController : ApiController
    {

        InMemoryEmployeesDataContext db = new InMemoryEmployeesDataContext();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(db.Employees, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage GetStates(DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(SampleData.States, loadOptions));
        }
        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            var values = form.Get("values");

            var newEmployee = new Employee();
            JsonConvert.PopulateObject(values, newEmployee);

            Validate(newEmployee);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            db.Employees.Add(newEmployee);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var values = form.Get("values");
            var employee = db.Employees.First(e => e.ID == key);

            JsonConvert.PopulateObject(values, employee);

            Validate(employee);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public void Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var employee = db.Employees.First(e => e.ID == key);

            db.Employees.Remove(employee);
            db.SaveChanges();
        }
        public string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}