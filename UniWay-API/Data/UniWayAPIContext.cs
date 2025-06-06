using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniWay_API.Models;

    public class UniWayAPIContext : DbContext
    {
        public UniWayAPIContext (DbContextOptions<UniWayAPIContext> options)
            : base(options)
        {
        }

        public DbSet<UniWay_API.Models.Usuario> Usuario { get; set; } = default!;

        public DbSet<UniWay_API.Models.Vehiculo> Vehiculo { get; set; } = default!;

        public DbSet<UniWay_API.Models.Viaje> Viaje { get; set; } = default!;

        public DbSet<UniWay_API.Models.Reserva> Reserva { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reserva>()
            .Property(r => r.Estado)
            .HasConversion<string>();

        modelBuilder.Entity<Reserva>()
            .Property(r => r.MetodoPago)
            .HasConversion<string>();
    }

}
