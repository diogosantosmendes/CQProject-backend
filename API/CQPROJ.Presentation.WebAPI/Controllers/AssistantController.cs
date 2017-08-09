﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Business.Entities.IUser;
using System.Text.RegularExpressions;
using CQPROJ.Business.Entities.Payload;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class AssistantController : ApiController
    {
        // GET assistant/pages
        [HttpGet]
        [Route("assistant/pages")]
        public Object Count()
        {
            Payload payload = BAccount.confirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            
            return new { result = true, data = BAssistant.GetAssistantsPages() };
        }

        // GET assistant/page/:id
        [HttpGet]
        [Route("assistant/page/{id}")]
        public Object Page(int id)
        {
            Payload payload = BAccount.confirmToken(this.Request);

            if (payload == null  || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info="Não autorizado." };
            }

            var assistant = BAssistant.GetAssistantsPage(id);

            if (assistant == null)
            {
                return new { result = false, info= "Impossível carregar página." };
            }
            return new { result = true, data = new { page = id, info = assistant} };
        }

        // GET assistant/:id
        [HttpGet]
        [Route("assistant/profile/{id}")]
        public Object Profile(int id)
        {
            Payload payload = BAccount.confirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var assistant = BAssistant.GetAssistant(id);

            if (assistant == null)
            {
                return new { result = false, info = "Utilizador não encontrado." };
            }
            return new { result = true, data = assistant };
        }

        //POST assistant/
        [HttpPost]
        [Route("assistant")]
        public Object Post([FromBody]User assistant)
        {
            Payload payload = BAccount.confirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BAssistant.CreateAssistant(assistant);

        }

        // PUT assistant/id
        [HttpPut]
        [Route("assistant/{id}")]
        public Object Put(int id,[FromBody]User assistant)
        {
            Payload payload = BAccount.confirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BAssistant.EditAssistant(id,assistant);
        }
    }
}