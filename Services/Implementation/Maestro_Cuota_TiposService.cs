﻿using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;

namespace Services.Implementation
{
    public class Maestro_Cuota_TiposService : IMaestro_Cuota_Tipos
    {
        private readonly IGeneric<Maestro_Cuota_Tipos> _cuotaTipo;

        public Maestro_Cuota_TiposService(IGeneric<Maestro_Cuota_Tipos> cuotaTipo)
        {
            _cuotaTipo = cuotaTipo;
        }

        public async Task<ResponseDTO<Maestro_Cuota_Tipos>> Add(Maestro_Cuota_Tipos model)
        {
            return await _cuotaTipo.Add(model);
        }

        public Task<ResponseDTO<Maestro_Cuota_Tipos>> Get(Maestro_Cuota_Tipos model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<IEnumerable<Maestro_Cuota_Tipos>>> GetALl()
        {
            ResponseDTO<IEnumerable<Maestro_Cuota_Tipos>> response = new ResponseDTO<IEnumerable<Maestro_Cuota_Tipos>>();
            var cuotaTipo =  _cuotaTipo.Get();

            response.Data = cuotaTipo.Data != null ? cuotaTipo.Data.ToList() : null;
            response.Message = cuotaTipo.Data?.Count() == 0 ? "Data list empty" : cuotaTipo.Message;
            response.IsCorrect = true;
            return  response;
        }

        public async Task<ResponseDTO<Maestro_Cuota_Tipos>> Update(Maestro_Cuota_Tipos model)
        {
            ResponseDTO<Maestro_Cuota_Tipos> response = new ResponseDTO<Maestro_Cuota_Tipos>();
            try
            {

                var currentResp = _cuotaTipo.Get(x => x.ID == model.ID);

                if (!currentResp.IsCorrect || currentResp.Data == null || !currentResp.Data.Any())
                {
                    response.Data = null;
                    response.IsCorrect = false;
                    response.Message = $"No se encontro un registro con este ID {model.ID}";
                }
                else
                {
                    var current = currentResp.Data?.FirstOrDefault();

                    current.Description = model.Description;
                    current.Status = model.Status;

                    var saved = await _cuotaTipo.Update(current);

                    response.Data = saved.Data != null ? saved.Data : response.Data;
                    response.Message = saved.Message;
                    response.IsCorrect = true;

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
