namespace StudentSystem.Services.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;
    using System.Web.Http;

    public class HomeworksController : ApiController
    {
        private IStudentSystemData data;

        public HomeworksController(IStudentSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            var result = this.data.Homeworks.All().ProjectTo<HomeworkModel>();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.data.Homeworks.SearchFor(h => h.StudentIdentification == id).ProjectTo<HomeworkModel>();

            return this.Ok(result);
        }
    }
}
