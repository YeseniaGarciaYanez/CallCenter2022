using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            return Ok(StationListResponse.GetResponse(Station.Get())); // key performance indicator
        }


    [HttpGet("{id}")]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            try
        {
            Station a = Station.Get(id);
            return Ok(StationResponse.GetResponse(a));
        }
            catch(SessionNotFoundException e)
            {
                return Ok(MessageResponse.GetReponse(1, e.Message, MessageType.Error));
            }
            catch(Exception e)
            {
                return Ok(MessageResponse.GetReponse(999, e.Message, MessageType.CriticalError));
            }
        }


    [HttpGet("row/{id}")]
    [Route("row/{id}")]
    public ActionResult GetRow(int id)
    {
        try
        {
            List<Station> a = Station.GetRow(id);
            return Ok(StationListResponse.GetResponse(a));
        }
        catch (StationNotFoundException e)
        {
            return Ok(MessageResponse.GetReponse(1, e.Message, MessageType.Error));
        }
        catch (Exception e)
        {
            return Ok(MessageResponse.GetReponse(999, e.Message, MessageType.CriticalError));
        }
    }

    [HttpGet("desk/{id}")]
    [Route("desk/{id}")]
    public ActionResult GetDesk(int id)
    {
        try
        {
            List<Station> a = Station.GetDesk(id);
            return Ok(StationListResponse.GetResponse(a));
        }
        catch (StationNotFoundException e)
        {
            return Ok(MessageResponse.GetReponse(1, e.Message, MessageType.Error));
        }
        catch (Exception e)
        {
            return Ok(MessageResponse.GetReponse(999, e.Message, MessageType.CriticalError));
        }
    }

    [HttpGet("active/{id}")]
    [Route("active/{id}")]
    public ActionResult GetActive(int id)
    {
        try
        {
            List<Station> a = Station.GetActive(id);
            return Ok(StationListResponse.GetResponse(a));
        }
        catch (StationNotFoundException e)
        {
            return Ok(MessageResponse.GetReponse(1, e.Message, MessageType.Error));
        }
        catch (Exception e)
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
