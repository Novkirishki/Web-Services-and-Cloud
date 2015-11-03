namespace StudentSystem.Services.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;
    using System;
    using System.Linq;
    using System.Web.Http;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            var result = this.data.Courses.All().ProjectTo<CourseModel>();

            return this.Ok(result);
        }

        public IHttpActionResult Get(Guid id)
        {
            var result = this.data.Courses.SearchFor(c => c.Id == id).ProjectTo<CourseModel>();

            return this.Ok(result);
        }

        public IHttpActionResult Post([FromBody] CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = Mapper.Map<Course>(course);

                this.data.Courses.Add(result);

                return this.Created(this.Url.ToString(), result);
            }
        }

        public IHttpActionResult Put([FromBody] CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = this.data.Courses
                    .SearchFor(c => c.Name == course.Name).FirstOrDefault();

                if (result == null)
                {
                    return this.NotFound();
                }
                else
                {
                    result.Description = course.Description;

                    this.data.Courses.Update(result);
                    return this.Ok(result);
                }
            }
        }

        public IHttpActionResult Delete(Guid id)
        {
            var course = this.data.Courses.SearchFor(c => c.Id == id).FirstOrDefault();

            if (course == null)
            {
                return this.NotFound();
            }
            else
            {
                this.data.Courses.Delete(course);
                return this.Ok(course);
            }
        }
    }
}
