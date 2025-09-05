using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using Repository.Entidades.DTO;
using System.Linq.Expressions;

namespace Repository.Implementation
{
    public class Generic<T> : IGeneric<T> where T : class
    {
        private readonly applicationDbContext _external_context;
        public Generic(applicationDbContext external_context)
        {
            _external_context = external_context;
        }
        public IQueryable<T> Query(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null
                ? _external_context.Set<T>()
                : _external_context.Set<T>().Where(filter);
        }

        public async Task<ResponseDTO<List<T>>> GetAsync(Expression<Func<T, bool>>? filter = null)
        {
            var response = new ResponseDTO<List<T>>();
            try
            {
                var query = Query(filter).AsNoTracking();
                response.Data = await query.ToListAsync();
                response.IsCorrect = true;
                response.Message = "data obtenida correctamente";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Entidades.DTO.ResponseDTO<IQueryable<T>> Get(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null)
        {
            ResponseDTO<IQueryable<T>> response = new ResponseDTO<IQueryable<T>>();

            try
            {
                var result = filter == null ? _external_context.Set<T>() : _external_context.Set<T>().Where(filter);
                response.Data = result;
                response.Message = "data obtenied successfully";
                response.IsCorrect = true;
                return response;

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.IsCorrect = false;
                return response;

            }
        }
        public async Task<Entidades.DTO.ResponseDTO<T>> Add(T model)
        {
            ResponseDTO<T> response = new ResponseDTO<T>();
            try
            {
                _external_context.Set<T>().Add(model);

                await _external_context.SaveChangesAsync();
                response.Data = model;
                response.Message = "Data Created successfully";
                response.IsCorrect = true;
                return response;
            }
            catch (Exception ex)
            {

                response.Data = null;
                response.Message = ex.Message;
                response.IsCorrect = false;
                return response;

            }
        }

        public async Task<Entidades.DTO.ResponseDTO<IEnumerable<T>>> AddRange(IEnumerable<T> model)
        {

            ResponseDTO<IEnumerable<T>> response = new ResponseDTO<IEnumerable<T>>();
            try
            {
                _external_context.Set<T>().AddRange(model);
                await _external_context.SaveChangesAsync();
                response.Data = model;
                response.Message = "Data list created successfully";
                response.IsCorrect = true;
                return response;
            }
            catch (Exception ex)
            {

                response.Data = null;
                response.Message = ex.Message;
                response.IsCorrect = false;
                return response;
            }
        }

        public Task<Entidades.DTO.ResponseDTO<IEnumerable<T>>> Empty(IEnumerable<T> model)
        {
            throw new NotImplementedException();
        }

        public async Task<Entidades.DTO.ResponseDTO<T>> Update(T model)
        {
            ResponseDTO<T> response = new ResponseDTO<T>();
            try
            {
                _external_context.ChangeTracker.Clear();
                _external_context.Set<T>().Update(model);
                await _external_context.SaveChangesAsync();
                response.Data = model;
                response.Message = "Data updated successfully";
                response.IsCorrect = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.IsCorrect = false;
                return response;
            }
        }

        public async Task<Entidades.DTO.ResponseDTO<IEnumerable<T>>> UpdateRange(IEnumerable<T> model)
        {
            ResponseDTO<IEnumerable<T>> response = new ResponseDTO<IEnumerable<T>>();
            try
            {
                _external_context.ChangeTracker.Clear();
                _external_context.Set<T>().UpdateRange(model);
                await _external_context.SaveChangesAsync();


                response.Data = model;
                response.Message = "Data list updated successfully";
                response.IsCorrect = true;
                return response;

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.IsCorrect = false;
                return response;
            }
        }
        public async Task<ResponseDTO<T>> UpdatePartial<T>( T model,params Expression<Func<T, object>>[] properties) where T : class
        {
            var response = new ResponseDTO<T>();
            try
            {
                // --- Evitar "another instance with the same key" ---
                var set = _external_context.Set<T>();
                var idProp = typeof(T).GetProperty("id"); // asumiendo PK = "id"
                if (idProp != null)
                {
                    var idVal = idProp.GetValue(model);
                    var local = set.Local.FirstOrDefault(e =>
                    {
                        var p = e!.GetType().GetProperty("id");
                        return p != null && Equals(p.GetValue(e), idVal);
                    });
                    if (local != null)
                        _external_context.Entry(local).State = EntityState.Detached;
                }
                // ----------------------------------------------------

                var entry = _external_context.Attach(model);

                foreach (var property in properties)
                    entry.Property(property).IsModified = true;

                await _external_context.SaveChangesAsync();

                response.Data = model;
                response.Message = "Data updated successfully";
                response.IsCorrect = true;
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
