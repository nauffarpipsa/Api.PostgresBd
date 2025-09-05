using System.ComponentModel.DataAnnotations.Schema;


namespace Services.Dtos
{
    public class PurchaseOrderDto
    {

        [Column("ordernumber")]
        public string? OrderNumber { get; set; }
        [Column("SearatesStatus")]
        public string? SearatesStatus { get; set; }
        [Column("createdbyuser")]
        public string? CreatedByUser { get; set; }

        [Column("createdate")]
        public DateTime? CreateDate { get; set; }

        [Column("contractnumberreference")]
        public string? ContractNumberReference { get; set; }

        [Column("suppliercode")]
        public string? SupplierCode { get; set; }

        [Column("suppliername")]
        public string? SupplierName { get; set; }

        [Column("etainitial")]
        public DateTime? ETAInitial { get; set; }

        [Column("masterblnumber")]
        public string? MasterBLNumber { get; set; }

        [Column("location_text")]
        public string? LocationText { get; set; }

        [Column("shippingcode")]
        public string? ShippingCode { get; set; }

        [Column("currency")]
        public string? Currency { get; set; }
        public List<PurchaseOrderDetailDto> Details { get; set; }

    }

    public class PurchaseOrderDetailDto 
    {
        [Column("productcode")]
        public string? ProductCode { get; set; }

        [Column("productdescription")]
        public string? ProductDescription { get; set; }

        [Column("productcategory")]
        public string? ProductCategory { get; set; }
        [Column("productnetprice")]
        public double? ProductNetPrice { get; set; }

        [Column("quantityrequested")]
        public double? QuantityRequested { get; set; }

        [Column("quantitydelivered")]
        public double? QuantityDelivered { get; set; }
        [Column("balance")]
        public double? Balance { get; set; }
        [Column("containernumber")]
        public string? ContainerNumber { get; set; }

    }

   
}
