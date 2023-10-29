using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace marcajeUMG.Models.DB
{
    public partial class marcajeUMGContext : DbContext
    {
        public marcajeUMGContext()
        {
        }

        public marcajeUMGContext(DbContextOptions<marcajeUMGContext> options)
            : base(options)
        {
        }

        public DbSet<Asignacion> Asignacions { get; set; }
        public DbSet<Asistencium> Asistencia { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Catedratico> Catedraticos { get; set; }
        public DbSet<Centro> Centros { get; set; }
        public DbSet<CentroCarrera> CentroCarreras { get; set; }
        public DbSet<Ciclo> Ciclos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Dia> Dias { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Jornadum> Jornada { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ONFHHKV; Database=marcajeUMG; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.HasKey(e => e.IdAsignacion);

                entity.ToTable("Asignacion");

                entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Curso_Asignacion");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiante_Asignacion");
            });

            modelBuilder.Entity<Asistencium>(entity =>
            {
                entity.HasKey(e => e.IdAsistencia);

                entity.Property(e => e.IdAsistencia).HasColumnName("idAsistencia");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Curso_Asistencia");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuraio_Asistencia");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera);

                entity.ToTable("Carrera");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Catedratico>(entity =>
            {
                entity.HasKey(e => e.IdCatedratico);

                entity.ToTable("Catedratico");

                entity.Property(e => e.IdCatedratico).HasColumnName("idCatedratico");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Centro>(entity =>
            {
                entity.HasKey(e => e.IdCentro);

                entity.ToTable("Centro");

                entity.Property(e => e.IdCentro).HasColumnName("idCentro");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<CentroCarrera>(entity =>
            {
                entity.HasKey(e => e.IdCentroCarrera);

                entity.ToTable("Centro_Carrera");

                entity.Property(e => e.IdCentroCarrera).HasColumnName("idCentro_Carrera");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.IdCentro).HasColumnName("idCentro");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.CentroCarreras)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrera_Centro_Carrera");

                entity.HasOne(d => d.IdCentroNavigation)
                    .WithMany(p => p.CentroCarreras)
                    .HasForeignKey(d => d.IdCentro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Centro_Centro_Carrera");
            });

            modelBuilder.Entity<Ciclo>(entity =>
            {
                entity.HasKey(e => e.IdCiclo);

                entity.ToTable("Ciclo");

                entity.Property(e => e.IdCiclo).HasColumnName("idCiclo");

                entity.Property(e => e.Grado)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("grado");

                entity.Property(e => e.IdCentroCarrera).HasColumnName("idCentro_Carrera");

                entity.Property(e => e.IdJornada).HasColumnName("idJornada");

                entity.Property(e => e.Seccion)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("seccion")
                    .IsFixedLength();

                entity.HasOne(d => d.IdCentroCarreraNavigation)
                    .WithMany(p => p.Ciclos)
                    .HasForeignKey(d => d.IdCentroCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Centro_Carrera_Ciclo");

                entity.HasOne(d => d.IdJornadaNavigation)
                    .WithMany(p => p.Ciclos)
                    .HasForeignKey(d => d.IdJornada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jornada_Ciclo");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.ToTable("Curso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.HoraFin).HasColumnName("horaFin");

                entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");

                entity.Property(e => e.IdCatedratico).HasColumnName("idCatedratico");

                entity.Property(e => e.IdCiclo).HasColumnName("idCiclo");

                entity.Property(e => e.IdDia).HasColumnName("idDia");

                entity.Property(e => e.MaxEstudiante).HasColumnName("maxEstudiante");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdCatedraticoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCatedratico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catedratico_Curso");

                entity.HasOne(d => d.IdCicloNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCiclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciclo_Curso");

                entity.HasOne(d => d.IdDiaNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdDia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dia_Curso");
            });

            modelBuilder.Entity<Dia>(entity =>
            {
                entity.HasKey(e => e.IdDia);

                entity.Property(e => e.IdDia).HasColumnName("idDia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.ToTable("Estudiante");

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.Property(e => e.Carne)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("carne");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Jornadum>(entity =>
            {
                entity.HasKey(e => e.IdJornada);

                entity.Property(e => e.IdJornada).HasColumnName("idJornada");

                entity.Property(e => e.HoraFin).HasColumnName("horaFin");

                entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK_Tip_Usuario");

                entity.ToTable("Tipo_Usuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipo_Usuario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Ususario");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.IdPropietario).HasColumnName("idPropietario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipo_Usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdPropietarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catedratico_Ususario");

                entity.HasOne(d => d.IdPropietario1)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiante_Ususario");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tipo_Ususario_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
