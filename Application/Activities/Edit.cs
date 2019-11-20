using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime? Date { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // handler logic
                var activity = await this.context.Activities.FindAsync(request.Id);

                if(activity == null)
                    throw new Exception("Could not find activity");

                // Null coalescing operator - ?? 
                // If obj is null then the object has the value to the right of it
                activity.Title = request.Title ?? activity.Title;
                activity.Description = request.Description ?? activity.Description;
                activity.Category = request.Category ?? activity.Category;
                // Since DateTime cannot be null we provided a '?' to be optional
                activity.Date = request.Date ?? activity.Date;
                activity.City = request.City ?? activity.City;
                activity.Venue = request.Venue ?? activity.Venue;

                var success = await this.context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}