using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPP.Models;
using Microsoft.EntityFrameworkCore;

namespace GPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public MessageController(ApplicationContext db)
        {
            this.db = db;
        }
        ApplicationContext db { get; set; }


        // GET: api/<MessageController>
        [HttpGet]
        public ActionResult<List<MessageModel>> Get()
        {
            return db.Messages
                .Select(g => g).
                ToList();
        }


        [HttpPost]
        public ActionResult Post([FromBody]AddMessageModel addMessageObj)
        {
            MessageModel message = new MessageModel { id = Guid.NewGuid().ToString(),
                userName=addMessageObj.userName,
                userMail=addMessageObj.email,
                subject=addMessageObj.subject,
                message=addMessageObj.message
            };

            db.Messages.Add(message);
            db.SaveChanges();
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            MessageModel mess = db.Messages.Where(u => u.id == id).SingleOrDefault();

            db.Remove(mess);
            db.SaveChanges();

            return NoContent();

            //db.applicationUsers.Remove(user);





        }

    }
}
