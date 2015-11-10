namespace StudentSystem.Services.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;
    using System;
    using System.Web.Http;

    public class TestsController : ApiController
    {
        private IStudentSystemData data;

        public TestsController(IStudentSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            var result = this.data.Tests.All().ProjectTo<TestModel>();

            return this.Ok(result);
        }

        public IHttpActionResult Get(Guid id)
        {
            var result = this.data.Tests.SearchFor(t => t.CourseId == id).ProjectTo<TestModel>();

            return this.Ok(result);
        }

        public IHttpActionResult Post([FromBody] TestModel test)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var resutl = Mapper.Map<Test>(test);

                this.data.Tests.Add(resutl);

                return this.Created(this.Url.ToString(), resutl);
            }
        }
    }
}
