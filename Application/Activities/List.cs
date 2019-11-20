using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        // nested class Query
        // IRequest is MediatR interface<Return Object>
        public class Query : IRequest<List<Activity>> { }

        // Must Implement IRequestHandler
        // Must generate constructor Handler
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            // Establish comminucation with our server in Persistence
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;

            }
            
            public async Task<List<Activity>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var activities = await this.context.Activities.ToListAsync();

                return activities;
            }
        }
    }
}