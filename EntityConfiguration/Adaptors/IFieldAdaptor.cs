using EntityConfiguration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityConfiguration.Adaptors
{
    public interface IFieldAdaptor
    {
        Task<FieldNameSet> GetFieldsAsync(string entityName);
    }
}
