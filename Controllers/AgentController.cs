using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            return Ok(AgentListResponse.GetResponse(Agent.Get()));
        }


        [HttpGet("{id}")]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Agent a = Agent.Get(id);
                return Ok(AgentResponse.GetResponse(a));
            }
            catch(AgentNotFoundException e)
            {
                return Ok(MessageResponse.GetReponse(1, e.Message, MessageType.Error));
            }
            catch(Exception e)
            {
                return Ok(MessageResponse.GetReponse(999, e.Message, MessageType.CriticalError));
            }
        }
        
        [HttpGet("pin/{id}")]
        [Route("pin/{id}")]
        public ActionResult GetPin(int id)
        {
            try
            {
                Agent a = Agent.GetPin(id);
                return Ok(AgentResponse.GetResponse(a));
            }
            catch(AgentNotFoundException e)
            {
                return Ok(MessageResponse.GetReponse(1, e.Message, MessageType.Error));
            }
            catch(Exception e)
            {
                return Ok(MessageResponse.GetReponse(999, e.Message, MessageType.CriticalError));
            }
        }


        [HttpPost]
        [Route("")]
        public ActionResult Post()
        {
            return Ok("post");
        }
    }
