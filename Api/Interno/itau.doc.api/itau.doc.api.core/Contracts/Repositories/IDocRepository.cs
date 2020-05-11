using itau.doc.api.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.api.core.Contracts.Repositories
{
    public interface IDocRepository
    {
        Doc Create(Doc clube);
        List<Doc> Get();
        Doc GetId(string id);
        void Remove(Doc clubeIn);
        Doc Update(string id, Doc clubeIn);
    }
}
