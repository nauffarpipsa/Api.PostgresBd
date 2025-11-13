using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Repository.Entidades.Odatas;
using Services.Contract;
using Services.Dtos;
using System.Linq.Expressions;

namespace Services.Implementation
{


    public class SAP_Maestro_PrestamosServices : ISAPMaestroPrestamos
    {
        private readonly ILogger<SAP_Maestro_PrestamosServices> _logger;
        private readonly IGeneric<SAPMaestroPrestamos> _maestroPrestamos;
        private readonly ISupplierBanckAccount _supplierBanckAccount;
        private readonly IRequestOData _odata;

        public SAP_Maestro_PrestamosServices(ILogger<SAP_Maestro_PrestamosServices> logger, IGeneric<SAPMaestroPrestamos> maestroPrestamos , ISupplierBanckAccount supplierBanckAccount , IRequestOData odata)
        {
            _logger = logger;
            _maestroPrestamos = maestroPrestamos;
            _supplierBanckAccount = supplierBanckAccount;
            _odata = odata;
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
        public async Task<ResponseDTO<IEnumerable<PrestamoDTO>>> GetAll(string sociedadID)
        {
            var response = new ResponseDTO<IEnumerable<PrestamoDTO>>();
         
            var prestamosTask = _maestroPrestamos.Query()
                .AsNoTracking()
                .Select(p => new {
                    p.id,
                    p.company,
                    p.prestamo_id,
                    p.factura_id,
                    p.c_proveedor,
                    p.n_proveedor,
                    p.f_creacion,
                    p.f_invoice,
                    p.f_modificacion,
                    p.f_inicial,
                    p.f_final,
                    p.prestamo_type_id,
                    p.prestamo_type_text,
                    p.tasa,
                    p.dia_pago,
                    p.meses_gracia,
                    p.plazo,
                    p.commets,
                    p.bank_id,
                    p.creditline_id,
                    p.cuotatipo_id,
                    p.condicion_id,
                    p.monto_neto,
                    p.monto_bruto,
                    p.verified,
                    p.dias_de_desembolso,
                    Bank_Name = p.Bank != null ? p.Bank.Bank_Name : null,
                    Line_Description = p.CreditLine != null ? p.CreditLine.Line_Description : null,
                    Cuota_Name = p.CuotaTipo != null ? p.CuotaTipo.Description : null,
                    Condicion_Name = p.condiciones != null ? p.condiciones.descripcion : null
                }).Where(p => p.company == sociedadID)
                .ToListAsync();

            //var proveedores = prestamosTask.Result
            //    .Select(p => p.c_proveedor)
            //    .Where(c => !string.IsNullOrWhiteSpace(c))
            //    .Distinct()
            //    .ToList();
            //var cuentasTask = _supplierBanckAccount.GetDataProveedor(1, string.Join(",", proveedores));
            ////---Mapeo / enriquecido-- -
            //var cuentasResp = cuentasTask.Result;

            //var cuentas = (cuentasResp.IsCorrect && cuentasResp.Data != null)
            //     ? cuentasResp.Data.Where(a => !string.IsNullOrWhiteSpace(a.CBP_UUID)).ToList() : null;
                //: new List<SupplierAccountItemDTO>();

            //var cuentasLookup = cuentas.ToLookup(a => a.CBP_UUID!);

            var lista = prestamosTask.Result.Select(p =>
            {
                //var cuenta = cuentasLookup[p.c_proveedor ?? ""].FirstOrDefault();

                return new PrestamoDTO
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
                    prestamo_type_id = p.prestamo_type_id,
                    prestamo_type_text = p.prestamo_type_text,
                    tasa = p.tasa,
                    dia_pago = p.dia_pago,
                    meses_gracia = p.meses_gracia,
                    plazo = p.plazo,
                    commets = p.commets,
                    bank_id = p.bank_id,
                    bank_name = p.Bank_Name,
                    creditline_id = p.creditline_id,
                    creditline_name = string.IsNullOrEmpty(p.Line_Description) ? null :
                                      string.IsNullOrEmpty(p.Bank_Name) ? p.Line_Description :
                                      $"{p.Line_Description}/{p.Bank_Name}",
                    cuotatipo_id = p.cuotatipo_id,
                    cuata_name = p.Cuota_Name,
                    condicion_id = p.condicion_id,
                    condicion_name = p.Condicion_Name,
                    monto_neto = p.monto_neto,
                    monto_bruto = p.monto_bruto,
                    verified = p.verified,
                    dias_de_desembolso = p.dias_de_desembolso,
                    //cbanK_ACCOUNT_ID = cuenta?.CBANK_ACCOUNT_ID,
                    //CBANK_NAME = cuenta?.CBANK_NAME,
                    //CBANK_NAT_CODE = cuenta?.CBANK_NAT_CODE
                };
            }).ToList();

           

            response.Data = lista;
            response.Message = lista.Any() ? "Data obtenida correctamente" : "No se encontraron registros";
            response.IsCorrect = true;
            return response;

        }

