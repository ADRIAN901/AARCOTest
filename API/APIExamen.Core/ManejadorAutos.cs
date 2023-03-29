using APIExamen.Core.Entity;
using APIExamen.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIExamen.Core
{
    public class ManejadorAutos
    {

        private readonly DataContext _context;

        public ManejadorAutos(DataContext context)
        {
            _context = context;
        }
        public async Task<List<DescripcionBase>> GetMarca()
        {
            List<DescripcionBase> lstDescripcionBase = new List<DescripcionBase>();
            try
            {
                var marcas = await _context.Marca.ToListAsync();
                foreach (var marca in marcas)
                {
                    DescripcionBase des = new DescripcionBase()
                    {
                        Id = marca.IdMarca,
                        Descripcion = marca.Descripcion
                    };
                    lstDescripcionBase.Add(des);
                }
            }
            catch (Exception ex)
            {
                return new List<DescripcionBase>();
            }
            return lstDescripcionBase;
        }

        public async Task<List<DescripcionBase>> GetSubMarca(int idMarca)
        {
            List<DescripcionBase> lstDescripcionBase = new List<DescripcionBase>();
            try
            {
                var subMarcas = await _context.SubMarca.ToListAsync();
                var descripciones = await _context.Descripcion.ToListAsync();

                var resSubMarcas = (from subMarca in subMarcas
                                    join descripcion in descripciones on subMarca.IdSubMarca equals descripcion.IdSubMarca
                                    where descripcion.IdMarca == idMarca
                                    select subMarca).Distinct().ToList();

                foreach (var subMarca in resSubMarcas)
                {
                    DescripcionBase des = new DescripcionBase()
                    {
                        Id = ((SubMarca)subMarca).IdSubMarca,
                        Descripcion = ((SubMarca)subMarca).Descripcion
                    };
                    lstDescripcionBase.Add(des);
                }
            }
            catch (Exception ex)
            {
                return new List<DescripcionBase>();
            }
            return lstDescripcionBase;
        }

        public async Task<List<DescripcionBase>> GetModeloSubMarca(int idSubMarca)
        {
            List<DescripcionBase> lstDescripcionBase = new List<DescripcionBase>();
            try
            {
                var modeloSubMarcas = await _context.ModeloSubMarca.ToListAsync();
                var descripciones = await _context.Descripcion.ToListAsync();

                var resModeoSubMarcas = (from modeloSubMarca in modeloSubMarcas
                                    join descripcion in descripciones on modeloSubMarca.IdModeloSubMarca equals descripcion.IdModeloSubMarca
                                    where descripcion.IdSubMarca == idSubMarca
                                    select modeloSubMarca).Distinct().ToList();

                foreach (var modeloSubMarca in resModeoSubMarcas)
                {
                    DescripcionBase des = new DescripcionBase()
                    {
                        Id = ((ModeloSubMarca)modeloSubMarca).IdModeloSubMarca,
                        Descripcion = ((ModeloSubMarca)modeloSubMarca).Descripcion
                    };
                    lstDescripcionBase.Add(des);
                }
            }
            catch (Exception ex)
            {
                return new List<DescripcionBase>();
            }
            return lstDescripcionBase;
        }

        public async Task<List<DescripcionModel>> GetDescripcion(int idMarca, int idSubMarca, int idModeloSubMarca)
        {
            List<DescripcionModel> lstDescripcion = new List<DescripcionModel>();
            try
            {
                var descripciones = await _context.Descripcion.ToListAsync();

                var filterDescripciones = (from descripcion in descripciones
                                         where descripcion.IdMarca == idMarca 
                                         && descripcion.IdSubMarca == idSubMarca
                                         && descripcion.IdModeloSubMarca == idModeloSubMarca
                                         select descripcion).ToList();

                foreach (var descript in filterDescripciones)
                {
                    DescripcionModel des = new DescripcionModel()
                    {
                        DescripcionId = ((Descripcion)descript).DescripcionId,
                        Descripcion = ((Descripcion)descript).DescripcionA
                    };
                    lstDescripcion.Add(des);
                }
            }
            catch (Exception ex)
            {
                return new List<DescripcionModel>();
            }
            return lstDescripcion;
        }
    }
}
