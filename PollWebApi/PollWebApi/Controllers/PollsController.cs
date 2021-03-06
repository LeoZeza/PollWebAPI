﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PollWebApi.Entities;
using PollWebApi.Models.Services;
using PollWebApi.Models.Responses;

namespace PollWebApi.Controllers
{
    public class PollsController : ApiController
    {
        private PollDataBaseEntities db = new PollDataBaseEntities();
        private PollService _PollService;
        public PollsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
            _PollService = new PollService(db);

        }

        // GET: poll/5
        [ResponseType(typeof(GetPollResponse))]
        [Route("poll/{id}")]
        public IHttpActionResult GetPoll(int id)
        {
            var poll = _PollService.GetPollByID(id);

            if (poll == null)
            {
                return NotFound();
            }

            _PollService.AddView(id);

            return Json(new { poll});            
        }
        
        // POST: poll
        [ResponseType(typeof(PostPollResponse))]
        [Route("poll")]
        public IHttpActionResult PostPoll(PostPollResponse poll)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var p = _PollService.AddPoll(poll);        
            
            return Json(new { poll_id = p.Poll_Id });
        }

        // POST: poll/5/vote
        [ResponseType(typeof(Poll))]
        [Route("poll/{op_id:int}/vote")]
        public IHttpActionResult PostVote(int op_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vote = _PollService.AddVote(op_id);
            if (!vote)
            {
                return NotFound();
            }            

            return Json(new { option_id = op_id });
        }

        // POST: poll/5/stats
        [ResponseType(typeof(GetStatsResponse))]
        [Route("poll/{poll_id:int}/stats")]
        public IHttpActionResult GetPollStats(int poll_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stats = _PollService.GetStatsById(poll_id);

            return Json(new { stats });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}