using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;
using System.Linq.Expressions;

namespace Services.Implementation
{


    public class SAP_Maestro_PrestamosServices : ISAPMaestroPrestamos
    {  
        private readonly IGeneric<SAPMaestroPrestamos> _maestroPrestamos;

        public SAP_Maestro_PrestamosServices(IGeneric<SAPMaestroPrestamos> maestroPrestamos)
        {
            _maestroPrestamos = maestroPrestamos;
        }

        public Task<ResponseDTO<SAPMaestroPrestamos>> Add(SAPMaestroPrestamos model)
        {
            return _maestroPrestamos.Add(model);
        }

        public Task<ResponseDTO<IEnumerable<SAPMaestroPrestamos>>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<SAPMaestroPrestamos>> Get(SAPMaestroPrestamos model)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseDTO<IEnumerable<PrestamoDTO>>> GetAll()
        {
            var response = new ResponseDTO<IEnumerable<PrestamoDTO>>();






            var lista = await _maestroPrestamos.Query() 
                .AsNoTracking()
                .Select(p => new PrestamoDTO
                {
                    id = p.id,
                    company = p.company,
                    prestamo_id = p.prestamo_id,
                    factura_id = p.factura_id,
                    c_proveedor = p.c_proveedor,
                    n_proveedor = p.n_proveedor,
                    f_creacion = p.f_creacion,
                    f_invoice = p.f_invoice,
                    f_modificacion = p.f_modificacion,
                    f_inicial = p.f_inicial,
                    f_final = p.f_final,
                    //category_id = p.category_id,
                    //category_text = p.category_text,
                    prestamo_type_id = p.prestamo_type_id,
                    prestamo_type_text = p.prestamo_type_text,
                    tasa = p.tasa,
                    dia_pago = p.dia_pago,
                    meses_gracia = p.meses_gracia,
                    plazo = p.plazo,
                    commets = p.commets,
                    bank_id = p.bank_id,
                    bank_name = p.Bank != null ? p.Bank.Bank_Name : null,
                    creditline_id = p.creditline_id,
                    creditline_name = 
                       (p.CreditLine != null && !string.IsNullOrEmpty(p.CreditLine.Line_Description))
                       ?((p.Bank != null && !string.IsNullOrEmpty(p.Bank.Bank_Name))
                            ? p.CreditLine.Line_Description + "/" + p.Bank.Bank_Name 
                            : p.CreditLine.Line_Description)
                           : null,
                    cuotatipo_id = p.cuotatipo_id,
                    cuata_name = p.CuotaTipo != null ? p.CuotaTipo.Description : null,
                    condicion_id = p.condicion_id,
                    condicion_name = p.condiciones != null ? p.condiciones.descripcion : null,

                    monto_neto = p.monto_neto,
                    monto_bruto = p.monto_bruto
        })
        .ToListAsync();

            response.Data = lista;
            response.Message = lista.Any() ? "Data obtenida correctamente" : "No se encontraron registros";
            response.IsCorrect = true;

            return response;
        }

        public Task<ResponseDTO<SAPMaestroPrestamos>> GetALl()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<SAPMaestroPrestamos>> Update(SAPMaestroPrestamos model)
        {
            ResponseDTO<SAPMaestroPrestamos> response = new ResponseDTO<SAPMaestroPrestamos>();
            try
            {
                var currentResp =  _maestroPrestamos.Get(x => x.prestamo_id == model.prestamo_id);
                if(!currentResp.IsCorrect || currentResp.Data == null || !currentResp.Data.Any())
                {
                    response.IsCorrect = false;
                    response.Message = "ID Prestamo no encontrado";
                    response.Data = null;
                    return response;
                }
                else
                {
                    var current = currentResp.Data?.FirstOrDefault();

                    // Armamos un "stub" solo con la clave y los campos a actualizar
                    var stub = new SAPMaestroPrestamos
                    {
                        id = current.id, // Clave primaria
                        tasa = model.tasa,
                        dia_pago = model.dia_pago,
                        meses_gracia = model.meses_gracia,
                        plazo = model.plazo,
                        commets = model.commets,
                        bank_id = model.bank_id,
                        creditline_id = model.creditline_id,
                        cuotatipo_id = model.cuotatipo_id,
                        condicion_id = model.condicion_id,

                    };

                    // 2) Solo marcar las props que vienen con valor (para no enviar NULL)
                    var props = new List<Expression<Func<SAPMaestroPrestamos, object>>>();
                    if (model.tasa.HasValue) props.Add(x => x.tasa);
                    if (model.dia_pago.HasValue) props.Add(x => x.dia_pago);
                    if (model.meses_gracia.HasValue) props.Add(x => x.meses_gracia);
                    if (model.plazo.HasValue) props.Add(x => x.plazo);
                    if (model.commets != null) props.Add(x => x.commets);
                    if (model.bank_id.HasValue) props.Add(x => x.bank_id);
                    if (model.creditline_id.HasValue) props.Add(x => x.creditline_id);
                    if (model.cuotatipo_id.HasValue) props.Add(x => x.cuotatipo_id);
                    if (model.condicion_id.HasValue) props.Add(x => x.condicion_id);

                    if (props.Count == 0)
                    {
                        response.IsCorrect = true;
                        response.Message = "No fields to update";
                        response.Data = current; // o stub
                        return response;
                    }

                    var saved = await _maestroPrestamos.UpdatePartial(stub, props.ToArray());

                    response.Data = saved.Data;
                    response.Message = saved.Message;
                    response.IsCorrect = saved.IsCorrect;

                }


            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message =  ex.Message;
                response.IsCorrect = false;
            }

            return response;
        }

        Task<ResponseDTO<IEnumerable<SAPMaestroPrestamos>>> IGenericInterface<SAPMaestroPrestamos>.GetALl()
        {
            throw new NotImplementedException();
        }
    }
}
