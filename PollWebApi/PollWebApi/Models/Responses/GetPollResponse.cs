﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollWebApi.Models.Responses
{
    public class GetPollResponse
    {
        public int Poll_id { get; set; }
        public string Poll_description { get; set; }
        public List<GetOptionResponse> Options  { get; set; }
    }

    public class GetOptionResponse
    {
        public int Option_id { get; set; }
        public string Option_description { get; set; }
    }


}