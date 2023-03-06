using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTareas
{
    public class TareasContex:DbContext
    {
        public DbSet <Categoria> Categorias { get; set; }
       public DbSet <Tarea> Tareas { get; set; }

        public TareasContex(DbContextOptions<TareasContex>options):base(options){

        }

        protected override  void OnModelCreating(ModelBuilder modelBuelder){
            List<Categoria> dataCategoria=new List<Categoria>();
            dataCategoria.Add(new Categoria(){
                CategoriaId=Guid.Parse("63dd0d09-209c-4d63-9076-172cbcbd3b92"),
                Nombre="Actividades pendientes",
                Descripcion="Actividades que estan por hacer",
                Esfuerzo=5

            });

            dataCategoria.Add(new Categoria(){
                CategoriaId=Guid.Parse("63dd0d09-209c-4d63-9076-172cbcbd3b93"),
                Nombre="Actividades realizadas",
                Descripcion="Actividades que e hicieron",
                Esfuerzo=10

            });

          modelBuelder.Entity<Categoria>(categoria=>{
            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);
            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=>p.Descripcion);
            categoria.Property(p=>p.Esfuerzo);
            categoria.HasData(dataCategoria);
          } );
           List<Tarea> dataTarea=new List<Tarea>();
           dataTarea.Add(new Tarea(){
            TareaId=Guid.Parse("63dd0d09-209c-4d63-9076-172cbcbd3b94"),
            CategoriaId=Guid.Parse("63dd0d09-209c-4d63-9076-172cbcbd3b92"),
            Titulo="Hacer presentación",
            Descripcion="Presentacion de SISSU",
             PrioridadTarea=Prioridad.baja,
            Responsable="Ricardo Mejía",
            FechaCreacion=DateTime.Now
           

           });


           dataTarea.Add(new Tarea(){
            TareaId=Guid.Parse("63dd0d09-209c-4d63-9076-172cbcbd3b95"),
            CategoriaId=Guid.Parse("63dd0d09-209c-4d63-9076-172cbcbd3b93"),
            Titulo="Ver pelis",
            Descripcion="Ver peli nueva",
             PrioridadTarea=Prioridad.baja,
            Responsable="Ricardo Mejía",
            FechaCreacion=DateTime.Now

           });
          modelBuelder.Entity<Tarea>(tarea=>{
            tarea.ToTable("Tarea");
            tarea.HasKey(t=>t.TareaId);
            tarea.HasOne(t=>t.Categoria).WithMany(t=>t.Tareas).HasForeignKey(t=>t.CategoriaId);
            tarea.Property(t=>t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(t=>t.Descripcion);
            tarea.Property(t=>t.PrioridadTarea);
            tarea.Property(t=>t.Responsable);
            tarea.Property(t=>t.FechaCreacion);
            tarea.Ignore(t=>t.Resumen);
            tarea.HasData(dataTarea);

          });
          
          }
        
    }
}