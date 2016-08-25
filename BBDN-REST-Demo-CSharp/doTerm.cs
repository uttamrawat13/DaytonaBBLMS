using BBDNRESTDemoCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBDN_REST_Demo_CSharp
{
    public class doTerm
    {
        public async Task<Term> CreateTerm(Term newterm)
        {
            Authorizer authorizer = new Authorizer();
            Token token = new Token();
            token = await authorizer.Authorize();
            TermService termService = new TermService(token);
            Term term = await termService.CreateObject(newterm);
            return term;
        }
        public async Task<Term> UpdateTerm(Term newterm)
        {
            Authorizer authorizer = new Authorizer();
            Token token = new Token();
            token = await authorizer.Authorize();
            TermService termService = new TermService(token);
            Term term = await termService.UpdateObject(newterm);
            return term;

        }
    }
}
