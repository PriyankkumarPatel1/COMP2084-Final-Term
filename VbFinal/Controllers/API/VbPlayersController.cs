using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using VbFinal.Models;
using System.Web.Mvc;

namespace VbFinal.Controllers.API
{
    public class VbPlayersController : Controller
    {

        // Connect to database
        private IMockVbPlayer db;

        public VbPlayersController()
        {
            this.db = new IDataVbPlayer();
        }

        public VbPlayersController(IMockVbPlayer db)
        {
            this.db = db;
        }

        //         public VbPlayersController(DbModel db)
        //         {
        //             this.db = db;
        //         }


        // GET api/<controller>
        public IEnumerable<VbPlayer> Get()
        {
            return db.VbPlayers.ToList();
        }

        
       // GET api/<controller>/5
         public ActionResult Get(int id)
         {
             var vbPlayer = db.VbPlayers.SingleOrDefault(s => s.VbPlayerId == id);
 
             if (vbPlayer == null)
             {
                 return NotFound();      // 404 not found error is better than 204 empty content error
             }
             else
             {
                 return Ok(vbPlayer);
             }
         }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}