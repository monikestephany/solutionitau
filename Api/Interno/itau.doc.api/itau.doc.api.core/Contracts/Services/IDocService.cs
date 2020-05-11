using itau.doc.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.api.core.Contracts.Services
{
   public interface IDocService
    {
        List<Doc> GetAll();
        Doc Create(Doc cliente);
        void Delete(string id);
    }
}
