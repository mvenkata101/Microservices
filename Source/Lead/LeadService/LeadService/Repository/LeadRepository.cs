using LeadService.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadService.Repository
{
    public class LeadRepository : ILeadRepository
    {
        private readonly LeadContext _leadContext;
        public LeadRepository(LeadContext leadContext)
        {
            _leadContext = leadContext;
        }

        public void DeleteLead(int LeadId)
        {
            var lead = _leadContext.Leads.Find(LeadId);
            _leadContext.Leads.Remove(lead);
            Save();
        }

        public Lead GetLeadByID(int LeadId)
        {
            return _leadContext.Leads.Find(LeadId);
        }

        public IEnumerable<Lead> GetLeads()
        {
            return _leadContext.Leads.ToList();
        }

        public void InsertLead(Lead lead)
        {
            _leadContext.Add(lead);
            Save();
        }

        public void Save()
        {
            _leadContext.SaveChanges();
        }

        public void UpdateLead(Lead lead)
        {
            _leadContext.Entry(lead).State = EntityState.Modified;
            Save();
        }
    }
}