        public Task<ResponseDTO<IEnumerable<SAPMaestroPrestamos>>> GetALl()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<IEnumerable<SupplierAccountItemDTO>>> GetProveedorXOdata(string idProveedor)
        {
            var provedor = await _supplierBanckAccount.GetDataProveedor(idProveedor);

            var response = new ResponseDTO<IEnumerable<SupplierAccountItemDTO>>
            {
                IsCorrect = provedor?.IsCorrect ?? false,
                Message = provedor?.Message ?? "Sin respuesta del servicio."
            };

            var origen = provedor?.Data ?? Enumerable.Empty<SupplierBanckAccount>();
            response.Data = origen.Select( Services.Dtos.SupplierAccountMapper.MapToDto).ToList(); 

            return response;
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
                     //   plazo = model.plazo,
                        commets = model.commets,
                        bank_id = model.bank_id,
                        creditline_id = model.creditline_id,
                        cuotatipo_id = model.cuotatipo_id,
                        condicion_id = model.condicion_id,
                        dias_de_desembolso = model.dias_de_desembolso

                    };

                    // 2) Solo marcar las props que vienen con valor (para no enviar NULL)
                    var props = new List<Expression<Func<SAPMaestroPrestamos, object>>>();
                    if (model.tasa.HasValue) props.Add(x => x.tasa);
                    if (model.dia_pago.HasValue) props.Add(x => x.dia_pago);
                    if (model.meses_gracia.HasValue) props.Add(x => x.meses_gracia);
                  //  if (model.plazo.HasValue) props.Add(x => x.plazo);
                    if (model.commets != null) props.Add(x => x.commets);
                    if (model.bank_id.HasValue) props.Add(x => x.bank_id);
                    if (model.creditline_id.HasValue) props.Add(x => x.creditline_id);
                    if (model.cuotatipo_id.HasValue) props.Add(x => x.cuotatipo_id);
                    if (model.condicion_id.HasValue) props.Add(x => x.condicion_id);
                    if (model.verified != current.verified) props.Add(x => x.verified);
                    if (model.dias_de_desembolso.HasValue) props.Add(x => x.dias_de_desembolso);


                    if (model.verified.HasValue)
                    {
                        stub.verified = model.verified.Value;
                        props.Add(x => x.verified);
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

        public async Task<ResponseDTO<SAPMaestroPrestamos>> UpdateVerified(SAPMaestroPrestamos model)
        {
            ResponseDTO<Repository.Entidades.db_Externa.SAPMaestroPrestamos> response = new ResponseDTO<Repository.Entidades.db_Externa.SAPMaestroPrestamos>();
            try
            {
                var currentResp = _maestroPrestamos.Get(x => x.prestamo_id == model.prestamo_id);
                if (!currentResp.IsCorrect || currentResp.Data == null || !currentResp.Data.Any())
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
                        verified = model.verified,

                    };

                    // 2) Solo marcar las props que vienen con valor (para no enviar NULL)
                    var props = new List<Expression<Func<SAPMaestroPrestamos, object>>>();
                  
                    if (model.verified != current.verified) props.Add(x => x.verified);


                    if (model.verified.HasValue)
                    {
                        stub.verified = model.verified.Value;
                        props.Add(x => x.verified);
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
                response.Message = ex.Message;
                response.IsCorrect = false;
            }

            return response;
        }

    }
}
