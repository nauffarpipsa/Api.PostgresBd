using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Services.Implementation
{
    public class Sap_Maesto_Purchase_OrdersService : ISap_Maesto_Purchase_Orders
    {
        private readonly IGeneric<SAP_Maestro_Purchase_Orders> _maestro_purcher;
        public Sap_Maesto_Purchase_OrdersService(IGeneric<SAP_Maestro_Purchase_Orders> maestro_purcher)
        {
            _maestro_purcher = maestro_purcher;
        }

        public Task<ResponseDTO<SAP_Maestro_Purchase_Orders>> Add(SAP_Maestro_Purchase_Orders model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<IEnumerable<PurchaseOrderDto>>> Get()
        {
            var response = new ResponseDTO<IEnumerable<PurchaseOrderDto>>();
            var resultList = new List<PurchaseOrderDto>();

            // Obtener todos los datos del maestro (cabecera + detalle en plano)
            var allOrders = _maestro_purcher.Get();

            // Agrupar por número de orden
            var groupedOrders = allOrders.Data
                .GroupBy(x => x.OrderNumber);

            foreach (var group in groupedOrders)
            {
                var first = group.First();

                var dto = new PurchaseOrderDto
                {
                    OrderNumber = first.OrderNumber,
                    SearatesStatus = first.SearatesStatus,
                    CreatedByUser = first.CreatedByUser,
                    CreateDate = first.CreateDate,
                    ContractNumberReference = first.ContractNumberReference,
                    SupplierCode = first.SupplierCode,
                    SupplierName = first.SupplierName,
                    ETAInitial = first.ETAInitial,
                    MasterBLNumber = first.MasterBLNumber,
                    LocationText = first.LocationText,
                    ShippingCode = first.ShippingCode,
                    Currency = first.Currency,
                    Details = group.Select(d => new PurchaseOrderDetailDto
                    {
                        ProductCode = d.ProductCode,
                        ProductDescription = d.ProductDescription,
                        ProductCategory = d.ProductCategory,
                        ProductNetPrice = d.ProductNetPrice,
                        QuantityRequested = d.QuantityRequested,
                        QuantityDelivered = d.QuantityDelivered,
                        Balance = d.Balance,
                        ContainerNumber = first.ContainerNumber,
                        
                    }).ToList()
                };

                resultList.Add(dto);
            }

            response.Data = resultList;
            response.IsCorrect = true;
            response.Message = resultList.Count == 0 ? "Data list empty" : "OK";

            return response;
        }

        public Task<ResponseDTO<SAP_Maestro_Purchase_Orders>> Get(SAP_Maestro_Purchase_Orders model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<PaginationDTO<PurchaseOrderDto>>> Get(int pageNumber, int pageSize)
        {
            
            var response = new ResponseDTO<PaginationDTO<PurchaseOrderDto>>();
            var resultList = new  List<PurchaseOrderDto>();

            // Obtener todos los datos del maestro (cabecera + detalle en plano)
            var allOrders = _maestro_purcher.Get();


            // Agrupar por número de orden
            var groupedOrders = allOrders.Data
                .GroupBy(x => x.OrderNumber);

            foreach (var group in groupedOrders)
            {
                var first = group.First();

                var dto = new PurchaseOrderDto
                {
                    OrderNumber = first.OrderNumber,
                    SearatesStatus = first.SearatesStatus,
                    CreatedByUser = first.CreatedByUser,
                    CreateDate = first.CreateDate,
                    ContractNumberReference = first.ContractNumberReference,
                    SupplierCode = first.SupplierCode,
                    SupplierName = first.SupplierName,
                    ETAInitial = first.ETAInitial,
                    MasterBLNumber = first.MasterBLNumber,
                    LocationText = first.LocationText,
                    ShippingCode = first.ShippingCode,
                    Currency = first.Currency,
                    Details = group.Select(d => new PurchaseOrderDetailDto
                    {
                        ProductCode = d.ProductCode,
                        ProductDescription = d.ProductDescription,
                        ProductCategory = d.ProductCategory,
                        ProductNetPrice = d.ProductNetPrice,
                        QuantityRequested = d.QuantityRequested,
                        QuantityDelivered = d.QuantityDelivered,
                        Balance = d.Balance,
                        ContainerNumber = first.ContainerNumber,
                        
                    }).ToList()
                };

                resultList.Add(dto);
            }
                
             // Calcular paginación
            var totalRecords = resultList.Count;
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            // Filtrar los registros de la página solicitada
            var pagedResult = resultList
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Crear objeto de paginación
            var pagination = new PaginationDTO<PurchaseOrderDto>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                items = pagedResult
            };

            // Asignar al ResponseDTO
            response.Data = pagination;
            response.IsCorrect = true;
            response.Message = resultList.Count == 0 ? "Data list empty" : "OK";

            return response;
           
        }

        public Task<ResponseDTO<IEnumerable<SAP_Maestro_Purchase_Orders>>> GetALl()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<SAP_Maestro_Purchase_Orders>> Update(SAP_Maestro_Purchase_Orders model)
        {
            throw new NotImplementedException();
        }
        
    }
}
