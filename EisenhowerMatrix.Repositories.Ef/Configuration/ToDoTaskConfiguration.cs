using EisenhowerMatrix.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EisenhowerMatrix.Repositories.Ef.Configuration
{
    class ToDoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(1024).IsRequired();
            builder.Property(x => x.Importance).IsRequired();
            builder.Property(x => x.Urgency).IsRequired();
            builder.Property(x => x.IsFinished).HasDefaultValue(false).IsRequired();

            builder.ToTable("TodoTasks");

        }
    }
}
