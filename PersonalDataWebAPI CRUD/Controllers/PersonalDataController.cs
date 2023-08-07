using Microsoft.AspNetCore.Mvc;
using PersonalDataWebAPI_CRUD.Repository;
using PersonalDataWebAPI_CRUD.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalDataWebAPI_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {


        //instance for class which contain crud methods
        PersonalBioRepository objApiCrud;

        public PersonalDataController()
        {
            objApiCrud = new PersonalBioRepository();
        }



        // GET: api/<PersonalDataController>
        [HttpGet]
        public IEnumerable<PersonalDataModel> Get()
        {
            return objApiCrud.SelectAllPersonalData();
        }

        // GET api/<PersonalDataController>/5
        
        [HttpGet("{id}")]
        public IEnumerable<PersonalDataModel> Get(int id)
        {
            return objApiCrud.SelectPersonalDataWithID(id);
        }


        // POST api/<PersonalDataController>
        [HttpPost]
        public void Post( [FromBody] PersonalDataModel value)
        {
            objApiCrud.InsertPersonalData(value);

        }

        // PUT api/<PersonalDataController>/5
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] PersonalDataModel value)
        {
            value.id = Id;
            objApiCrud.ubdatePersonalData(value);
        }

        // DELETE api/<PersonalDataController>/5
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {

            objApiCrud.DeletePersonalDataCRUD(Id);
        }
    }
}
