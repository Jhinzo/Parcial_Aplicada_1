using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Parcial_Aplicada_1.DAL;
using Parcial_Aplicada_1.Entidades;

namespace Parcial_Aplicada_1.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                if (contexto.Articulos.Add(articulos) != null)
                {
                    paso = (contexto.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            try
            {
                contexto.Entry(articulos).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            try
            {
                var articulos = contexto.Articulos.Find(id);
                if (articulos != null)
                {
                    contexto.Articulos.Remove(articulos);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Articulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Articulos articulos;

            try
            {
                articulos = contexto.Articulos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return articulos;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> articulos)
        {
            Contexto contexto = new Contexto();
            List<Articulos> listado = new List<Articulos>();

            try
            {
                listado = contexto.Articulos.Where(articulos).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listado;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Articulos.Any(d => d.ArticuloId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static List<Articulos> GetArticulos()
        {
            List<Articulos> lista = new List<Articulos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Articulos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        }
}