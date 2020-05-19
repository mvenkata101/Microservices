using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadService.Repository
{
    public interface ILeadRepository
    {
        IEnumerable<Lead> GetLeads();
        Lead GetLeadByID(int LeadId);
        void InsertLead(Lead lead);
        void DeleteLead(int LeadId);
        void UpdateLead(Lead lead);
        void Save();
    }
}
