using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinkManager.Domain.DAL.Abstract;
using LinkManager.Domain.Entities;
using LinkManager.WebUI.App_Start;
using LinkManager.WebUI.Infrastructure;
using Newtonsoft.Json;
using Ninject;
using Ninject.Infrastructure.Language;

namespace LinkManager.WebUI.Controllers
{
    [RoutePrefix("api/links")]
    public class LinksController : ApiController
    {
        private ILinkRepository repository;

        public LinksController()
        {
            repository = NinjectWebCommon.Kernel.Get<ILinkRepository>();
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Link> GetLinks()
        {
            return repository.GetAllLinks();
        }

        [Route("{id:int:min(1)}")]
        [HttpGet]
        public Link GetLinkById(int id)
        {
            return repository.GetLink(id);
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage CreateLink([FromBody]Link link)
        {
            repository.Add(link);
            return Request.CreateResponse<Link>(HttpStatusCode.OK, link);
        }

        [Route("")]
        [HttpPut]
        public HttpResponseMessage UpdateLink([FromBody]Link link)
        {
            repository.Update(link);
            return Request.CreateResponse<Link>(HttpStatusCode.OK, link);
        }

        [Route("")]
        [HttpDelete]
        public HttpResponseMessage RemoveLink([FromBody]Link link)
        {
            repository.Delete(link.LinkID);
            return Request.CreateResponse<Link>(HttpStatusCode.OK, link);
        }
    }
}
