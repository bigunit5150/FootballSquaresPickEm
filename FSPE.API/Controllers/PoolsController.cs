using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FSPE.API.DAL;
using FSPE.API.DAL.Models;

namespace FSPE.API.Controllers
{
    public class PoolsController : ApiController
    {
        private PoolManagerContext db = new PoolManagerContext();

        // GET: api/Pools
        public IQueryable<Pool> GetPools()
        {
            return db.Pools;
        }

        // GET: api/Pools/5
        [ResponseType(typeof(Pool))]
        public async Task<IHttpActionResult> GetPool(int id)
        {
            Pool pool = await db.Pools.FindAsync(id);
            if (pool == null)
            {
                return NotFound();
            }

            return Ok(pool);
        }

        // PUT: api/Pools/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPool(int id, Pool pool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pool.PoolId)
            {
                return BadRequest();
            }

            db.Entry(pool).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pools
        [ResponseType(typeof(Pool))]
        public async Task<IHttpActionResult> PostPool(Pool pool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pools.Add(pool);

            for ( var i = 0; i < 10; i++ )
                for ( var j = 0; j < 10; j++ )
                    pool.Squares.Add(new Square{ HomePosition = i, VisitorPosition = j});

            pool.CreationDate = DateTime.Now;

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pool.PoolId }, pool);
        }

        // DELETE: api/Pools/5
        [ResponseType(typeof(Pool))]
        public async Task<IHttpActionResult> DeletePool(int id)
        {
            Pool pool = await db.Pools.FindAsync(id);
            if (pool == null)
            {
                return NotFound();
            }

            db.Pools.Remove(pool);
            await db.SaveChangesAsync();

            return Ok(pool);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoolExists(int id)
        {
            return db.Pools.Count(e => e.PoolId == id) > 0;
        }
    }
}