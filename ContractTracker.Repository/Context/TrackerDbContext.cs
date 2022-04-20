﻿using System;
using ContractTracker.Repository.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.Context
{
    public class TrackerDbContext : DbContext, IDisposable
    {
        public TrackerDbContext(DbContextOptions<TrackerDbContext> options) : base(options)
        {
            //10 minutes to complete any stored proc. 
            //This is not the same Connection Timeout in the appsettings/connection string. That is for "establishing" a connection. Not the max time it takes a command to complete.
            //Also, if you have screwed up any of the entities or their mappings, this is where it will complain!
            
            
            
            //Cant be used in in memory
            //TimeSpan timeSpan = new TimeSpan(0, 10, 0);
            //this.Database.SetCommandTimeout(timeSpan);
        }

        public DbSet<Users> Users => Set<Users>();
        public DbSet<UserUnits> UserUnits => Set<UserUnits>();
        public DbSet<UserRoles> UserRoles => Set<UserRoles>();
        public DbSet<AmendmentAttachments> AmendmentAttachments => Set<AmendmentAttachments>();
        public DbSet<Amendments> Amendments => Set<Amendments>();
        public DbSet<Announcements> Announcements => Set<Announcements>();
        public DbSet<Units> Units => Set<Units>();
        public DbSet<AttachmentTypes> AttachmentTypes => Set<AttachmentTypes>();
        public DbSet<Budgets> Budgets => Set<Budgets>();
        public DbSet<ContractPersons> ContractPersons => Set<ContractPersons>();
        public DbSet<Contracts> Contracts => Set<Contracts>();
        public DbSet<ContractTypes> ContractTypes => Set<ContractTypes>();
        public DbSet<Deliverables> Deliverables => Set<Deliverables>();
        public DbSet<ErrorLogs> ErrorLogs => Set<ErrorLogs>();
        public DbSet<FlairCodes> FlairCodes => Set<FlairCodes>();
        public DbSet<MethodOfPayments> MethodOfPayments => Set<MethodOfPayments>();
        public DbSet<Persons> Persons => Set<Persons>();
        public DbSet<PersonTypes> PersonTypes => Set<PersonTypes>();
        public DbSet<ProcurementMethods> ProcurementMethods => Set<ProcurementMethods>();
        public DbSet<Reports> Reports => Set<Reports>();
        public DbSet<TrackingHistory> TrackingHistory => Set<TrackingHistory>();
     
        public DbSet<TrackingSteps> TrackingSteps => Set<TrackingSteps>();
        public DbSet<Vendors> Vendors => Set<Vendors>();

    }
}
