namespace StudentSystem.Services.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using StudentSystem.Models;
    using System.Linq;
    using System.Web.Http;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            var result = this.data.Students.All().ProjectTo<StudentModel>();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.data.Students.SearchFor(s => s.StudentIdentification == id).ProjectTo<StudentModel>();

            return this.Ok(result);
        }

        public IHttpActionResult Post([FromBody] StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = Mapper.Map<Student>(student);

                this.data.Students.Add(result);

                return this.Created(this.Url.ToString(), result);
            }
        }

        public IHttpActionResult Put([FromBody] StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = this.data.Students
                    .SearchFor(s => s.FirstName == student.FirstName && s.LastName == student.LastName).FirstOrDefault();

                if (result == null)
                {
                    return this.NotFound();
                }
                else
                {
                    result.Level = student.Level;

                    this.data.Students.Update(result);
                    return this.Ok(result);
                }
            }
        }

        public IHttpActionResult Delete(int id)
        {
            var student = this.data.Students.SearchFor(s => s.StudentIdentification == id).FirstOrDefault();

            if (student == null)
            {
                return this.NotFound();
            }
            else
            {
                this.data.Students.Delete(student);
                return this.Ok(student);
            }
        }
    }
}
