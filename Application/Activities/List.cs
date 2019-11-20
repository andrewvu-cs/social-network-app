using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext context;
     
            public Handler(DataContext context, ILogger<List> logger)
            {
                this.context = context;

            }

            public async Task<List<Activity>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                // Testing out cancellation token
                // try
                // {
                //     for (var i = 0; i < 10; i++)
                //     {
                //         cancellationToken.ThrowIfCancellationRequested();
                //         await Task.Delay(1000, cancellationToken);
                //         logger.LogInformation($"Task {i} has completed");
                //     }
                // }
                // catch (Exception ex) when (ex is TaskCanceledException)
                // {
                //     this.logger.LogInformation("Task has been cancelled");
                // }
                // var activities = await this.context.Activities.ToListAsync(cancellationToken);

                var activities = await this.context.Activities.ToListAsync(cancellationToken);

                return activities;
            }
        }
    }
}