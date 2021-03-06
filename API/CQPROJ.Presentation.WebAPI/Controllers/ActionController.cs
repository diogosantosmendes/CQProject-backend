﻿using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ActionController : ApiController
    {
        // GET action/pages/:userid
        /// <summary>
        /// Numero de páginas das ações de um utilizador ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("action/pages/{userid}")]
        public Object Page(int userid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            return BAction.GetPagesByUser(userid);
        }

        // GET action/page/:userid/:pageid
        /// <summary>
        /// Página específica das ações de um utilizador ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("action/page/{userid}/{pageid}")]
        public Object GetByUser(int userid, int pageid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            return BAction.GetActionsbyUser(userid, pageid);
        }
    }
}