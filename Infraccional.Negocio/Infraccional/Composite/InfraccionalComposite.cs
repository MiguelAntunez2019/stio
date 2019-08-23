using Infraccional.Negocio.Infraccional.Negocio.Interfaces;
using Infraccional.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.Negocio.Infraccional.Composite
{
    /// <summary>
    /// Descripcion: Clase que compone al negocio infraccional.
    /// </summary>
    /// 
    /// <remarks>
    /// Derechos Reservados para Servicio Agricola y Ganadero, Departamento de Tecnologias de la Informacion,
    /// Unidad Transversal.
    /// </remarks>
    /// 
    /// Control de versiones:
    /// 
    /// 1.0 01/08/2017 Carlos Chacon Ibacache : Version Inicial.
    ///
    public class InfraccionalComposite
    {
        /// <summary>
        /// Contenedor de composiciones.
        /// </summary>
        private CompositionContainer _container;
        /// <summary>
        /// Negocio Infraccional.
        /// </summary>
        [Import(typeof(IInfraccional))]
        public IInfraccional InfraccionalNegocio { get; set; }
        /// <summary>
        /// Negocio Fiscalizacion.
        /// </summary>
        [Import(typeof(IFiscalizacion))]
        public IFiscalizacion FiscalizacionNegocio { get; set; }
        /// <summary>
        /// Constructor del contenedor de composiciones.
        /// </summary>
        public InfraccionalComposite()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IInfraccional).Assembly));
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }

    }
}
