using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Plan_aereo.Models;

public partial class PlanAereoContext : DbContext
{
    public PlanAereoContext()
    {
    }

    public PlanAereoContext(DbContextOptions<PlanAereoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aerolinea> Aerolineas { get; set; }

    public virtual DbSet<Aeropuerto> Aeropuertos { get; set; }

    public virtual DbSet<Asiento> Asientos { get; set; }

    public virtual DbSet<Avion> Avions { get; set; }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<ClaseAsiento> ClaseAsientos { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Pasajero> Pasajeros { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Tarifa> Tarifas { get; set; }

    public virtual DbSet<Tarjetum> Tarjeta { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=plan_aereo;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aerolinea>(entity =>
        {
            entity.HasKey(e => e.IdAerolinea);

            entity.ToTable("Aerolinea");

            entity.Property(e => e.IdAerolinea).HasColumnName("id_aerolinea");
            entity.Property(e => e.NombreAerolinea)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombre_aerolinea");
        });

        modelBuilder.Entity<Aeropuerto>(entity =>
        {
            entity.HasKey(e => e.IdAeropuerto);

            entity.ToTable("Aeropuerto");

            entity.Property(e => e.IdAeropuerto).HasColumnName("id_aeropuerto");
            entity.Property(e => e.NombreCiudad).HasColumnName("nombre_ciudad");
			entity.Property(e => e.NombrePais).HasColumnName("nombre_pais");
			entity.Property(e => e.NombreAeropuerto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_aeropuerto");
			
		});

        modelBuilder.Entity<Asiento>(entity =>
        {
            entity.HasKey(e => e.IdAsiento);

            entity.ToTable("Asiento");

            entity.Property(e => e.IdAsiento).HasColumnName("id_asiento");
            entity.Property(e => e.ClaseAsiento).HasColumnName("clase_asiento");
            entity.Property(e => e.FilaAsiento)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("fila_asiento");
            entity.Property(e => e.IdVuelo).HasColumnName("id_vuelo");
            entity.Property(e => e.LetraAsiento)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("letra_asiento");

			entity.Property(e => e.DisponibilidadASiento).HasColumnName("disponibilidad_asiento"); 



		});

        modelBuilder.Entity<Avion>(entity =>
        {
            entity.HasKey(e => e.IdAvion);

            entity.ToTable("Avion");

            entity.Property(e => e.IdAvion).HasColumnName("id_avion");
            entity.Property(e => e.CapacidadPasajerosAvion).HasColumnName("capacidad_pasajeros_avion");
            entity.Property(e => e.FabricanteAvion)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("fabricante_avion");
            entity.Property(e => e.ModeloAvion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("modelo_avion");
        });

        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.IdBanco).HasName("PK_Banco_1");

            entity.ToTable("Banco");

            entity.Property(e => e.IdBanco).HasColumnName("id_banco");
            entity.Property(e => e.NombreBanco)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_banco");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad);

            entity.ToTable("Ciudad");

            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_ciudad");

        
        });

        modelBuilder.Entity<ClaseAsiento>(entity =>
        {
            entity.HasKey(e => e.IdClase);

            entity.ToTable("Clase_Asiento");

            entity.Property(e => e.IdClase).HasColumnName("id_clase");
            entity.Property(e => e.NombreClase)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_clase");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario);

            entity.ToTable("Horario");

            entity.Property(e => e.IdHorario).HasColumnName("id_horario");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasPrecision(1)
                .HasColumnName("hora");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais);

            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.NombrePais)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombre_pais");
        });

        modelBuilder.Entity<Pasajero>(entity =>
        {
            entity.HasKey(e => e.IdPasajero);

            entity.ToTable("Pasajero");

            entity.Property(e => e.IdPasajero).HasColumnName("id_pasajero");
            entity.Property(e => e.ClavePasajero)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("clave_pasajero");
            entity.Property(e => e.CodigoPostalPasajero).HasColumnName("codigoPostal_pasajero");
            entity.Property(e => e.CorreoPasajero)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("correo_pasajero");
            entity.Property(e => e.DireccionPasajero)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("direccion_pasajero");
            entity.Property(e => e.NombrePasajero)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombre_pasajero");
            entity.Property(e => e.NumIdentificacion).HasColumnName("num_identificacion");
            entity.Property(e => e.NumTelefonoPasajero).HasColumnName("numTelefono_pasajero");
            entity.Property(e => e.UsuarioPasajero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario_pasajero");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva);

            entity.ToTable("Reserva");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.CodigoReserva)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("codigo_reserva");
            entity.Property(e => e.IdTarjeta).HasColumnName("id_tarjeta");
            entity.Property(e => e.IdVuelo).HasColumnName("id_vuelo");

        
        });

        modelBuilder.Entity<Tarifa>(entity =>
        {
            entity.HasKey(e => e.IdTarifa);

            entity.ToTable("Tarifa");

            entity.Property(e => e.IdTarifa).HasColumnName("id_tarifa");
            entity.Property(e => e.ClaseAsiento).HasColumnName("clase_asiento");
            entity.Property(e => e.PrecioTarifa).HasColumnName("precio_tarifa");

          
        });

        modelBuilder.Entity<Tarjetum>(entity =>
        {
            entity.HasKey(e => e.IdTarjeta);

            entity.Property(e => e.IdTarjeta).HasColumnName("id_tarjeta");
            entity.Property(e => e.FechaVencimiento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fecha_vencimiento");
            entity.Property(e => e.IdBanco).HasColumnName("id_banco");
            entity.Property(e => e.IdPasajero).HasColumnName("id_pasajero");
            entity.Property(e => e.NumeroTarjeta).HasColumnName("numero_tarjeta");
            entity.Property(e => e.TipoTarjeta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_tarjeta");

          
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.IdVuelo);

            entity.ToTable("Vuelo");

            entity.Property(e => e.IdVuelo).HasColumnName("id_vuelo");
            entity.Property(e => e.AeropuertoDestino).HasColumnName("aeropuerto_destino");
            entity.Property(e => e.AeropuertoOrigen).HasColumnName("aeropuerto_origen");
            entity.Property(e => e.FechaLlegada).HasColumnName("fecha_llegada");
            entity.Property(e => e.FechaSalida).HasColumnName("fecha_salida");
            entity.Property(e => e.IdAerolinea).HasColumnName("id_aerolinea");
            entity.Property(e => e.IdAvion).HasColumnName("id_avion");
            entity.Property(e => e.IdTarifa).HasColumnName("id_tarifa");

	

            
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
