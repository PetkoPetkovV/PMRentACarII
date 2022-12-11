using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMRentACar.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Infrastructure.Data.Configuration
{
    internal class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            //builder.HasData(CreateAgents());
        }

        private List<Agent> CreateAgents()
        {
            var agents = new List<Agent>();

            var agent = new Agent()
            {
                Id = 1,
                Email = "pts@gmail.com",
                PhoneNumber = "0884346362",
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
            };

            agents.Add(agent);

            return agents;
        }
    }
}
