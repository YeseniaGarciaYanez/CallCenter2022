using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

    [Route("api/[controller]")]
    [ApiController]
public class SessionController : ControllerBase
{

    [HttpGet]
    [Route("")]
    
    public ActionResult Get()
    {
        return Ok(SessionListResponse.GetResponse(Session.Get()));
    }

    [HttpGet("{id}")]
    [Route("{id}")]
    public ActionResult Get(int id)
    {
        try
        {
            Session a = Session.Get(id);
            return Ok(SessionResponse.GetResponse(a));
        }
        catch (SessionNotFoundException e)
        {
            return Ok(MessageResponse.GetReponse(1, e.Message, MessageType.Error));
        }
        catch (Exception e)
        {
            return Ok(MessageResponse.GetReponse(999, e.Message, MessageType.CriticalError));
        }
    }


    [HttpGet("agent/{id}")]
    [Route("agent/{id}")]
    public ActionResult GetSessionAgent(int id)
    {
        try
        {
            Session a = Session.GetSessionAgent(id);
            return Ok(SessionResponse.GetResponse(a));
        }
        catch (SessionNotFoundException e)
        {
            return Ok(MessageResponse.GetReponse(1, e.Message, MessageType.Error));
        }
        catch (Exception e)
        {
            return Ok(MessageResponse.GetReponse(999, e.Message, MessageType.CriticalError));
        }
    }



    [HttpGet("station/{id}")]
    [Route("station/{id}")]
    public ActionResult GetSessionStation(int id)
    {
        try
        {
            Session a = Session.GetSessionStation(id);
            return Ok(SessionResponse.GetResponse(a));
        }
        catch (SessionNotFoundException e)
        {
            return Ok(MessageResponse.GetReponse(1, e.Message, MessageType.Error));
        }
        catch (Exception e)
        {
            return Ok(MessageResponse.GetReponse(999, e.Message, MessageType.CriticalError));
        }
    }



    [HttpGet("[action]/{station}")]
    [Route("[action]/{station}")]
    public ActionResult Login (int station)
    {
        if (!String.IsNullOrEmpty(Request.Headers["agent"]) && !String.IsNullOrEmpty(Request.Headers["pin"])) 
        {
            int agentId = Int32.Parse(Request.Headers["agent"]);
            int pin = Int32.Parse(Request.Headers["pin"]);
            int status = Session.Login(agentId, pin, station);
            //Message
            string message = ((LoginStatus)status).ToString();

            // Message type
            MessageType type = MessageType.Succes;
            if (status > 0) type = MessageType.Error;
            //return Result
            return Ok(MessageResponse.GetReponse(status, message,  type));
        }
        else return Ok(MessageResponse.GetReponse(500, "Missing Security Headers", MessageType.CriticalError));
    }   


}
